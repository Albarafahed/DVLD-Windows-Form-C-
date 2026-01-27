using DataLayerProjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
namespace BussnisProject
{
    public class clsPeople
    {
       public enum enPeopleAddOrUpdate { AddNewPeope=1,UpdatePeople=2};

        public int PersonId { get; set; }
        public string NationalNo { get; set; }

        public string FirstName { get; set; }
         public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public int Gendor {  get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Phone {  get; set; }

        public int NationalityCountryID { get; set; }

        public string Address { get; set; }
        public string ImagePath { get; set; }
        public string Email { get; set; }

        public enPeopleAddOrUpdate PeopleStatues= enPeopleAddOrUpdate.AddNewPeope;

       public clsPeople()
        {
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            Gendor = 0;
            DateOfBirth = DateTime.MinValue;
            Phone = string.Empty;
            NationalityCountryID = -1;
            Address = string.Empty;
            ImagePath = string.Empty;
            Email = string.Empty;

            PeopleStatues=enPeopleAddOrUpdate.AddNewPeope;
            this.PersonId = -1;

        }

       public clsPeople(int PersonId, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
                           int Gendor, DateTime DateOfBirth, string Phone, int NationalityCountryID, string Address,
                           string ImagePath, string Email)
        {
            this.PersonId=PersonId;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Gendor = Gendor;
            this.DateOfBirth = DateOfBirth;
            this.Phone = Phone;
            this.NationalityCountryID = NationalityCountryID;
            this.Address = Address;
            this.ImagePath = ImagePath;
            this.Email = Email;
            PeopleStatues = enPeopleAddOrUpdate.UpdatePeople;

        }



        private bool _AddNewPeople()
        {
            this.PersonId = clsDataLayer.SavePepole(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Gendor, this.DateOfBirth, this.Phone, this.NationalityCountryID, this.Address,this.ImagePath, this.Email);
            return PersonId > 0;
        }

        public static clsPeople GetPeopleByPersonId(int PersonId)
        {
           
            string NationalNo = ""; string FirstName = ""; string SecondName = ""; string ThirdName = ""; string LastName = "";
            int Gendor =0; DateTime DateOfBirth=DateTime.Now ; string Phone = ""; int NationalityCountryID = -1; string Address = "";
            string ImagePath = ""; string Email = "";

            if (clsDataLayer.GetPeopleByPersonID(PersonId, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                            ref Gendor, ref DateOfBirth, ref Phone, ref NationalityCountryID, ref Address,
                            ref ImagePath, ref Email))
            {

                return new clsPeople(PersonId,NationalNo, FirstName, SecondName, ThirdName, LastName, Gendor, DateOfBirth, Phone, NationalityCountryID, Address, ImagePath, Email);
            }
            else
                return null;
        }

        public static int GetPeopleByPersonID(int PersonId)
        {



            return clsDataLayer.GetPeopleByPersonID(PersonId);
        }

        public static int GetPeopleByNationalNo(string NationalNo)
        {
            

            
                return clsDataLayer.GetPeopleByNationalNo(NationalNo);
        }

        public bool _UpdatePeople(int PersonId)
        {
            return clsDataLayer.UpdatePeploe(PersonId,this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Gendor, this.DateOfBirth, this.Phone, this.NationalityCountryID, this.Address, this.ImagePath, this.Email);
          
        }

        public static bool DeletePeople(int PersonId)
        {
           return clsDataLayer.DeletePeople(PersonId);
        }
        public static DataTable ListPeople()
        {
            return clsDataLayer.ListPeople();
        }

        public static bool IsFound(string NationalNumber)
        {
            return clsDataLayer.IsFound(NationalNumber);
        }

        public static bool IsValidateEmail(string Email)
        {
            try
            {
                var add = new MailAddress(Email);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DataTable GetCountryName()
        {
            return clsDataLayer.GetCountryName();
        }

        public static string GetCountry(int CountryId)
        {
            return clsDataLayer.GetCountry(CountryId);
        }
        public  bool SavePepole()
        {
           
           switch(PeopleStatues)
            {
                case enPeopleAddOrUpdate.AddNewPeope:
                    if(_AddNewPeople())
                    return true;
                    else
                    return false;
                    break;
                    case enPeopleAddOrUpdate.UpdatePeople:
                    if (_UpdatePeople(this.PersonId))
                        return true;
                    else
                        return false;
                        break;
            }
            return false;

        }
    }
}
