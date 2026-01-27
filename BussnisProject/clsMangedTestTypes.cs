using DataLayerProjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussnisProject
{
    public class clsMangedTestTypes
    {
        public clsMangedTestTypes() { }
        public int TestTypeID { get; set; }

        public string TestTypeTitle { get; set; }

        public string TestTypeDescription { get; set; }

        public double TestTypeFees { get; set; }
        public clsMangedTestTypes(int TestTypeID, string TestTypeTitle, string TestTypeDescription, double TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeFees = TestTypeFees;
            this.TestTypeDescription= TestTypeDescription;

        }

        private bool _UpdateTestTypes()
        {
            return clsDataAccessMangedTestTypes.UpdateTestTypes(this.TestTypeID, this.TestTypeTitle,this.TestTypeDescription, this.TestTypeFees);
        }
        public static DataTable GetTestTypes()
        {
            return clsDataAccessMangedTestTypes.GetMangedTestTypes();
        }

        public static clsMangedTestTypes GetApplicationByID(int TestTypeID)
        {
            string TestTypeTitle = "";
            string TestTypeDescription = "";
     
            double TestTypeFees = 0.0;
            if (clsDataAccessMangedTestTypes.GetTestTypesByID(TestTypeID, ref TestTypeTitle,ref TestTypeDescription, ref TestTypeFees))
                return new clsMangedTestTypes(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            else
                return null;
        }

        public bool Save()
        {
            if (_UpdateTestTypes())
            {
                return true;
            }
            return false;
        }
    }
}
