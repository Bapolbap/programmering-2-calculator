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
            if(Int32.TryParse(stringToCheck, out int number))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
