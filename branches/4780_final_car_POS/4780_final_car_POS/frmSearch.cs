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
    public partial class frmSearch : Form
    {
        #region Variables

        /// <summary>
        /// Validates input and handles errors.
        /// </summary>
        dataValidator dv = new dataValidator();

        #endregion

        public frmSearch()
        {
            InitializeComponent();

            //Create 4 columns to be displayed in the DataGridView
            DataGridViewTextBoxColumn Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();

            //Add the columns to the DataGridView
            dataGridView1.Columns.Add(Column1);
            dataGridView1.Columns.Add(Column2);
            dataGridView1.Columns.Add(Column3);
            dataGridView1.Columns.Add(Column4);
            dataGridView1.Columns.Add(Column5);

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

            dataGridView1.AutoGenerateColumns = false;

            //dataGridView1.DataSource = s.item;
        }

        #region Button Methods

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
