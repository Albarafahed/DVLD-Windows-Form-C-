using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmShowPersonDatalis : Form
    {
        
        public frmShowPersonDatalis(int personId  )
        {

            InitializeComponent();
            ctrlPersonCard1.LoadPersonInfo(personId);     
        }

        public frmShowPersonDatalis(string NationalN)
        {

            InitializeComponent();
            ctrlPersonCard1.LoadPersonInfo(NationalN);
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPersonDatalis_Load(object sender, EventArgs e)
        {

        }
    }
}
