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
    public partial class frmShowUserDatalis : Form
    {
       
        public frmShowUserDatalis(int userID)
        {
            InitializeComponent();
            ctrlUserCard1.LoadUserInfo(userID);
        }

     

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void ctrlUserCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
