using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_calculator
{
    class Number
    {
        public string addedNumber = "";
        public void AppendNumber(string numberToAdd)
        {
            switch (numberToAdd)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    addedNumber += numberToAdd;
                break;

                case "0":
                    if(addedNumber.Length < 0)
                    {
                        try
                        {
                            if(addedNumber[1] == ',')
                            {
                                addedNumber += numberToAdd;
                            }
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                    else
                    {
                        addedNumber += numberToAdd;
                    }
                break;

                case ",":
                    if (addedNumber.Length == 0)
                    {
                        addedNumber += "0,";
                    }
                    else if (addedNumber.Contains(","))
                    {
                        break;
                    }
                    else
                    {
                        addedNumber += ",";
                    }
                    break;

                case "±":
                    if (addedNumber.Length != 0)
                    {
                        if (addedNumber[0] == '-')
                        {
                            addedNumber = addedNumber.Substring(1);
                        }
                        else
                        {
                            addedNumber = "-" + addedNumber;
                        }
                    }
                    else
                    {
                        addedNumber = "-";
                    }
                    break;

            }
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
