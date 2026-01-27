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

namespace FullProject19DVLD
{
    public partial class AddOrUpdateUserControl : UserControl
    {
        public enum enAddOrUpdate { AddUser=1,UpdateUser=2 }
        private int _UserID = -1;
        private int _personId = -1;
        public enAddOrUpdate status=enAddOrUpdate.AddUser;
        public clsUsers users1 = new clsUsers();
        public AddOrUpdateUserControl()
        {
            InitializeComponent();
            status = enAddOrUpdate.AddUser;
            
        }

        public AddOrUpdateUserControl(int UserID)
        {
            InitializeComponent();
            status = enAddOrUpdate.UpdateUser;
            _UserID = UserID;

        }

        private void _AddUser()
        {
            if (status == enAddOrUpdate.AddUser)
            {
                clsUsers users = new clsUsers();
                //   users.PersonId = personinfoByFilttiring1.PersonId;
                users.UserName = txtUserName.Text;
                users.Passowrd = txtPassorwrd.Text;
                users.IsActive = checkBox1.Checked;
                if (!users.IsPersonIsUser(users.PersonId))
                {

                    if (users.SaveUser())
                    {
                        MessageBox.Show("Saved");
                        lbUserId.Text = users.UserId.ToString();
                    }

                    else
                    {
                        MessageBox.Show("UserName Or User Name is Empty !");
                    }
                }
                else
                {
                    MessageBox.Show("Person Id is oready Exist !");
                }
                }
            } 
        private void _UpdateUser()
        {
            clsUsers user = new clsUsers(int.Parse(lbUserId.Text), "",_personId, txtUserName.Text, txtPassorwrd.Text, checkBox1.Checked);
          
      
                if (user.SaveUser())
                {
                    MessageBox.Show("Saved");

                }

                else
                {
                    MessageBox.Show("UserName Or User Name is Empty !");
                }
            
         
        }

        public void UpdateUser(int userId)
        {
            _UserID= userId;
            status = enAddOrUpdate.UpdateUser;
            
        }

        private void _Fill()
        {
           users1= users1.GetUsersById(_UserID);
            if (users1 != null)
            {
                _personId = users1.PersonId;
                pesonInfo1.loadPersonInfor(users1.PersonId);
                lbUserId.Text=_UserID.ToString();
                txtUserName.Text = users1.UserName;
                checkBox1.Checked = users1.IsActive;
                txtPassorwrd.Text = users1.Passowrd;
                txtPassowrdConfirm.Text = users1.Passowrd;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

       
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, "Requerd The Text Of User Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtPassorwrd_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassorwrd.Text))
            {
                e.Cancel = true;
                txtPassorwrd.Focus();
                errorProvider1.SetError(txtPassorwrd, "Passorwrd  is Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassorwrd, "");
            }

        }

        private void txtPassowrdConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassowrdConfirm.Text))
            {
                e.Cancel = true;
                txtPassowrdConfirm.Focus();
                errorProvider1.SetError(txtPassowrdConfirm, "Passowrd Confirm  is Empty");
            }
            else if (txtPassorwrd.Text != txtPassowrdConfirm.Text)
            {
                e.Cancel = true;
                txtPassowrdConfirm.Focus();
                errorProvider1.SetError(txtPassowrdConfirm, "Passowrd Confirm  is not Equle Password!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassowrdConfirm, "");
            }

        }

         private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtPassorwrd.Text) || string.IsNullOrEmpty(txtPassowrdConfirm.Text) || string.IsNullOrEmpty(txtPassowrdConfirm.Text)))
            {
                
                 switch(status)
                {
                    case enAddOrUpdate.AddUser:
                        _AddUser();
                        break;
                    case enAddOrUpdate.UpdateUser:
                        _UpdateUser(); break;
                }
               

            }
        }

        private void personinfoByFilttiring1_Load(object sender, EventArgs e)
        {

        }

        private void filtiringControl1_OnePersonSelected(int obj)
        {
            if(obj>0)
            {
                pesonInfo1.loadPersonInfor(obj);
            }
        }

        private void filtiringControl1_Load(object sender, EventArgs e)
        {

        }

        private void AddOrUpdateUserControl_Load(object sender, EventArgs e)
        {
            
            switch(status)
            {
                case enAddOrUpdate.AddUser:
                    return;
                case enAddOrUpdate.UpdateUser:
                    filtiringControl1.Enabled = false;
                    _Fill();
                    break;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
