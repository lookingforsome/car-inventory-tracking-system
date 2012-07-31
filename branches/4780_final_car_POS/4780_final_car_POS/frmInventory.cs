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

        #endregion

        public frmInventory()
        {
            InitializeComponent();
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
