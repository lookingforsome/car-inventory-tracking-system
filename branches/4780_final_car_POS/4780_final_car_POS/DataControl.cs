using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;

/// <summary>
/// Class handles the querying to the database
/// </summary>
static class DataControl
{
    /// <summary>
    /// Validates inputs and handles errors.
    /// </summary>
    private static dataValidator dv = new dataValidator();

    /// <summary>
    /// Method retrieves the invoice's items from the database
    /// </summary>
    /// <param name="id">invoice ID number</param>
    /// <returns>List of car objects that represent the invoice's items</returns>
    public static List<Car> getCarsByInvoiceID(int invoiceId)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            int iRet2 = 0;                          // Represents the number of rows from the query to retrieve an inventory item
            DataSet ds;                             // Dataset to hold results from database queries
            DataSet ds2;                            // Dataset to hold a specific inventory item's information

            //SQL Query to the database to search for invoiceItems given a certain invoiceID
            string sqlQuery = "SELECT * FROM InvoiceItems WHERE InvoiceKey = " + invoiceId + ";";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            //create a list of all the invoiceItems, if there is an invoice found, add the invoice's items to the list
            List<Car> invoiceItems = new List<Car>();

            if (iRet > 0)
            {
                //go through the dataset adding the invoice's items
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    //retrieve the inventory item's information given the inventory ID
                    sqlQuery = "SELECT * FROM Inventory WHERE VIN = " + Convert.ToInt64(ds.Tables[0].Rows[x][0].ToString()) + ";";
                    ds2 = da.ExecuteSQLStatement(sqlQuery, ref iRet2);

                    Car tempInvoiceItem = new Car(ds2.Tables[0].Rows[x][1].ToString(), Convert.ToInt32(ds.Tables[0].Rows[x][3].ToString()), Convert.ToDecimal(ds2.Tables[0].Rows[x][2].ToString()), ds2.Tables[0].Rows[x][0].ToString(), ds2.Tables[0].Rows[x][5].ToString());
                    invoiceItems.Add(tempInvoiceItem);
                }
            }
            return invoiceItems;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method retrieves the invoice's items from the database and puts them into a Binding List
    /// </summary>
    /// <param name="id">invoice ID number</param>
    /// <returns>Binding List of car objects that represent the invoice's items</returns>
    public static BindingList<Car> getCarsBindingListByInvoiceID(int invoiceId)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            int iRet2 = 0;                          // Represents the number of rows from the query to retrieve an inventory item
            DataSet ds;                             // Dataset to hold results from database queries
            DataSet ds2;                            // Dataset to hold a specific inventory item's information

            //SQL Query to the database to search for invoiceItems given a certain invoiceID
            string sqlQuery = "SELECT * FROM InvoiceItems WHERE InvoiceKey = " + invoiceId + ";";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            //create a binding list of all the invoiceItems, if there is an invoice found, add the invoice's items to the list
            BindingList<Car> invoiceItems = new BindingList<Car>();

            if (iRet > 0)
            {
                //go through the dataset adding the invoice's items
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    //retrieve the inventory item's information given the inventory ID
                    sqlQuery = "SELECT * FROM Inventory WHERE VIN = " + Convert.ToInt64(ds.Tables[0].Rows[x][0].ToString()) + ";";
                    ds2 = da.ExecuteSQLStatement(sqlQuery, ref iRet2);

                    Car tempInvoiceItem = new Car(getCarModel(Convert.ToInt32(ds2.Tables[0].Rows[0][1].ToString())), Convert.ToInt32(ds2.Tables[0].Rows[0][3].ToString()), Convert.ToDecimal(ds2.Tables[0].Rows[0][2].ToString()), ds2.Tables[0].Rows[0][0].ToString(), ds2.Tables[0].Rows[0][5].ToString());
                    invoiceItems.Add(tempInvoiceItem);
                }
            }
            return invoiceItems;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method returns a vehicles model string according to the vehicles model Key number.
    /// </summary>
    /// <param name="modelKey">the vehicles model key number</param>
    /// <returns>the name string of the vehicle model</returns>
    public static string getCarModel(int modelKey)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries

            //SQL Query to the database to retrieve the vehicles model name
            string sqlQuery = "SELECT ModelName FROM Models WHERE ModelKey = " + modelKey + ";";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            //set the model string from the queried value, and return it
            string model = ds.Tables[0].Rows[0][0].ToString();

            return model;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method returns a vehicles make string according to the vehicles model Key number.
    /// </summary>
    /// <param name="modelKey">the vehicles model key number</param>
    /// <returns>the name string of the vehicle make</returns>
    public static string getCarMake(int modelKey)
    {
        try
        {

            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries

            //SQL Query to the database to retrieve the vehicles make key
            string sqlQuery = "SELECT MakeKey FROM Models WHERE ModelKey = " + modelKey + ";";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            int makeKey = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

            //SQL Query to the database to retrieve the vehicles make name
            sqlQuery = "SELECT MakeName FROM Makes WHERE MakeKey = " + makeKey + ";";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            //set the make string from the queried value, and return it
            string make = ds.Tables[0].Rows[0][0].ToString();

            return make;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method inserts a new invoice with its given invoice items to the database
    /// </summary>
    /// <param name="salesPersonKey">ID of the sales person</param>
    /// <param name="customerKey">ID of the customer</param>
    /// <param name="purchaseDate">Date of purchase</param>
    /// <param name="invoiceItems">List of all the invoice items objects (car objects)</param>
    /// <param name="totalCost">the accumulated total cost of the invoice items for the given invoice</param>
    /// <returns>true if successful, false otherwise</returns>
    public static long AddInvoice(int salesPersonKey, int customerKey, string purchaseDate, List<Car> invoiceItems, decimal totalCost)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int result = 0;                         // Represents whether the query was successful
            int iRet = 0;                           // Represents how many rows are returned from the query
            DataSet ds;                             // Dataset to hold results from database queries
            int insertErrors = 0;                   // Represents the number of insert errors when inserting invoice items

            DateTime dtPurchaseDate = DateTime.Parse(purchaseDate);     //converted purchase date to a date time object

            // SQL Query to the database to insert an invoice
            string sqlQuery = "INSERT INTO Invoices (TotalCost, CustomerKey, SalesmenKey, PurchaseDate) VALUES (" + totalCost + ", " + customerKey + ", " + salesPersonKey + ", #" + dtPurchaseDate.ToString() + "#);";

            result = da.ExecuteNonQuery(sqlQuery);

            //if the result was successful, check if there are invoice items and insert them if needed, otherwise return just return the added invoice's id.
            if (result == 1)
            {
                //first retrieve the just added invoice key number of the invoice added
                sqlQuery = "SELECT InvoiceKey FROM Invoices WHERE CustomerKey = " + customerKey + " AND SalesmenKey = " + salesPersonKey + " AND PurchaseDate = #" + dtPurchaseDate.ToString() + "# AND TotalCost = " + totalCost + ";";
                ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

                //if the query didn't return anything return 0 as the invoice key, else continue to add the invoice items
                if (iRet > 0)
                {
                    long invoiceKey = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
                    //if there are items to insert, insert them keeping a running total of all failed inserts, if there are no failures return invoice key, otherwise still return the invoice key.
                    if (invoiceItems.Count > 0)
                    {
                        foreach (var item in invoiceItems)
                        {
                            sqlQuery = "INSERT INTO InvoiceItems (VIN, InvoiceKey) VALUES (" + Convert.ToInt64(item.vin) + ", " + invoiceKey + ")";
                            result = da.ExecuteNonQuery(sqlQuery);

                            if (result != 1)
                            {
                                insertErrors++;
                            }
                        }

                        return invoiceKey;
                    }
                    else
                        return invoiceKey;
                }
                else
                    return 0;
            }
            else
                return 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Method updates an invoice in the database
    /// </summary>
    /// <param name="invoiceID">invoice id number</param>
    /// <param name="salesPersonKey">ID of the sales person</param>
    /// <param name="customerKey">ID of the customer</param>
    /// <param name="purchaseDate">Date of purchase</param>
    /// <param name="invoiceItems">List of invoice items objects (car objects)</param>
    /// <param name="totalCost">the accumulated total cost of the invoice items for the given invoice</param>
    /// <returns>true if successful, false otherwise</returns>
    public static bool EditInvoice(int invoiceID, int salesPersonKey, int customerKey, string purchaseDate, List<Car> invoiceItems, decimal totalCost)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int result = 0;                         // Represents whether the query was successful
            int updateErrors = 0;                   // Represents the number of update errors when updating invoice items

            DateTime dtPurchaseDate = DateTime.Parse(purchaseDate);     //converted purchase date to a date time object

            // SQL Query to the database to update the given invoice
            string sqlQuery = "UPDATE Invoices SET TotalCost = " + totalCost + ", CustomerKey = "
                                + customerKey + ", SalesmenKey = " + salesPersonKey + ", PurchaseDate = #"
                                + dtPurchaseDate.ToString() + "# WHERE InvoiceKey = " + invoiceID + ";";

            result = da.ExecuteNonQuery(sqlQuery);

            //if the result was successful, check if there are invoice items and insert them if needed, otherwise return true
            if (result == 1)
            {
                //if there are items to update, update them keeping a running total of all failed updates, if there are no failures return true, otherwise false.
                if (invoiceItems.Count > 0)
                {
                    //Delete all prior invoice items and then insert the new ones to appear to be updating the items
                    sqlQuery = "DELETE FROM InvoiceItems WHERE InvoiceKey = " + invoiceID + ";";
                    result = da.ExecuteNonQuery(sqlQuery);

                    if (result == 1)
                    {
                        foreach (var item in invoiceItems)
                        {
                            sqlQuery = "INSERT INTO InvoiceItems (VIN, InvoiceKey) VALUES (" + Convert.ToInt64(item.vin) + ", " + invoiceID + ")";
                            result = da.ExecuteNonQuery(sqlQuery);

                            if (result != 1)
                            {
                                updateErrors++;
                            }
                        }

                        if (updateErrors == 0)
                        {
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return true;
            }
            else
                return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Method deletes an invoice from the database
    /// </summary>
    /// <param name="invoiceID">invoice id number</param>
    /// <returns>true if successful, false otherwise</returns>
    public static bool DeleteInvoice(int invoiceID)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows returned from a query
            int result = 0;                         // Represents whether the query was successful
            DataSet ds;                             // object that holds a query's result

            //Before deleting the invoice, delete the invoices items
            string sqlQuery = "SELECT * FROM InvoiceItems WHERE InvoiceKey = " + invoiceID + ";";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            //If there are invoice items to delete, delete them.  Then delete the invoice.
            if (iRet > 0)
            {
                sqlQuery = "DELETE FROM InvoiceItems WHERE InvoiceKey = " + invoiceID + ";";
                result = da.ExecuteNonQuery(sqlQuery);

                if (result > 0)
                {
                    // SQL Query to the database to delete the invoice
                    sqlQuery = "DELETE FROM Invoices WHERE InvoiceKey = " + invoiceID + ";";

                    result = da.ExecuteNonQuery(sqlQuery);

                    //check to see if the deletion was successful
                    if (result == 1)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
            {
                // SQL Query to the database to delete the invoice
                sqlQuery = "DELETE FROM Invoices WHERE InvoiceKey = " + invoiceID + ";";

                result = da.ExecuteNonQuery(sqlQuery);

                //check to see if the deletion was successful
                if (result == 1)
                    return true;
                else
                    return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method deletes and invoice item from an invoice in the database
    /// </summary>
    /// <param name="invoiceID">invoice ID number</param>
    /// <param name="vin">item ID vin number</param>
    /// <returns>true if successful, false otherwise</returns>
    public static bool DeleteInvoiceItem(int invoiceID, long vin)
    {
        try
        {
            clsDataAccess da = new clsDataAccess();   // Object that connects to the database and executes queries
            int result = 0;                           // Represents whether a database query was successful

            // SQL Query to the database to delete the given invoice item from the invoice
            string sqlQuery = "DELETE FROM InvoiceItems WHERE InvoiceKey = " + invoiceID + " AND VIN = " + vin + ";";
            result = da.ExecuteNonQuery(sqlQuery);

            //check if the deletion was successful
            if (result == 1)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method adds an inventory item to the database
    /// </summary>
    /// <param name="vin">the vin number of the vehicle</param>
    /// <param name="modelKey">the vehicle's model ID number</param>
    /// <param name="year">the vehicle's year</param>
    /// <param name="cost">the vehicle's cost</param>
    /// <returns>true if successful, false otherwise</returns>
    public static bool AddInventoryItem(long vin, int modelKey, int year, decimal cost)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int result = 0;                           // Represents whether the database query was successful

            // SQL Query to the database to add the new inventory item
            string sqlQuery = "INSERT INTO Inventory (VIN, ModelKey, Price, VehicleYear) VALUES (" + vin + "," + modelKey + ", " + cost + ", " + year + ");";
            result = da.ExecuteNonQuery(sqlQuery);

            //check to see if the insert was successful
            if (result == 1)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method updates an inventory item in the database
    /// </summary>
    /// <param name="vin">the vehicle's vin number</param>
    /// <param name="model">the vehicle's model ID number</param>
    /// <param name="year">the vehicle's year</param>
    /// <param name="cost">the cost of the vehicle</param>
    /// <returns>true if successful, false otherwise</returns>
    public static bool EditInventoryItem(long vin, int model, int year, decimal cost)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int result = 0;                         // Represents whether the query to the database was successful

            // SQL Query to the database to update the given inventory item
            string sqlQuery = "UPDATE Inventory SET ModelKey = " + model + ", SET Price = " + cost + ", SET VehicleYear = " + year + " WHERE VIN = " + vin + ";";
            result = da.ExecuteNonQuery(sqlQuery);

            //check to see if the update was successful
            if (result == 1)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method attempts to delete an inventory item, 
    /// but only deletes it if there are no current invoices containing this inventory item.
    /// </summary>
    /// <param name="vin">the vin number of the vehicle</param>
    /// <param name="invoiceIDs">the invoice ids that contain this item</param>
    /// <returns>true if successful, false if an invoice contains the item or deletion failure</returns>
    public static bool DeleteInventoryItem(long vin, ref string invoiceIDs)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows from a database query
            DataSet ds;                             // Dataset to hold results from database queries
            int result = 0;                         // Represents whether a query was successful

            // SQL Query to the database to see if there are any invoices with this item, if so return false and the invoice ids that contain the item.
            // Otherwise delete the item.
            string sqlQuery = "SELECT DISTINCT InvoiceKey FROM InvoiceItems WHERE VIN = " + vin + ";";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            if (iRet > 0)
            {
                //go through the dataset and populates the invoiceIDs string
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    if (x == 0)
                    {
                        invoiceIDs += ds.Tables[0].Rows[x][1].ToString();
                    }
                    else
                    {
                        invoiceIDs += ", " + ds.Tables[0].Rows[x][1].ToString();
                    }
                }
                return false;
            }
            else
            {
                //Delete the item from the database
                sqlQuery = "DELETE FROM Inventory WHERE VIN = " + vin + ";";
                result = da.ExecuteNonQuery(sqlQuery);

                //check to see if the deletion was successful
                if (result == 1)
                    return true;
                else
                    return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Retrieves all inventory item's and their IDs.
    /// The item's name will consist of the year, make, and model.
    /// </summary>
    /// <returns>the current inventory items' full names and ID's</returns>
    public static DataSet getInventoryItems()
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries

            //SQL Query to the database to search for all current inventory items, then return them in a dataset.
            string sqlQuery = "SELECT Inventory.VIN, FORMAT(VehicleYear, '0000') + ' ' + MakeName + ' ' + ModelName AS InventoryName " +
                              "FROM Inventory, Models, Makes " +
                              "WHERE Inventory.ModelKey = Models.ModelKey AND Models.MakeKey = Makes.MakeKey;";

            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Retrieves an inventory item's cost from the database 
    /// given a certain inventory ID.
    /// </summary>
    /// <param name="vin">the vin number of the vehicle</param>
    /// <returns>the inventory item's cost; format: $00.00</returns>
    public static string getInventoryItemCost(long vin)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            string cost;                            //string to hold the returned item's cost from the database

            //SQL Query to the database to retrieve the given inventory item's cost, then return it.
            string sqlQuery = "SELECT Price FROM Inventory WHERE VIN = " + vin + ";";
            cost = da.ExecuteScalarSQL(sqlQuery);

            return cost;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method retrieves all the invoices by a given cost
    /// </summary>
    /// <param name="cost">total cost for the invoices</param>
    /// <returns>List of all the invoices that fit the total cost criteria</returns>
    public static BindingList<Invoice> getInvoicesByCost(decimal cost)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries
            string customerName;                    // Customer Name retrieved from the database
            string salesPersonName;                 // Sales person name retrieved from the database

            //SQL Query to the database to search for invoices given a certain cost
            string sqlQuery = "SELECT * FROM Invoices WHERE TotalCost = " + cost + ";";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            //create a list of all the invoices, if there are invoices found, add them to the list
            BindingList<Invoice> invoices = new BindingList<Invoice>();

            if (iRet > 0)
            {
                //go through the dataset adding the invoices
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    customerName = getCustomerByID(Convert.ToInt32(ds.Tables[0].Rows[x][2].ToString()));
                    salesPersonName = getSalesPersonByID(Convert.ToInt32(ds.Tables[0].Rows[x][3].ToString()));

                    Invoice tempInvoice = new Invoice(ds.Tables[0].Rows[x][0].ToString(), customerName, salesPersonName, ds.Tables[0].Rows[x][4].ToString(), ds.Tables[0].Rows[x][1].ToString());
                    invoices.Add(tempInvoice);
                }
            }
            return invoices;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method retrieves all invoices by a given purchase date
    /// </summary>
    /// <param name="purchaseDate">purchase date for the invoices</param>
    /// <returns>List of all the invoices that fit the purchase date criteria</returns>
    public static BindingList<Invoice> getInvoicesByDate(string purchaseDate)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries
            string customerName;                    // Customer Name retrieved from the database
            string salesPersonName;                 // Sales person name retrieved from the database

            DateTime dtPurchaseDate = DateTime.Parse(purchaseDate); // convert the purchase date string to a date time object

            //SQL Query to the database to search for invoices given a certain purchase date
            string sqlQuery = "SELECT * FROM Invoices WHERE PurchaseDate = #" + dtPurchaseDate.ToString() + "#;";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            //create a list of all the invoices, if there are invoices found, add them to the list
            BindingList<Invoice> invoices = new BindingList<Invoice>();

            if (iRet > 0)
            {
                //go through the dataset adding the invoices
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    customerName = getCustomerByID(Convert.ToInt32(ds.Tables[0].Rows[x][2].ToString()));
                    salesPersonName = getSalesPersonByID(Convert.ToInt32(ds.Tables[0].Rows[x][3].ToString()));

                    Invoice tempInvoice = new Invoice(ds.Tables[0].Rows[x][0].ToString(), customerName, salesPersonName, ds.Tables[0].Rows[x][4].ToString(), ds.Tables[0].Rows[x][1].ToString());
                    invoices.Add(tempInvoice);
                }
            }
            return invoices;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method retrieve an invoice by its invoice id
    /// </summary>
    /// <param name="invoiceID">the invoice's id number</param>
    /// <returns>List of the searched for invoice</returns>
    public static BindingList<Invoice> getInvoiceByID(int invoiceID)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries
            string customerName;                    // Customer Name retrieved from the database
            string salesPersonName;                 // Sales person name retrieved from the database

            //SQL Query to the database to search for the given invoice
            string sqlQuery = "SELECT * FROM Invoices WHERE InvoiceKey = " + invoiceID + ";";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            //create a list of the invoice, if there is an invoice found, add it to the list
            BindingList<Invoice> invoices = new BindingList<Invoice>();

            if (iRet > 0)
            {
                //go through the dataset adding the invoice
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    customerName = getCustomerByID(Convert.ToInt32(ds.Tables[0].Rows[x][2].ToString()));
                    salesPersonName = getSalesPersonByID(Convert.ToInt32(ds.Tables[0].Rows[x][3].ToString()));

                    Invoice tempInvoice = new Invoice(ds.Tables[0].Rows[x][0].ToString(), customerName, salesPersonName, ds.Tables[0].Rows[x][4].ToString(), ds.Tables[0].Rows[x][1].ToString());
                    invoices.Add(tempInvoice);
                }
            }
            return invoices;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method retrieve an invoice by its invoice id, but for customers and sales person, only their id's are returned not their full names.
    /// </summary>
    /// <param name="invoiceID">the invoice's id number</param>
    /// <returns>List of the searched for invoice</returns>
    public static BindingList<Invoice> getInvoiceByIDNoNames(int invoiceID)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries

            //SQL Query to the database to search for the given invoice
            string sqlQuery = "SELECT * FROM Invoices WHERE InvoiceKey = " + invoiceID + ";";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            //create a list of the invoice, if there is an invoice found, add it to the list
            BindingList<Invoice> invoices = new BindingList<Invoice>();

            if (iRet > 0)
            {
                //go through the dataset adding the invoice
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    Invoice tempInvoice = new Invoice(ds.Tables[0].Rows[x][0].ToString(), ds.Tables[0].Rows[x][2].ToString(), ds.Tables[0].Rows[x][3].ToString(), ds.Tables[0].Rows[x][4].ToString(), ds.Tables[0].Rows[x][1].ToString());
                    invoices.Add(tempInvoice);
                }
            }
            return invoices;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method returns all of the invoices in the database
    /// </summary>
    /// <returns>List of all the invoices in the database</returns>
    public static BindingList<Invoice> getAllInvoices()
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries
            string customerName;                    // Customer Name retrieved from the database
            string salesPersonName;                 // Sales person name retrieved from the database

            //SQL Query to the database to retrieve all of the invoices
            string sqlQuery = "SELECT * FROM Invoices;";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            //create a list of the invoices, if there are invoices found, add them to the list
            BindingList<Invoice> invoices = new BindingList<Invoice>();

            if (iRet > 0)
            {
                //go through the dataset adding the invoices
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    customerName = getCustomerByID(Convert.ToInt32(ds.Tables[0].Rows[x][2].ToString()));
                    salesPersonName = getSalesPersonByID(Convert.ToInt32(ds.Tables[0].Rows[x][3].ToString()));

                    Invoice tempInvoice = new Invoice(ds.Tables[0].Rows[x][0].ToString(), customerName, salesPersonName, ds.Tables[0].Rows[x][4].ToString(), ds.Tables[0].Rows[x][1].ToString());
                    invoices.Add(tempInvoice);
                }
            }
            return invoices;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method retrieves a customer's full name given the customer ID
    /// </summary>
    /// <param name="customerKey">the customer's ID number</param>
    /// <returns>the customer's full name</returns>
    public static string getCustomerByID(int customerKey)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries
            string customerName = "";               // Represents the customer's full name

            // SQL Query to the database to retrieve the given customer
            string sqlQuery = "SELECT FirstName, LastName FROM Customers WHERE CustomerKey = " + customerKey + ";";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            //create the customer's full name from the database's results
            if (iRet > 0)
            {
                customerName = ds.Tables[0].Rows[0][0].ToString() + " " + ds.Tables[0].Rows[0][1].ToString();
                return customerName;
            }
            else
                return customerName;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Method retrieves a sales person's full name given the sales person ID
    /// </summary>
    /// <param name="salesPersonKey">the sales person's ID number</param>
    /// <returns>the sales person's full name</returns>
    public static string getSalesPersonByID(int salesPersonKey)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries
            string salesManName = "";               // Represents the sale person's full name

            // SQL Query to the database to retrieve the given sales person
            string sqlQuery = "SELECT FirstName, LastName FROM Salesmen WHERE SalesmanKey = " + salesPersonKey + ";";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            //create the customer's full name from the database's results
            if (iRet > 0)
            {
                salesManName = ds.Tables[0].Rows[0][0].ToString() + " " + ds.Tables[0].Rows[0][1].ToString();
                return salesManName;
            }
            else
                return salesManName;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Retrieves all of the customers and their IDs from the database.
    /// </summary>
    /// <returns>all the customers and their IDs</returns>
    public static DataSet getCustomers()
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries

            //SQL Query to the database to search for all customers, then return them in a dataset.
            string sqlQuery = "SELECT CustomerKey, FirstName + ' ' + LastName AS CustomerName FROM Customers;";

            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// method that returns a dataset containing a distinct list of invoice id's
    /// </summary>
    /// <returns>dataset containing invoice ids</returns>
    public static DataSet getDistinctInvoiceIDs()
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); //Data Access object to query database
            DataSet ds; //Data set to store results of SQL statement
            string sInvoiceSQL = "SELECT DISTINCT InvoiceKey FROM Invoices"; //SQL statement to execute

            int iTotalResults = 0;  //Number of results that came back from SQL statement

            //Run the statement and store the result into the dataset
            ds = da.ExecuteSQLStatement(sInvoiceSQL, ref iTotalResults);

            //return the dataset
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// method that returns a dataset containing a distinct list of invoice Dates
    /// </summary>
    /// <returns>dataset containing invoice Dates</returns>
    public static DataSet getDistinctInvoiceDates()
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); //Data Access object to query database
            DataSet ds; //Data set to store results of SQL statement
            string sDateSQL = "SELECT DISTINCT PurchaseDate FROM Invoices"; //SQL statement to execute

            int iTotalResults = 0;  //Number of results that came back from SQL statement

            //Run the statement and store the result into the dataset
            ds = da.ExecuteSQLStatement(sDateSQL, ref iTotalResults);

            //return the dataset
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// method that returns a dataset containing a distinct list of invoice Cost values
    /// </summary>
    /// <returns>dataset containing invoice Cost values</returns>
    public static DataSet getDistinctInvoiceCosts()
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); //Data Access object to query database
            DataSet ds; //Data set to store results of SQL statement
            string sCostSQL = "SELECT DISTINCT TotalCost FROM Invoices"; //SQL statement to execute

            int iTotalResults = 0;  //Number of results that came back from SQL statement

            //Run the statement and store the result into the dataset
            ds = da.ExecuteSQLStatement(sCostSQL, ref iTotalResults);

            //return the dataset
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Retrieves all of the sales people and their IDs from the database.
    /// </summary>
    /// <returns>all the sales people and their IDs</returns>
    public static DataSet getSalesPersons()
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries

            //SQL Query to the database to search for all sales people, then return them in a dataset.
            string sqlQuery = "SELECT SalesmanKey, FirstName + ' ' + LastName AS SalesName FROM Salesmen;";

            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Retrieves the current model names from the database and their model keys. 
    /// </summary>
    /// <returns>All the current model names and their keys</returns>
    public static DataSet getModels()
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries

            //SQL Query to the database to search for all current Models, then return them in a dataset.
            string sqlQuery = "SELECT Models.ModelKey, Models.ModelName FROM Models";

            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Adds the care to the database
    /// </summary>
    /// <param name="model">Model of the car that you want to insert</param>
    /// <param name="vin">Vin of the car</param>
    /// <param name="price">Price of the car</param>
    /// <param name="year">Year of the car</param>
    /// <param name="description">Description of the car</param>
    public static void addCar(string model, string vin, double price, int year, string description)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries

            //sets the sql query to get the model key and executes it.  Also stores the model number into the int model number
            string sqlQuery = "SELECT Models.ModelKey FROM Models WHERE Models.ModelName = '" + model + "'";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);
            int modelNumber = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            //sets the sql query to insert the values into the inventory table
            sqlQuery = "INSERT INTO Inventory(VIN, ModelKey, Price, VehicleYear, Sold, Description) VALUES('" + vin + "', " + modelNumber + ", " + price + ", " + year + ", 0 , '" + description + "');";
            da.ExecuteNonQuery(sqlQuery);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    /// <summary>
    /// Checks to see if the vin exists on a invoice.
    /// </summary>
    /// <param name="vin">Vin that you are wanting to delete</param>
    /// <returns>false if the item does not exist on an invoice.  true if a car is on an invoice</returns>
    public static bool vinExistsOnInvoice(string vin)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries

            //query to get the vin to see if it is on an invoice or not
            string sqlQuery = "SELECT InvoiceItems.Vin FROM InvoiceItems WHERE InvoiceItems.VIN = '" + vin + "';";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            //checks to see if the vin is on an invoice
            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    /// <summary>
    /// Deletes the car from the inventory table
    /// Make sure you see if that vin exists on an invoice.
    /// </summary>
    /// <param name="vin">Vin of the car that you want to delete.</param>
    public static void deleteCar(string vin)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            DataSet ds;                             // Dataset to hold results from database queries

            string sqlQuery = "DELETE INVENTORY FROM Inventory WHERE Inventory.Vin = '" + vin + "';";

            da.ExecuteNonQuery(sqlQuery);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Michael Meyer
    /// <summary>
    /// Method retrieves all the invoices by a given cost
    /// </summary>
    /// <param name="cost">total cost for the invoices</param>
    /// <returns>List of all the invoices that fit the total cost criteria</returns>
    public static BindingList<Car> getCarList()
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries

            //SQL Query to the database to search for invoices given a certain cost
            string sqlQuery = "SELECT Models.ModelName, Inventory.VIN, Inventory.Price, Inventory.VehicleYear, Inventory.Description FROM Inventory INNER JOIN Models ON Models.ModelKey = Inventory.ModelKey";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            //create a list of all the invoices, if there are invoices found, add them to the list
            BindingList<Car> cars = new BindingList<Car>();

            if (iRet > 0)
            {
                //go through the dataset adding the invoices
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    //Car(string passedModel, int passedYear, decimal passedPrice, string passedVin, string passedDescription)
                    Car tempCar = new Car(ds.Tables[0].Rows[x][0].ToString(), Convert.ToInt32(ds.Tables[0].Rows[x][3].ToString()), Convert.ToDecimal(ds.Tables[0].Rows[x][2].ToString()), ds.Tables[0].Rows[x][1].ToString(), ds.Tables[0].Rows[x][4].ToString());
                    cars.Add(tempCar);
                }
            }
            return cars;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Retrieves a specific car's details from the databases inventory.
    /// </summary>
    /// <param name="vin">the vehicle's vin number</param>
    /// <returns>the requested car object; null if the car searched for wasn't found.</returns>
    public static Car getCarByVIN(long vin)
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            int iRet = 0;                           // Represents the number of rows
            DataSet ds;                             // Dataset to hold results from database queries

            // SQL Query to the database to retrieve the given car from inventory
            string sqlQuery = "SELECT VIN, Models.ModelName, Price, VehicleYear, Description FROM Inventory, Models WHERE Inventory.ModelKey = Models.ModelKey AND VIN = " + vin + ";";
            ds = da.ExecuteSQLStatement(sqlQuery, ref iRet);

            //create the customer's full name from the database's results
            if (iRet > 0)
            {
                return new Car(ds.Tables[0].Rows[0][1].ToString(), Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString()), Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString()), ds.Tables[0].Rows[0][0].ToString(), ds.Tables[0].Rows[0][4].ToString());
            }
            else
                return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Method returns the next invoice key to be created.
    /// </summary>
    /// <returns>the next invoice key number, or 0 if the next invoice key number couldn't be retrieved</returns>
    public static int getNextInvoiceKey()
    {
        try
        {
            clsDataAccess da = new clsDataAccess(); // Object that connects to the database and executes queries
            string result = "";                     // Represents the returned string value form the database
            bool validatorResult = false;           //Represents whether the returned database result is a number.

            // SQL Query to the database to retrieve the max invoice key
            string sqlQuery = "SELECT MAX(InvoiceKey) FROM Invoices;";
            result = da.ExecuteScalarSQL(sqlQuery);

            //check to see if the string returned isn't empty.  Then check to see if it is a number.
            if (!String.IsNullOrEmpty(result))
            {
                validatorResult = dv.isNumber(result);

                if (validatorResult)
                {
                    return (Convert.ToInt32(result) + 1);
                }
                else
                    return 0;
            }
            else
                return 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
