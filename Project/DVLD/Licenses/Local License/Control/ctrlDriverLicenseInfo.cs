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

namespace DVLD.Licenses.Local_License.Control
{
    
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        private int _LicenseID = -1;
        private clsLicense _License;
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public int LicenssID { get { return _LicenseID; } }

        public clsLicense LicenseInfo {  get { return _License; } }

        private void _LoadPersonImage()
        {
            string ImagePath=_License.DriverInfo.PersonInfo.ImagePath;
            if(ImagePath =="")
            {
                if (_License.DriverInfo.PersonInfo.Gendor == 0)
                    pbGendor.Image = Resources.Male_512;
                else
                    pbGendor.Image= Resources.Female_512;
            }
            else
            {
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void LoadInfo(int LicensesID)
        {
            _LicenseID = LicensesID;
            _License = clsLicense.Find(_LicenseID);
            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
            lblClass.Text = _License.LicenseClassIfo.ClassName;
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = clsFormat.DateToShort(_License.DriverInfo.PersonInfo.DateOfBirth);

            lblDriverID.Text = _License.DriverID.ToString();
            lblIssueDate.Text = clsFormat.DateToShort(_License.IssueDate);
            lblExpirationDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            _LoadPersonImage();



        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlDriverLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
