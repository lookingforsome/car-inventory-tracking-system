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
        //DataSet ds;
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
        /// Represents a newly created invoice, or a read-only editable/delete worthy invoice.  Used to populate a data viewer.
        /// </summary>
        BindingList<Invoice> invoice = new BindingList<Invoice>();

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

                //Create 4 columns to be displayed in the DataGridView
                //DataGridViewTextBoxColumn Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                //DataGridViewTextBoxColumn Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                //DataGridViewTextBoxColumn Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                //DataGridViewButtonColumn Column4 = new System.Windows.Forms.DataGridViewButtonColumn();

                ////Set the properties of the columns.
                ////Note the property "DataPropertyName".  
                ////The value of this property corresponds to the name of the property in the class Employee.  
                ////This binds this column to that field in the class.

                //Column1.DataPropertyName = "ID";
                //Column1.HeaderText = "Employee ID";
                //Column1.Name = "EmployeeID";

                //Column2.DataPropertyName = "FirstName";
                //Column2.HeaderText = "First Name";
                //Column2.Name = "FirstName";
                //Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                //Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;

                //Column3.DataPropertyName = "LastName";
                //Column3.HeaderText = "Last Name";
                //Column3.Name = "LastName";

                //Column4.HeaderText = "Delete Employee";
                //Column4.Name = "DeleteEmployee";
                //Column4.Text = "Delete the Employee";
                //Column4.UseColumnTextForButtonValue = true;
                //Column4.Width = 200;

                ////Add the columns to the DataGridView
                //dataGridView1.Columns.Add(Column1);
                //dataGridView1.Columns.Add(Column2);
                //dataGridView1.Columns.Add(Column3);
                //dataGridView1.Columns.Add(Column4);

                ////Create three employee objects and set their data
                //Employee emp1 = new Employee();
                //emp1.ID = 123;
                //emp1.FirstName = "Shawn";
                //emp1.LastName = "Cowder";

                //Employee emp2 = new Employee();
                //emp2.ID = 456;
                //emp2.FirstName = "Melissa";
                //emp2.LastName = "Cowder";

                //Employee emp3 = new Employee();
                //emp3.ID = 789;
                //emp3.FirstName = "John";
                //emp3.LastName = "Smith";

                ////Add the employee objects to the BindingList
                //lstEmployees.Add(emp1);
                //lstEmployees.Add(emp2);
                //lstEmployees.Add(emp3);

                ////Don't generate columns automatically
                //dataGridView1.AutoGenerateColumns = false;

                ////Set the DataSource for the DataGridView
                //dataGridView1.DataSource = lstEmployees;
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
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Extract the employee that corresponds to the row that was clicked
            //Employee emp = (Employee)dataGridView1.Rows[e.RowIndex].DataBoundItem;

            ////Make sure there is an employee
            //if (emp != null)
            //{
            //    //Determine if the "Delete" button was clicked
            //    if (e.ColumnIndex == dataGridView1.Columns["DeleteEmployee"].Index)
            //    {
            //        //Remove the employee from the list
            //        lstEmployees.Remove(emp);
            //        //or
            //        //dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
            //    }
            //    else
            //    {
            //        //A row was selected so display the employee's information
            //        lblID.Text = emp.ID.ToString();
            //        lblFirstName.Text = emp.FirstName;
            //        lblLastName.Text = emp.LastName;
            //    }
            //}
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
                isCreate = true;    //flag the form that we are creating an invoice
                
                //disable necessary invoice option buttons
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;

                //re-data bind the item inventory drop down to use current inventory items
                //ds = DataControl.getInventoryItems();

                //cmbxInventory.DataSource = ds.Tables[0];
                //cmbxInventory.DisplayMember = "InventoryName";
                //cmbxInventory.ValueMember = "InventoryKey";

                //enable form fields
                dgvInvoiceItems.Enabled = true;
                dgvInvoiceItems.ReadOnly = false;
                btnSave.Enabled = true;
                cmbxInventory.Enabled = true;
                dtpInvoiceDate.Enabled = true;
                btnAddItem.Enabled = true;

                //clear form fields out of any possible existing data
                lblInvoiceNum.Text = "";
                txtItemCost.Text = "";
                txtTotalCost.Text = "";
                dtpInvoiceDate.Text = "";
                dgvInvoiceItems.DataSource = null;

                //disable access to the menu button
                menuToolStripMenuItem.Enabled = false;
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
                isEdit = true;      //flag the form that we are editing an invoice

                //disable necessary invoice option buttons
                btnDelete.Enabled = false;
                btnCreate.Enabled = false;

                //re-data bind the item inventory drop down to use current inventory items
                //ds = DataControl.getInventoryItems();

                //cmbxInventory.DataSource = ds.Tables[0];
                //cmbxInventory.DisplayMember = "InventoryName";
                //cmbxInventory.ValueMember = "InventoryKey";

                //enable form fields
                dgvInvoiceItems.Enabled = true;
                dgvInvoiceItems.ReadOnly = false;
                btnSave.Enabled = true;
                cmbxInventory.Enabled = true;
                dtpInvoiceDate.Enabled = true;
                btnAddItem.Enabled = true;

                //disable access to the menu button
                menuToolStripMenuItem.Enabled = false;
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

                    //Clear out form fields
                    lblInvoiceNum.Text = "";
                    txtItemCost.Text = "";
                    txtTotalCost.Text = "";
                    dtpInvoiceDate.Text = "";
                    dgvInvoiceItems.DataSource = null;
                }
                else
                {
                    MessageBox.Show("The invoice was not successfully deleted, please try again.", "Delete Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
               txtItemCost.Text = "$" + DataControl.getInventoryItemCost(Convert.ToInt32(cmbxInventory.SelectedValue.ToString()));
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
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {

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
                result = true;      //temporary for testing

                if (isCreate)
                {
                    //result = DataControl.AddInvoice();
                    if (result)
                    {
                        dgvInvoiceItems.ReadOnly = true;
                        cmbxInventory.Enabled = false;
                        dtpInvoiceDate.Enabled = false;
                        btnAddItem.Enabled = false;
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;

                        isCreate = false;   //flag the form that we are done creating an invoice

                        //enable access to the menu button
                        menuToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("The invoice did not create successfully, please try again.", "Create Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (isEdit)
                {
                    //result = DataControl.EditInvoice();
                    if (result)
                    {
                        dgvInvoiceItems.ReadOnly = true;
                        cmbxInventory.Enabled = false;
                        dtpInvoiceDate.Enabled = false;
                        btnAddItem.Enabled = false;
                        btnCreate.Enabled = true;
                        btnDelete.Enabled = true;

                        isEdit = false;     //flag the form that we are done editing an invoice

                        //enable access to the menu button
                        menuToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("The invoice did not update successfully, please try again.", "Edit Invoice Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                dv.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion
    }
}
