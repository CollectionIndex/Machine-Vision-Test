using Matrox.MatroxImagingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Erosion_and_dilation {
	class Program : MIL{

		static string IMAGE_FILE = M_IMAGE_PATH + "Cell.mim";
		static int IMAGE_WIDTH = 512;
		static int IMAGE_HEIGHT = 480;
		static int IMAGE_THRESHOLD_VALUE = 128;

		static int SMALL_PARTICLE_RADIUS = 2;

		static void Main( string[] args ) {
			MIL_ID MilApplication = new MIL_ID();
			MIL_ID MilSystem = new MIL_ID();
			MIL_ID MilDisplay = new MIL_ID();
			MIL_ID MilImage = new MIL_ID();
			MIL_ID BinImage = new MIL_ID();
			MIL_ID DilBinImage = new MIL_ID();

			MappAllocDefault( M_DEFAULT, ref MilApplication, ref MilSystem, ref MilDisplay, M_NULL, M_NULL );

			MbufRestore( IMAGE_FILE, MilSystem, ref MilImage );
			MdispSelect( MilDisplay, MilImage );

			MbufAlloc2d( M_DEFAULT, IMAGE_WIDTH, IMAGE_HEIGHT, 1 + M_UNSIGNED, M_IMAGE + M_PROC, ref BinImage );
			MbufAlloc2d( M_DEFAULT, IMAGE_WIDTH, IMAGE_HEIGHT, 1 + M_UNSIGNED, M_IMAGE + M_PROC, ref DilBinImage );

			Console.WriteLine( "Thsi program finds the exoskeletons" );
			Console.WriteLine( "Press <Enter> to continue." );
			Console.ReadKey();

			// Binarize the image
			MimBinarize( MilImage, BinImage, M_LESS_OR_EQUAL, IMAGE_THRESHOLD_VALUE, M_NULL );

			// Remove small particles
			MimOpen( BinImage, BinImage, SMALL_PARTICLE_RADIUS, M_BINARY );

			// Dilate image ( adds one pixel around all objects )
			MimDilate( BinImage, DilBinImage, 1, M_BINARY );

			// XOR the dilated image with the original image
			MimArith( BinImage, DilBinImage, BinImage, M_XOR );

			// Convert the binary iamge to a visible grayscale image ( 0 - 0xFF )
			MimBinarize( BinImage, MilImage, M_GREATER, 0, M_NULL );

			Console.WriteLine( "Exoskeletons of the object's perimeters are being calculated." );
			Console.WriteLine( "Press <Enter> to continue." );
			Console.ReadKey();

			MbufFree( BinImage );
			MbufFree( DilBinImage );
			MbufFree( MilImage );
			MappFreeDefault( MilApplication, MilSystem, MilDisplay, M_NULL, M_NULL );
		}
	}
}
