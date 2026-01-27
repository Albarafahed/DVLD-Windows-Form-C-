namespace FullProject19DVLD
{
    partial class frmShowUserDatalis
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
            this.userControlInfo1 = new FullProject19DVLD.UserControlInfo();
            this.SuspendLayout();
            // 
            // userControlInfo1
            // 
            this.userControlInfo1.BackColor = System.Drawing.Color.White;
            this.userControlInfo1.Location = new System.Drawing.Point(0, 0);
            this.userControlInfo1.Name = "userControlInfo1";
            this.userControlInfo1.Size = new System.Drawing.Size(910, 452);
            this.userControlInfo1.TabIndex = 0;
            this.userControlInfo1.Load += new System.EventHandler(this.userControlInfo1_Load);
            // 
            // frmShowUserDatalis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 450);
            this.Controls.Add(this.userControlInfo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowUserDatalis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowUserDatalis";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlInfo userControlInfo1;
    }
}