using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


static class DataControl
{
    /// <summary>
    /// 
    /// </summary>
    clsDataAccess da = new clsDataAccess();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static List<car> getCarsByInvoiceID(int invoiceId)
    {
        try
        {
            List<car> invoiceItems = new List<car>();
            return invoiceItems;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="salesPersonKey"></param>
    /// <param name="customerKey"></param>
    /// <param name="purchaseDate"></param>
    /// <param name="invoiceItems"></param>
    /// <returns></returns>
    public static bool AddInvoice(int salesPersonKey, int customerKey, string purchaseDate, List<car> invoiceItems)
    {
        try
        {
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="invoiceID"></param>
    /// <param name="salesPersonKey"></param>
    /// <param name="customerKey"></param>
    /// <param name="purchaseDate"></param>
    /// <param name="invoiceItems"></param>
    /// <returns></returns>
    public static bool EditInvoice(int invoiceID, int salesPersonKey, int customerKey, string purchaseDate, List<car> invoiceItems)
    {
        try
        {
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="invoiceID"></param>
    /// <returns></returns>
    public static bool DeleteInvoice(int invoiceID)
    {
        try
        {
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="invoiceID"></param>
    /// <param name="inventoryID"></param>
    /// <returns></returns>
    public static bool DeleteInvoiceItem(int invoiceID, int inventoryID)
    {
        try
        {
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="make"></param>
    /// <param name="model"></param>
    /// <param name="year"></param>
    /// <param name="cost"></param>
    /// <returns></returns>
    public static bool AddInventoryItem(string make, string model, int year, decimal cost)
    {
        try
        {
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="inventoryID"></param>
    /// <param name="make"></param>
    /// <param name="model"></param>
    /// <param name="year"></param>
    /// <param name="cost"></param>
    /// <returns></returns>
    public static bool EditInventoryItem(int inventoryID, string make, string model, int year, decimal cost)
    {
        try
        {
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="inventoryID"></param>
    /// <param name="invoiceIDs"></param>
    /// <returns></returns>
    public static bool DeleteInventoryItem(int inventoryID, ref string invoiceIDs)
    {
        try
        {
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cost"></param>
    /// <returns></returns>
    //public static BindingList<Invoice> getInvoicesByCost(decimal cost)
    //{
    //    try
    //    {
    //        BindingList<Invoice> invoices = new BindingList<Invoice>();
    //        return invoices;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    /// <summary>
    /// 
    /// </summary>
    /// <param name="purchaseDate"></param>
    /// <returns></returns>
    //public static BindingList<Invoice> getInvoicesByDate(string purchaseDate)
    //{
    //    try
    //    {
    //        BindingList<Invoice> invoices = new BindingList<Invoice>();
    //        return invoices;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    /// <summary>
    /// 
    /// </summary>
    /// <param name="invoiceID"></param>
    /// <returns></returns>
    //public static BindingList<Invoice> getInvoiceByID(int invoiceID)
    //{
    //    try
    //    {
    //        BindingList<Invoice> invoices = new BindingList<Invoice>();
    //        return invoices;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    //public static BindingList<Invoice> getAllInvoices()
    //{
    //    try
    //    {
    //        BindingList<Invoice> invoices = new BindingList<Invoice>();
    //        return invoices;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    /// <summary>
    /// 
    /// </summary>
    /// <param name="customerKey"></param>
    /// <returns></returns>
    public static string getCustomerByID(int customerKey)
    {
        
        try
        {
            string customerName = "";
            return customerName;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="salesPersonKey"></param>
    /// <returns></returns>
    public static string getSalesPersonByID(int salesPersonKey)
    {
        try
        {
            string salesPersonName = "";
            return salesPersonName;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
