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
    /// Логика взаимодействия для Vidomosti.xaml
    /// </summary>
    public partial class Vidomosti : Page
    {
        static SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6LIBL55;Initial Catalog=curs;" + "Integrated Security=true;");
       
        
        static SqlCommand Com;
        public Vidomosti()
        {
            InitializeComponent();
        }
        private void close_butt_Click(object sender, RoutedEventArgs e)
        {
            Window win = (Window)this.Parent;
            win.Close();
            UserForm userFormWPF = new UserForm();
           
            userFormWPF.Show();
        }
        private void b1_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
          
            int knigNum = Int32.Parse(NameField.Text);
           
            string nakaz1 = phonesList.SelectedItem.ToString();
            string[] a = nakaz1.Split(": ");
            string nakaz = a[1];
            int nakNum = Int32.Parse(loginRegField_Copy.Text);
            var nakDate1 = DateOnly.FromDateTime((DateTime)datePicker5_Copy.SelectedDate);
            string nakDate = nakDate1.ToString();
            String podr = loginRegField_Copy1.Text;
            string strQ;
            strQ = "INSERT INTO trudKn ";
            strQ += "VALUES ('" + nakDate + "', '" + nakNum + "', '" + nakaz + "', '" + podr + "', '" + knigNum + "' ) ";
            Com = new SqlCommand(strQ, sqlConn);
            Com.ExecuteNonQuery();




            sqlConn.Close();

        }
        private void b2_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();

            int knigNum = Int32.Parse(NameField_Copy.Text);
            String podr = loginRegField_Copy3.Text;
            string strQ;
            strQ = "INSERT INTO nagr ";
            strQ += "VALUES ('" + podr + "', '" + knigNum + "' ) ";
            Com = new SqlCommand(strQ, sqlConn);
            Com.ExecuteNonQuery();




            sqlConn.Close();

        }
        private void b3_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();

            int knigNum = Int32.Parse(NameField_Copy1.Text);
            String podr = loginRegField_Copy2.Text;
            string strQ;
            strQ = "INSERT INTO disc ";
            strQ += "VALUES ('" + podr + "', '" + knigNum + "' ) ";
            Com = new SqlCommand(strQ, sqlConn);
            Com.ExecuteNonQuery();




            sqlConn.Close();

        }
    }
}
