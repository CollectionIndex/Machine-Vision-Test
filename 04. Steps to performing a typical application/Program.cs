using Matrox.MatroxImagingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Steps_to_performing_a_typical_application {
	class Program : MIL {

		static string IMAGE_FILE = M_IMAGE_PATH + "Cell.mim";
		static int IMAGE_SMALL_PARTICEL_RADIUS = 1;

		static void Main( string[] args ) {
			MIL_ID MilApplication = new MIL_ID();
			MIL_ID MilSystem = new MIL_ID();
			MIL_ID MilDisplay = new MIL_ID();
			MIL_ID MilImage = new MIL_ID();
			MIL_ID MilExtremeResult = 0;

			MIL_INT MaxLabelNumber = 0;
			MIL_INT LicenseModules = 0;

			MappAllocDefault( M_DEFAULT, ref MilApplication, ref MilSystem, ref MilDisplay, M_NULL, M_NULL );

			MbufRestore( IMAGE_FILE, MilSystem, ref MilImage );
			MdispSelect( MilDisplay, MilImage );

			Console.WriteLine( "IMAGE PROCESSING:" );
			Console.WriteLine( "Press <Enter> to continue." );
			Console.ReadKey();

			MimBinarize( MilImage, MilImage, M_LESS_OR_EQUAL, M_DEFAULT, M_NULL );

			Console.WriteLine( "These particles were extracted from the original image." );

#if( !M_MIL_LITE )
			MsysInquire( MilSystem, M_LICENSE_MODULES, ref LicenseModules );
			//if( LicenseModules.Equals( M_LICENSE_IM ) ) {
			if( Convert.ToBoolean( ((int)(LicenseModules) & M_LICENSE_IM) ) ) {
				Console.WriteLine( "Press <Enter> to continue." );
				Console.ReadKey();

				// Close small holes
				MimClose( MilImage, MilImage, IMAGE_SMALL_PARTICEL_RADIUS, M_BINARY );

				// Remove small particles
				MimOpen( MilImage, MilImage, IMAGE_SMALL_PARTICEL_RADIUS, M_BINARY );

				// Label the image
				MimLabel( MilImage, MilImage, M_DEFAULT );

				// The largest label value corresponds to the number of particles in the image
				MimAllocResult( MilSystem, 1, M_EXTREME_LIST, ref MilExtremeResult );
				MimFindExtreme( MilImage, MilExtremeResult, M_MAX_VALUE );
				MimGetResult( MilExtremeResult, M_VALUE, ref MaxLabelNumber );
				MimFree( MilExtremeResult );

				// Multiply the labeling result to augment the gray level of the particles
				MimArith( MilImage, ( MIL_INT )( 256L / ( double )MaxLabelNumber ), MilImage, M_MULT_CONST );

				// Display the resulting paricles in pseudo-color
				MdispLut( MilDisplay, M_PSEUDO );

				// Print results
				Console.WriteLine( "There were {0} large particles in the original image", MaxLabelNumber );
			}
#endif

			Console.WriteLine( "Press <Enter> to continue." );
			Console.ReadKey();

			MbufFree( MilImage );
			MappFreeDefault( MilApplication, MilSystem, MilDisplay, M_NULL, M_NULL );
		}
	}
}
