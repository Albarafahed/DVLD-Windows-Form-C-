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

namespace DVLD.Tests
{
    public partial class frmScheduleTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private int _AppointmentID = -1;
      

        private clsTest.enStatues _Statues=clsTest.enStatues.NotFound;
        public frmScheduleTest(int LocalDrivingLicenseApplicationID,clsTestType.enTestType testType, clsTest.enStatues statues = clsTest.enStatues.NotFound,int AppointmentID=-1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID=LocalDrivingLicenseApplicationID;
            _AppointmentID=AppointmentID;
            _TestTypeID=testType;
            _Statues=statues;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _TestTypeID;
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _AppointmentID,_Statues);

        }

        private void ctrlScheduleTest1_Load(object sender, EventArgs e)
        {

        }
    }
}
