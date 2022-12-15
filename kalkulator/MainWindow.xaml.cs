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

namespace kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double firstNumber, secondNumber, result = 0;
        string whatToDo;
        string secondNumberS;
        bool a = true;
        bool end = false;
        string content;
        string prevContent;
        public MainWindow()
        {
            InitializeComponent();
        }
        double calculate()
        {
            if (whatToDo == "+")
            {
                return add();
            }
            else if (whatToDo == "-")
            {
                return sub();
            }
            else if (whatToDo == "*")
            {
                return mul();
            }
            else
                return div();
        }
        double add()
        {
            return firstNumber + secondNumber;
        }
        double sub()
        {
            return firstNumber - secondNumber;
        }
        double mul()
        {
            return firstNumber * secondNumber;
        }
        double div()
        {
            return firstNumber / secondNumber;
        }
        void reset ()
        {
            end = false;
            a = true;
            secondNumberS = "";
            firstNumber = secondNumber = 0;
            Text.Text = "";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            prevContent = content;
            content = (sender as Button).Content.ToString();
            
            if (end == true)
            {
                reset();
            }
            if (a == false && content != "=")
            {
                secondNumberS += content;
            }

            if (content == "=")
            {
                end = true;
                secondNumber = double.Parse(secondNumberS);
                Text.Text += content;
                result = calculate();
                Text.Text += result;
            }
            else if (content == "+" || content =="-" || content == "*" || content == "/")
            {
                if (prevContent == "=")
                {
                    firstNumber = result;
                    Text.Text += result;
                }
                else
                    firstNumber = double.Parse(Text.Text);

                a = false;
                whatToDo = content;
                Text.Text += content;
            }
            else
            {
                Text.Text += content;
            }
        }
    }
}
