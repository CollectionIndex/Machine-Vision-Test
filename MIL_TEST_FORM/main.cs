using System;
using System.Drawing;
using System.Windows.Forms;

namespace MIL_TEST_FORM {
	public partial class main : Form {
		public main() {
			InitializeComponent();
		}

		private void btnLoadImg_Click( object sender, EventArgs e ) {
			var result = openFileDialog.ShowDialog();
			if( result != DialogResult.OK )
				return;

			string strImgName = openFileDialog.FileName;
			lbFileName.Text = strImgName;

			var img = Image.FromFile( strImgName );
			pnlSource.BackgroundImageLayout = ImageLayout.Zoom;
			pnlSource.BackgroundImage = img;
		}
	}
}
