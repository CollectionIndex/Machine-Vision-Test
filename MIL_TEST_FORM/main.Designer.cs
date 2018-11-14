namespace MIL_TEST_FORM {
	partial class main {
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent() {
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("노드0");
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("노드1");
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("노드2");
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("노드3");
			System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("노드4");
			System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("노드5");
			this.treeView = new System.Windows.Forms.TreeView();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.pnlSource = new System.Windows.Forms.Panel();
			this.pnlDestination = new System.Windows.Forms.Panel();
			this.btnLoadImg = new System.Windows.Forms.Button();
			this.lbFileName = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnDel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// treeView
			// 
			this.treeView.Location = new System.Drawing.Point(576, 66);
			this.treeView.Name = "treeView";
			treeNode7.Name = "노드0";
			treeNode7.Text = "노드0";
			treeNode8.Name = "노드1";
			treeNode8.Text = "노드1";
			treeNode9.Name = "노드2";
			treeNode9.Text = "노드2";
			treeNode10.Name = "노드3";
			treeNode10.Text = "노드3";
			treeNode11.Name = "노드4";
			treeNode11.Text = "노드4";
			treeNode12.Name = "노드5";
			treeNode12.Text = "노드5";
			this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12});
			this.treeView.Size = new System.Drawing.Size(182, 350);
			this.treeView.TabIndex = 0;
			// 
			// propertyGrid
			// 
			this.propertyGrid.Location = new System.Drawing.Point(368, 40);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new System.Drawing.Size(202, 376);
			this.propertyGrid.TabIndex = 1;
			// 
			// pnlSource
			// 
			this.pnlSource.Location = new System.Drawing.Point(12, 66);
			this.pnlSource.Name = "pnlSource";
			this.pnlSource.Size = new System.Drawing.Size(350, 350);
			this.pnlSource.TabIndex = 2;
			// 
			// pnlDestination
			// 
			this.pnlDestination.Location = new System.Drawing.Point(764, 66);
			this.pnlDestination.Name = "pnlDestination";
			this.pnlDestination.Size = new System.Drawing.Size(350, 350);
			this.pnlDestination.TabIndex = 3;
			// 
			// btnLoadImg
			// 
			this.btnLoadImg.Location = new System.Drawing.Point(12, 9);
			this.btnLoadImg.Name = "btnLoadImg";
			this.btnLoadImg.Size = new System.Drawing.Size(75, 51);
			this.btnLoadImg.TabIndex = 4;
			this.btnLoadImg.Text = "Load Img";
			this.btnLoadImg.UseVisualStyleBackColor = true;
			this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
			// 
			// lbFileName
			// 
			this.lbFileName.AutoSize = true;
			this.lbFileName.Location = new System.Drawing.Point(93, 14);
			this.lbFileName.Name = "lbFileName";
			this.lbFileName.Size = new System.Drawing.Size(38, 12);
			this.lbFileName.TabIndex = 5;
			this.lbFileName.Text = "label1";
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(495, 422);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 6;
			this.btnAdd.Text = "ADD >>";
			this.btnAdd.UseVisualStyleBackColor = true;
			// 
			// btnDel
			// 
			this.btnDel.Location = new System.Drawing.Point(576, 422);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(75, 23);
			this.btnDel.TabIndex = 7;
			this.btnDel.Text = "<< DEL";
			this.btnDel.UseVisualStyleBackColor = true;
			// 
			// main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1129, 456);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lbFileName);
			this.Controls.Add(this.btnLoadImg);
			this.Controls.Add(this.pnlDestination);
			this.Controls.Add(this.pnlSource);
			this.Controls.Add(this.propertyGrid);
			this.Controls.Add(this.treeView);
			this.Name = "main";
			this.Text = "MIL TEST";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.PropertyGrid propertyGrid;
		private System.Windows.Forms.Panel pnlSource;
		private System.Windows.Forms.Panel pnlDestination;
		private System.Windows.Forms.Button btnLoadImg;
		private System.Windows.Forms.Label lbFileName;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnDel;
	}
}

