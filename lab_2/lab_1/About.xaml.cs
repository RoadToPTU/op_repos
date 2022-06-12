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
using System.Windows.Shapes;

namespace lab_1
{
    /// <summary>
    /// Логика взаимодействия для DB.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            Button button_tohome = new Button();
            button_tohome.Content = "Back";
            button_tohome.HorizontalAlignment = HorizontalAlignment.Center;
            button_tohome.VerticalAlignment = VerticalAlignment.Center;
            button_tohome.Width = 267;
            button_tohome.Height = 74;
            button_tohome.FontSize = 36;
            button_tohome.Click += ToHome;
            Grid.SetColumn(button_tohome, 2);
            Grid.SetRow(button_tohome, 2);
            grid.Children.Add(button_tohome);

            Label label = new Label();
            
            label.Content = "Сiлкiн Дмитро Андрiйович КП-13 2022";
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.FontSize = 44;
            label.Height = 182;
            label.Width = 800;
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 1);
            Grid.SetColumnSpan(label, 4);
            grid.Children.Add(label);

            Asd.Content = grid;
        }

        private void ToHome(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            mw.Show();
            Hide(); 

        }
    }
}
