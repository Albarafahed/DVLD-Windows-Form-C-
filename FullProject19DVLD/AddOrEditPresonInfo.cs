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

namespace FullProject19DVLD
{
    public partial class AddOrEditPresonInfo : UserControl
    {
       private  string _ImageName = "";

        public  int personId = -1;
        public AddOrEditPresonInfo()
        {
            InitializeComponent();
            Statues = enUpdateOrAdd.Add;
        }

        public AddOrEditPresonInfo(int personId)
        {
            InitializeComponent();
            Statues = enUpdateOrAdd.Update;
          
            this.personId = personId;
          
        }

        public enum enUpdateOrAdd { Update=0, Add=1};
        public enUpdateOrAdd Statues=enUpdateOrAdd.Update;

        private void _ChingeImageToCheckedGeder()
        {
            if (rdbFemale.Checked)
            {
                pbImage.Image = Resources.كمبيوتر_صديق_خدع_بصرية__1_;
            }
            else
                pbImage.Image = Resources.كمبيوتر_صديق_خدع_بصرية__7_;

        }


        public void loadPersonInfor(int PersonId)
        {
            Statues = enUpdateOrAdd.Update;
            personId=PersonId;
            clsPeople people = clsPeople.GetPeopleByPersonId(personId);
            if (people != null)
            {

                lbPersonId.Text = personId.ToString();
                txbFirstName.Text = people.FirstName;
                txbSecondName.Text = people.SecondName;
                txbThirdName.Text = people.ThirdName;
                txbLastName.Text = people.LastName;
                if (people.Gendor == 0)
                    rdbMale.Checked = true;
                else
                    rdbFemale.Checked = true;
                txbNathonal.Text = people.NationalNo;
                txbEmali.Text = people.Email;
                txbAddress.Text = people.Address;
                txbPhoneN.Text = people.Phone;

               // dtpDateOfBirth.Value = people.DateOfBirth;
                cmbCountry.SelectedIndex = people.NationalityCountryID-1;
                _ImageName = people.ImagePath;
                try
                {
                    pbImage.Image = Image.FromFile(_ImageName);
                }
                catch (Exception ex) { MessageBox.Show("Image is Not Found"); }
                }
                

            linkLabel1.Visible = true;






        }

        private void _AddNewPeople()
        {
            clsPeople people = new clsPeople();
            people.NationalNo = txbNathonal.Text;
            people.FirstName = txbFirstName.Text;
            people.SecondName = txbSecondName.Text;
            people.ThirdName = txbThirdName.Text;
            people.LastName = txbLastName.Text;
            people.Address = txbAddress.Text;
            people.Phone = txbPhoneN.Text;
            if (txbEmali.Text == "")
                people.Email = "";
            else
                people.Email = txbEmali.Text;

            people.DateOfBirth = dtpDateOfBirth.Value;

            people.ImagePath = _ImageName;

            people.NationalityCountryID = cmbCountry.SelectedIndex + 1;

            if (rdbMale.Checked)
                people.Gendor = 0;
            else
                people.Gendor = 1;

            if (people.SavePepole())
            {
                MessageBox.Show("Save Is SuccessFully");

                personId = people.PersonId;
               lbPersonId.Text = personId.ToString();
            }
            else
            {
                MessageBox.Show("Save Is Faild");
            }
        }

        private void _UpdatePeople()
        {
            int gender=rdbFemale.Checked ? 1 : 0;
            int NationalityCountryID=cmbCountry.SelectedIndex + 1;
            clsPeople people = new clsPeople(int.Parse(lbPersonId.Text),txbNathonal.Text, txbFirstName.Text, txbSecondName.Text, txbThirdName.Text, txbLastName.Text,
                           gender, dtpDateOfBirth.Value,txbPhoneN.Text, NationalityCountryID, txbAddress.Text,
                           _ImageName, txbEmali.Text);

            if (people.SavePepole())
            {
                MessageBox.Show("The Update SuccessFully");
            }
            else
                MessageBox.Show("the Update Faildy");
        }
        

    
        private void txbFirstName_Validating(object sender, CancelEventArgs e)
        {
        
            if (string.IsNullOrWhiteSpace(txbFirstName.Text))
            {
                e.Cancel = true;
                txbFirstName.Focus();
                errorProvider1.SetError(txbFirstName, "First Name Should Have A value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txbFirstName, "");
            }
        }

        private void txbSecondName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbSecondName.Text))
            {
                e.Cancel = true;
                txbSecondName.Focus();
                errorProvider1.SetError(txbSecondName, "First Name Should Have A value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txbSecondName, "");
            }
        }

        private void txbThirdName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbThirdName.Text))
            {
                e.Cancel = true;
                txbThirdName.Focus();
                errorProvider1.SetError(txbThirdName, "First Name Should Have A value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txbThirdName, "");
            }
        }

        private void txbLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbLastName.Text))
            {
                e.Cancel = true;
                txbLastName.Focus();
                errorProvider1.SetError(txbLastName, "First Name Should Have A value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txbLastName, "");
            }
        }

     

        private void txbPhoneN_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbPhoneN.Text))
            {
                e.Cancel = true;
                txbPhoneN.Focus();
                errorProvider1.SetError(txbPhoneN, "Requerd The Text OfPhone");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txbPhoneN, "");
            }
        }

        private void txbNathonal_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txbNathonal.Text) || clsPeople.IsFound(txbNathonal.Text))
            {
                e.Cancel = true;
                txbNathonal.Focus();
                errorProvider1.SetError(txbNathonal, "Is Found");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txbNathonal, "");
            }
        }

        private void txbEmali_Validating(object sender, CancelEventArgs e)
        {
            if (!clsPeople.IsValidateEmail(txbEmali.Text) && !string.IsNullOrEmpty(txbEmali.Text))
            {
                e.Cancel = true;
                txbEmali.Focus();
                errorProvider1.SetError(txbEmali, "Syntax of Email Is Validate");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txbEmali, "");
            }
        }

        private void txbAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbAddress.Text))
            {
                e.Cancel = true;
                txbAddress.Focus();
                errorProvider1.SetError(txbAddress, "Adrees Should Have A value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txbAddress, "");
            }
        }

      
        private void _Fill()
        {
            
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.ValueMember = "CountryName";
            cmbCountry.DataSource = clsPeople.GetCountryName().DefaultView;
            cmbCountry.SelectedIndex = cmbCountry.FindStringExact("Yemen");

            DateTime Today = DateTime.Today.AddYears(-18);
            dtpDateOfBirth.MaxDate= Today;

           

            if (_ImageName == "")
            {
                linkLabel1.Visible = false;
               
            }
        }

        private void AddOrEditPresonInfo_Load(object sender, EventArgs e)
        {
           _Fill();
            cmbCountry.SelectedItem = "Jordan";
        }

        private void lbSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd=new OpenFileDialog();
            ofd.Filter = "Image Files | *.jpg;*.jpeg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string sourcePath = ofd.FileName;
                    string extention=Path.GetExtension(sourcePath).ToLower();
                    //if(!(extention=="jpg" || extention=="jpeg" || extention=="png" || extention=="gif"))
                    //{
                    //    MessageBox.Show("Invalide Image Format");
                    //    return;
                    //
                    FileInfo fileInfo = new FileInfo(sourcePath);
                    if (fileInfo.Length > 5 * 1024 * 1024) 
                    {
                        MessageBox.Show("Image Size is too Large");
                        return;
                    }

                    string fileName = Guid.NewGuid().ToString() + extention;
                    string targeFolder = @"c:\CDVLD-People-Images";

                    if(!Directory.Exists(targeFolder))
                        Directory.CreateDirectory(targeFolder);

                    string targepath=Path.Combine(targeFolder, fileName);
                    File.Copy(sourcePath, targepath,true);
                   _ImageName = targepath;
                    pbImage.Image=Image.FromFile(ofd.FileName);
                    MessageBox.Show("Success Fully an image");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
                if (_ImageName == "")
                {
                    linkLabel1.Visible = false;

                }
                else
                {
                    linkLabel1.Visible = true;
                }


            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(cmbCountry.SelectedIndex == -1 || txbFirstName.Text == "" || txbSecondName.Text == "" && txbThirdName.Text == "" || txbLastName.Text == ""
                     || txbNathonal.Text == "" || txbAddress.Text == "" || txbPhoneN.Text == ""))
            {
               
                switch(Statues)
                {
                    case enUpdateOrAdd.Add:
                        _AddNewPeople();
                        break;
                    case enUpdateOrAdd.Update:
                        _UpdatePeople();
                        break;
                }

            }
            else
            {
                MessageBox.Show("Name Or National Number Or Phone Is Empty");
            }
        }

        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {
            _ChingeImageToCheckedGeder();
        }

        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {
            _ChingeImageToCheckedGeder();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_ImageName=="")
            {
                linkLabel1.Visible = false;
                return;
            }
            if(pbImage.Image != null)
            {
                pbImage.Image.Dispose();
                pbImage.Image= null;
            }
            ;
            File.Delete(_ImageName);
            _ChingeImageToCheckedGeder();
            linkLabel1.Visible = false;
            _ChingeImageToCheckedGeder();
        }

        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txbPhoneN_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                // السماح بالأرقام فقط + زر Backspace
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // يمنع الإدخال
                }
            
        }
    }
}
