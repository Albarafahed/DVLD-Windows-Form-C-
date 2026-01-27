using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BussnisProject;
namespace FullProject19DVLD
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UserName=txbUsername.Text;
            string Passowrd=txbPassowrd.Text;
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Passowrd))
                return;
            if (clsLoginScreen.ChickedUserNameAndPassord(UserName, Passowrd))
            {
                clsGlouble.UserID = clsUsers.GetIDUserByUserName(UserName);
                clsGlouble.UserName= UserName;
               
                if (clsLoginScreen.ChickedUserisActive(UserName, Passowrd))
                {
                    clsGlouble.IsActive = 1;
                    if (chbRemberMe.Checked)
                    {
                        File.WriteAllText("UserInfo.txt", UserName + '\n' + Passowrd);
                    }
                    else
                    {
                        if (File.Exists("UserInfo.txt"))
                            File.Delete("UserInfo.txt");
                    }
                    frmMainScreen frm=new frmMainScreen();
                    frm.ShowDialog()
                        ;this.Close();
                }
                else
                    MessageBox.Show(" UserName is not Active ", "Checked", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Passord or UserName is Invalid ","Checked",MessageBoxButtons.OK, MessageBoxIcon.Error);


           
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            this.Font=new Font("Tahoma",12f,FontStyle.Bold);
            try
            {
                string[] data = File.ReadAllLines("UserInfo.txt");

                if (data.Length == 2)
                {
                    txbUsername.Text = data[0];
                    txbPassowrd.Text = data[1];
                    chbRemberMe.Checked = true;
                }
            }
            catch (Exception ex) { }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
