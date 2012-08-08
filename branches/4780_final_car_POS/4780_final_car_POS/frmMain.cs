using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace _4780_final_car_POS
{
    public partial class frmMain : Form
    {
        #region Variables

        /// <summary>
        /// Represents the create, update, or delete Item Inventory form
        /// </summary>
        frmInventory frmInventoryWindow;
        /// <summary>
        /// Represents the Search Invoices form
        /// </summary>
        frmSearch frmSearchWindow;
        /// <summary>
        /// Validates inputs and handles errors.
        /// </summary>
        dataValidator dv = new dataValidator();
        /// <summary>
        /// Represents the data sent back from the database from queries.
        /// </summary>
        DataSet ds;
        /// <summary>
        /// Represents whether the user is creating an invoice or not.
        /// </summary>
        bool isCreate = false;
        /// <summary>
        /// Represents whether the user is editing an invoice or not.
        /// </summary>
        bool isEdit = false;
        /// <summary>
        /// Represents whether a database call returns successful or not.
        /// </summary>
        bool result = false;
        /// <summary>
        /// Represents the current invoice key number showing. 
        /// </summary>
        long invoiceKey;
        /// <summary>
        /// Represents the calculated total cost for the invoice.
        /// </summary>
        decimal totalCost = 0;
        /// <summary>
        /// Represents a newly created invoice's items, or read-only editable/delete worthy invoice's items.  Used to populate a data grid viewer.
        /// </summary>
        BindingList<Car> invoiceCars = new BindingList<Car>();
        /// <summary>
        /// Represents a newly created invoice, or a read-only editable/delete worthy invoice.  Used to populate the invoice form fields.
        /// </summary>
        BindingList<Invoice> invoice = new BindingList<Invoice>();
        /// <summary>
        /// Represents the list of invoice items added to a given invoice
        /// </summary>
        List<Car> invoiceItems = new List<Car>();
        /// <summary>
        /// Represents the current selected date and time for the created invoice.
        /// </summary>
        string selectedDateTime = "";

        #endregion

        #region Form Constructor/Initializer
        /// <summary>
        /// Initializes this form window, sets up the initial columns and Data Grid definitions and attributes
        /// </summary>
        public frmMain()
        {
            try
            {
                InitializeComponent();

                //Initialize the Data Grid View and create it's view definition

                //Create 4 columns to be displayed in the DataGridView
                DataGridViewTextBoxColumn Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                DataGridViewButtonColumn Column6 = new System.Windows.Forms.DataGridViewButtonColumn();

                //Set the properties of the columns.
                //Note the property "DataPropertyName".  
                //The value of this property corresponds to the name of the property in the class Employee.  
                //This binds this column to that field in the class.

                Column1.DataPropertyName = "vin";
                Column1.HeaderText = "VIN #";
                Column1.Name = "VIN";
                Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;

                Column2.DataPropertyName = "year";
                Column2.HeaderText = "Year";
                Column2.Name = "Year";
                Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;

                Column3.DataPropertyName = "model";
                Column3.HeaderText = "Model";
                Column3.Name = "Model";
                Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;

                Column4.DataPropertyName = "price";
                Column4.HeaderText = "Cost";
                Column4.Name = "Cost";
                Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;

                Column5.DataPropertyName = "description";
                Column5.HeaderText = "Description";
                Column5.Name = "Description";
                Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;

                Column6.HeaderText = "Delete Invoice Item";
                Column6.Name = "DeleteInvoiceItem";
                Column6.Text = "Delete";
                Column6.UseColumnTextForButtonValue = true;
                Column6.Width = 200;

                //Add the columns to the DataGridView
                dgvInvoiceItems.Columns.Add(Column1);
                dgvInvoiceItems.Columns.Add(Column2);
                dgvInvoiceItems.Columns.Add(Column3);
                dgvInvoiceItems.Columns.Add(Column4);
                dgvInvoiceItems.Columns.Add(Column5);
                dgvInvoiceItems.Columns.Add(Column6);

                //Don't generate columns automatically
                dgvInvoiceItems.AutoGenerateColumns = false;

                //disable the grid
                dgvInvoiceItems.Enabled = false;

                //Populate the sales person and customer drop downs
                ds = DataControl.getSalesPersons();

                cmbxSalePerson.DisplayMember = "SalesName";
                cmbxSalePerson.ValueMember = "SalesmanKey";
                cmbxSalePerson.DataSource = ds.Tables[0];

                ds = DataControl.getCustomers();

                cmbxCustomer.DisplayMember = "CustomerName";
                cmbxCustomer.ValueMember = "CustomerKey";
                cmbxCustomer.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                dv.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion

        #region Invoice Data Grid Controls
        /// <summary>
        /// Method handles when a cell has had a click acted upon it.
        /// If delete button has been clicked, the selected invoice item 
        /// row will be removed from the data grid view.
        /// Also the running total cost for the invoice will be decremented.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvInvoiceItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //check to see if a valid row was clicked and not the table headers
                if (e.RowIndex > -1)
                {
                    //Extract the invoice item that corresponds to the row that was clicked
                    Car invoiceItem = (Car)dgvInvoiceItems.Rows[e.RowIndex].DataBoundItem;

                    //Make sure there is a car invoice item
                    if (invoiceItem != null)
                    {
                        //Determine if the "Delete" button was clicked
                        if (e.ColumnIndex == dgvInvoiceItems.Columns["DeleteInvoiceItem"].Index)
                        {
                            //if our total cost isn't o or negative, decrement it.
                            if (totalCost > 0)
                            {
                                //decrement the total cost by subtracting the deleted invoice item's price
                                totalCost -= invoiceItem.price;
                                txtTotalCost.Text = totalCost.ToString();
                            }
                            //Remove the invoice item from the bound invoice list and in the data grid view
                            invoiceCars.Remove(invoiceItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dv.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion

        #region Menu Select
        /// <summary>
        /// Method handles the selection of Search Invoices from the the Menu drop down.
        /// Hides the main screen and opens up a new Search Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchInvoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                frmSearchWindow = new frmSearch();
                frmSearchWindow.ShowDialog();
                this.Show();

                //Populate the invoice fields with the given invoice selected, if there was an invoice selected.
                if (frmSearchWindow.PassedInvoiceKey != 0)
                {
                    invoice = DataControl.getInvoiceByIDNoNames(frmSearchWindow.PassedInvoiceKey);
                    cmbxSalePerson.SelectedValue = invoice.ElementAt(0).SalesPersonName;
                    cmbxCustomer.SelectedValue = invoice.ElementAt(0).CustomerName;
                    lblInvoiceNum.Text = invoice.ElementAt(0).InvoiceKey.ToString();
                    dtpInvoiceDate.Text = invoice.ElementAt(0).PurchaseDate;
                    txtTotalCost.Text = invoice.ElementAt(0).Cost.ToString();

                    //If an invoice was selected from the search form, populate the data grid view with the selected invoice's items.
                    invoiceCars = DataControl.getCarsBindingListByInvoiceID(frmSearchWindow.PassedInvoiceKey);
                    dgvInvoiceItems.DataSource = invoiceCars;

                    //repopulate the item inventory drop down to reflect possible changes
                    ds = DataControl.getInventoryItems();

                    cmbxInventory.DisplayMember = "InventoryName";
                    cmbxInventory.ValueMember = "VIN";
                    cmbxInventory.DataSource = ds.Tables[0];

                    //disable necessary drop downs, textboxes, data grid viewer, and buttons
                    dgvInvoiceItems.Enabled = false;
                    btnSave.Enabled = false;
                    btnAddItem.Enabled = false;
                    cmbxCustomer.Enabled = false;
                    cmbxInventory.Enabled = false;
                    cmbxSalePerson.Enabled = false;
                    dtpInvoiceDate.Enabled = false;

                    //If all is returned correctly, enable the edit and delete buttons, and the search menu.
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                    menuToolStripMenuItem.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                dv.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Method handles the selection of Edit Inventory from the the Menu drop down.
        /// Hides the main screen and opens up a new Inventory Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                frmInventoryWindow = new frmInventory();
                frmInventoryWindow.ShowDialog();
                this.Show();

                //repopulate the item inventory drop down to reflect possible changes
                ds = DataControl.getInventoryItems();

                cmbxInventory.DisplayMember = "InventoryName";
                cmbxInventory.ValueMember = "VIN";
                cmbxInventory.DataSource = ds.Tables[0];

                //if there is a invoice showing currently in read-only format repopulate to handle any inventory item changes.  
                //Do this check just in case, even if there wasn't any changes to the inventory items def table.

                if (!(lblInvoiceNum.Text == "" || lblInvoiceNum == null))
                {
                    invoice = DataControl.getInvoiceByIDNoNames(Convert.ToInt32(lblInvoiceNum.Text));
                    cmbxSalePerson.SelectedValue = invoice.ElementAt(0).SalesPersonName;
                    cmbxCustomer.SelectedValue = invoice.ElementAt(0).CustomerName;
                    lblInvoiceNum.Text = invoice.ElementAt(0).InvoiceKey.ToString();
                    dtpInvoiceDate.Text = invoice.ElementAt(0).PurchaseDate;
                    txtTotalCost.Text = invoice.ElementAt(0).Cost.ToString();

                    //If an invoice was selected from the search form, populate the data grid view with the selected invoice's items.
                    invoiceCars = DataControl.getCarsBindingListByInvoiceID(Convert.ToInt32(lblInvoiceNum.Text));
                    dgvInvoiceItems.DataSource = invoiceCars;

                    //disable necessary drop downs, textboxes, data grid viewer, and buttons
                    dgvInvoiceItems.Enabled = false;
                    btnSave.Enabled = false;
                    btnAddItem.Enabled = false;
                    cmbxCustomer.Enabled = false;
                    cmbxInventory.Enabled = false;
                    cmbxSalePerson.Enabled = false;
                    dtpInvoiceDate.Enabled = false;

                    //If all is returned correctly, enable the edit and delete buttons, and the search menu.
                    btnDelete.Enabled = true;
                    btnEdit.Enabled = true;
                    menuToolStripMenuItem.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                dv.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion

        #region Invoice Options Controls
        /// <summary>
        /// Method handles the Invoice Create button functionality.
        /// When clicked, the user will be able to create a new invoice.
        /// The invoice form viewer controls will become enabled to allow 
        /// invoice creation.  Flags the form that we are creating an invoice.
        /// Disables Edit and Delete Invoice until the created invoice is saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                //disable necessary invoice option buttons
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;

                //re-data bind the item inventory drop down to use current inventory items
                ds = DataControl.getInventoryItems();

                cmbxInventory.DisplayMember = "InventoryName";
                cmbxInventory.ValueMember = "VIN";
                cmbxInventory.DataSource = ds.Tables[0];

                //enable form fields
                dgvInvoiceItems.Enabled = true;
                btnSave.Enabled = true;
                cmbxInventory.Enabled = true;
                cmbxCustomer.Enabled = true;
                cmbxSalePerson.Enabled = true;
                dtpInvoiceDate.Enabled = true;
                btnAddItem.Enabled = true;

                //clear form fields out of any possible existing data, and set drop downs to their first index.
                lblInvoiceNum.Text = "";
                txtTotalCost.Text = "0.00";
                dtpInvoiceDate.Text = "";
                dgvInvoiceItems.DataSource = null;
                cmbxCustomer.SelectedIndex = 0;
                cmbxSalePerson.SelectedIndex = 0;

                //disable access to the menu button
                menuToolStripMenuItem.Enabled = false;

                isCreate = true;    //flag the form that we are creating an invoice

                //populate the invoice number label with the next upcoming invoice number to be created.
                invoiceKey = DataControl.getNextInvoiceKey();
                lblInvoiceNum.Text = invoiceKey.ToString();
            }
            catch (Exception ex)
            {
                dv.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Method handles the Invoice Edit button functionality.
        /// When clicked, the user will be able to edit an invoices details
        /// and invoice inventory items.  The invoice form viewer controls 
        /// will become enabled as well.  Only controls that can be edited for an
        /// invoice will be enabled. Disables the create and delete invoice buttons, 
        /// until the edited invoice is saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                //disable necessary invoice option buttons
                btnDelete.Enabled = false;
                btnCreate.Enabled = false;

                //re-data bind the item inventory drop down to use current inventory items
                ds = DataControl.getInventoryItems();

                cmbxInventory.DisplayMember = "InventoryName";
                cmbxInventory.ValueMember = "VIN";
                cmbxInventory.DataSource = ds.Tables[0];

                //enable form fields
                dgvInvoiceItems.Enabled = true;
                btnSave.Enabled = true;
                cmbxInventory.Enabled = true;
                cmbxSalePerson.Enabled = true;
                cmbxCustomer.Enabled = true;
                btnAddItem.Enabled = true;

                //disable access to the menu button, and date text box
                menuToolStripMenuItem.Enabled = false;
                dtpInvoiceDate.Enabled = false;

                isEdit = true;      //flag the form that we are editing an invoice
            }
            catch (Exception ex)
            {
                dv.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Method handles the Invoice Delete button functionality.
        /// When clicked, an entire invoice and all of it's details will 
        /// be removed/deleted from the database.  After clicking this button
        /// a confirmation window will appear to verify whether or not to really
        /// delete the currently viewed invoice.  After deletion is complete the invoice's 
        /// form fields and data grid view will be cleared out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Confirm that the user truly wants to delete the invoice.
                DialogResult resultConfirm = MessageBox.Show("Are you sure you want to delete this invoice?", "Delete Invoice?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultConfirm.Equals(DialogResult.Yes))
                {
                    //attempt to delete the invoice from the database, check to see if the deletion was successful.  
                    //If not, show an error message.
                    result = DataControl.DeleteInvoice(Convert.ToInt32(lblInvoiceNum.Text));
                    if (result)
                    {
                        //Disable all necessary form controls and invoice option buttons.
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = false;
                        btnAddItem.Enabled = false;
                        dtpInvoiceDate.Enabled = false;
                        cmbxInventory.Enabled = false;
                        cmbxCustomer.Enabled = false;
                        cmbxSalePerson.Enabled = false;

                        //Clear out form fields
                        lblInvoiceNum.Text = "";
                        txtItemCost.Text = "";
                        txtTotalCost.Text = "0.00";
                        dtpInvoiceDate.Text = "";
                        dgvInvoiceItems.DataSource = null;
                        dgvInvoiceItems.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("The invoice was not successfully deleted, please try again.", "Delete Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                dv.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion

        #region Invoice Form Viewer Controls
        /// <summary>
        /// Method handles when an item is selected from the 
        /// item inventory drop down.  After an item is selected
        /// the respective item's cost will be populated into the 
        /// cost read-only text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbxInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtItemCost.Text = DataControl.getInventoryItemCost(Convert.ToInt64(cmbxInventory.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {
                dv.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Method handles the Add item button functionality.
        /// When clicked, the item's name from the drop down and 
        /// its respective cost will be added to the data grid view.
        /// Also, the running total cost for the invoice will be incremented.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Create a new car
                Car newInvoiceItem = DataControl.getCarByVIN(Convert.ToInt64(cmbxInventory.SelectedValue.ToString()));

                //add the new car to the binding list for the data grid view, then add the list as the data source for the data grid view.
                invoiceCars.Add(newInvoiceItem);
                dgvInvoiceItems.DataSource = invoiceCars;

                //update the total cost and the label's text.
                totalCost += newInvoiceItem.price;
                txtTotalCost.Text = totalCost.ToString();
            }
            catch (Exception ex)
            {
                dv.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Method handles the Save invoice button functionality.
        /// When clicked, an invoice and it's details will be saved to the database.
        /// Also, validates form fields and data grid view cell values.
        /// If an errors occur a message will be displayed notifying of the specifics.
        /// Once the invoice is saved, the invoice viewer form and its controls will become
        /// read-only. The edit, delete and create invoice buttons will be enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //populate the invoice items list with the new values from the data grid view control.
                populateInvoiceItems();

                if (isCreate)
                {
                    //concatenate the date and time strings into a single string.  Then validate it.
                    createDateTime(dtpInvoiceDate.Text, DateTime.Now.ToLongTimeString());

                    //check the date string to see if it is a valid date.
                    result = dv.isDate(selectedDateTime);

                    if (result)
                    {
                        //add the invoice to the database
                        invoiceKey = DataControl.AddInvoice(Convert.ToInt32(cmbxSalePerson.SelectedValue.ToString()), Convert.ToInt32(cmbxCustomer.SelectedValue.ToString()), selectedDateTime, invoiceItems, Convert.ToDecimal(txtTotalCost.Text));

                        //if the invoice was added successfully, re-enable invoice option buttons, but make the invoice form fields and data grid view to be read-only.
                        if (invoiceKey != 0)
                        {
                            dgvInvoiceItems.Enabled = false;
                            cmbxInventory.Enabled = false;
                            cmbxCustomer.Enabled = false;
                            cmbxSalePerson.Enabled = false;
                            dtpInvoiceDate.Enabled = false;
                            btnAddItem.Enabled = false;
                            btnEdit.Enabled = true;
                            btnDelete.Enabled = true;
                            btnSave.Enabled = false;
                            lblInvoiceNum.Text = invoiceKey.ToString();

                            isCreate = false;   //flag the form that we are done creating an invoice

                            //enable access to the menu button
                            menuToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("The invoice did not create successfully, please try again.", "Create Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("The invoice did not create successfully, the date field must be a valid date.", "Create Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (isEdit)
                {
                    //edit the invoice in the database
                    result = DataControl.EditInvoice(Convert.ToInt32(lblInvoiceNum.Text), Convert.ToInt32(cmbxSalePerson.SelectedValue.ToString()), Convert.ToInt32(cmbxCustomer.SelectedValue.ToString()), dtpInvoiceDate.Value.ToString(), invoiceItems, Convert.ToDecimal(txtTotalCost.Text));

                    //if the invoice was updated successfully, re-enable the invoice option buttons, but make the invoice form fields and data grid view to be read-only.
                    if (result)
                    {
                        dgvInvoiceItems.Enabled = false;
                        cmbxInventory.Enabled = false;
                        cmbxCustomer.Enabled = false;
                        cmbxSalePerson.Enabled = false;
                        dtpInvoiceDate.Enabled = false;
                        btnAddItem.Enabled = false;
                        btnCreate.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSave.Enabled = false;

                        isEdit = false;     //flag the form that we are done editing an invoice

                        //enable access to the menu button
                        menuToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("The invoice did not update successfully, please try again.", "Edit Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("The invoice did not update successfully, the date field must be a valid date.", "Edit Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                dv.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Method populates the invoice items list from what is in the data grid view.
        /// </summary>
        /// <returns>List of all the cars in the data grid view control</returns>
        public void populateInvoiceItems()
        {
            //clear out any items in the list before inserting the new or updated list of cars from the data grid.
            invoiceItems.Clear();

            //iterate through the data grid's rows and insert their cells' info into the car list.
            for (int i = 0; i < dgvInvoiceItems.RowCount; i++)
            {
                if (dgvInvoiceItems.Rows[i].Cells[2].Value == null)
                {
                    continue;
                }
                else
                {
                    string item = dgvInvoiceItems.Rows[i].Cells[2].Value.ToString();
                    Car tempCar = new Car(dgvInvoiceItems.Rows[i].Cells[2].Value.ToString(), Convert.ToInt32(dgvInvoiceItems.Rows[i].Cells[1].Value.ToString()), Convert.ToDecimal(dgvInvoiceItems.Rows[i].Cells[3].Value.ToString()), dgvInvoiceItems.Rows[i].Cells[0].Value.ToString(), dgvInvoiceItems.Rows[i].Cells[4].Value.ToString());
                    invoiceItems.Add(tempCar);
                }
            }
        }
        /// <summary>
        /// Method concatenates a date string and a time string together
        /// </summary>
        /// <param name="date">the selected date</param>
        /// <param name="time">the current time</param>
        public void createDateTime(string date, string time)
        {
            //combine the date and time string, then assign it to the selected date and time variable
            string tempDateSpace = String.Concat(date, " ");
            selectedDateTime = String.Concat(tempDateSpace, time);
        }

        #endregion
    }
}
