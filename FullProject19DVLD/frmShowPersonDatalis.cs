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
    public partial class frmShowPersonDatalis : Form
    {
        private int _personId = -1;
        public frmShowPersonDatalis(int personId    )
        {

            InitializeComponent();
            _personId = personId;
        }

        private void frmShowPersonDatalis_Load(object sender, EventArgs e)
        {
            pesonInfo1.loadPersonInfor(_personId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }
    }
}
