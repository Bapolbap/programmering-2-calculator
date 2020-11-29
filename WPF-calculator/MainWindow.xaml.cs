using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> computeArray = new List<string>();
        private Number _number = new Number();
        private Operation _operation = new Operation();
        public MainWindow()
        {
            computeArray.Add("");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(e.Source is Button button)
            {
                switch (button.Content)
                {
                    case "0":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case ",":
                    case "±":
                        Textfield.Text = "";
                        _number.AppendNumber(Convert.ToString(button.Content));
                        if(computeArray.Count > 0)
                        {
                            computeArray[computeArray.Count - 1] = _number.addedNumber;
                        }
                        PrintCurrentExpression();

                    break;

                    case "+":
                    case "-":
                    case "×":
                    case "÷":
                        if(computeArray.Count > 0)
                        {
                            //computeArray.Add(_number.addedNumber);
                            _number.addedNumber = "";
                            computeArray.Add(Convert.ToString(button.Content));
                            computeArray.Add("");
                        }
                        PrintCurrentExpression();
                    break;

                    case "( )":
                        foreach(string i in _operation.AddParenthesis(computeArray))
                        {
                            computeArray.Add(i);
                        }
                        _number.addedNumber = "";
                        computeArray.Add("");
                        PrintCurrentExpression();
                        break;

                    case "=": 
                        var result = ComputePostfix(ShuntingYard(computeArray));
                        computeArray.Clear();
                        computeArray.Add(result);
                        _number.addedNumber = "";
                        PrintCurrentExpression();
                        break;

                    case "AC":
                        computeArray.Clear();
                        computeArray.Add("");
                        Textfield.Text = "";
                        _number.addedNumber = "";
                        break;
                }
            }
        }


        private void PrintCurrentExpression()
        {
            Textfield.Text = "";
            foreach(string i in computeArray)
            {
                Textfield.Text += i;
            }
        }

        //translated the pseudocode example on the shunting yard wikipedia page to c#
        private List<string> ShuntingYard(List<string> infixStack)
        {
            List<string> postfixStack = new List<string>();
            List<string> operatorStack = new List<string>();

            foreach(string i in infixStack)
            {
                if(Number.IsNumber(i))
                {
                    postfixStack.Add(i);
                }
                else if(Operation.IsOperation(i))
                {
                    while((operatorStack.Count != 0) && (Operation.Priority(operatorStack.Last()) >= Operation.Priority(i)) && (operatorStack.Last() != "("))
                    {
                        postfixStack.Add(operatorStack.Last());
                        operatorStack.RemoveAt(operatorStack.Count - 1);
                    }
                    operatorStack.Add(i);
                }
                else if(i == "(")
                {
                    operatorStack.Add(i);
                }
                else if(i == ")")
                {
                    while(operatorStack.Last() != "(")
                    {
                        postfixStack.Add(operatorStack.Last());
                        operatorStack.RemoveAt(operatorStack.Count - 1);
                    }

                    if (operatorStack.Last() == "(")
                    {
                        operatorStack.RemoveAt(operatorStack.Count - 1);
                    }
                }
            }

            while(operatorStack.Count != 0)
            {
                postfixStack.Add(operatorStack.Last());
                operatorStack.RemoveAt(operatorStack.Count - 1);
            }

            return postfixStack;
        }

        private string ComputePostfix(List<string> postfixStack)
        {
            List<double> numberStack = new List<double>();

            foreach(string i in postfixStack)
            {
                if(Number.IsNumber(i))
                {
                    numberStack.Add(Convert.ToDouble(i));
                }
                else if(Operation.IsOperation(i))
                {
                    var number1 = numberStack[numberStack.Count - 1];
                    var number2 = numberStack[numberStack.Count - 2];
                    numberStack.RemoveAt(numberStack.Count - 1);
                    numberStack.RemoveAt(numberStack.Count - 1);

                    double result;

                    switch(i)
                    {
                        case "+": result = number2 + number1; break;
                        case "-": result = number2 - number1; break;
                        case "×": result = number2 * number1; break;
                        case "÷": result = number2 / number1; break;
                        default: result = 0; break;
                    }

                    numberStack.Add(result);
                }
            }
            string answer = Convert.ToString(numberStack[0]);
            return answer;
        }

    }
}
