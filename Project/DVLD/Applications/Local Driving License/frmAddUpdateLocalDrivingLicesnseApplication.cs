using DVLD.Classes;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Applications.Local_Driving_License
{
   
    public partial class frmAddUpdateLocalDrivingLicesnseApplication : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }

        private enMode _Mode = enMode.AddNew;

        public frmAddUpdateLocalDrivingLicesnseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }
        public frmAddUpdateLocalDrivingLicesnseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID=LocalDrivingLicenseApplicationID;
            _Mode = enMode.Update;
        }
      

      

        private int _SelectedPersonID=-1;

        private clsLocalDrivingApplication _LocalDrivingApplication;

        private void _FillLicenseClassCombo()
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClasses();
            if (dt != null)
            {
                cbLicenseClass.DataSource = dt;
                cbLicenseClass.DisplayMember = "ClassName";
                cbLicenseClass.ValueMember = "LicenseClassID";
            }
        }
        private void _ResetDefualtValues()
        {
            _FillLicenseClassCombo();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Local Driving License Application";
                this.Text= lblTitle.Text;
                tpApplicationInfo.Enabled = false;
                cbLicenseClass.SelectedIndex = 2;
                ctrlPersonCardWithFilter1.FiltterFocuse();
                _LocalDrivingApplication = new clsLocalDrivingApplication();
                lblApplicationDate.Text= DateTime.Now.ToShortDateString();
                lblFees.Text=clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                //lblCreatedByUser.Text=clsGlobal.CurrentUser.UserId.ToString();
                lblCreatedByUser.Text = "1";
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = lblTitle.Text;

            }
           
            btnSave.Enabled = false;
            ctrlPersonCardWithFilter1.FilterEnabled = (short)_Mode;
          



        }
        private void _LoadData()
        {

            _LocalDrivingApplication = clsLocalDrivingApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            if (_LocalDrivingApplication == null)
            {


                MessageBox.Show("No LocalDrivingApplication with ID = " + _LocalDrivingApplication, "LocalDrivingApplication Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingApplication.ApplicantPersonID);
            lblLocalDrivingLicebseApplicationID.Text=_LocalDrivingApplication.LocalDrivingApplicationId.ToString();
            lblApplicationDate.Text=_LocalDrivingApplication.ApplicationDate.ToString();
            cbLicenseClass.SelectedIndex = _LocalDrivingApplication.LicenseClassID-1;
            lblFees.Text=_LocalDrivingApplication.PaidFees.ToString();
            lblCreatedByUser.Text=_LocalDrivingApplication.CreatedByUserID.ToString();
            tpApplicationInfo.Enabled = true;
            btnSave.Enabled = true;
            _SelectedPersonID = _LocalDrivingApplication.ApplicantPersonID;


        }

        private void frmAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if(_Mode==enMode.Update)
                _LoadData();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void btnApplicationInfoNext_Click(object sender, EventArgs e)
        {

            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_SelectedPersonID == -1)
                        {
                            MessageBox.Show("Please Selected Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ctrlPersonCardWithFilter1.FiltterFocuse();
                            return;
                        }

                        btnSave.Enabled = true;
                        tpApplicationInfo.Enabled = true;
                        tcApplicationInfo.SelectedIndex = 1;

                    }
                    break;
                case enMode.Update:
                    {

                        tcApplicationInfo.SelectedIndex = 1;
                    }
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID,(int)cbLicenseClass.SelectedValue,(byte)clsApplication.enApplicationType.NewDrivingLicense);
            if(ActiveApplicationID != -1)
            {
                
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }
            if (clsLicense.IsLicenseExistByPersonID(_SelectedPersonID, (int)cbLicenseClass.SelectedValue))
            {

                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingApplication.LicenseClassID = (int)cbLicenseClass.SelectedValue;
            _LocalDrivingApplication.ApplicantPersonID = _SelectedPersonID;
            _LocalDrivingApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingApplication.ApplicationTypeID=(int)clsApplication.enApplicationType.NewDrivingLicense;
            _LocalDrivingApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingApplication.CreatedByUserID = clsGlobal.CurrentUser.UserId;
            _LocalDrivingApplication.PaidFees = Convert.ToSingle(lblFees.Text);

            if (_LocalDrivingApplication.Save())
            {
                lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingApplication.LocalDrivingApplicationId.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
