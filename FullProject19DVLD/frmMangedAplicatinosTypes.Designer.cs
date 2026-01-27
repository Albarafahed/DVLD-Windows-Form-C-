namespace FullProject19DVLD
{
    partial class frmMangedAplicatinosTypes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnColse = new System.Windows.Forms.Button();
            this.dgvListViewMagedApplications = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListViewMagedApplications)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRecords
            // 
            this.lbRecords.AllowDrop = true;
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.Location = new System.Drawing.Point(148, 509);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(21, 24);
            this.lbRecords.TabIndex = 20;
            this.lbRecords.Text = "0";
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 509);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 24);
            this.label3.TabIndex = 19;
            this.label3.Text = "# Rcords:";
            // 
            // btnColse
            // 
            this.btnColse.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColse.Location = new System.Drawing.Point(765, 489);
            this.btnColse.Name = "btnColse";
            this.btnColse.Size = new System.Drawing.Size(88, 44);
            this.btnColse.TabIndex = 18;
            this.btnColse.Text = "Close";
            this.btnColse.UseVisualStyleBackColor = true;
            this.btnColse.Click += new System.EventHandler(this.btnColse_Click);
            // 
            // dgvListViewMagedApplications
            // 
            this.dgvListViewMagedApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListViewMagedApplications.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListViewMagedApplications.BackgroundColor = System.Drawing.Color.White;
            this.dgvListViewMagedApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListViewMagedApplications.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvListViewMagedApplications.Location = new System.Drawing.Point(78, 100);
            this.dgvListViewMagedApplications.Name = "dgvListViewMagedApplications";
            this.dgvListViewMagedApplications.RowHeadersWidth = 51;
            this.dgvListViewMagedApplications.RowTemplate.Height = 26;
            this.dgvListViewMagedApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListViewMagedApplications.Size = new System.Drawing.Size(718, 383);
            this.dgvListViewMagedApplications.TabIndex = 17;
            this.dgvListViewMagedApplications.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListViewMagedApplications_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(319, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 34);
            this.label1.TabIndex = 85;
            this.label1.Text = "Manged Applicatinos";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editApplicationsToolStripMenuItem});
            this.contextMenuStrip1.Margin = new System.Windows.Forms.Padding(10);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(233, 36);
            // 
            // editApplicationsToolStripMenuItem
            // 
            this.editApplicationsToolStripMenuItem.Name = "editApplicationsToolStripMenuItem";
            this.editApplicationsToolStripMenuItem.Size = new System.Drawing.Size(232, 32);
            this.editApplicationsToolStripMenuItem.Text = "Edit Applications";
            this.editApplicationsToolStripMenuItem.Click += new System.EventHandler(this.editApplicationsToolStripMenuItem_Click);
            // 
            // frmMangedAplicatinosTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 574);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnColse);
            this.Controls.Add(this.dgvListViewMagedApplications);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMangedAplicatinosTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMangedAplicatinosTypes";
            this.Load += new System.EventHandler(this.frmMangedAplicatinosTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListViewMagedApplications)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnColse;
        public System.Windows.Forms.DataGridView dgvListViewMagedApplications;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editApplicationsToolStripMenuItem;
    }
}