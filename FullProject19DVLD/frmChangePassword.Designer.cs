namespace FullProject19DVLD
{
    partial class frmChangePassword
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurrentPassorwrd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewPassowrd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textConfirmPassowrd = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.userControlInfo1 = new FullProject19DVLD.UserControlInfo();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Current Passowrd :";
            // 
            // txtCurrentPassorwrd
            // 
            this.txtCurrentPassorwrd.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPassorwrd.Location = new System.Drawing.Point(207, 451);
            this.txtCurrentPassorwrd.Name = "txtCurrentPassorwrd";
            this.txtCurrentPassorwrd.PasswordChar = '*';
            this.txtCurrentPassorwrd.Size = new System.Drawing.Size(165, 28);
            this.txtCurrentPassorwrd.TabIndex = 4;
            this.txtCurrentPassorwrd.TextChanged += new System.EventHandler(this.txtCurrentPassorwrd_TextChanged);
            this.txtCurrentPassorwrd.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassorwrd_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 507);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "New Passowrd :";
            // 
            // txtNewPassowrd
            // 
            this.txtNewPassowrd.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassowrd.Location = new System.Drawing.Point(207, 500);
            this.txtNewPassowrd.Name = "txtNewPassowrd";
            this.txtNewPassowrd.PasswordChar = '*';
            this.txtNewPassowrd.Size = new System.Drawing.Size(165, 28);
            this.txtNewPassowrd.TabIndex = 6;
            this.txtNewPassowrd.Validating += new System.ComponentModel.CancelEventHandler(this.txtNewPassowrd_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 547);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Confirm Passowrd :";
            // 
            // textConfirmPassowrd
            // 
            this.textConfirmPassowrd.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textConfirmPassowrd.Location = new System.Drawing.Point(207, 540);
            this.textConfirmPassowrd.Name = "textConfirmPassowrd";
            this.textConfirmPassowrd.PasswordChar = '*';
            this.textConfirmPassowrd.Size = new System.Drawing.Size(165, 28);
            this.textConfirmPassowrd.TabIndex = 8;
            this.textConfirmPassowrd.TextChanged += new System.EventHandler(this.textConfirmPassowrd_TextChanged);
            this.textConfirmPassowrd.Validating += new System.ComponentModel.CancelEventHandler(this.textConfirmPassowrd_Validating);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Traditional Arabic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(492, 632);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 31);
            this.btnSave.TabIndex = 89;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Traditional Arabic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(362, 632);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 31);
            this.btnClose.TabIndex = 90;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // userControlInfo1
            // 
            this.userControlInfo1.BackColor = System.Drawing.Color.White;
            this.userControlInfo1.Location = new System.Drawing.Point(12, 3);
            this.userControlInfo1.Name = "userControlInfo1";
            this.userControlInfo1.Size = new System.Drawing.Size(910, 428);
            this.userControlInfo1.TabIndex = 91;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(943, 712);
            this.Controls.Add(this.userControlInfo1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textConfirmPassowrd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNewPassowrd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCurrentPassorwrd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChangePassword";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrentPassorwrd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewPassowrd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textConfirmPassowrd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private UserControlInfo userControlInfo1;
    }
}