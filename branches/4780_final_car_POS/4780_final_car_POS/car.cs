using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    class car
    {
        #region constructor
       
            public car(int passedMake, int passedModel, int passedYear, string passedVin, decimal passedPrice)
            {
                //sets the attributes of the car
                make = passedMake;
                model = passedModel;
                year = passedYear;
                vin = passedVin;
                price = passedPrice;

            }

        #endregion

        #region variables/properties
        
            /// <summary>
            /// Stores the make of the car
            /// </summary>
            public int make {get; set;}

            /// <summary>
            /// Stores the model of the car
            /// </summary>
            public int model { get; set; }

            /// <summary>
            /// stores the year of the car
            /// </summary>
            public int year { get; set; }

            /// <summary>
            /// Stores the vin of the car
            /// </summary>
            public string vin { get; set; }

            /// <summary>
            /// Stores the price of the car
            /// </summary>
            public decimal price { get; set; }

        #endregion

        #region methods

        #endregion
    }
