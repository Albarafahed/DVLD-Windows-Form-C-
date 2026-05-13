using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        private int _PersonId = -1;

        public event Action<int> OnPersonSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }
        public int PersonId {get { return ctrlPersonCard1.PersonID; } }
        public short FilterEnabled { set { gbFilters.Enabled = value == 0; } }
       
        private void _FindNow()
        {

            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    ctrlPersonCard1.LoadPersonInfo(int.Parse(txtFilterValue.Text.Trim()));

                    break;

                case "National No.":
                    ctrlPersonCard1.LoadPersonInfo(txtFilterValue.Text);
                    break;

                default:
                    break;
            }

            if (OnPersonSelected != null && gbFilters.Enabled)
                // Raise the event with a parameter
                OnPersonSelected(ctrlPersonCard1.PersonID);
        }

        public void LoadPersonInfo(int PersonID)
        {
            _PersonId = PersonID;
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text=_PersonId.ToString();
          
            ctrlPersonCard1.LoadPersonInfo(_PersonId);

        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtFilterValue.Text))
            {
                MessageBox.Show("Text Box Is Empty", "Error", MessageBoxButtons.OK);
                return;
            }
            _FindNow();




        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        public void FiltterFocuse()
        {
            txtFilterValue.Focus();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson();
            frmAddUpdatePerson.DataBack += DataBackPerson;
            frmAddUpdatePerson.ShowDialog();
        }

        private void DataBackPerson(object sender, int PersonID)
        {
       
           
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            _FindNow();
        }

        public void ResetPersonInfo()
        {
            ctrlPersonCard1.ResetPersonInfo();
        }
    }
}
