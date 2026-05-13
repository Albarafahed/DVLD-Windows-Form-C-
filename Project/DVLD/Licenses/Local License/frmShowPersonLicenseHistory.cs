using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.Local_License
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        private int _LocalDrivenLicenseID = -1;
        private int _PersonID = -1;
        private clsLocalDrivingApplication _localDrivingApplication;
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
           
            if (_PersonID<=0)
            {
               
                ctrlPersonCardWithFilter1.FilterEnabled = 0;
                ctrlPersonCardWithFilter1.FiltterFocuse();
            }
            else
            {
                ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
                ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);
                ctrlPersonCardWithFilter1.FilterEnabled = 1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            if(obj > 0)
            {
                ctrlDriverLicenses1.LoadInfoByPersonID(obj);
            }
            else
            {
               ctrlDriverLicenses1.Clear();
            }
        }
    }
}
