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
    public partial class frmMangedTestTypes : Form
    {
        private int _TestTypeID = -1;
        public frmMangedTestTypes()
        {
            InitializeComponent();
        }

        private void _FillManagedTestTypes()
        {
            try
            {
                DataTable TestTypesTable = clsMangedTestTypes.GetTestTypes();
                DataView TestTypesView = TestTypesTable.DefaultView;

                // ❌ لا تمدد الصفوف حسب المحتوى
                dgvListViewMagedTestTypes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvListViewMagedTestTypes.RowTemplate.Height = 30;

                // ✔️ منع التفاف النص (يُقص إذا كان طويل)
                dgvListViewMagedTestTypes.DefaultCellStyle.WrapMode =
                    DataGridViewTriState.False;

                // ✔️ الأعمدة تملأ المساحة
                dgvListViewMagedTestTypes.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvListViewMagedTestTypes.AllowUserToAddRows = false;
                dgvListViewMagedTestTypes.ReadOnly = true;

                dgvListViewMagedTestTypes.Font =
                    new Font("Calibri", 11, FontStyle.Regular);

                dgvListViewMagedTestTypes.ColumnHeadersDefaultCellStyle.Font =
                    new Font("Calibri", 12, FontStyle.Bold);

                dgvListViewMagedTestTypes.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvListViewMagedTestTypes.ColumnHeadersDefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvListViewMagedTestTypes.DataSource = TestTypesView;
                // تأكيد أن الأعمدة تملأ المساحة
                dgvListViewMagedTestTypes.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                // تكبير عمود TestTypeDescription
                dgvListViewMagedTestTypes.Columns["TestTypeDescription"].FillWeight = 300;

            


                lbRecords.Text = TestTypesView.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void frmMangedTestTypes_Load(object sender, EventArgs e)
        {
            _FillManagedTestTypes();

        }

        private void editApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_TestTypeID != -1)
            {
                frmUpdateTestype frm = new frmUpdateTestype(_TestTypeID);
                frm.DataBack += DataBack;
                frm.ShowDialog();
            }
        }

        private void DataBack(object sender)
        {
            _FillManagedTestTypes();
        }


        private void dgvListViewMagedTestTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) { return; }
                DataGridViewRow row = dgvListViewMagedTestTypes.Rows[e.RowIndex];

                if (row.Cells["TestTypeID"].Value != null && int.TryParse(row.Cells["TestTypeID"].Value.ToString(), out int id))
                    _TestTypeID = id;

            }
            catch (Exception ex) { }
        }

        private void btnColse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListViewMagedTestTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
