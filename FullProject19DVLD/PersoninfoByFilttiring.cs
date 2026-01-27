using BussnisProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullProject19DVLD
{
    public partial class PersoninfoByFilttiring : UserControl
    {
        public int PersonId = -1;
        public PersoninfoByFilttiring()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            
            frmAddNewPeople frm = new frmAddNewPeople();
            frm.DataBack1 += DataBack;
            frm.ShowDialog();
           

        }

        private void DataBack(object sender, int personid)
        {
            PersonId=personid;
            pesonInfo1.loadPersonInfor(PersonId);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiterBy.SelectedItem != null && cbFiterBy.SelectedItem.ToString() == "PersonID")
            {
                // السماح بالأرقام فقط + زر Backspace
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                {
                    e.Handled = true; // يمنع الإدخال
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbFiterBy.SelectedItem == "NationalNo" && !string.IsNullOrEmpty(textBox1.Text))
            {
               PersonId=clsPeople.GetPeopleByNationalNo(textBox1.Text);
                if (PersonId > 0)
                {
                    pesonInfo1.loadPersonInfor(PersonId);

                }
                else
                {
                    MessageBox.Show("Person Not Found");
                }
              
            }
            else if(cbFiterBy.SelectedItem == "PersonID" && !string.IsNullOrEmpty(textBox1.Text))
            {
               
                PersonId = clsPeople.GetPeopleByPersonID(int.Parse(textBox1.Text));
                if (PersonId>0)
                {
                    pesonInfo1.loadPersonInfor(PersonId);

                }
                else
                {
                    MessageBox.Show("Person Not Found");
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbFiterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiterBy.SelectedIndex != 0)
            {
                textBox1.Visible = true;
            }
        }

        private void pesonInfo1_Load(object sender, EventArgs e)
        {
            cbFiterBy.SelectedIndex = 1;
        }
    }
}
