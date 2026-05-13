using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsUsers
    {
        public enum enUserAddOrUpdate { AddNewPeope = 1, UpdatePeople = 2 };

        public int UserId { get; set; }
        public int PersonId { get; set; }


        public string FullName { get 
            { 
            return clsPerson.Find(this.PersonId).FullName;
            } 
        }

        public string UserName { get; set; }

        public bool IsActive { get; set; }

        public string Passowrd { get; set; }


        public enUserAddOrUpdate PeopleStatues = enUserAddOrUpdate.AddNewPeope;

        public clsUsers()
        {
            UserName = string.Empty;
            PersonId = -1;
            UserId = -1;
            IsActive = false;

            PeopleStatues = enUserAddOrUpdate.AddNewPeope;


        }

        public clsUsers(int UserId, int PersonId, string UserName, string Password, bool IsActive)
        {
            this.UserName = UserName;
            this.PersonId = PersonId;
            this.UserId = UserId;
            this.Passowrd = Password;
            this.IsActive = IsActive;
         
            PeopleStatues = enUserAddOrUpdate.UpdatePeople;


        }

        public static clsUsers FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;

            bool IsActive = false;

            bool IsFound = clsDataAccessUsrers.GetUserInfoByUsernameAndPassword
                                (UserName, Password, ref UserID, ref PersonID, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUsers(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        private bool _AddNewUser()
        {
            this.UserId = clsDataAccessUsrers.SaveUser(this.PersonId, this.UserName, this.Passowrd, this.IsActive);
            return PersonId > 0;
        }

        private bool _UpdateUser()
        {
            return clsDataAccessUsrers.UpdateUser(this.UserId,this.PersonId, this.UserName, this.Passowrd, this.IsActive?1:0);
        }

        public static bool IsPersonIsUser(int PersonId)
        {
            return clsDataAccessUsrers.IsPersonIsUser(PersonId);
        }

        public static bool isUserExist(string UserName)
        {
            return clsDataAccessUsrers.IsUserExist(UserName);
        }

        public static clsUsers Find(int userId)
        {

         
            int PersonId = -1;
            string Passowrd = "";
            string UserName = "";
            bool IsActive = false;
            if (clsDataAccessUsrers.GetUserByUserID(userId, ref PersonId, ref UserName, ref Passowrd, ref IsActive))
                {
              

                return new clsUsers(userId, PersonId, UserName, Passowrd, IsActive);
            }
            else
                return null; 
                            
            
        }

        public static clsUsers FindByPersonID(int PersonID)
        {


            int userId = -1;
            string Passowrd = "";
            string UserName = "";
            bool IsActive = false;
            if (clsDataAccessUsrers.GetUserByPersonID(PersonID, ref userId, ref UserName, ref Passowrd, ref IsActive))
            {


                return new clsUsers(userId, PersonID, UserName, Passowrd, IsActive);
            }
            else
                return null;


        }
        public static clsUsers Find(string UserName)
        {


            int PersonId = -1;
            string Passowrd = "";
            int userId = -1;
            bool IsActive = false;
            if (clsDataAccessUsrers.GetUserByUserName(UserName, ref PersonId, ref userId, ref Passowrd, ref IsActive))
            {


                return new clsUsers(userId, PersonId, UserName, Passowrd, IsActive);
            }
            else
                return null;


        }

        public static int GetIDUserByUserName(string UserName)
        {
            int UserID = -1;
            
            if (clsDataAccessUsrers.GetIDUserByUserName(UserName, ref UserID))
            {


                return UserID;
            }
            else
                return UserID;


        }

       
        public static DataTable ListUser()
        {
            return clsDataAccessUsrers.ListUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return clsDataAccessUsrers.DeleteUser(UserID);
        }

      
        public bool SaveUser()
        {

            switch (PeopleStatues)
            {
                case enUserAddOrUpdate.AddNewPeope:
                    if (_AddNewUser())
                        return true;
                    else
                        return false;
                  
                case enUserAddOrUpdate.UpdatePeople:
                    if (_UpdateUser())
                        return true;
                    else

                        return false;
                   
            }
            return false;

            
        }
    }
}