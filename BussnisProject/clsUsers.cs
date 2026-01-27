using DataLayerProjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BussnisProject
{
    public class clsUsers
    {
        public enum enUserAddOrUpdate { AddNewPeope = 1, UpdatePeople = 2 };

        public int UserId { get; set; }
        public int PersonId { get; set; }


        public string FullName { get; set; }

        public string UserName { get; set; }

        public bool IsActive { get; set; }

        public string Passowrd { get; set; }


        public enUserAddOrUpdate PeopleStatues = enUserAddOrUpdate.AddNewPeope;

        public clsUsers()
        {
            UserName = string.Empty;
            FullName = string.Empty;
            PersonId = -1;
            UserId = -1;
            IsActive = false;

            PeopleStatues = enUserAddOrUpdate.AddNewPeope;


        }

        public clsUsers(int UserId, string FullName, int PersonId, string UserName, string Password, bool IsActive)
        {
            this.UserName = UserName;
            this.FullName = FullName;
            this.PersonId = PersonId;
            this.UserId = UserId;
            this.Passowrd = Password;
            this.IsActive = IsActive;
         
            PeopleStatues = enUserAddOrUpdate.UpdatePeople;


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

        public bool IsPersonIsUser(int PersonId)
        {
            return clsDataAccessUsrers.IsPersonIsUser(PersonId);
        }

        public clsUsers GetUsersById(int userId)
        {

            int UsserId = -1;
            int PersonId = -1;
            string Passowrd = "";
            string UserName = "";
            bool IsActive = false;
            if (clsDataAccessUsrers.GetUserByUserID(userId, ref PersonId, ref UserName, ref Passowrd, ref IsActive))
                {
              

                return new clsUsers(userId, "", PersonId, UserName, Passowrd, IsActive);
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

        public static bool UpdatePassword(int UserId,string Password)
        {
           return clsDataAccessUsrers.UpdatePassword(UserId, Password);
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