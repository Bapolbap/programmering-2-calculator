using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_calculator
{
    class Operation
    {

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
