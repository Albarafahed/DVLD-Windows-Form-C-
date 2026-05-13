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

namespace DVLD.User.Control
{
    public partial class ctrlUserCard : UserControl
    {
        private clsUsers _User;
        public ctrlUserCard()
        {
            InitializeComponent();
        }
        public void ResetPersonInfo()
        {
            ctrlPersonCard1.ResetPersonInfo();
            lblIsActive.Text = lblUserID.Text = lblUserName.Text = "???";
           
        }
        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonId);
            lblUserName.Text = _User.UserName;
            lblUserID.Text = _User.UserId.ToString();
            lblIsActive.Text = _User.IsActive ? "Yes" : "No";
        }
        public void LoadUserInfo(int UserId)
        {
             _User = clsUsers.Find(UserId);
            if (_User == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }

        private void ctrlUserCard_Load(object sender, EventArgs e)
        {

        }
    }
}
