namespace FullProject19DVLD
{
    partial class frmAddNewPeople
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
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addOrEditPresonInfo1 = new FullProject19DVLD.AddOrEditPresonInfo();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(320, 483);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 58);
            this.btnClose.TabIndex = 82;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(376, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 34);
            this.label1.TabIndex = 83;
            this.label1.Text = "Add New People";
            // 
            // addOrEditPresonInfo1
            // 
            this.addOrEditPresonInfo1.BackColor = System.Drawing.Color.White;
            this.addOrEditPresonInfo1.Location = new System.Drawing.Point(32, 63);
            this.addOrEditPresonInfo1.Name = "addOrEditPresonInfo1";
            this.addOrEditPresonInfo1.Size = new System.Drawing.Size(1105, 518);
            this.addOrEditPresonInfo1.TabIndex = 0;
            this.addOrEditPresonInfo1.Load += new System.EventHandler(this.addOrEditPresonInfo1_Load);
            // 
            // frmAddNewPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1159, 585);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.addOrEditPresonInfo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddNewPeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddNewPeople";
            this.Load += new System.EventHandler(this.frmAddNewPeople_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AddOrEditPresonInfo addOrEditPresonInfo1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}