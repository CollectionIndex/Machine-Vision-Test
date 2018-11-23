using Matrox.MatroxImagingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Reader {
	class Program :MIL {

		private static string IMAGE_FILE_DEFINITION = M_IMAGE_PATH + "QcPlates.mim";
		private static string IMAGE_FILE_TO_READ = M_IMAGE_PATH + "LicPlate.mim";

		//private const string TEXT_DEFINITION = "AVS300CVK781JNK278 EBX380QKN918HCC839 YRH900ZQR756977AMQ GPK742389EYE569ESQ";
		private const string TEXT_DEFINITION = "AVS300CVK781JNK278 123456789012345678 ABCDEFGHIJKLMNOPQR STUVWXYZABCDEFGHIJ";


		private static int NORMALIZATION_SIZE_Y = 20;
		private static int STRING_MAX_SIZE = 32;

		static void Main( string[] args ) {
			MIL_ID MilApplication = M_NULL;
			MIL_ID MilSystem = M_NULL;
			MIL_ID MilDisplay = M_NULL;
			MIL_ID MilImage = M_NULL;
			MIL_ID MilOverlayImage = M_NULL;
			MIL_ID MilStrContext = M_NULL;
			MIL_ID MilStrResult = M_NULL;

			MIL_INT NumberOfStringRead = 0;
			double Score = 0.0;
			StringBuilder StringResult = new StringBuilder( STRING_MAX_SIZE + 1 ); // String of characters read.
			double Time = 0.0;

			Console.WriteLine( "STRING READER MODULE : " );

			MappAllocDefault( M_DEFAULT, ref MilApplication, ref MilSystem, ref MilDisplay, M_NULL, M_NULL );

			MbufRestore( IMAGE_FILE_DEFINITION, MilSystem, ref MilImage );

			MdispSelect( MilDisplay, MilImage );
			MdispControl( MilDisplay, M_OVERLAY, M_ENABLE );
			MdispInquire( MilDisplay, M_OVERLAY_ID, ref MilOverlayImage );

			MstrAlloc( MilSystem, M_FEATURE_BASED, M_DEFAULT, ref MilStrContext );

			MstrAllocResult( MilSystem, M_DEFAULT, ref MilStrResult );

			MstrControl( MilStrContext, M_CONTEXT, M_FONT_ADD, M_USER_DEFINED );

			MstrEditFont( MilStrContext, M_FONT_INDEX( 0 ), M_CHAR_ADD, M_USER_DEFINED + M_FOREGROUND_BLACK, MilImage, TEXT_DEFINITION );

			MgraColor( M_DEFAULT, M_COLOR_GREEN );
			MstrDraw( M_DEFAULT, MilStrContext, MilOverlayImage, M_DRAW_CHAR, M_FONT_INDEX( 0 ), M_NULL, M_ORIGINAL );

			MstrEditFont( MilStrContext, M_FONT_INDEX( 0 ), M_CHAR_NORMALIZE, M_SIZE_Y, NORMALIZATION_SIZE_Y, M_NULL, M_NULL );

			MstrControl( MilStrContext, M_CONTEXT, M_STRING_ADD, M_USER_DEFINED );
			MstrControl( MilStrContext, M_CONTEXT, M_STRING_ADD, M_USER_DEFINED );

			MstrControl( MilStrContext, M_CONTEXT, M_STRING_NUMBER, 1 );

			MstrControl( MilStrContext, M_STRING_INDEX( M_ALL ), M_STRING_SIZE_MIN, 6 );
			MstrControl( MilStrContext, M_STRING_INDEX( M_ALL ), M_STRING_SIZE_MAX, 6 );

			MstrSetConstraint( MilStrContext, M_STRING_INDEX( 0 ), M_DEFAULT, M_LETTER + M_UPPERCASE, M_NULL );
			MstrSetConstraint( MilStrContext, M_STRING_INDEX( 1 ), M_DEFAULT, M_LETTER + M_UPPERCASE, M_NULL );

			MstrSetConstraint( MilStrContext, M_STRING_INDEX( 0 ), 3, M_DIGIT, M_NULL );
			MstrSetConstraint( MilStrContext, M_STRING_INDEX( 0 ), 4, M_DIGIT, M_NULL );
			MstrSetConstraint( MilStrContext, M_STRING_INDEX( 0 ), 5, M_DIGIT, M_NULL );

			MstrSetConstraint( MilStrContext, M_STRING_INDEX( 1 ), 0, M_DIGIT, M_NULL );
			MstrSetConstraint( MilStrContext, M_STRING_INDEX( 1 ), 1, M_DIGIT, M_NULL );
			MstrSetConstraint( MilStrContext, M_STRING_INDEX( 1 ), 2, M_DIGIT, M_NULL );

			Console.WriteLine( "This program has defined a font with this Quebec plates mosaic image." );
			Console.WriteLine( "Press < Endter > to continue." );
			Console.ReadKey();

			MdispControl( MilDisplay, M_OVERLAY_CLEAR, M_DEFAULT );

			MbufLoad( IMAGE_FILE_TO_READ, MilImage );

			MstrPreprocess( MilStrContext, M_DEFAULT );

			MstrRead( MilStrContext, MilImage, MilStrResult );

			MappTimer( M_TIMER_RESET + M_SYNCHRONOUS, ref Time );

			MstrRead( MilStrContext, MilImage, MilStrResult );

			MappTimer( M_TIMER_READ + M_SYNCHRONOUS, ref Time );

			MstrGetResult( MilStrResult, M_GENERAL, M_STRING_NUMBER + M_TYPE_MIL_INT, ref NumberOfStringRead );

			if( NumberOfStringRead >= 1 ) {
				Console.WriteLine( "The license plate was read successfully ({0} ms)", (Time * 1000.0).ToString("N2") );

				MgraColor( M_DEFAULT, M_COLOR_BLUE );
				MstrDraw( M_DEFAULT, MilStrResult, MilOverlayImage, M_DRAW_STRING, M_ALL, M_NULL, M_DEFAULT );

				MgraColor( M_DEFAULT, M_COLOR_GREEN );
				MstrDraw( M_DEFAULT, MilStrResult, MilOverlayImage, M_DRAW_STRING_BOX, M_ALL, M_NULL, M_DEFAULT );

				Console.WriteLine( "String                      Score" );
				MstrGetResult( MilStrResult, 0, M_STRING + M_TYPE_TEXT_CHAR, StringResult );
				MstrGetResult( MilStrResult, 0, M_STRING_SCORE, ref Score );
				Console.WriteLine( "{0}                      {1}", StringResult.ToString(), Score.ToString( "N1" ) );
			} else {
				Console.WriteLine( "Error: Plate was not read" );
			}

			Console.WriteLine( "Press < Endter > to End." );
			Console.ReadKey();

			MstrFree( MilStrContext );
			MstrFree( MilStrResult );
			MbufFree( MilImage );

			MappFreeDefault( MilApplication, MilSystem, MilDisplay, M_NULL, M_NULL );
		}
	}
}
