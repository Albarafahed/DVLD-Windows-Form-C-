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
    public partial class frmMangedAplicatinosTypes : Form
    {
        private int _ApplicationTypeID = -1;

       
        public frmMangedAplicatinosTypes()
        {
            InitializeComponent();
        }

        private void _FillManagedApplications()
        {
            try
            {
                DataTable applicationsTable =
                    clsMangedApplications.GetApplicationTypes();

                DataView applicationsView = applicationsTable.DefaultView;
                dgvListViewMagedApplications.AllowUserToAddRows = false;
                dgvListViewMagedApplications.ReadOnly = true;
                dgvListViewMagedApplications.Font = new Font("Calibri", 11, FontStyle.Regular);
                dgvListViewMagedApplications.ColumnHeadersDefaultCellStyle.Font =
                    new Font("Calibri", 12, FontStyle.Bold);
                dgvListViewMagedApplications.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                dgvListViewMagedApplications.ColumnHeadersDefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                dgvListViewMagedApplications.DataSource = applicationsView;

                lbRecords.Text = applicationsView.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmMangedAplicatinosTypes_Load(object sender, EventArgs e)
        {

            _FillManagedApplications();
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void dgvListViewMagedApplications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) { return; }
                DataGridViewRow row = dgvListViewMagedApplications.Rows[e.RowIndex];

                if (row.Cells["ApplicationTypeID"].Value != null && int.TryParse(row.Cells["ApplicationTypeID"].Value.ToString(), out int id))
                    _ApplicationTypeID = id;

            }
            catch (Exception ex) { }
        }

        private void editApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_ApplicationTypeID!=-1)
            {
                frmEditApplicationTypes frm=new frmEditApplicationTypes(_ApplicationTypeID);
                frm.DataBack += DataBack;
                frm.ShowDialog();
            }
        }

        private void DataBack(object sender)
        {
            _FillManagedApplications();
        }
    }
}
