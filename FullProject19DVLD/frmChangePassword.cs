using BussnisProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FullProject19DVLD
{
    public partial class frmChangePassword : Form
    {
        private int _UserID=-1;
        private clsUsers user1=new clsUsers();
        public frmChangePassword(int UserID)
        {
            _UserID = UserID;
            user1=user1.GetUsersById(_UserID);
            InitializeComponent();
           
        }

       
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            userControlInfo1.Fill(_UserID);
            txtCurrentPassorwrd.Focus();
        }

        private void txtPassorwrd_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassorwrd.Text) || txtCurrentPassorwrd.Text != user1.Passowrd)
            {
                e.Cancel = true;
                txtCurrentPassorwrd.Focus();
                errorProvider1.SetError(txtCurrentPassorwrd, "Password Is Not CurrentPassword!");
               
            }
            else
                errorProvider1.SetError(txtCurrentPassorwrd, "");

        }

        private void txtNewPassowrd_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassorwrd.Text))
            {
                e.Cancel = true;
                txtNewPassowrd.Focus();
                errorProvider1.SetError(txtNewPassowrd, "Password Is Empty !");
            }
            else
                errorProvider1.SetError(txtNewPassowrd, "");

        }

        private void textConfirmPassowrd_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassorwrd.Text) || textConfirmPassowrd.Text != txtNewPassowrd.Text)
            {
                e.Cancel = true;
                textConfirmPassowrd.Focus();

                errorProvider1.SetError(textConfirmPassowrd, "Password Is Not CurrentPassword!");
            }


            else
                errorProvider1.SetError(textConfirmPassowrd, "");
        }

        private void textConfirmPassowrd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassorwrd.Text) || string.IsNullOrEmpty(txtNewPassowrd.Text) || string.IsNullOrEmpty(textConfirmPassowrd.Text))
                MessageBox.Show("Password Is Empty !");
            else
                if(clsUsers.UpdatePassword(user1.UserId, txtNewPassowrd.Text))
                 MessageBox.Show("Password Is SuccessFully!");


        }

        private void txtCurrentPassorwrd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
