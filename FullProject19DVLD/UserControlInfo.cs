using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussnisProject;
namespace FullProject19DVLD
{
    public partial class UserControlInfo : UserControl
    {
       clsUsers user1=new clsUsers();
        
        public UserControlInfo()
        {
            InitializeComponent();
        }

       

        public void Fill(int _UserID)
        {
            user1 = user1.GetUsersById(_UserID);
            if (user1 != null)
            {

                pesonInfo1.loadPersonInfor(user1.PersonId);
                lbUserID.Text = _UserID.ToString();
                lbUserName.Text = user1.UserName;
                lbIsActive.Text = user1.IsActive ? "yes" : "No";

            }
        }

        private void UserControlInfo_Load(object sender, EventArgs e)
        {
           
        }
    }
}
