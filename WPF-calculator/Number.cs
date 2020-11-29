using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_calculator
{
    class Number
    {
        public string addedNumber = "";

        /*append the last number in computaArray*/
        public void AppendNumber(string numberToAdd)
        {
            switch (numberToAdd)
            {
                /*for the regular numbers, not much has to be done*/
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

                /*in the case of zero, we don't want to be able to write something like "00,1"
                 so we must cover the case where two or more zeros can be wirtten before a comma*/
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

                /*in the case of the comma, we want to make it so if the user presses the comma before anything else, we still get something usable
                 we also don't want to be able to have more than one comma per number*/
                case ",":
                    if ((addedNumber.Length == 0) || (addedNumber.Length == 1 && addedNumber[0] == '-'))
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

                /*if there is already a minus in front of the number, we want to remove it
                 else, add one to the front of the number*/
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

        /*check if the given string is able to be converted to a double*/
        public static bool IsNumber(string stringToCheck)
        {
            try
            {
                var isNumber = Convert.ToDouble(stringToCheck);
                return true; //if an exception is thrown, this line won't be read
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
