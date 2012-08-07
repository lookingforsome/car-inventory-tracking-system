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

        BindingList<Car> inventory = new BindingList<Car>();

        #endregion

        public frmInventory()
        {
            InitializeComponent();

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

        #region Methods

        /// <summary>
        /// Updates the binding list
        /// </summary>
        public void updateInventoryList()
        {
            //sets the binding list
            inventory = DataControl.getCarList();

            dataGridView1.DataSource = inventory;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //extracts the car that corresponds to the row that was clicked
            Car tempCar = (Car)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            
            //makes sure that there is a car
            if (tempCar != null)
            {
                //creates temp button for the sender
                Button tempButton = (Button)sender;
                if (tempButton.Text == "Delete")
                {
                    //Deletes the employee from the list
                    inventory.Remove(tempCar);
                }
                if (tempButton.Text == "Edit")
                {

                }
            }
            
            ////Make sure there is an employee
            //if (emp != null)
            //{
            //    //Determine if the "Delete" button was clicked
            //    if (e.ColumnIndex == dataGridView1.Columns["DeleteEmployee"].Index)
            //    {
            //        //Remove the employee from the list
            //        inventory.Remove(tempCar);
            //        //or
            //        //dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
            //    }
            //}
        }

        /// <summary>
        /// Handles the cancel buttons functionality, returns the user to the main menu screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
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
                //Hids the error label and resets it
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
                    //public static void addCar(string model, string vin, double price, int year, string description)
                    DataControl.addCar(cmb_model.SelectedItem.ToString(), tbx_vin.Text, Convert.ToDouble(tbx_price.Text), Convert.ToInt32(tbx_year.Text), tbx_description.Text);

                    //updates the list and clears out the fields
                    updateInventoryList();
                    clearFields();
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
                clearFields();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        #endregion
    }
}
