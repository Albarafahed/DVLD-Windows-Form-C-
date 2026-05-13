using DVLD_Buisness;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.User
{
    public partial class frmListUser : Form
    {
        DataTable _dataUserAll;
        DataTable _dataUser;
       
        private int _UserID;
        enum _enFilterByActive { All=1,Yes=2,No=3};
        public frmListUser()
        {
            InitializeComponent();
           
            _dataUserAll=clsUsers.ListUser();
            _dataUser=_dataUserAll.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "IsActive");
        }

        private void _RefrashData()
        {
            _dataUserAll = clsUsers.ListUser();
            _dataUser = _dataUserAll.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "IsActive");
            dgvUsers.DataSource = _dataUser;
        }
        private void frmListUser_Load(object sender, EventArgs e)
        {
           dgvUsers.DataSource = _dataUser;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();

            dgvUsers.Columns[0].HeaderText = "User ID";
            dgvUsers.Columns[0].Width = 110;

            dgvUsers.Columns[1].HeaderText = "Person ID";
            dgvUsers.Columns[1].Width = 120;

            dgvUsers.Columns[2].HeaderText = "Full Name";
            dgvUsers.Columns[2].Width = 350;

            dgvUsers.Columns[3].HeaderText = "UserName";
            dgvUsers.Columns[3].Width = 120;

            dgvUsers.Columns[4].HeaderText = "Is Active";
            dgvUsers.Columns[4].Width = 120;

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text=string.Empty;
            bool isActive = (cbFilterBy.Text == "Is Active");
            bool isNone =( cbFilterBy.Text == "None");

            txtFilterValue.Visible =! (isActive ||isNone);
            cbIsActive.Visible = (isActive);
            if(txtFilterValue.Visible)
                txtFilterValue.Focus();
            else if(cbIsActive.Visible)
            {
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            else
                cbFilterBy.Focus();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;
                default:
               
                    FilterColumn = "None";
                    break;

            }
            if(FilterColumn=="None" || txtFilterValue.Text.Trim() == "")
            {
                _dataUser.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
                return;


            }
          

                if (FilterColumn == "PersonID" || FilterColumn == "UserID")
                {
                    _dataUser.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
                }
                else
                    _dataUser.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            
           
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();

        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsActive.SelectedIndex)
            {
                case 0:
                    _dataUser.DefaultView.RowFilter = "";
                    break;
                case 1:
                    _dataUser.DefaultView.RowFilter=string.Format("[{0}] = {1}", "IsActive",true); break;
                case 2:
                    _dataUser.DefaultView.RowFilter = string.Format("[{0}] = {1}", "IsActive", false); break;

            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")
                e.Handled=!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmAddUpdateUser = new frmAddUpdateUser();
            frmAddUpdateUser.ShowDialog();
            _RefrashData();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmAddUpdateUser = new frmAddUpdateUser();
            frmAddUpdateUser.ShowDialog();
            _RefrashData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _UserID=(int)dgvUsers.CurrentRow.Cells[0].Value;
            frmAddUpdateUser frmAddUpdateUser = new frmAddUpdateUser(_UserID);
            frmAddUpdateUser.ShowDialog();
            _RefrashData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDatalis frmShowUser=new frmShowUserDatalis((int)dgvUsers.CurrentRow.Cells[0].Value);
            frmShowUser.ShowDialog();
        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmchangePassword frm = new frmchangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefrashData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + dgvUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsUsers.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefrashData();
                }

                else
                    MessageBox.Show("User was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Feature is Not Implemented Yes ! ", "Not Ready !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Feature is Not Implemented Yes ! ", "Not Ready !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void frmListUser_Activated(object sender, EventArgs e)
        {
            //_RefrashData();
        }
    }
}
