namespace _4780_final_car_POS
{
    partial class frmSearch
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.InvoiceDataGridView = new System.Windows.Forms.DataGridView();
			this.cmbInvoiceNumber = new System.Windows.Forms.ComboBox();
			this.lblInvoiceNumber = new System.Windows.Forms.Label();
			this.lblInvoiceDate = new System.Windows.Forms.Label();
			this.cmbInvoiceDate = new System.Windows.Forms.ComboBox();
			this.lblTotalCost = new System.Windows.Forms.Label();
			this.cmbTotalCost = new System.Windows.Forms.ComboBox();
			this.lblFilters = new System.Windows.Forms.Label();
			this.btnClearFilters = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(683, 389);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(85, 23);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// InvoiceDataGridView
			// 
			this.InvoiceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.InvoiceDataGridView.Location = new System.Drawing.Point(56, 72);
			this.InvoiceDataGridView.Name = "InvoiceDataGridView";
			this.InvoiceDataGridView.Size = new System.Drawing.Size(683, 294);
			this.InvoiceDataGridView.TabIndex = 1;
			this.InvoiceDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InvoiceDataGridView_CellClick);
			// 
			// cmbInvoiceNumber
			// 
			this.cmbInvoiceNumber.FormattingEnabled = true;
			this.cmbInvoiceNumber.Location = new System.Drawing.Point(116, 35);
			this.cmbInvoiceNumber.Name = "cmbInvoiceNumber";
			this.cmbInvoiceNumber.Size = new System.Drawing.Size(121, 21);
			this.cmbInvoiceNumber.TabIndex = 2;
			this.cmbInvoiceNumber.SelectedIndexChanged += new System.EventHandler(this.cmbInvoiceNumber_SelectedIndexChanged);
			// 
			// lblInvoiceNumber
			// 
			this.lblInvoiceNumber.AutoSize = true;
			this.lblInvoiceNumber.Location = new System.Drawing.Point(113, 19);
			this.lblInvoiceNumber.Name = "lblInvoiceNumber";
			this.lblInvoiceNumber.Size = new System.Drawing.Size(85, 13);
			this.lblInvoiceNumber.TabIndex = 3;
			this.lblInvoiceNumber.Text = "Invoice Number:";
			// 
			// lblInvoiceDate
			// 
			this.lblInvoiceDate.AutoSize = true;
			this.lblInvoiceDate.Location = new System.Drawing.Point(294, 19);
			this.lblInvoiceDate.Name = "lblInvoiceDate";
			this.lblInvoiceDate.Size = new System.Drawing.Size(71, 13);
			this.lblInvoiceDate.TabIndex = 5;
			this.lblInvoiceDate.Text = "Invoice Date:";
			// 
			// cmbInvoiceDate
			// 
			this.cmbInvoiceDate.FormattingEnabled = true;
			this.cmbInvoiceDate.Location = new System.Drawing.Point(297, 35);
			this.cmbInvoiceDate.Name = "cmbInvoiceDate";
			this.cmbInvoiceDate.Size = new System.Drawing.Size(121, 21);
			this.cmbInvoiceDate.TabIndex = 4;
			this.cmbInvoiceDate.SelectedIndexChanged += new System.EventHandler(this.cmbInvoiceDate_SelectedIndexChanged);
			// 
			// lblTotalCost
			// 
			this.lblTotalCost.AutoSize = true;
			this.lblTotalCost.Location = new System.Drawing.Point(486, 19);
			this.lblTotalCost.Name = "lblTotalCost";
			this.lblTotalCost.Size = new System.Drawing.Size(69, 13);
			this.lblTotalCost.TabIndex = 7;
			this.lblTotalCost.Text = "Invoice Cost:";
			// 
			// cmbTotalCost
			// 
			this.cmbTotalCost.FormattingEnabled = true;
			this.cmbTotalCost.Location = new System.Drawing.Point(489, 35);
			this.cmbTotalCost.Name = "cmbTotalCost";
			this.cmbTotalCost.Size = new System.Drawing.Size(121, 21);
			this.cmbTotalCost.TabIndex = 6;
			this.cmbTotalCost.SelectedIndexChanged += new System.EventHandler(this.cmbTotalCost_SelectedIndexChanged);
			// 
			// lblFilters
			// 
			this.lblFilters.AutoSize = true;
			this.lblFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFilters.Location = new System.Drawing.Point(25, 11);
			this.lblFilters.Name = "lblFilters";
			this.lblFilters.Size = new System.Drawing.Size(65, 24);
			this.lblFilters.TabIndex = 8;
			this.lblFilters.Text = "Filters:";
			// 
			// btnClearFilters
			// 
			this.btnClearFilters.Location = new System.Drawing.Point(645, 26);
			this.btnClearFilters.Name = "btnClearFilters";
			this.btnClearFilters.Size = new System.Drawing.Size(94, 37);
			this.btnClearFilters.TabIndex = 9;
			this.btnClearFilters.Text = "Clear Filters";
			this.btnClearFilters.UseVisualStyleBackColor = true;
			this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
			// 
			// frmSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 424);
			this.Controls.Add(this.btnClearFilters);
			this.Controls.Add(this.lblFilters);
			this.Controls.Add(this.lblTotalCost);
			this.Controls.Add(this.cmbTotalCost);
			this.Controls.Add(this.lblInvoiceDate);
			this.Controls.Add(this.cmbInvoiceDate);
			this.Controls.Add(this.lblInvoiceNumber);
			this.Controls.Add(this.cmbInvoiceNumber);
			this.Controls.Add(this.InvoiceDataGridView);
			this.Controls.Add(this.btnCancel);
			this.Name = "frmSearch";
			this.Text = "Search Invoices";
			((System.ComponentModel.ISupportInitialize)(this.InvoiceDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
	   private System.Windows.Forms.DataGridView InvoiceDataGridView;
	   private System.Windows.Forms.ComboBox cmbInvoiceNumber;
	   private System.Windows.Forms.Label lblInvoiceNumber;
	   private System.Windows.Forms.Label lblInvoiceDate;
	   private System.Windows.Forms.ComboBox cmbInvoiceDate;
	   private System.Windows.Forms.Label lblTotalCost;
	   private System.Windows.Forms.ComboBox cmbTotalCost;
	   private System.Windows.Forms.Label lblFilters;
	   private System.Windows.Forms.Button btnClearFilters;
    }
}