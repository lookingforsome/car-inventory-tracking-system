using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Reflection;

/// <summary>
/// Built to validate data entered into a text box, but works for all strings
/// </summary>
class dataValidator
{
    #region methods

    /// <summary>
    /// Tests the string to see if it is a digit or not.
    /// </summary>
    /// <param name="userInput">String that the user passes in.</param>
    /// <returns>True if it is a number, false if it is not a number.</returns>
    public bool isNumber(string userInput)
    {
        try
        {
            //Temp variable just so we can use the try parse method.
            int s = 0;

            //Takes the user input and validates if it is a number or not.
            if (int.TryParse(userInput, out s))
            {
                //The string entered in is a number.
                return true;
            }
            else
            {
                //The string entered in was not a number.
                return false;
            }
        }
        catch (Exception ex)
        {
            HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                        MethodInfo.GetCurrentMethod().Name, ex.Message);

            //Returns false due to an error
            return false;
        }

    }

    //http://stackoverflow.com/questions/1046740/how-to-validate-a-string-to-only-allow-alphanumeric-characters-in-it-regex
    /// <summary>
    /// Tests the string passed in to see if it is alphanumeric.
    /// </summary>
    /// <param name="userInput">String that is passed in.</param>
    /// <returns>True if it is alphanumeric, false if it is not alphanumeric.</returns>
    public bool isAlphaNumeric(string userInput)
    {
        try
        {
            //Creates an alphanumeric regualr expression to compare the string passed in to.
            Regex alphanumeric = new Regex("^[a-zA-Z0-9]*$");

            //Compares the userInput to the alphanumeric regex
            if (alphanumeric.IsMatch(userInput))
            {
                //UserInput is alphanumeric
                return true;
            }
            else
            {
                //UserInput is not alphanumeric
                return false;
            }
        }
        catch (Exception ex)
        {
            HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                        MethodInfo.GetCurrentMethod().Name, ex.Message);

            //will return false due to error
            return false;
        }

    }

    /// <summary>
    /// Tests the string passed in to see if it is just letters
    /// </summary>
    /// <param name="userInput">String that is passed in to be tested.</param>
    /// <returns>True if it is just letters, false if it includes other characters.</returns>
    public bool isJustLetters(string userInput)
    {
        try
        {
            //Creates a letter regualr expression to compare the string passed in to.
            Regex letters = new Regex("^[a-zA-Z]*$");

            //Compares the userInput to the letters regex
            if (letters.IsMatch(userInput))
            {
                //UserInput are letters
                return true;
            }
            else
            {
                //UserInput are letters
                return false;
            }
        }
        catch (Exception ex)
        {
            HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                        MethodInfo.GetCurrentMethod().Name, ex.Message);

            //will return false due to error
            return false;
        }

    }
    /// <summary>
    /// Tests the string passed into to see if it is a valid date time.
    /// </summary>
    /// <param name="date">string that is passed into to be tested.</param>
    /// <returns>True if it is a valid date and time, false otherwise.</returns>
    public bool isDate(string dateTime)
    {
        try
        {
            //create a temporary date time variable to house the tested output of the try parse.
            DateTime tempDate;

            if (DateTime.TryParse(dateTime, out tempDate))
            {
                return true;
            }
            else
                return false;
        }
        catch (Exception ex)
        {
            HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                        MethodInfo.GetCurrentMethod().Name, ex.Message);

            //will return false due to error
            return false;
        }
    }

    /// <summary>
    /// Handle the error.
    /// </summary>
    /// <param name="sClass">The class in which the error occurred in.</param>
    /// <param name="sMethod">The method in which the error occurred in.</param>
    public void HandleError(string sClass, string sMethod, string sMessage)
    {
        try
        {
            //Would write to a file or database here.
            MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
        }
        catch (Exception ex)
        {
            System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                         "HandleError Exception: " + ex.Message);
        }
    }

    #endregion
}

