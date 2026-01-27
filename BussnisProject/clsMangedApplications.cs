using DataLayerProjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BussnisProject
{
    public class clsMangedApplications
    {
        public clsMangedApplications() { }
        public int ApplicationTypeID { get; set; }

         public string ApplicationTypeTitle { get; set; }

         public double ApplicationFees { get; set; }
        public clsMangedApplications(int applicationTypeID, string applicationTypeTitle, double applicationFees)
        {
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationTypeTitle = applicationTypeTitle;
            this.ApplicationFees = applicationFees;

        }

        private bool _UpdateApplicationTypes()
        {
            return clsAccessApplicationTypes.UpdateApplicationTypes(this.ApplicationTypeID,this.ApplicationTypeTitle,this.ApplicationFees);
        }
        public static DataTable GetApplicationTypes()
        {
            return clsAccessApplicationTypes.GetApplicationTypes();
        }

        public static clsMangedApplications GetApplicationByID(int ApplicationID)
        {
            string ApplicationTypeTitle = "";
            double ApplicationFees = 0.0;
            if (clsAccessApplicationTypes.GetApplicationByID(ApplicationID, ref ApplicationTypeTitle,ref ApplicationFees))
                return new clsMangedApplications(ApplicationID, ApplicationTypeTitle, ApplicationFees);
            else
                return null;
        }

        public bool Save()
        {
            if (_UpdateApplicationTypes())
            {
                return true;
            }
            return false; }
    }
}
