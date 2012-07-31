namespace _4780_final_car_POS
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchInvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbInvoiceOptions = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.gbInvoiceForm = new System.Windows.Forms.GroupBox();
            this.dgvInvoiceItems = new System.Windows.Forms.DataGridView();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.lblInvoiceNum = new System.Windows.Forms.Label();
            this.lblInvoiceLabel = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.txtItemCost = new System.Windows.Forms.TextBox();
            this.lblItemCost = new System.Windows.Forms.Label();
            this.lblSelectItem = new System.Windows.Forms.Label();
            this.cmbxInventory = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.gbInvoiceOptions.SuspendLayout();
            this.gbInvoiceForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceItems)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchInvoicesToolStripMenuItem,
            this.editInventoryToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "&Menu";
            // 
            // searchInvoicesToolStripMenuItem
            // 
            this.searchInvoicesToolStripMenuItem.Name = "searchInvoicesToolStripMenuItem";
            this.searchInvoicesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.searchInvoicesToolStripMenuItem.Text = "&Search Invoices";
            this.searchInvoicesToolStripMenuItem.Click += new System.EventHandler(this.searchInvoicesToolStripMenuItem_Click);
            // 
            // editInventoryToolStripMenuItem
            // 
            this.editInventoryToolStripMenuItem.Name = "editInventoryToolStripMenuItem";
            this.editInventoryToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.editInventoryToolStripMenuItem.Text = "&Edit Inventory";
            this.editInventoryToolStripMenuItem.Click += new System.EventHandler(this.editInventoryToolStripMenuItem_Click);
            // 
            // gbInvoiceOptions
            // 
            this.gbInvoiceOptions.Controls.Add(this.btnDelete);
            this.gbInvoiceOptions.Controls.Add(this.btnEdit);
            this.gbInvoiceOptions.Controls.Add(this.btnCreate);
            this.gbInvoiceOptions.Location = new System.Drawing.Point(177, 46);
            this.gbInvoiceOptions.Name = "gbInvoiceOptions";
            this.gbInvoiceOptions.Size = new System.Drawing.Size(424, 100);
            this.gbInvoiceOptions.TabIndex = 1;
            this.gbInvoiceOptions.TabStop = false;
            this.gbInvoiceOptions.Text = "Invoice Options";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(314, 28);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 44);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(175, 28);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 44);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(36, 28);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 44);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // gbInvoiceForm
            // 
            this.gbInvoiceForm.Controls.Add(this.dgvInvoiceItems);
            this.gbInvoiceForm.Controls.Add(this.txtTotalCost);
            this.gbInvoiceForm.Controls.Add(this.lblTotalCost);
            this.gbInvoiceForm.Controls.Add(this.btnSave);
            this.gbInvoiceForm.Controls.Add(this.lblDate);
            this.gbInvoiceForm.Controls.Add(this.dtpInvoiceDate);
            this.gbInvoiceForm.Controls.Add(this.lblInvoiceNum);
            this.gbInvoiceForm.Controls.Add(this.lblInvoiceLabel);
            this.gbInvoiceForm.Controls.Add(this.btnAddItem);
            this.gbInvoiceForm.Controls.Add(this.txtItemCost);
            this.gbInvoiceForm.Controls.Add(this.lblItemCost);
            this.gbInvoiceForm.Controls.Add(this.lblSelectItem);
            this.gbInvoiceForm.Controls.Add(this.cmbxInventory);
            this.gbInvoiceForm.Location = new System.Drawing.Point(34, 176);
            this.gbInvoiceForm.Name = "gbInvoiceForm";
            this.gbInvoiceForm.Size = new System.Drawing.Size(708, 454);
            this.gbInvoiceForm.TabIndex = 2;
            this.gbInvoiceForm.TabStop = false;
            this.gbInvoiceForm.Text = "Invoice Form Viewer";
            // 
            // dgvInvoiceItems
            // 
            this.dgvInvoiceItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceItems.Location = new System.Drawing.Point(63, 137);
            this.dgvInvoiceItems.Name = "dgvInvoiceItems";
            this.dgvInvoiceItems.Size = new System.Drawing.Size(564, 229);
            this.dgvInvoiceItems.TabIndex = 12;
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(194, 407);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(100, 20);
            this.txtTotalCost.TabIndex = 11;
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCost.Location = new System.Drawing.Point(73, 410);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(115, 13);
            this.lblTotalCost.TabIndex = 10;
            this.lblTotalCost.Text = "Invoice Total Cost:";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(504, 395);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 43);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save Invoice";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(345, 33);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(38, 13);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Date:";
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Enabled = false;
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(417, 30);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(100, 20);
            this.dtpInvoiceDate.TabIndex = 7;
            // 
            // lblInvoiceNum
            // 
            this.lblInvoiceNum.AutoSize = true;
            this.lblInvoiceNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNum.Location = new System.Drawing.Point(134, 30);
            this.lblInvoiceNum.Name = "lblInvoiceNum";
            this.lblInvoiceNum.Size = new System.Drawing.Size(0, 16);
            this.lblInvoiceNum.TabIndex = 6;
            // 
            // lblInvoiceLabel
            // 
            this.lblInvoiceLabel.AutoSize = true;
            this.lblInvoiceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceLabel.Location = new System.Drawing.Point(61, 30);
            this.lblInvoiceLabel.Name = "lblInvoiceLabel";
            this.lblInvoiceLabel.Size = new System.Drawing.Size(74, 16);
            this.lblInvoiceLabel.TabIndex = 5;
            this.lblInvoiceLabel.Text = "Invoice #:";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Enabled = false;
            this.btnAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.Location = new System.Drawing.Point(552, 66);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 39);
            this.btnAddItem.TabIndex = 4;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // txtItemCost
            // 
            this.txtItemCost.Location = new System.Drawing.Point(417, 77);
            this.txtItemCost.Name = "txtItemCost";
            this.txtItemCost.ReadOnly = true;
            this.txtItemCost.Size = new System.Drawing.Size(100, 20);
            this.txtItemCost.TabIndex = 3;
            // 
            // lblItemCost
            // 
            this.lblItemCost.AutoSize = true;
            this.lblItemCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCost.Location = new System.Drawing.Point(345, 80);
            this.lblItemCost.Name = "lblItemCost";
            this.lblItemCost.Size = new System.Drawing.Size(64, 13);
            this.lblItemCost.TabIndex = 2;
            this.lblItemCost.Text = "Item Cost:";
            // 
            // lblSelectItem
            // 
            this.lblSelectItem.AutoSize = true;
            this.lblSelectItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectItem.Location = new System.Drawing.Point(60, 79);
            this.lblSelectItem.Name = "lblSelectItem";
            this.lblSelectItem.Size = new System.Drawing.Size(132, 13);
            this.lblSelectItem.TabIndex = 1;
            this.lblSelectItem.Text = "Select Inventory Item:";
            // 
            // cmbxInventory
            // 
            this.cmbxInventory.Enabled = false;
            this.cmbxInventory.FormattingEnabled = true;
            this.cmbxInventory.Location = new System.Drawing.Point(194, 76);
            this.cmbxInventory.Name = "cmbxInventory";
            this.cmbxInventory.Size = new System.Drawing.Size(121, 21);
            this.cmbxInventory.TabIndex = 0;
            this.cmbxInventory.SelectedIndexChanged += new System.EventHandler(this.cmbxInventory_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 642);
            this.Controls.Add(this.gbInvoiceForm);
            this.Controls.Add(this.gbInvoiceOptions);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Car Invoice System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbInvoiceOptions.ResumeLayout(false);
            this.gbInvoiceForm.ResumeLayout(false);
            this.gbInvoiceForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchInvoicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editInventoryToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbInvoiceOptions;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox gbInvoiceForm;
        private System.Windows.Forms.TextBox txtItemCost;
        private System.Windows.Forms.Label lblItemCost;
        private System.Windows.Forms.Label lblSelectItem;
        private System.Windows.Forms.ComboBox cmbxInventory;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label lblInvoiceNum;
        private System.Windows.Forms.Label lblInvoiceLabel;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvInvoiceItems;
    }
}

