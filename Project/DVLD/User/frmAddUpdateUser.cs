using DVLD_Buisness;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmAddUpdateUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _UserID = -1;
        private clsUsers _User;
        private int _PersonId = -1;
        
        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateUser(int UserId)
        {
            InitializeComponent();
            _UserID = UserId;
            _Mode = enMode.Update;
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
        private void _ResetDefualtValues()
        {

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                _User = new clsUsers();
            }
            else
            {
                lblTitle.Text = "Update User";
               
            }
            tpLoginInfo.Enabled = false;
            btnSave.Enabled = false;
            ctrlPersonCardWithFilter1.FilterEnabled = (short)_Mode;
            lblUserID.Text = "???";
            txtConfirmPassword.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
           
            chkIsActive.Checked = true;
            
           
            
        }
        private void LoadData()
        {
            _User = clsUsers.Find(_UserID);
            if( _User == null ) {
               
        
                    MessageBox.Show("No USer with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }

             ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonId);
            txtConfirmPassword.Text = _User.Passowrd;
            txtPassword.Text = _User.Passowrd;
            txtUserName.Text= _User.UserName;
            lblUserID.Text = _User.UserId.ToString();
            chkIsActive.Checked = _User.IsActive;
            tpLoginInfo.Enabled = true;
            btnSave.Enabled = true;
            _PersonId = _User.PersonId;
            

        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if(_Mode == enMode.Update)
                LoadData();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _User.UserName = txtUserName.Text;
            _User.Passowrd=txtPassword.Text;
            _User.IsActive=chkIsActive.Checked;
            _User.PersonId=_PersonId;
            if(_User.SaveUser())
            {
                lblTitle.Text = "Update User";
                _Mode = enMode.Update;
                lblUserID.Text = _User.UserId.ToString();

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
       

        private void txtBoxValidating(object sender, CancelEventArgs e)
        {
            TextBox Empty=(TextBox)sender;
            if (string.IsNullOrEmpty(Empty.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(Empty, "This field is required!");
            }
            else
                errorProvider1.SetError(Empty, null);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "This field is required!");
            }
            else if(txtConfirmPassword.Text.Trim()!=txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "This field don't equal TxtPassword!");
            }
            else
                errorProvider1.SetError(txtConfirmPassword, null);
        }

        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {
            
            switch(_Mode)
            {
                case enMode.AddNew: {
                        if (_PersonId == -1)
                        {
                            MessageBox.Show("Please Selected Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ctrlPersonCardWithFilter1.FiltterFocuse();
                            return;
                        }
                        if (clsUsers.IsPersonIsUser(_PersonId))
                        {
                            MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ctrlPersonCardWithFilter1.FiltterFocuse();
                            return;
                        }
                        btnSave.Enabled = true;
                        tpLoginInfo.Enabled = true;
                        tcUserInfo.SelectedIndex = 1;

                    }
                    break;
                    case enMode.Update: {

                        tcUserInfo.SelectedIndex = 1;
                    }
                    break;
            }
          

        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _PersonId = obj;
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
            ;


            if (_Mode == enMode.AddNew)
            {

                if (clsUsers.isUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }
                ;
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (clsUsers.isUserExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    }
                    ;
                }
            }
        }

        private void frmAddUpdateUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FiltterFocuse();
        }
    }
}
