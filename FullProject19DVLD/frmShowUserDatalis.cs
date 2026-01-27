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
    public partial class frmShowUserDatalis : Form
    {
        private int _UserID = -1;
        public frmShowUserDatalis(int userID)
        {
            _UserID = userID;
            InitializeComponent();
           
        }

        private void userControlInfo1_Load(object sender, EventArgs e)
        {
            userControlInfo1.Fill(_UserID);
        }
    }
}
