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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("노드0");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("노드1");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("노드2");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("노드3");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("노드4");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("노드5");
			this.treeView = new System.Windows.Forms.TreeView();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.btnLoadImg = new System.Windows.Forms.Button();
			this.lbFileName = new System.Windows.Forms.Label();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnDel = new System.Windows.Forms.Button();
			this.image_panel_destination = new MIL_TEST_FORM.image_panel();
			this.image_panel_source = new MIL_TEST_FORM.image_panel();
			this.SuspendLayout();
			// 
			// treeView
			// 
			this.treeView.Location = new System.Drawing.Point(616, 66);
			this.treeView.Name = "treeView";
			treeNode1.Name = "노드0";
			treeNode1.Text = "노드0";
			treeNode2.Name = "노드1";
			treeNode2.Text = "노드1";
			treeNode3.Name = "노드2";
			treeNode3.Text = "노드2";
			treeNode4.Name = "노드3";
			treeNode4.Text = "노드3";
			treeNode5.Name = "노드4";
			treeNode5.Text = "노드4";
			treeNode6.Name = "노드5";
			treeNode6.Text = "노드5";
			this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
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
			// btnLoadImg
			// 
			this.btnLoadImg.Location = new System.Drawing.Point(12, 24);
			this.btnLoadImg.Name = "btnLoadImg";
			this.btnLoadImg.Size = new System.Drawing.Size(102, 36);
			this.btnLoadImg.TabIndex = 4;
			this.btnLoadImg.Text = "Load Img";
			this.btnLoadImg.UseVisualStyleBackColor = true;
			this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
			// 
			// lbFileName
			// 
			this.lbFileName.AutoSize = true;
			this.lbFileName.Location = new System.Drawing.Point(12, 9);
			this.lbFileName.Name = "lbFileName";
			this.lbFileName.Size = new System.Drawing.Size(63, 12);
			this.lbFileName.TabIndex = 5;
			this.lbFileName.Text = "File Name";
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(576, 152);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(34, 23);
			this.btnAdd.TabIndex = 6;
			this.btnAdd.Text = ">>";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDel
			// 
			this.btnDel.Location = new System.Drawing.Point(576, 181);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(34, 23);
			this.btnDel.TabIndex = 7;
			this.btnDel.Text = "<<";
			this.btnDel.UseVisualStyleBackColor = true;
			// 
			// image_panel_destination
			// 
			this.image_panel_destination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.image_panel_destination.Location = new System.Drawing.Point(804, 66);
			this.image_panel_destination.Name = "image_panel_destination";
			this.image_panel_destination.Size = new System.Drawing.Size(350, 350);
			this.image_panel_destination.TabIndex = 9;
			// 
			// image_panel_source
			// 
			this.image_panel_source.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.image_panel_source.Location = new System.Drawing.Point(12, 66);
			this.image_panel_source.Name = "image_panel_source";
			this.image_panel_source.Size = new System.Drawing.Size(350, 350);
			this.image_panel_source.TabIndex = 8;
			// 
			// main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1166, 429);
			this.Controls.Add(this.image_panel_destination);
			this.Controls.Add(this.image_panel_source);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lbFileName);
			this.Controls.Add(this.btnLoadImg);
			this.Controls.Add(this.propertyGrid);
			this.Controls.Add(this.treeView);
			this.DoubleBuffered = true;
			this.Name = "main";
			this.Text = "MIL TEST";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.PropertyGrid propertyGrid;
		private System.Windows.Forms.Button btnLoadImg;
		private System.Windows.Forms.Label lbFileName;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnDel;
		private image_panel image_panel_source;
		private image_panel image_panel_destination;
	}
}

