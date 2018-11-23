using System.Drawing;
using System.Windows.Forms;

namespace MIL_TEST_FORM {

	public partial class image_panel : UserControl {
		
		public image_panel() {
			InitializeComponent();
		}

		public void set_image( string _img_path ) {
			Image img = Image.FromFile( _img_path );
			this.BackgroundImageLayout = ImageLayout.Zoom;
			this.BackgroundImage = img;			
		}
	}


	class BufferedPanel : Panel {
		public BufferedPanel() {
			this.DoubleBuffered = true;
			this.ResizeRedraw = true;
		}
	}
}
