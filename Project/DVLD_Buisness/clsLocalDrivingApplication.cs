using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsLocalDrivingApplication : clsApplication
    {
        public enum enMode { Add = 1, Update = 2 }

        private enMode _Mode = enMode.Add;

        public int LocalDrivingApplicationId { get; set; }
        public int LicenseClassID { set; get; }
        public clsLicenseClass LicenseClassInfo;

        public clsLocalDrivingApplication()
        {
            this.LocalDrivingApplicationId = -1;
            this.LicenseClassID = -1;
            this._Mode = enMode.Add;
        }

        public clsLocalDrivingApplication(int LocalDrivingApplicationId, int LicenseClassID, int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID)
        {
            this.LocalDrivingApplicationId = LocalDrivingApplicationId;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            this._Mode = enMode.Update;


        }





        public static clsLocalDrivingApplication FindByLocalDrivingAppLicenseID(int LocalDrivingApplicationId)
        {
            int ApplicationID = -1, LiceseClassID = -1;

            if (clsLocalDrivingApplicationData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingApplicationId, ref ApplicationID, ref LiceseClassID))
            {
                clsApplication application = clsApplication.FindBaseApplication(ApplicationID);
                if (application != null)
                {
                    return new clsLocalDrivingApplication(
                        LocalDrivingApplicationId, LiceseClassID, ApplicationID, application.ApplicantPersonID,
                        application.ApplicationDate, application.ApplicationTypeID, application.ApplicationStatus, application.LastStatusDate,
                        application.PaidFees, application.CreatedByUserID
                        );
                }

            }
            return null;
        }

        public static clsLocalDrivingApplication FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingApplicationId = -1, LiceseClassID = -1;

            if (clsLocalDrivingApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID(ApplicationID, ref LocalDrivingApplicationId, ref LiceseClassID))
            {
                clsApplication application = clsApplication.FindBaseApplication(ApplicationID);
                if (application != null)
                {
                    return new clsLocalDrivingApplication(
                        LocalDrivingApplicationId, LiceseClassID, ApplicationID, application.ApplicantPersonID,
                        application.ApplicationDate, application.ApplicationTypeID, application.ApplicationStatus, application.LastStatusDate,
                        application.PaidFees, application.CreatedByUserID
                        );
                }

            }
            return null;
        }


        private bool _AddNewLocalDrivingApplication()
        {
            this.LocalDrivingApplicationId = clsLocalDrivingApplicationData.AddNewLocalDrivingApplication(this.ApplicationID, this.LicenseClassID);

            return this.LocalDrivingApplicationId > 0;
        }

        private bool _UpdateLocalDrivingApplication()
        {
            return clsLocalDrivingApplicationData.UpdateLocalDrivingApplication(this.LocalDrivingApplicationId,this.ApplicationID,this.LicenseClassID);
        }

        public  bool Delete()
        {
            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;
              IsLocalDrivingApplicationDeleted = clsLocalDrivingApplicationData.DeleteLocalDrivingApplication(this.LocalDrivingApplicationId);
            if(!IsLocalDrivingApplicationDeleted)
                return false;
            IsBaseApplicationDeleted = base.Delete();
            return IsBaseApplicationDeleted;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingApplicationData.GetAllLocalDrivingLicenseApplications();
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {//this will get the license id that belongs to this application
            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }

        public bool DoesPassTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingApplicationData.DoesPassTestType(this.LocalDrivingApplicationId,(int)TestTypeID);
        }

        public bool PassedAllTests()
        {
            return clsTest.GetPassedTestCount(this.LocalDrivingApplicationId)==3;
        }

        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingApplicationData.IsThereAnActiveScheduledTest(this.LocalDrivingApplicationId,(int) TestTypeID);
        }
        public static bool IsThereAnActiveScheduledTest(int LocalDrivingApplicationId,clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingApplicationData.IsThereAnActiveScheduledTest(LocalDrivingApplicationId, (int)TestTypeID);
        }

        public clsTest FindLastTestPerPersonAndLicenseClass(clsTestType.enTestType TestTypeID)
        {
            return clsTest.FindLastTestPerPersonAndLicenseClass(this.LocalDrivingApplicationId,this.LicenseClassID,TestTypeID);
        }
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTest.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }
        public  byte GetPassedTestCount()
        {
            return clsTest.GetPassedTestCount(this.LocalDrivingApplicationId);
        }

        public bool SetComplate()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, 3);
        }
        public int IssueLicenseForTheFirtTime(string Notes,int UserID)
        {
            clsDriver driver = clsDriver.FindByPersonID(this.ApplicantPersonID);
            if(driver == null)
            {

               driver= new clsDriver();
               driver.PersonID = this.ApplicantPersonID;
                driver.CreatedByUserID = UserID;
                if (!driver.Save())
                    return -1;
            }
            clsLicense license=new clsLicense();
            license.ApplicationID = this.ApplicationID;
            license.DriverID = driver.DriverID;
            license.LicenseClass = this.LicenseClassInfo.LicenseClassID;
            license.IssueDate = DateTime.Now;
            license.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            license.Notes = Notes;
            license.PaidFees = this.LicenseClassInfo.ClassFees;
            license.IsActive = true;
            license.IssueReason = clsLicense.enIssueReason.FirstTime;
            license.CreatedByUserID = UserID;
            if (license.Save())
            {
                this.SetComplate();
                return license.LicenseID;
            }
            else { return -1; }

        }
     

        public byte TotalTrialsPerTest(clsTestType.enTestType TestTypeID)
        {
          return clsLocalDrivingApplicationData.TotalTrialsPerTest(this.LocalDrivingApplicationId,(int) TestTypeID);
        }
        public bool Save()
        {
            base.Mode=(clsApplication.enMode) _Mode;
            if(!base.Save())
                return false;
            switch(_Mode)
            {
                case enMode.Add:
                    if(_AddNewLocalDrivingApplication())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    break;
                    case enMode.Update:
                    return _UpdateLocalDrivingApplication();
            }
            return false;


        } 

    }
}
