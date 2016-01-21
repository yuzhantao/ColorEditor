namespace ColorEditor
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbInsertImage = new System.Windows.Forms.ToolStripButton();
            this.colorEditor1 = new ColorEditorControl.Editor.ColorEditor();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbInsertImage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(337, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbInsertImage
            // 
            this.tbInsertImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbInsertImage.Image = ((System.Drawing.Image)(resources.GetObject("tbInsertImage.Image")));
            this.tbInsertImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbInsertImage.Name = "tbInsertImage";
            this.tbInsertImage.Size = new System.Drawing.Size(60, 22);
            this.tbInsertImage.Text = "插入图片";
            this.tbInsertImage.Click += new System.EventHandler(this.tbInsertImage_Click);
            // 
            // colorEditor1
            // 
            this.colorEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorEditor1.BackgroundImage = global::ColorEditor.Properties.Resources.background;
            this.colorEditor1.Location = new System.Drawing.Point(0, 28);
            this.colorEditor1.Name = "colorEditor1";
            this.colorEditor1.Size = new System.Drawing.Size(337, 281);
            this.colorEditor1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 309);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.colorEditor1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColorEditorControl.Editor.ColorEditor colorEditor1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbInsertImage;
    }
}

