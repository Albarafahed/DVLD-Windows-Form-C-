using BussnisProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullProject19DVLD
{
    public partial class FiltiringControl : UserControl
    {
        private int _personId = -1;
        public  int PersonId = -1;

       public event Action<int> OnePersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handeler = OnePersonSelected;
            if (handeler != null)
            {
                handeler(PersonID);
            }
        }
        public FiltiringControl()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbFiterBy.SelectedItem == null || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please select filter and enter value");
                return;
            }

            int personId = -1;
            string filter = cbFiterBy.SelectedItem.ToString();

            if (filter == "NationalNo")
            {
                personId = clsPeople.GetPeopleByNationalNo(textBox1.Text);
            }
            else if (filter == "PersonID")
            {
                if (!int.TryParse(textBox1.Text, out int id))
                {
                    MessageBox.Show("Invalid Person ID");
                    return;
                }

                personId = clsPeople.GetPeopleByPersonID(id);
            }

            if (personId > 0)
            {
                PersonId = personId;
                OnePersonSelected(PersonId);
            }
            else
            {
                MessageBox.Show("Person Not Found");
            }

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddNewPeople frm = new frmAddNewPeople();
            frm.DataBack1 += DataBack;
            frm.ShowDialog();
        }

        private void DataBack(object sender,int personId)
        {
            OnePersonSelected(personId);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbFiterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiterBy.SelectedIndex != 0)
            {
                textBox1.Visible = true;
            }
            else
                { textBox1.Visible = false; }
        }

        private void FiltiringControl_Load(object sender, EventArgs e)
        {
            cbFiterBy.SelectedIndex = 1;
        }
    }
}
