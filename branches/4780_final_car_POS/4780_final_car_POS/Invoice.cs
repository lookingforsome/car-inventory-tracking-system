using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;


/// <summary>
/// Class that contains invoices for the sales that have taken place
/// Includes a generic list for invoice items
/// </summary>
class Invoice
{
	/// <summary>
	/// Auto property for int InvoiceKey
	/// </summary>
	public int InvoiceKey { get; set; }
	/// <summary>
	/// Autoproperty for int salespersonkey
	/// </summary>
	public string SalesPersonName { get; set; }
	/// <summary>
	/// Auto property for int CustomerKey
	/// </summary>
	public string CustomerName { get; set; }
	/// <summary>
	/// AutoProperty for PurchaseDate
	/// </summary>
	public string PurchaseDate { get; set; }
	/// <summary>
	/// Auto property for Decimal Cost
	/// </summary>
	public decimal Cost { get; set; }
	/// <summary>
	/// Generic LIst of Type Car to hold all the cars that were sold to a customer.
	/// </summary>
	private List<Car> InvoiceItems = new List<Car>();

	/// <summary>
	/// Constructor to create an invoice object
	/// </summary>
	/// <param name="InvoiceKey">InvoiceKey from db</param>
	/// <param name="CustomerKey">CustomerKey from db</param>
	/// <param name="SalesPersonKey">SalesPersonKey from db</param>
	/// <param name="PurchaseDate">PurchaseDate from db</param>
	//public Invoice(string InvoiceKey, string CustomerKey, string SalesPersonKey, string PurchaseDate, string Cost)
	public Invoice(string InvoiceKey, string CustomerName, string SalesPersonName, string PurchaseDate, string Cost)
	{
		try
		{
			this.InvoiceKey = Convert.ToInt32(InvoiceKey);
			this.SalesPersonName = SalesPersonName;
			this.CustomerName = CustomerName;
			this.PurchaseDate = PurchaseDate;
			this.Cost = Convert.ToDecimal(Cost);
		}
		catch (Exception ex)
		{
			MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
		}
	}

	/// <summary>
	/// Method that adds all the car items to the invoice list variable.
	/// </summary>
	/// <param name="carId"></param>
	private void AddItemToList (int carId)
	{
		try
		{
			//gets a list of car objects and copies that into the car object list
			InvoiceItems = DataControl.getCarsByInvoiceID(InvoiceKey);
		}
		catch (Exception ex)
		{
			MessageBox.Show(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
		}
	}

	//private Invoice PassInvoiceToInvoiceForm()
	//{

	//     return Invoice;
	//}


	

}

