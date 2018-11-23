using Matrox.MatroxImagingLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIL_TEST_FORM {
	class MIL_Adapter : MIL{


		static int IMAGE_WIDTH = 512;
		static int IMAGE_HEIGHT = 480;
		static int IMAGE_THRESHOLD_VALUE = 128;

		static int SMALL_PARTICLE_RADIUS = 2;

		MIL_ID m_MilApplication = new MIL_ID();
		MIL_ID m_MilSystem = new MIL_ID();
		MIL_ID m_MilDisplay = new MIL_ID();
		MIL_ID m_SourceImage = new MIL_ID();
		MIL_ID m_WorkImage = new MIL_ID();
		MIL_ID m_MilDigitizer = new MIL_ID();

		public MIL_Adapter() {

		}

		public void init() {
			MappAllocDefault( M_DEFAULT, ref m_MilApplication, ref m_MilSystem, ref m_MilDisplay, M_NULL, M_NULL );
		}

		public void MbufRestore( string _img_file ) {
			try {
				MbufRestore( _img_file, m_MilSystem, ref m_SourceImage );
			}
			catch( Exception ex ) {
				throw ex;
			}
		}

		public Image test() {
			MbufAlloc2d( M_DEFAULT, IMAGE_WIDTH, IMAGE_HEIGHT, 1 + M_UNSIGNED, M_IMAGE + M_PROC, ref m_WorkImage );

			// Binarize the image
			MimBinarize( m_SourceImage, m_WorkImage, M_LESS_OR_EQUAL, IMAGE_THRESHOLD_VALUE, M_NULL );

			// Remove small particles
			MimOpen( m_WorkImage, m_WorkImage, SMALL_PARTICLE_RADIUS, M_BINARY );

			// Dilate image ( adds one pixel around all objects )
			MimDilate( m_WorkImage, m_WorkImage, 1, M_BINARY );

			// XOR the dilated image with the original image
			MimArith( m_SourceImage, m_WorkImage, m_WorkImage, M_XOR );

			// Convert the binary iamge to a visible grayscale image ( 0 - 0xFF )
			MimBinarize( m_WorkImage, m_WorkImage, M_GREATER, 0, M_NULL );

			MbufSave( "C:\\test.bmp", m_WorkImage );

			Image img = Image.FromFile( "C:\\test.bmp" );
			return img;
		}
	}
}
