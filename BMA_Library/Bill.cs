using System;
using System.Collections.Generic;
using System.Text;
using BMA_Database.Models;


namespace BMA_Library
{
    public static class Bill
    {
        #region Bill Properties

        private static readonly double taxRate = 0.11125;
        private static readonly double gratiutyRate = 0.18;

        #endregion

        /// <summary>
        /// This method take in a list of order price and sum them up. 
        /// Then the method calculate the tax, gratiuty and the total.
        /// </summary>
        /// <param name="orderPrice"></param>
        /// <param name="tax"></param>
        /// <param name="totalPrice"></param>
        /// <param name="gratiuty"> will return 0 if it's not a big group </param>
        /// <param name="isBigGroup"></param>
        public static void calculation(List<Contain> orderList, out double tax, out double totalPrice, out double gratiuty, bool isBigGroup = false)
        {
            getPrice(orderList);

            double totalOrderPrice = 0;
            

            tax = totalOrderPrice * taxRate;
            gratiuty = (isBigGroup) ? totalOrderPrice * gratiutyRate : 0;
            totalPrice = totalOrderPrice + tax + gratiuty;   
        }

        public static void getPrice(List<Contain> orderList)
        {

        }

        public static void print()
        {
            //to print out the bill
        }
    }
}
