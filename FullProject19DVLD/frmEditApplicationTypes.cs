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
    public partial class frmEditApplicationTypes : Form
    {
        private int _ApplicationID = -1;
        public delegate void DataBackEventHandler(object sender);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public frmEditApplicationTypes(int ApplicationID)
        {
            _ApplicationID = ApplicationID;
            InitializeComponent();
        }
        private void _Fill()
        {
            clsMangedApplications mangedApplications=clsMangedApplications.GetApplicationByID(_ApplicationID);
            if (mangedApplications != null)
            {
                lbApplicationID.Text=mangedApplications.ApplicationTypeID.ToString();
                txtApplicationFees.Text=mangedApplications.ApplicationFees.ToString();
                txtApplicationTypeTitle.Text=mangedApplications.ApplicationTypeTitle.ToString();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this);
            this.Close();
        }

        private void frmEditApplicationTypes_Load(object sender, EventArgs e)
        {
            _Fill();
        }

        private void txtApplicationTypeTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtApplicationFees.Text!="" &&  txtApplicationTypeTitle.Text!="")
            {
                clsMangedApplications mangedApplications=new clsMangedApplications();
                mangedApplications.ApplicationTypeID = _ApplicationID;
                mangedApplications.ApplicationTypeTitle=txtApplicationTypeTitle.Text.Trim();
                mangedApplications.ApplicationFees=Convert.ToDouble(txtApplicationFees.Text.Trim());

                if (mangedApplications.Save())
                {
                    MessageBox.Show("SuccessFully");

                }
                else
                    MessageBox.Show("Faildy");

            }
        }
    }
}
