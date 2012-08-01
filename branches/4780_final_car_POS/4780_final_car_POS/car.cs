using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    class Car
    {
        #region constructor
       
            public Car(int passedModel, int passedYear, decimal passedPrice, string passedVin, string passedDescription)
            {
                //sets the attributes of the car
                model = passedModel;
                year = passedYear;
                price = passedPrice;
                vin = passedVin;
                description = passedDescription;

            }

        #endregion

        #region variables/properties

            /// <summary>
            /// Stores the model of the car
            /// </summary>
            public int model { get; set; }

            /// <summary>
            /// stores the year of the car
            /// </summary>
            public int year { get; set; }

            /// <summary>
            /// Stores the price of the car
            /// </summary>
            public decimal price { get; set; }

            /// <summary>
            /// Stores the VIN of the car
            /// </summary>
            public string vin { get; set; }

            /// <summary>
            /// Stores the description for the car
            /// </summary>
            public string description { get; set; }

        #endregion

        #region methods

        #endregion
    }
