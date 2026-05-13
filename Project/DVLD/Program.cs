using DVLD.Applications.Local_Driving_License;
using DVLD.People;
using DVLD.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new frmLoginScreen());
            //Application.Run(new frmAddUpdateLocalDrivingLicesnseApplication());

        }
    }
}
