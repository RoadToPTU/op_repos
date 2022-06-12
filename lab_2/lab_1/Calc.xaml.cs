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
        char sign;
        TextBox textBox = new TextBox();
        public Calc()
        {
            InitializeComponent();
            Grid grid1 = new Grid();
            var tc = new RowDefinition();
            var gridLengthConverter = new GridLengthConverter();
            tc.Height = (GridLength)gridLengthConverter.ConvertFrom("3*");
            grid1.RowDefinitions.Add(tc);
            grid1.RowDefinitions.Add(new RowDefinition());

            var tcc = new ColumnDefinition();
            tcc.Width = (GridLength)gridLengthConverter.ConvertFrom("3*");

            grid1.ColumnDefinitions.Add(new ColumnDefinition());
            grid1.ColumnDefinitions.Add(tcc);
            grid1.ColumnDefinitions.Add(new ColumnDefinition());
            grid1.ColumnDefinitions.Add(new ColumnDefinition());

            Button button_tohome = new Button();
            button_tohome.Content = "Back";
            button_tohome.HorizontalAlignment = HorizontalAlignment.Center;
            button_tohome.VerticalAlignment = VerticalAlignment.Center;
            button_tohome.Width = 267;
            button_tohome.Height = 74;
            button_tohome.FontSize = 36;
            button_tohome.Click += ToHome;
            Grid.SetColumn(button_tohome, 3);
            Grid.SetRow(button_tohome, 1);
            grid1.Children.Add(button_tohome);
            Grid calc_grid = new Grid();
            for (int i = 0; i < 6; i++)
                calc_grid.RowDefinitions.Add(new RowDefinition());
            for (int j = 0; j < 4; j++)
                calc_grid.ColumnDefinitions.Add(new ColumnDefinition());
            Grid.SetColumn(calc_grid, 1);
            Grid.SetRowSpan(calc_grid, 2);
            grid1.Children.Add(calc_grid);
            Grid.SetColumnSpan(textBox, 4);
            textBox.FontSize = 50;
            textBox.TextAlignment = TextAlignment.Right;
            
           
            calc_grid.Children.Add(textBox);
            calc_grid.Children.Add(ButGenerator(3, 2, "+", (object s, RoutedEventArgs e) => math(s, e, '+')));
            calc_grid.Children.Add(ButGenerator(3, 3, "-", (object s, RoutedEventArgs e) => math(s, e, '-')));
            calc_grid.Children.Add(ButGenerator(3, 4, "×", (object s, RoutedEventArgs e) => math(s, e, '*')));
            calc_grid.Children.Add(ButGenerator(3, 5, "÷", (object s, RoutedEventArgs e) => math(s, e, '/')));
            calc_grid.Children.Add(ButGenerator(1, 1, "<-", Button_Clear));
            calc_grid.Children.Add(ButGenerator(2, 1, "c", Button_C));
            calc_grid.Children.Add(ButGenerator(0, 5, "+/-", Button_Revers));
            calc_grid.Children.Add(ButGenerator(3, 1, "=", Button_Ecval));
            calc_grid.Children.Add(ButGenerator(0, 2, "1", (object s, RoutedEventArgs e) => textBox.Text += "1"));
            calc_grid.Children.Add(ButGenerator(1, 2, "2", (object s, RoutedEventArgs e) => textBox.Text += "2"));
            calc_grid.Children.Add(ButGenerator(2, 2, "3", (object s, RoutedEventArgs e) => textBox.Text += "3"));
            calc_grid.Children.Add(ButGenerator(0, 3, "4", (object s, RoutedEventArgs e) => textBox.Text += "4"));
            calc_grid.Children.Add(ButGenerator(1, 3, "5", (object s, RoutedEventArgs e) => textBox.Text += "5"));
            calc_grid.Children.Add(ButGenerator(2, 3, "6", (object s, RoutedEventArgs e) => textBox.Text += "6"));
            calc_grid.Children.Add(ButGenerator(0, 4, "7", (object s, RoutedEventArgs e) => textBox.Text += "7"));
            calc_grid.Children.Add(ButGenerator(1, 4, "8", (object s, RoutedEventArgs e) => textBox.Text += "8"));
            calc_grid.Children.Add(ButGenerator(2, 4, "9", (object s, RoutedEventArgs e) => textBox.Text += "9"));
            calc_grid.Children.Add(ButGenerator(1, 5, "0", (object s, RoutedEventArgs e) => textBox.Text += "0"));
            calc_grid.Children.Add(ButGenerator(2, 5, ",", (object s, RoutedEventArgs e) => textBox.Text += ","));
            Asd.Content = grid1;

        }
        private void ToHome(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            mw.Show();
            Hide(); 
        }
        private Button ButGenerator(int Column, int Row, string Content, RoutedEventHandler fun)
        {
            var btn = new Button();
            Grid.SetColumn(btn, Column);
            Grid.SetRow(btn, Row);
            btn.Content = Content;
            btn.Click += fun;
            btn.FontSize = 48;
            return btn;
        }
        private void math(object sender, RoutedEventArgs e, char signnn)
        {
            value = textBox.Text;
            textBox.Text = "";
            sign = signnn;
        }
        static string f_calc(string a, string b, char sign)
        {
            switch (sign)
            {
                case '+': return (double.Parse(a) + double.Parse(b)).ToString();
                case '-': return (double.Parse(a) - double.Parse(b)).ToString();
                case '*': return (double.Parse(a) * double.Parse(b)).ToString();
                case '/': return (double.Parse(a) / double.Parse(b)).ToString();
                default: return "!";
            }


        }
        private void Button_Ecval(object sender, RoutedEventArgs e)
        {
            textBox.Text = f_calc(value, textBox.Text, sign);
        }

        private void Button_Revers(object sender, RoutedEventArgs e)
        {
            if (textBox.Text[0] == '-')
            {
                textBox.Text = textBox.Text.Substring(1);
            }
            else
            {
                textBox.Text = "-" + textBox.Text;
            }
        }
        private void Button_C(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
        }
        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length != 0)
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
        }
    }
}
