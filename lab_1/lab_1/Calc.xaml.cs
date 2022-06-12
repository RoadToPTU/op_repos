using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab_1
{
    /// <summary>
    /// Логика взаимодействия для DB.xaml
    /// </summary>
    /// 
  
    public partial class Calc : Window
    {
        string value = "0";
        int sign;
        public Calc()
        {
            InitializeComponent();
            
        }
        private void ToHome(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            mw.Show();
            Hide(); 
        }


        static string f_calc(string a, string b, int sign)
        {
            switch (sign)
            {
                case 1: return (double.Parse(a) + double.Parse(b)).ToString();
                case 2: return (double.Parse(a) - double.Parse(b)).ToString();
                case 3: return (double.Parse(a) * double.Parse(b)).ToString();
                case 4: return (double.Parse(a) / double.Parse(b)).ToString();
                default: return "!";
            }


        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox.Text += "0";
        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            textBox.Text = f_calc(value, textBox.Text, sign);
        }

       

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            textBox.Text += "1";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            textBox.Text += "2";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            textBox.Text += "3";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            textBox.Text += "4";
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            textBox.Text += "5";
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            textBox.Text += "6";
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            textBox.Text += "7";
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            textBox.Text += "8";        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            textBox.Text += "9";
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            value = textBox.Text;
            textBox.Text = "";
            sign = 4;
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            value = textBox.Text;
            textBox.Text = "";
            sign = 3;        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            value = textBox.Text;
            textBox.Text = "";
            sign = 2;
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            value = textBox.Text;
            textBox.Text = "";
            sign = 1;
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            textBox.Text += ",";
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            if(textBox.Text[0] == '-')
            {
                textBox.Text = textBox.Text.Substring(1);
            }
            else
            {
                textBox.Text = "-"+textBox.Text;
            }
            
            
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            textBox.Text = textBox.Text.Substring(0,textBox.Text.Length-1);
            
            
        }
    }
}
