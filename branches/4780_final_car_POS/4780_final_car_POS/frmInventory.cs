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
    public partial class frmInventory : Form
    {
        #region Variables

        /// <summary>
        /// Validates input and handles errors.
        /// </summary>
        dataValidator dv = new dataValidator();

        /// <summary>
        /// Inventory binding list.  This populates the datagrid
        /// </summary>
        BindingList<Car> inventory = new BindingList<Car>();

        #endregion

        #region constructor
        
        /// <summary>
        /// Constructor for the form
        /// </summary>
        public frmInventory()
        {
            try
            {
                InitializeComponent();

                //hides save button
                btn_save.Visible = false;

                //sets the binding list
                inventory = DataControl.getCarList();

                //Create 4 columns to be displayed in the DataGridView
                DataGridViewTextBoxColumn Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
                DataGridViewButtonColumn Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
                DataGridViewButtonColumn Column7 = new System.Windows.Forms.DataGridViewButtonColumn();

                //Add the columns to the DataGridView
                dataGridView1.Columns.Add(Column1);
                dataGridView1.Columns.Add(Column2);
                dataGridView1.Columns.Add(Column3);
                dataGridView1.Columns.Add(Column4);
                dataGridView1.Columns.Add(Column5);
                dataGridView1.Columns.Add(Column6);
                dataGridView1.Columns.Add(Column7);

                //Set the column properties
                Column1.DataPropertyName = "VIN";
                Column1.HeaderText = "VIN";

                Column2.DataPropertyName = "Model";
                Column2.HeaderText = "Model";

                Column3.DataPropertyName = "Price";
                Column3.HeaderText = "Price";

                Column4.DataPropertyName = "Year";
                Column4.HeaderText = "Year";

                Column5.DataPropertyName = "Description";
                Column5.HeaderText = "Description";

                Column6.HeaderText = "Edit";
                Column6.Name = "Edit";
                Column6.Text = "Edit";
                Column6.UseColumnTextForButtonValue = true;
                Column6.Width = 100;

                Column7.HeaderText = "Delete";
                Column7.Name = "Delete";
                Column7.Text = "Delete";
                Column7.UseColumnTextForButtonValue = true;
                Column7.Width = 100;

                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.DataSource = inventory;

                //populates the dropdown
                populateModelDropdown();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the binding list
        /// </summary>
        public void updateInventoryList()
        {
            try
            {
                //sets the binding list
                inventory = DataControl.getCarList();

                //binds the binding list to the datagrid view
                dataGridView1.DataSource = inventory;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Populates the model dropdown list
        /// </summary>
        public void populateModelDropdown()
        {
            try
            {
                //Creates a dataset to hold the data
                DataSet ds;

                //How many rows are returned
                //int rowsReturned = 0;

                //creates a data set and stores the values in ds
                ds = DataControl.getModels();

                //goes through the dataset and populates the drop down box
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    cmb_model.Items.Add(ds.Tables[0].Rows[x][1].ToString());
                }
            }
            catch (Exception ex)
            {
                dv.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
                //throw;
            }
        }

        /// <summary>
        /// When a cell is clicked this gets called
        /// </summary>
        /// <param name="sender">datagrid view</param>
        /// <param name="e">event args</param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //hides the error message labels
                lbl_errors.Visible = false;
                //extracts the car that corresponds to the row that was clicked
                Car tempCar = (Car)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                //makes sure that there is a car
                if (tempCar != null)
                {
                    //creates temp button for the sender
                   // Button tempButton = (Button)sender;
                    if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
                    {
                        //Deletes the employee from the list
                        if (DataControl.vinExistsOnInvoice(tempCar.vin))
                        {
                            //shows label errors
                            lbl_errors.Visible = true;
                            lbl_errors.Text = "Car exists on the following invoices: " + DataControl.getInvoiceByVin(tempCar.vin);
                        }
                        else
                        {
                            //deletes the car
                            DataControl.deleteCar(tempCar.vin);

                            //updates datagrid
                            updateInventoryList();
                        }

                    }
                    if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
                    {
                        //updates the car information boxes and disables the items that we don't want the user to change
                        cmb_model.SelectedItem = tempCar.model;
                        tbx_vin.Text = tempCar.vin;
                        tbx_price.Text = tempCar.price.ToString();
                        tbx_year.Text = tempCar.year.ToString();
                        tbx_description.Text = tempCar.description;

                        cmb_model.Enabled = false;
                        tbx_vin.Enabled = false;
                        dataGridView1.Enabled = false;
                        bnt_addCar.Enabled = false;
                        btn_clear.Enabled = false;

                        //enables the save button
                        btn_save.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                dv.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Handles the cancel buttons functionality, returns the user to the main menu screen.
        /// </summary>
        /// <param name="sender">btn cancel</param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //hides the form
                this.Hide();
            }
            catch (Exception ex)
            {
                dv.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Clears the text fields
        /// </summary>
        private void clearFields()
        {
            try
            {
                //Clears out the model selection
                cmb_model.SelectedItem = null;
                tbx_vin.Text = null;
                tbx_price.Text = null;
                tbx_year.Text = null;
                tbx_description.Text = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Adds the values for the fields that are filled out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnt_addCar_Click(object sender, EventArgs e)
        {
            try
            {
                //Hides the error label and resets it
                lbl_errors.Text = "Errors";
                lbl_errors.Visible = false;

                ///checks to see if we the fields are valid
                if (cmb_model.SelectedItem != null &&
                        dv.isAlphaNumeric(tbx_vin.Text) && tbx_vin.Text != "" && tbx_vin.Text != null &&
                        dv.isNumber(tbx_price.Text) && tbx_price.Text != "" && tbx_price.Text != null &&
                        dv.isNumber(tbx_year.Text) && tbx_year.Text != "" && tbx_year.Text != null &&
                    /*dv.isAlphaNumeric(tbx_description.Text) && */tbx_description.Text != "" && tbx_description != null
                    )
                {
                    if (!DataControl.vinExists(tbx_vin.Text))
                    {
                        //public static void addCar(string model, string vin, double price, int year, string description)
                        DataControl.addCar(cmb_model.SelectedItem.ToString(), tbx_vin.Text, Convert.ToDouble(tbx_price.Text), Convert.ToInt32(tbx_year.Text), tbx_description.Text);

                        //updates the list and clears out the fields
                        updateInventoryList();
                        clearFields();
                    }
                    else
                    {
                        lbl_errors.Text = "VIN already exists.";
                        lbl_errors.Visible = true;
                    }
                }
                else
                {
                    //Updates the error message.
                    lbl_errors.Text = "Please enter valid information.";
                    lbl_errors.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Clears the values
        /// </summary>
        /// <param name="sender">btn_clear</param>
        /// <param name="e">event args</param>
        private void btn_clear_Click(object sender, EventArgs e)
        {
            try
            {
                //clears the fields to add a car
                clearFields();

                //hides error
                lbl_errors.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// When the person saves the car that they are editing this gets called
        /// </summary>
        /// <param name="sender">btn_Save</param>
        /// <param name="e">event args</param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                //stores the price
                decimal price = 0;
                //validates the price
                if(dv.isNumber(tbx_price.Text) && tbx_price.Text != "" && tbx_price.Text != null)
                {
                    price = int.Parse(tbx_price.Text);
                }
                else 
                {
                    lbl_errors.Visible = true;
                    lbl_errors.Text = "Enter a valid price";
                }
                //stores the year
                int year = 0;
                //validates the year
                if(dv.isNumber(tbx_year.Text) && tbx_year.Text != "" && tbx_year.Text != null)
                {
                    year = int.Parse(tbx_year.Text);
                }    
                else
                {
                    lbl_errors.Visible = true;
                    lbl_errors.Text = "Enter a valid year";
                }

                //stores the description
                string description;
                //makes the description not null or an empty string when it is null.
                if (tbx_description.Text == null || tbx_description.Text == "")
                    description = "";
                else
                    description = tbx_description.Text;

                //makes sure that they have entered in a year and price
                if (price != 0 && year != 0)
                {
                    //updates the car
                    DataControl.updateCar(tbx_vin.Text, price, year, description);

                    //hides the error label
                    lbl_errors.Visible = false;

                    //makes everything else valid
                    cmb_model.Enabled = true;
                    tbx_vin.Enabled = true;
                    bnt_addCar.Enabled = true;
                    btn_clear.Enabled = true;

                    //clears the fields
                    clearFields();
                    //hides the save button
                    btn_save.Visible = false;

                    //updates and enables the data grid
                    dataGridView1.Enabled = true;
                    updateInventoryList();

                    //deselects everything in the model combobox
                    cmb_model.SelectedText = null;
                    cmb_model.SelectedValue = null;
                    cmb_model.SelectedItem = null;
                }
                else
                {
                    //shows the errors
                    lbl_errors.Visible = true;
                    lbl_errors.Text = "Enter a valid price or year.";
                }
                
            }
            catch (Exception ex)
            {
                dv.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion


    }
}
