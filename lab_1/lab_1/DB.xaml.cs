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
        public DB()
        {
            InitializeComponent();
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
