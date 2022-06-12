using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

namespace prac_1_2
{
    /// <summary>
    /// Interaction logic for ProtectionMode.xaml
    /// </summary>
    public partial class ProtectionMode : Window
    {

        static double stuard = 2.36;
        static double fisher = 3.79;
        static long seconds;
        static int i, j, p1 = 0, p2 = 0;
        static int times = 3;

        
        static List<long> list = new List<long>();
        static long[] arr = new long[8];
        static string[] arrr = new string[8];

        static List<List<long>> check_list = new List<List<long>>();
        public ProtectionMode()
        {
            InitializeComponent();
            i = 0; j = 0;
            
            string[] ar = File.ReadAllLines("DB.txt");
            
            foreach (string a in ar)
            {
                arrr = a.Split(' ');
                int g = 0;
                foreach (string b in arrr)
                {

                    arr[g] = long.Parse(b);
                    g++;
                }
                check_list.Add(arr.ToList());
               
            }
            
            P1Field.Content = 0;
            P2Field.Content = 0;
        }

        private void CloseStudyMode_Click(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).Show();
            Hide();
        }

        private void InputField_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            var tb = (TextBox)sender;
            
                if (i == 8)
                {
                InputField.Clear();
                list.Add(DateTime.Now.Ticks - seconds);
                   string f = fisher_test(list, check_list, 8);
                    DispField.Content = f; 
                    double f2 = stuard_test(list, check_list, 8);
                    StatisticsBlock.Content = f2;
                    j++;
                    i = 0;
                    var result = MessageBox.Show("are you right user?", "1", MessageBoxButton.YesNo);
                    var flag1 = (result == MessageBoxResult.Yes);
                    result = MessageBox.Show("dispersions are equal?", "2", MessageBoxButton.YesNo);
                    var flag2 = (result == MessageBoxResult.Yes);
                    if (!flag1 && flag2)
                        p1++;
                    P2Field.Content = (double)p1/j;
                    if (flag1 && !flag2)
                        p2++;
                    P1Field.Content = (double)p2 /j;
                   
                    list = new List<long>();
                    if (j == times)
                    {
                        (new MainWindow()).Show();
                        Hide();
                    }
                }
                else
                {
                    if (i != 0)
                    {
                        list.Add(DateTime.Now.Ticks - seconds);
                    }
                    seconds = DateTime.Now.Ticks;
                    i++;
                }
            
          
        }

        private double stuard_test(List<long> list1, List<List<long>> check_list, int n)
        {
            double counter = 0;
            foreach(List<long> list2 in check_list)
            {
               
                var y1 = list1.ToList();
                var M1 = y1.Sum() / 8.0;
                var S1 = Math.Sqrt((y1.Select(x => (x - M1) * (x - M1)).Sum())/7.0);
                var y2 = list2.ToList();
                var M2 = y2.Sum() / 8.0;
                var S2 = Math.Sqrt((y2.Select(x => (x - M1) * (x - M2)).Sum()) / 7.0);
                var S = Math.Sqrt((S1 * S1 + S2 * S2) * 7.0 / 15.0);
                var T = Math.Abs(M1 - M2) / (S*Math.Sqrt(2.0/8.0));
                if (T < stuard)
                {
                    counter++;
                }
            }
            return counter/8.0;

        }

        private string fisher_test(List<long> list1, List<List<long>> check_list, int n)
        {
            var y1 = list1.ToList();
            var M1 = y1.Sum() / 8.0;
            var S1 = Math.Sqrt((y1.Select(x => (x - M1) * (x - M1)).Sum()) / 7.0);
            var y2 = check_list[0].ToList();
            var M2 = y2.Sum() / 8.0;
            var S2 = Math.Sqrt((y2.Select(x => (x - M1) * (x - M2)).Sum()) / 7.0);  
            double F = Math.Max(S1*S1,S2*S2)/ Math.Min(S1 * S1, S2 * S2);
            if (F > fisher)
            {
                return "неоднорiднi";
            }
            else
            {
                return "однорiднi";
            }
            
        }

        private void CountProtection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            times = int.Parse(((ComboBoxItem)((ComboBox)sender).SelectedValue).Content.ToString());
        }
    }
}
