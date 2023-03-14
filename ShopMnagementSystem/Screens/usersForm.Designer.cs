namespace ShopMnagementSystem.Screens
{
    partial class usersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usersForm));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.studentrecordtoolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closetoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(319, 50);
            this.comboBox1.TabIndex = 71;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentrecordtoolStripButton1,
            this.toolStripSeparator1,
            this.closetoolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(343, 25);
            this.toolStrip1.TabIndex = 72;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // studentrecordtoolStripButton1
            // 
            this.studentrecordtoolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.studentrecordtoolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("studentrecordtoolStripButton1.Image")));
            this.studentrecordtoolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.studentrecordtoolStripButton1.Name = "studentrecordtoolStripButton1";
            this.studentrecordtoolStripButton1.Size = new System.Drawing.Size(105, 22);
            this.studentrecordtoolStripButton1.Text = "Change Password";
            this.studentrecordtoolStripButton1.Click += new System.EventHandler(this.studentrecordtoolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // closetoolStripButton
            // 
            this.closetoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.closetoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("closetoolStripButton.Image")));
            this.closetoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closetoolStripButton.Name = "closetoolStripButton";
            this.closetoolStripButton.Size = new System.Drawing.Size(40, 22);
            this.closetoolStripButton.Text = "Close";
            this.closetoolStripButton.ToolTipText = "Close(Esc)";
            this.closetoolStripButton.Click += new System.EventHandler(this.closetoolStripButton_Click);
            // 
            // usersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(343, 157);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "usersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Info Form";
            this.Load += new System.EventHandler(this.usersForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usersForm_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton studentrecordtoolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton closetoolStripButton;
    }
}