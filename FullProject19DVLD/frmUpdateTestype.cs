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
    public partial class frmUpdateTestype : Form
    {
        private int _TestTypeID = -1;

        public delegate void DataBackEventHandler(object sender);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public frmUpdateTestype(int testTypeID)
        {
            InitializeComponent();
            _TestTypeID = testTypeID;
        }

        private void _Fill()
        {
            clsMangedTestTypes mangedTestTypes = clsMangedTestTypes.GetApplicationByID(_TestTypeID);
            if (mangedTestTypes != null)
            {
                lbTestTypeID.Text = mangedTestTypes.TestTypeID.ToString();
                txtTestTypeFees.Text = mangedTestTypes.TestTypeFees.ToString();
                txtTestTypeTitle.Text = mangedTestTypes.TestTypeTitle.ToString();
                txtTestTypeDescription.Text= mangedTestTypes.TestTypeDescription.ToString();
            }

        }
        private void frmUpdateTestype_Load(object sender, EventArgs e)
        {
            _Fill();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this);
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTestTypeFees.Text != "" && txtTestTypeTitle.Text != "")
            {
                clsMangedTestTypes mangedTest = new clsMangedTestTypes();
                mangedTest.TestTypeID = _TestTypeID;
                mangedTest.TestTypeTitle = txtTestTypeTitle.Text.Trim();
                mangedTest.TestTypeFees = Convert.ToDouble(txtTestTypeFees.Text.Trim());
                mangedTest.TestTypeDescription = txtTestTypeDescription.Text;

                if (mangedTest.Save())
                {
                    MessageBox.Show("SuccessFully");

                }
                else
                    MessageBox.Show("Faildy");
            }
        }
    }
}
