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
        }

        #region Button Methods

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
            
            //Make sure there is an employee
            if (emp != null)
            {
                //Determine if the "Delete" button was clicked
                if (e.ColumnIndex == dataGridView1.Columns["DeleteEmployee"].Index)
                {
                    //Remove the employee from the list
                    inventory.Remove(tempCar);
                    //or
                    //dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                }
            }
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

        #endregion

    }
}
