using System;
using System.Collections;
using System.IO;
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

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
    }
    public partial class DB : Window
    {

        TextBox id1 = new TextBox();
        TextBox id2 = new TextBox();
            TextBox name = new TextBox();
            TextBox comment = new TextBox();
            public DB()
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

            id1.HorizontalAlignment = HorizontalAlignment.Left;
            id1.VerticalAlignment = VerticalAlignment.Top;
            id1.Margin = new Thickness(0, 100, 0, 0);
            id1.TextWrapping = TextWrapping.Wrap;
            id1.Width = 120;
            grid.Children.Add(id1);

            id2.HorizontalAlignment = HorizontalAlignment.Left;
            id2.VerticalAlignment = VerticalAlignment.Top;
            id2.Margin = new Thickness(0, 122, 0, 0);
            id2.TextWrapping = TextWrapping.Wrap;
            id2.Width = 120;
            Grid.SetRow(id2, 1);
            grid.Children.Add(id2);

            comment.HorizontalAlignment = HorizontalAlignment.Left;
            comment.VerticalAlignment = VerticalAlignment.Top;
            comment.Margin = new Thickness(59, 100, 0, 0);
            comment.TextWrapping = TextWrapping.Wrap;
            comment.Width = 300;
            comment.Height = 18;
            Grid.SetColumnSpan(comment, 2);
            Grid.SetColumn(comment, 2);
            grid.Children.Add(comment);

            name.HorizontalAlignment = HorizontalAlignment.Center;
            name.VerticalAlignment = VerticalAlignment.Top;
            name.Margin = new Thickness(0, 100, 0, 0);
            name.TextWrapping = TextWrapping.Wrap;
            name.Width = 180;
            Grid.SetColumn(name, 1);
            grid.Children.Add(name);
            
            Label label1 = new Label();
            label1.HorizontalAlignment = HorizontalAlignment.Left;
            label1.VerticalAlignment = VerticalAlignment.Top;
            label1.Content = "№";
            label1.FontSize = 36;
            label1.Margin = new Thickness(35, 31, 0, 0);
            grid.Children.Add(label1);

            Label label2 = new Label();
            label2.Margin = new Thickness(27, 31, 0, 0);
            label2.Content = "Name";
            label2.HorizontalAlignment = HorizontalAlignment.Left;
            label2.VerticalAlignment = VerticalAlignment.Top;
            label2.FontSize = 36;
            Grid.SetColumn(label2, 1);
            grid.Children.Add(label2);

            Label label3 = new Label();
            label3.Content = "About";
            label3.HorizontalAlignment = HorizontalAlignment.Left;
            label3.VerticalAlignment = VerticalAlignment.Top;
            label3.Margin = new Thickness(58, 37, 0, 0);
            label3.FontSize = 36;
            label3.Width = 174;
            Grid.SetColumn(label3, 2);
            grid.Children.Add(label3);

            Label label4 = new Label();
            label4.Content = "№";
            label4.HorizontalAlignment = HorizontalAlignment.Left;
            label4.VerticalAlignment = VerticalAlignment.Top;
            label4.FontSize = 36;
            label4.Margin = new Thickness(0, 59, 0, 0);
            Grid.SetRow(label4, 1);
            grid.Children.Add(label4);

            Button butadd = new Button();
            butadd.Content = "Add";
            butadd.HorizontalAlignment = HorizontalAlignment.Left;
            butadd.VerticalAlignment = VerticalAlignment.Top;
            butadd.Width = 267;
            butadd.Height = 74;
            Grid.SetRow(butadd, 1);
            Grid.SetColumnSpan(butadd, 2);
            butadd.FontSize = 36;
            butadd.Click += Add;
            grid.Children.Add(butadd);

            Button butdel = new Button();
            butdel.Content = "Del";
            butadd.HorizontalAlignment = HorizontalAlignment.Left;
            butadd.VerticalAlignment = VerticalAlignment.Top;
            butdel.Width = 267;
            butdel.Height = 74;
            Grid.SetRow(butdel, 2);
            Grid.SetColumnSpan(butdel, 2);
            butdel.Click += Del;
            butdel.FontSize = 36;
            grid.Children.Add(butdel);

            Asd.Content = grid;
            File.Delete("DB.csv");
        }

        private void ToHome(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            mw.Show();
            Hide(); 

        }

        private void Add(object sender, RoutedEventArgs e)
        {

            string path = "DB.csv";

            
            var student = new Student();
            student.ID = int.Parse(id1.Text);
            student.Name = name.Text;
            student.About = comment.Text;
            File.AppendAllText(path, String.Format("{0};{1};{2}\n", student.ID, student.Name, student.About));
        }

        private void Del(object sender, RoutedEventArgs e)
        {
            var students = new List<Student>();
            var student = new Student();
            string path = "DB.csv";
            using (StreamReader streamReader = new StreamReader(path))
            {
                string line;
                line = streamReader.ReadLine() ;
                while (line != null)
                {
                    student = new Student();
                    var vals = line.Split(';');
                    student.ID = Convert.ToInt32(vals[0]);
                    student.Name = vals[1];
                    student.About = vals[2];
                    if (student.ID != int.Parse(id2.Text))
                    {
                        students.Add(student);
                    }
                    line = streamReader.ReadLine() ;
                }
            }

            File.Delete(path);

          

            foreach (var stud in students) 
            {
                File.AppendAllText(path, String.Format("{0};{1};{2}\n", stud.ID, stud.Name, stud.About));
                
            }
            
        }

       
    }
}
