using DVLD_Buisness;
using DVLD.Classes;
using DVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.International_Licenses.Controls
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        private int _InternationalLicenseID = -1;
        private clsInternationalLicense _InternationalLicense;
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public int InternationalLicenseID { get { return _InternationalLicenseID; } }

        public clsInternationalLicense SelectedInternationalLicense {  get { return _InternationalLicense; } }

        private void _LoadPersonImage()
        {
            string ImagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath=="")
            {
                switch(lblGendor.Text)
                {
                    case "Male":
                        pbGendor.Image=Resources.Male_512; break;
                    case "Female":
                        pbGendor.Image = Resources.Female_512; break;
                }
                return;
            }

            if (File.Exists(ImagePath))
                pbGendor.Load(ImagePath);
            else
                MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        private void _FillInternationalLicenseInfo()
        {
            lblInternationalLicenseID.Text=_InternationalLicenseID.ToString();
            lblLocalLicenseID.Text=_InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lblFullName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _InternationalLicense.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = clsFormat.DateToShort(_InternationalLicense.DriverInfo.PersonInfo.DateOfBirth);

            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblIssueDate.Text = clsFormat.DateToShort(_InternationalLicense.IssueDate);
            lblExpirationDate.Text = clsFormat.DateToShort(_InternationalLicense.ExpirationDate);
            lblApplicationID.Text=_InternationalLicense.ApplicationID.ToString();

            _LoadPersonImage();
        }
        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID=InternationalLicenseID;
            _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);
            if(_InternationalLicense==null)
            {
                MessageBox.Show("Could not find License ID = " + _InternationalLicenseID.ToString(),
                     "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationalLicenseID = -1;
                return;
            }
            _FillInternationalLicenseInfo();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
