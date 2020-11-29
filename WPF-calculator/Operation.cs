using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_calculator
{
    class Operation
    {
        /*abandon all hope, ye who enter
         a bunch of special cases for how parentheses should be added, depending on if there are the same number of left and right parentheses or not,
        and if the last element in the computeArray is a number, operator, left parenthesis, or right parenthesis.*/
        public List<string> AddParenthesis(List<string> computeArray)
        {
            List<string> parenthesis = new List<String>();
            int leftParenthesisCounter = 0;
            int rightParenthesisCounter = 0;

            if(!(computeArray.Count == 1 && computeArray[0] == ""))
            {
                foreach (string i in computeArray)
                {
                    if(i == "(")
                    {
                        leftParenthesisCounter++;
                    }
                    else if(i == ")")
                    {
                        rightParenthesisCounter++;
                    }
                }
                if(leftParenthesisCounter == rightParenthesisCounter){
                    if(Number.IsNumber(computeArray[computeArray.Count - 1]))
                    {
                        parenthesis.Add("×");
                        parenthesis.Add("(");
                    }
                    else if(computeArray[computeArray.Count - 2] == ")")
                    {
                        computeArray.RemoveAt(computeArray.Count - 1);
                        parenthesis.Add("×");
                        parenthesis.Add("(");
                    }
                    else if(IsOperation(computeArray[computeArray.Count - 2]))
                    {
                        parenthesis.Add("(");
                    }
                } 
                else if(leftParenthesisCounter > rightParenthesisCounter)
                {
                    if(IsOperation(computeArray[computeArray.Count - 2]) && !Number.IsNumber(computeArray[computeArray.Count - 1]))
                    {
                        computeArray.RemoveAt(computeArray.Count - 1);
                        parenthesis.Add("(");
                    }
                    else if(Number.IsNumber(computeArray[computeArray.Count - 1]))
                    {
                        parenthesis.Add(")");
                    }
                    else if(computeArray[computeArray.Count - 2] == ")")
                    {
                        computeArray.RemoveAt(computeArray.Count - 1);
                        parenthesis.Add(")");
                    }
                    else if(computeArray[computeArray.Count - 2] == "(")
                    {
                        computeArray.RemoveAt(computeArray.Count - 1);
                        parenthesis.Add("(");
                    }
                }
            }
            else
            {
                parenthesis.Add("(");
            }

            return parenthesis;
        }

        /*check if the input is one of the accepted operators*/
        public static bool IsOperation(string stringToCheck)
        {
            switch (stringToCheck)
            {
                case "+":
                case "-":
                case "×":
                case "÷":
                    return true;
                default:
                    return false;
            }
        }

        /*check what the priority is for the given operation*/
        public static int Priority(string operatorString)
        {
            switch (operatorString)
            {
                case "+":
                case "-":
                    return 1;
                case "×":
                case "÷":
                    return 2;
                default:
                    return 0;
            }
        }
    }
}
