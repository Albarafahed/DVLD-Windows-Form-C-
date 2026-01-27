using DataLayerProjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussnisProject
{
    public class clsLoginScreen
    {
        static public bool ChickedUserNameAndPassord(string username, string password)
        {
            return clsDataAccessLoginScreen.CheckeUseNameAndPassoredIsFound(username, password);
        }
        static public bool ChickedUserisActive(string username, string password)
        {
            return clsDataAccessLoginScreen.CheckeIsActive(username, password);
        }
    }
}
