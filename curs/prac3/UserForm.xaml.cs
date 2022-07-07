using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace prac3
{
    /// <summary>
    /// Interaction logic for UserForm.xaml
    /// </summary>
    public partial class UserForm : Window
    {
        static SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6LIBL55;Initial Catalog=curs;" + "Integrated Security=true;");
        static SqlCommand Com;
        
       
        public UserForm()
        {
            InitializeComponent();
        } 

        private void close_butt_Click(object sender, RoutedEventArgs e)
        {
              Close();
              (new MainWindow()).Show(); 
        }
        private void vidom_Click(object sender, RoutedEventArgs e)
        {
            Vidomosti v = new Vidomosti(); 
            this.Content = v;
        }
        private void register_butt_Click(object sender, RoutedEventArgs e)
        { 
           sqlConn.Open();
            String nameReg = NameField.Text;
            int knigNum = Int32.Parse(SurnameField.Text);
            var knigDate1 = DateOnly.FromDateTime((DateTime)datePicker5_Copy.SelectedDate);
            string knigDate = knigDate1.ToString();
            int IPN = Int32.Parse(loginRegField_Copy.Text);
            int pensNum = Int32.Parse(loginRegField_Copy1.Text);
            String kafVid = loginRegField_Copy2.Text;
            var nadhDate1 = DateOnly.FromDateTime((DateTime)datePicker1.SelectedDate);
            string nadhDate = nadhDate1.ToString();
            string nakaz1 = phonesList.SelectedItem.ToString();
            string[] a = nakaz1.Split(": ");
            string posada = a[1];
            String stupin = loginRegField_Copy5.Text;
            String zvanna = loginRegField_Copy6.Text;
            var vidp1Date1 = DateOnly.FromDateTime((DateTime)datePicker3.SelectedDate);
            string vidp1Date = vidp1Date1.ToString();
            var vidp2Date1 = DateOnly.FromDateTime((DateTime)datePicker2.SelectedDate);
            string vidp2Date = vidp2Date1.ToString();
            int navant = Int32.Parse(loginRegField_Copy9.Text);
            int stazh = Int32.Parse(loginRegField_Copy12.Text);
            var contr1Date1 = DateOnly.FromDateTime((DateTime)datePicker5.SelectedDate);
            string contr1Date = contr1Date1.ToString();
            var contr2Date1 = DateOnly.FromDateTime((DateTime)datePicker4.SelectedDate);
            string contr2Date = contr2Date1.ToString();
            string strQ;
                
                        strQ = "INSERT INTO person ";
            strQ += "VALUES ('" + nameReg + "', '" + knigNum + "', '" + knigDate + "', '" + IPN + "', '" + pensNum + "','" + kafVid + "','" + nadhDate + "','" + posada + "','" + stupin + "','" + zvanna + "','" + vidp1Date + "','" + vidp2Date + "','" + navant + "','" + contr1Date + "','" + contr2Date + "','" + stazh + "' ) ";
            Com = new SqlCommand(strQ, sqlConn);
                        Com.ExecuteNonQuery();
                   
                      
                
            
           sqlConn.Close();

        }

     
    }
}
