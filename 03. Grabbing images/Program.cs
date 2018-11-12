using Matrox.MatroxImagingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Grabbing_images {
	class Program : MIL {
		static void Main( string[] args ) {
			MIL_ID MilApplication = new MIL_ID();
			MIL_ID MilSystem = new MIL_ID();
			MIL_ID MilDisplay = new MIL_ID();
			MIL_ID MilImage = new MIL_ID();
			MIL_ID MilDigitizer = new MIL_ID();

			MappAlloc( M_DEFAULT, ref MilApplication );
			MsysAlloc( M_SYSTEM_DEFAULT, M_DEFAULT, M_DEFAULT, ref MilSystem );
			MdispAlloc( MilSystem, M_DEFAULT, "M_DEFAULT", M_WINDOWED, ref MilDisplay );

			MdigAlloc( MilSystem, M_DEV0, "M_DEFAULT", M_DEFAULT, ref MilDigitizer );

			MbufAlloc2d( MilSystem, 512, 512, 8 + M_UNSIGNED, M_IMAGE + M_DISP + M_GRAB, ref MilImage );

			MbufClear( MilImage, 0L );
			MgraArcFill( M_DEFAULT, MilImage, 256L, 240L, 100L, 100L, 0.0, 360.0 );
			MgraText( M_DEFAULT, MilImage, 238L, 234L, " MIL " );

			MdispSelect( MilDisplay, MilImage );

			Console.WriteLine( "A circle was drawn in the displayed image buffer." );
			Console.ReadKey();

			MdigGrab( MilDigitizer, MilImage );

			Console.WriteLine( "An image was grabbed in the displayed image buffer." );
			Console.ReadKey();

			MbufFree( MilImage );
			MdigFree( MilDigitizer );
			MdispFree( MilDisplay );
			MsysFree( MilSystem );
			MappFree( MilApplication );
		}
	}
}
