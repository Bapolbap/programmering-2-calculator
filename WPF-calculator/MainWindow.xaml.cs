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
        private Number _number = new Number();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void initializeComponents()
        {
            List<string> computeArray = new List<string>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(e.Source is Button button)
            {
                switch (button.Content)
                {
                    case "0":
                        if(Textfield.Text.Length >= 1 && Textfield.Text[0] != '0')
                        {
                            Textfield.Text += button.Content;
                        }
                    break;

                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "=":
                        Textfield.Text += button.Content;
                    break;

                    case "AC":
                        Textfield.Text = "";
                    break;

                    case ".":
                        if(Textfield.Text.Length == 0)
                        {
                            Textfield.Text += "0.";
                        } else if(Textfield.Text.Contains("."))
                        {
                            //gör inget
                            break;
                        }
                        else
                        {
                            Textfield.Text += ".";
                        }
                    break;

                    case "±":
                        if(Textfield.Text.Length != 0)
                        {
                            if (Textfield.Text[0] == '-')
                            {
                                Textfield.Text = Textfield.Text.Substring(1);
                            }
                            else
                            {
                                Textfield.Text = "-" + Textfield.Text;
                            }
                        } else
                        {
                            Textfield.Text = "-";
                        }

                    break;

                    case "+":
                    case "-":
                    case "×":
                    case "÷":
                    case "( )":

                    break;
                }
            }
        }

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
                    while((operatorStack.Count != 0) && (Operation.Priority(operatorStack.Last()) > Operation.Priority(i)) && (operatorStack.Last() != "("))
                    {
                        postfixStack.Add(operatorStack.Last());
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
                    }

                    if(operatorStack.Last() == "(")
                    {
                        operatorStack.RemoveAt(operatorStack.Count - 1);
                    }
                }
            }

            while(operatorStack.Count != 0)
            {
                postfixStack.Add(operatorStack.Last());
            }

            return postfixStack;
        }

    }
}
