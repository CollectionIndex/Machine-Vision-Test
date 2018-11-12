using Matrox.MatroxImagingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Testing_the_installation {
	class Program {
		static void Main( string[] args ) {
			MIL_ID MilApplication = new MIL_ID();
			MIL_ID MilSystem = new MIL_ID();
			MIL_ID MilDisplay = new MIL_ID();
			MIL_ID MilImage = new MIL_ID();

			MIL.MappAllocDefault( MIL.M_DEFAULT, ref MilApplication, ref MilSystem, ref MilDisplay, MIL.M_NULL, ref MilImage );

			MIL_INT ret = MIL.MappGetError( MIL.M_GLOBAL, MIL.M_NULL );
			if( ret != 0 ) {
				Console.WriteLine( "System allocation error." );
				MIL.MappFreeDefault( MilApplication, MilSystem, MilDisplay, MIL.M_NULL, MilImage );
				return;
			}


			MIL.MgraColor( MIL.M_DEFAULT, 0xF0 );
			MIL.MgraFont( MIL.M_DEFAULT, MIL.M_FONT_DEFAULT_LARGE );
			MIL.MgraText( MIL.M_DEFAULT, MilImage, 160L, 230L, " Welcome to MIL !!! " );
			MIL.MgraColor( MIL.M_DEFAULT, 0xC0 );
			MIL.MgraRect( MIL.M_DEFAULT, MilImage, 100L, 150L, 530L, 340L );
			MIL.MgraRect( MIL.M_DEFAULT, MilImage, 120L, 170L, 510L, 320L );
			MIL.MgraRect( MIL.M_DEFAULT, MilImage, 140L, 190L, 490L, 300L );

			Console.WriteLine( "System allocation successful." );

			Console.ReadKey();

			MIL.MappFreeDefault( MilApplication, MilSystem, MilDisplay, MIL.M_NULL, MilImage );
		}
	}
}
