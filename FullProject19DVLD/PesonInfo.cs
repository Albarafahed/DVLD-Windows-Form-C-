using BussnisProject;
using FullProject19DVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace FullProject19DVLD
{
    public partial class PesonInfo : UserControl
    {
        private int _PersonID = -1;
        public PesonInfo()
        {
            InitializeComponent();
        }


        public void loadPersonInfor(int PersonId)
        {
           
            _PersonID = PersonId;
            clsPeople people = clsPeople.GetPeopleByPersonId(_PersonID);
            if (people != null)
            {

                LbPesonId.Text = _PersonID.ToString();
                lbName.Text = people.FirstName + " "+people.SecondName + " "+ people.ThirdName + " " + people.LastName;

                if (people.Gendor == 0)
                    lbGender.Text = "Male";
                else
                    lbGender.Text = "Female";
               
                lbNational.Text = people.NationalNo;
                LbEmail.Text = people.Email;
                lbAddress.Text = people.Address;
                lbPhone.Text = people.Phone;
                lbDateOfBirth.Text=people.DateOfBirth.ToString();
                lbCountry.Text=clsPeople.GetCountry(people.NationalityCountryID);
                try
                {
                    PbPesonImage.Image = Image.FromFile(people.ImagePath);
                }
                catch (Exception ex) { }

              
            }

         






        }
        private void PesonInfo_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUpdatePeople frm = new frmUpdatePeople(_PersonID);
            frm.DataBack1 += DataBack;
            frm.ShowDialog();
        }
        private void DataBack(object sender)
        {
            loadPersonInfor(_PersonID);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       

        }
    }
