using DVLD.Classes;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace DVLD
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            string UserName = "", Passowrd = "";
            if (clsGlobal.GetStoredCredential(ref UserName, ref Passowrd))
            {
                txbUsername.Text = UserName;
                txbPassowrd.Text = Passowrd;
                btnLogin.Focus();
                chbRemberMe.Checked = true;

            }
            else
                chbRemberMe.Checked = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUsers User=clsUsers.FindByUsernameAndPassword(txbUsername.Text.Trim(),txbPassowrd.Text.Trim());

            if (User != null)
            {
                if(chbRemberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(txbUsername.Text.Trim() , txbPassowrd.Text.Trim());
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");
                }

                if(User.IsActive)
                {
                    clsGlobal.CurrentUser = User;
                    this.Hide();
                    frmMainScreen frm = new frmMainScreen(this);
                    frm.ShowDialog();
                }
                else
                {
                    txbUsername.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                txbUsername.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
