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
        public MainWindow()
        {
            InitializeComponent();
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
                        if(Textfield.Text[0] == '-')
                        {
                            Textfield.Text = Textfield.Text.Substring(1);
                        } else
                        {
                            Textfield.Text = "-" + Textfield.Text;
                        }
                    break;

                    case "+":
                    case "-":
                    case "×":
                    case "÷":
                    case "%":
                        if(Textfield.Text.Length != 0)
                        {
                            Console.WriteLine("bruh");
                        }
                    break;
                }
            }
        }

    }
}
