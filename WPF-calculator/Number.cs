using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_calculator
{
    class Number
    {
        public string currentNumber = "";
        public void AddNumber(string numberToAdd)
        {
            currentNumber += numberToAdd;
            
        }

        public static bool IsNumber(string stringToCheck)
        {
            try
            {
                var isNumber = Convert.ToDouble(stringToCheck);
                return true; //if an exception is caught, this line won't be read
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
