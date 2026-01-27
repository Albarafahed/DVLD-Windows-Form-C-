using BussnisProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullProject19DVLD
{
    public partial class frmMangedUser : Form
    {
        DataView ListUsers;
        private int _UserId = -1;
        public frmMangedUser()
        {
            InitializeComponent();
        }
        private void _GetListUser()
        {
            dgvListViewUsers.DataSource = null;
            ListUsers = clsUsers.ListUser().DefaultView;
            dgvListViewUsers.DataSource = ListUsers;
            dgvListViewUsers.AllowUserToAddRows = false;
            lbRecords.Text = ListUsers.Count.ToString();
            cbFiterBy.Items.Clear();
            cbFiterBy.Items.Add("No");
            foreach (DataGridViewColumn data in dgvListViewUsers.Columns)
            {
                cbFiterBy.Items.Add(data.Name);
            }
            cbFiterBy.SelectedIndex = cbFiterBy.FindString("No");
            dgvListViewUsers.DefaultCellStyle.Font = new Font("Segoe UI", 10,FontStyle.Bold);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmMangedUser_Load(object sender, EventArgs e)
        {
            _GetListUser();
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                string selectedItem = cbFiterBy.SelectedItem.ToString();
                string result = textBox1.Text.Trim();

                if (selectedItem == "PersonID" ||selectedItem=="UserID")
                    ListUsers.RowFilter = $"{selectedItem} ={int.Parse(result)} ";
                else
                    ListUsers.RowFilter = $"{selectedItem} LIKE '%{result}%'";
                 dgvListViewUsers.DataSource = ListUsers;


            }
            else
                ListUsers.RowFilter = "";

            lbRecords.Text = ListUsers.Count.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFiterBy.SelectedItem != null && (cbFiterBy.SelectedItem.ToString() == "PersonID"|| cbFiterBy.SelectedItem.ToString() == "UserID"))
            {
                // السماح بالأرقام فقط + زر Backspace
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                {
                    e.Handled = true; // يمنع الإدخال
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddNewUsers frm = new frmAddNewUsers();
            frm.DataBack += DataBack;
            frm.ShowDialog();
        }

        private void DataBack(object sender)
        {
            _GetListUser();
        }

        private void cbFiterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFiterBy.SelectedIndex != 0)
            {
                textBox1.Visible = true;
            }
            else {
                textBox1.Visible = false;
            }

            if (cbFiterBy.SelectedIndex == cbFiterBy.FindString("IsActive"))
            {
                comboBox1.Visible = true;
                textBox1.Visible=false;
                comboBox1.SelectedIndex = 0;
            }
            else
                comboBox1.Visible= false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                ListUsers.RowFilter = "";

            else if (comboBox1.SelectedIndex == 1)
                ListUsers.RowFilter = "IsActive=true";
            else if (comboBox1.SelectedIndex == 2)
            {
                ListUsers.RowFilter = "IsActive=false";
            }
            else
                ListUsers.RowFilter = ""; ;
            dgvListViewUsers.DataSource = ListUsers;

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUsers frm = new frmAddNewUsers();
            frm.DataBack += DataBack;
            frm.ShowDialog();
        }

        private void dgvListViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvListViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) { return; }
                DataGridViewRow row = dgvListViewUsers.Rows[e.RowIndex];

                if (row.Cells["UserID"].Value != null && int.TryParse(row.Cells["UserID"].Value.ToString(), out int id))
                    _UserId = id;

            }
            catch (Exception ex) { }
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_UserId != -1)
            {
                frmUpdateUser frm = new frmUpdateUser(_UserId);
                frm.DataBack += DataBacks;
                frm.ShowDialog();
            }
          
        

        }
        private void DataBacks(object data)
        {
            _GetListUser();
        }

        private void sendPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_UserId != -1)
            {
                frmChangePassword frm = new frmChangePassword(_UserId);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Please Selected Item");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure ?", "Deleted", MessageBoxButtons.OKCancel) == DialogResult.OK)
                if (clsUsers.DeleteUser(_UserId))
                {

                    MessageBox.Show("SuceesFully");
                    _GetListUser();
                }
                else
                    MessageBox.Show("Faild");
        }

        private void showDatelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_UserId != -1)
            {
                frmShowUserDatalis frm=new frmShowUserDatalis(_UserId);
                frm.ShowDialog();

            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Feature is Not Implemented Yes ! ", "Not Ready !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void sendPhoneToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Feature is Not Implemented Yes ! ", "Not Ready !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
