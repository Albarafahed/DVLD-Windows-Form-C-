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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BussnisProject;
using System.Linq.Expressions;
namespace FullProject19DVLD
{
    public partial class frmMangedPeople : Form
    {
        DataView listPeople;
        private int _personId = -1;
        public frmMangedPeople()
        {
            InitializeComponent();
        }
        private void _GetListPeploe()
        {
           
            listPeople = clsPeople.ListPeople().DefaultView;
            dgvListViewPeople.AllowUserToAddRows = false;
            dgvListViewPeople.DataSource = listPeople;

            lbRecords.Text = listPeople.Count.ToString();
            cbFiterBy.Items.Clear();
            cbFiterBy.Items.Add("No");
            foreach (DataGridViewColumn data in dgvListViewPeople.Columns)
            {
                cbFiterBy.Items.Add(data.Name);
            }
            cbFiterBy.SelectedIndex = cbFiterBy.FindString("No");
            dgvListViewPeople.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private void frmMangedPeople_Load(object sender, EventArgs e)
        {
            _GetListPeploe();

        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddNewPeople frm = new frmAddNewPeople();
            frm.DataBack += DatatBak;
            frm.ShowDialog();
        }

        private void DatatBak(object sender)
        {
            // Handle the data received from Form2
            _GetListPeploe();


        }

       
        private void dgvListViewPeople_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) { return; }
                DataGridViewRow row = dgvListViewPeople.Rows[e.RowIndex];

                if (row.Cells["PersonID"].Value!=null && int.TryParse(row.Cells["PersonID"].Value.ToString(),out int id))
                   _personId =id;

            }
            catch (Exception ex) { }
           }
        

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewPeople frm = new frmAddNewPeople();
            frm.DataBack += DatatBak;
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_personId != -1)
            {


                if (MessageBox.Show("Are You Sure", "Deleted", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    if (clsPeople.DeletePeople(_personId))
                    {
                        MessageBox.Show("Success Fully");
                        _GetListPeploe();
                    }

                    else
                        MessageBox.Show("Faild");
            }

        }

        private void cbFiterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiterBy.SelectedIndex == cbFiterBy.FindString("No"))
            { textBox1.Visible = false;
            cbFiterBy.Focus();
            }
            else
            {
                textBox1.Visible = true;
               textBox1.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                string selectedItem = cbFiterBy.SelectedItem.ToString();
                string result = textBox1.Text.Trim();

                if (selectedItem == "PersonID")
                    listPeople.RowFilter = $"{selectedItem} ={int.Parse(result)} ";
                else
                    listPeople.RowFilter = $"{selectedItem} LIKE '%{result}%'";
                dgvListViewPeople.DataSource = listPeople;

             
            }
            else
                listPeople.RowFilter = "";

            lbRecords.Text = listPeople.Count.ToString();
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

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_personId != -1)
            {
                frmUpdatePeople frm = new frmUpdatePeople(_personId);
                frm.DataBack += DatatBak;
                frm.ShowDialog();
            }
        }

        private void showDatelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_personId != -1)
            {
                frmShowPersonDatalis frm=new frmShowPersonDatalis(_personId);
                frm.ShowDialog();
            }
        }

        private void sendPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Feature is Not Implemented Yes ! ","Not Ready !",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void sendPhoneToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Feature is Not Implemented Yes ! ", "Not Ready !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

}
