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

			BindingList<Invoice> Invoices = DataControl.getAllInvoices();

			//string InvoiceKey, string CustomerKey, string SalesPersonKey, string PurchaseDate, string Cost

			//Create 4 columns to be displayed in the DataGridView
			DataGridViewTextBoxColumn InvoiceKeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn CustomerFirstNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn CustomerLastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn SalesPersonFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			DataGridViewTextBoxColumn SalesPersonLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
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

			CustomerFirstNameColumn.DataPropertyName = "customerName";
			CustomerFirstNameColumn.HeaderText = "Full Name";
			CustomerFirstNameColumn.Name = "customerName";
			//CustomerFirstNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			//CustomerFirstNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;

			CustomerLastNameColumn.DataPropertyName = "LastName";
			CustomerLastNameColumn.HeaderText = "Last Name";
			CustomerLastNameColumn.Name = "LastName";

			SalesPersonFirstName.DataPropertyName = "customerName";
			SalesPersonFirstName.HeaderText = "SalesPerson First Name";
			SalesPersonFirstName.Name = "SalesPersonFirstName";

			SalesPersonLastName.DataPropertyName = "LastName";
			SalesPersonLastName.HeaderText = "Last Name";
			SalesPersonLastName.Name = "LastName";

			PurchaseDateColumn.DataPropertyName = "LastName";
			PurchaseDateColumn.HeaderText = "Last Name";
			PurchaseDateColumn.Name = "LastName";

			CostColumn.DataPropertyName = "LastName";
			CostColumn.HeaderText = "Last Name";
			CostColumn.Name = "LastName";

			SelectInvoiceButtonColumn.HeaderText = "Select Invoice";
			SelectInvoiceButtonColumn.Name = "SelectInvoice";
			SelectInvoiceButtonColumn.Text = "Select the Invoice";
			SelectInvoiceButtonColumn.UseColumnTextForButtonValue = true;
			SelectInvoiceButtonColumn.Width = 200;

			//Add the columns to the DataGridView
			InvoiceDataGridView.Columns.Add(InvoiceKeyColumn);
			InvoiceDataGridView.Columns.Add(CustomerFirstNameColumn);
			InvoiceDataGridView.Columns.Add(CustomerLastNameColumn);
			InvoiceDataGridView.Columns.Add(SalesPersonFirstName);
			InvoiceDataGridView.Columns.Add(SalesPersonLastName);
			InvoiceDataGridView.Columns.Add(PurchaseDateColumn);
			InvoiceDataGridView.Columns.Add(CostColumn);
			InvoiceDataGridView.Columns.Add(SelectInvoiceButtonColumn);

			//Create three employee objects and set their data
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
			//Invoices.Add(emp1);
			//Invoices.Add(emp2);
			//Invoices.Add(emp3);

			//Don't generate columns automatically
			InvoiceDataGridView.AutoGenerateColumns = false;

			//Set the DataSource for the DataGridView
			InvoiceDataGridView.DataSource = Invoices;
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
