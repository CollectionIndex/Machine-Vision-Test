using Matrox.MatroxImagingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02.Allocating_and_displaying_an_image_buffer {
	class Program : MIL{
		static void Main( string[] args ) {
			MIL_ID MilApplication = new MIL_ID();
			MIL_ID MilSystem = new MIL_ID();
			MIL_ID MilDisplay = new MIL_ID();
			MIL_ID MilImage = new MIL_ID();

			MappAlloc( M_DEFAULT, ref MilApplication );
			MsysAlloc( M_SYSTEM_GPU, M_DEFAULT, M_DEFAULT, ref MilSystem );
			MdispAlloc( MilSystem, M_DEFAULT, "M_DEFAULT", M_WINDOWED, ref MilDisplay );

			MbufAlloc2d( MilSystem, 512, 512, 8 + M_UNSIGNED, M_IMAGE + M_DISP + M_GRAB, ref MilImage );

			MdispSelect( MilDisplay, MilImage );
			for( int i = 0; i < 10; i++ ) {
				MbufClear( MilImage, 0L );
				Thread.Sleep( 250 );
				MgraArcFill( M_DEFAULT, MilImage, 256L, 240L, 100L, 100L, 0.0, 360.0 );
				Thread.Sleep( 250 );
				MgraText( M_DEFAULT, MilImage, 238L, 234L, " MIL " );
				Thread.Sleep( 250 );
			}

			Console.WriteLine( "A circle was drawn in the displayed image buffer." );
			Console.ReadKey();

			MbufFree( MilImage );
			MdispFree( MilDisplay );
			MsysFree( MilSystem );
			MappFree( MilApplication );
		}
	}
}
