using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    class car
    {
        #region constructor
       
            public car(int passedModel, int passedYear, decimal passedPrice)
            {
                //sets the attributes of the car
                model = passedModel;
                year = passedYear;
                price = passedPrice;
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

        #endregion

        #region methods

        #endregion
    }
