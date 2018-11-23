using System;
using System.Drawing;
using System.Windows.Forms;

namespace MIL_TEST_FORM {
	public partial class main : Form {

		private MIL_Adapter m_mil = new MIL_Adapter();

		public main() {
			InitializeComponent();

			m_mil.init();
		}

		void ShowMessageBox( Exception _ex ) {
			string msg = "1. Message : " + _ex.Message + "\r\n";
			msg += "2. Source : " + _ex.Source + "\r\n";
			msg += "3. StackTrace : " + _ex.StackTrace + "\r\n";
			MessageBox.Show( msg );
		}

		private void btnLoadImg_Click( object sender, EventArgs e ) {
			var result = openFileDialog.ShowDialog();
			if( result != DialogResult.OK )
				return;

			try {
				string strImgName = openFileDialog.FileName;
				m_mil.MbufRestore( strImgName );

				lbFileName.Text = strImgName;
				image_panel_source.set_image( strImgName );
			} catch( Exception ex ) {
				ShowMessageBox( ex );
			}
		}

		private void btnAdd_Click( object sender, EventArgs e ) {
			m_mil.test();

			image_panel_destination.set_image( "C:\\Destination.bmp" );
		}
	}
}
