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

		clsDataAccess da = new clsDataAccess();

		/// <summary>
		/// Global InvoiceKey to be used by the Invoice retrieve screen/class.
		/// </summary>
		public int PassedInvoiceKey { get; set; }

		#endregion

		#region Constructor(s)

		public frmSearch()
		{
			InitializeComponent();

			//populate/create datagridview data
			fillDataGridView();

			//instantiate the Invoice Number dropdown
			fillInvoiceDropdown();

			//instantiate the cost dropdown
			fillCostDropdown();

			//instantiate the date dropdown.
			fillDateDropdown();
		}
		
		#endregion

		#region Methods

		public void fillDataGridView()
		{
			try
			{
				BindingList<Invoice> Invoices = DataControl.getAllInvoices();

				//Create 4 columns to be displayed in the DataGridView
				DataGridViewTextBoxColumn InvoiceKeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
				DataGridViewTextBoxColumn CustomerNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
				DataGridViewTextBoxColumn SalesPersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
				DataGridViewTextBoxColumn PurchaseDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
				DataGridViewTextBoxColumn CostColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
				DataGridViewButtonColumn SelectInvoiceButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();

				//Set the properties of the columns.
				//Note the property "DataPropertyName".  
				//The value of this property corresponds to the name of the property in the class Employee.  
				//This binds this column to that field in the class.

				InvoiceKeyColumn.DataPropertyName = "InvoiceKey";
				InvoiceKeyColumn.HeaderText = "Invoice ID";
				InvoiceKeyColumn.Name = "InvoiceID";

				CustomerNameColumn.DataPropertyName = "customerName";
				CustomerNameColumn.HeaderText = "Customer Full Name";
				CustomerNameColumn.Name = "customerName";
				//CustomerFirstNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
				//CustomerFirstNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;

				SalesPersonName.DataPropertyName = "salesPersonName";
				SalesPersonName.HeaderText = "Sales Person Name";
				SalesPersonName.Name = "salesPersonName";

				PurchaseDateColumn.DataPropertyName = "PurchaseDate";
				PurchaseDateColumn.HeaderText = "Purchase Date";
				PurchaseDateColumn.Name = "PurchaseDate";

				CostColumn.DataPropertyName = "Cost";
				CostColumn.HeaderText = "Total Cost";
				CostColumn.Name = "Cost";

				SelectInvoiceButtonColumn.HeaderText = "Select Invoice";
				SelectInvoiceButtonColumn.Name = "SelectInvoice";
				SelectInvoiceButtonColumn.Text = "Select the Invoice";
				SelectInvoiceButtonColumn.UseColumnTextForButtonValue = true;
				SelectInvoiceButtonColumn.Width = 200;

				//Add the columns to the DataGridView
				InvoiceDataGridView.Columns.Add(InvoiceKeyColumn);
				InvoiceDataGridView.Columns.Add(CustomerNameColumn);
				InvoiceDataGridView.Columns.Add(SalesPersonName);
				InvoiceDataGridView.Columns.Add(PurchaseDateColumn);
				InvoiceDataGridView.Columns.Add(CostColumn);
				InvoiceDataGridView.Columns.Add(SelectInvoiceButtonColumn);

				//Don't generate columns automatically
				InvoiceDataGridView.AutoGenerateColumns = false;

				//Set the DataSource for the DataGridView
				InvoiceDataGridView.DataSource = Invoices;
			}
			catch (Exception ex)
			{
				MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

		public void fillInvoiceDropdown()
		{
			try
			{
				//clear out old data
				cmbInvoiceNumber.Items.Clear();

				da = new clsDataAccess(); //Data Access object to query database
				DataSet ds; //Data set to store results of SQL statement
				string sInvoiceSQL = "SELECT DISTINCT InvoiceKey FROM Invoices"; //SQL statement to execute

				int iTotalResults = 0;  //Number of results that came back from SQL statement

				//Run the statement and store the result into the dataset
				ds = da.ExecuteSQLStatement(sInvoiceSQL, ref iTotalResults);

				//For each row in the data set, add a new item to the combo box
				foreach (DataRow dr in ds.Tables[0].Rows)
					cmbInvoiceNumber.Items.Add(dr["InvoiceKey"].ToString());
			}
			catch (Exception ex)
			{
				MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

		public void fillDateDropdown()
		{
			try
			{
				//clear out old data
				cmbInvoiceDate.Items.Clear();

				da = new clsDataAccess(); //Data Access object to query database
				DataSet ds; //Data set to store results of SQL statement
				string sDateSQL = "SELECT DISTINCT PurchaseDate FROM Invoices"; //SQL statement to execute

				int iTotalResults = 0;  //Number of results that came back from SQL statement

				//Run the statement and store the result into the dataset
				ds = da.ExecuteSQLStatement(sDateSQL, ref iTotalResults);

				//For each row in the data set, add a new item to the combo box
				foreach (DataRow dr in ds.Tables[0].Rows)
					cmbInvoiceDate.Items.Add(dr["PurchaseDate"].ToString());
			}
			catch (Exception ex)
			{
				MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

		public void fillCostDropdown()
		{

			try
			{
				//clear out old data
				cmbTotalCost.Items.Clear();

				da = new clsDataAccess(); //Data Access object to query database
				DataSet ds; //Data set to store results of SQL statement
				string sCostSQL = "SELECT DISTINCT TotalCost FROM Invoices"; //SQL statement to execute

				int iTotalResults = 0;  //Number of results that came back from SQL statement

				//Run the statement and store the result into the dataset
				ds = da.ExecuteSQLStatement(sCostSQL, ref iTotalResults);

				//For each row in the data set, add a new item to the combo box
				foreach (DataRow dr in ds.Tables[0].Rows)
					cmbTotalCost.Items.Add(dr["TotalCost"].ToString());
			}
			catch (Exception ex)
			{
				MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}


		#endregion

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

		private void btnClearFilters_Click(object sender, EventArgs e)
		{
			//set the dropdown text to blank.
			cmbTotalCost.Text = "";
			cmbInvoiceDate.Text = "";
			cmbInvoiceNumber.Text = "";

			//Add in any new items by first clearing out the dropdown lists and then re-populating them
			fillInvoiceDropdown();
			fillDateDropdown();
			fillCostDropdown();

			//repopulate the datagridview with no filters.
			InvoiceDataGridView.DataSource = DataControl.getAllInvoices();
		}

		private void InvoiceDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				//Grab the invoice record that was clicked on
				Invoice invTemp = (Invoice)InvoiceDataGridView.Rows[e.RowIndex].DataBoundItem;

				//Make sure there is an Invoice
				if (invTemp != null)
				{
					//Determine if the "Select This Invoice" button was clicked
					if (e.ColumnIndex == InvoiceDataGridView.Columns["SelectInvoice"].Index)
					{
						//Here's where I throw the invoice key to the Create invoice
						int InvoiceKey = invTemp.InvoiceKey;
						this.Hide();
					}
					else
					{
						////A row was selected so display the employee's information
						//lblID.Text = invTemp.ID.ToString();
						//lblFirstName.Text = invTemp.FirstName;
						//lblLastName.Text = invTemp.LastName;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

		#endregion

		#region FilterEvents

		private void cmbInvoiceNumber_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				//set the other dropdowns to blank
				cmbInvoiceDate.Text = "";
				cmbTotalCost.Text = "";
				//get the string value selected and convert that into an int.
				string sSelection = cmbInvoiceNumber.SelectedItem.ToString();
				int iSelection = Convert.ToInt32(sSelection);
				//use the int value of the value selected to repopulate the binding list
				InvoiceDataGridView.DataSource = DataControl.getInvoiceByID(iSelection);
			}
			catch (Exception ex)
			{
				MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

		private void cmbInvoiceDate_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				//set the other dropdowns to blank
				cmbInvoiceNumber.Text = "";
				cmbTotalCost.Text = "";
				//get the string value selected.
				string sSelection = cmbInvoiceDate.SelectedItem.ToString();
				//use the string date value to repopulate the data grid view
				InvoiceDataGridView.DataSource = DataControl.getInvoicesByDate(sSelection);
			}
			catch (Exception ex)
			{
				MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

		private void cmbTotalCost_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				//set the other dropdowns to blank
				cmbInvoiceDate.Text = "";
				cmbInvoiceNumber.Text = "";
				//get the string value selected and convert that into a decimal.
				string sSelection = cmbTotalCost.SelectedItem.ToString();
				decimal dSelection = Convert.ToDecimal(sSelection);
				//use the int value of the value selected to repopulate the binding list
				InvoiceDataGridView.DataSource = DataControl.getInvoicesByCost(dSelection);
			}
			catch (Exception ex)
			{
				MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
			}
		}

		#endregion
	}
}
