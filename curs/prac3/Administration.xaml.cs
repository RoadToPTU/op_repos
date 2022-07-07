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
    /// Interaction logic for Administration.xaml
    /// </summary>
    public partial class Administration : Window
    {
        static SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6LIBL55;Initial Catalog=curs;" + "Integrated Security=true;");
        static SqlCommand Com;
        static SqlDataAdapter Data;
        static DataTable dT = new DataTable();
        static DataGrid dataGrid = new DataGrid();
        static int LenTable;
        static int index = 0;
        static List<int> someList = new List<int>();
        public Administration()
        { 
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
            (new MainWindow()).Show();
        }

        private void login_butt_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            String strQ;
           
            string a = add_login1.Text;
                strQ = "Delete FROM person WHERE IPN='" +a+ "';";
                Com = new SqlCommand(strQ, sqlConn);
            Com.ExecuteNonQuery();

            sqlConn.Close();
            
            
        }
        private void login_butt_Click1(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            String strQ;

            string a = add_login1_Copy.Text;
            
            var b = DateOnly.FromDateTime((DateTime)datePicker5_Copy.SelectedDate);
            string c = b.ToString();
            var d = DateOnly.FromDateTime((DateTime)datePicker5_Copy1.SelectedDate);
            string f = d.ToString();
              strQ = "UPDATE person SET CONTRSTART ='" + c + "' WHERE IPN='" + a + "';";
            
            Com = new SqlCommand(strQ, sqlConn);
            Com.ExecuteNonQuery();
            strQ = "UPDATE person SET CONTREND ='" + f + "' WHERE IPN='" + a + "';";
            Com = new SqlCommand(strQ, sqlConn);
            Com.ExecuteNonQuery();

            sqlConn.Close();


        }
        private void login_butt_Click2(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            String strQ;

            var b = DateOnly.FromDateTime((DateTime)datePicker5_Copy2.SelectedDate);
            string c = b.ToString();
            var d = DateOnly.FromDateTime((DateTime)datePicker5_Copy3.SelectedDate);
            string f = d.ToString();
            strQ = "UPDATE person SET DATESTART ='" + c +  "';";

            Com = new SqlCommand(strQ, sqlConn);
            Com.ExecuteNonQuery();
            strQ = "UPDATE person SET DATEEND ='" + f +  "';";
            Com = new SqlCommand(strQ, sqlConn);
            Com.ExecuteNonQuery();

            sqlConn.Close();


        }
        private void login_butt_Click3(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            String strQ;
            string a = add_login1_Copy1.Text;
            string b = add_login1_Copy2.Text;
            strQ = "UPDATE person SET POSADA ='" + b + "' WHERE IPN='" + a + "';";

            Com = new SqlCommand(strQ, sqlConn);
            Com.ExecuteNonQuery();
            

            sqlConn.Close();


        }
        private void login_butt_Click4(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            String strQ;
            string a = add_login1_Copy3.Text;
            Data = new SqlDataAdapter("SELECT FULLNAME, POSADA, STAZH FROM person WHERE PLACE='" + a + "'", sqlConn);
            dT = new DataTable("USERS");
            Data.Fill(dT);
            dataGrid.ItemsSource = dT.DefaultView;
            LenTable = dT.Rows.Count;
            UsersLogins.ItemsSource = dT.DefaultView;


            sqlConn.Close();


        }
        private void login_butt_Click5(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            string a = add_login1_Copy3.Text;
            string selectSql = "select * from person  WHERE PLACE='" + a + "' AND POSADA = 'Асистент'";
            Com = new SqlCommand(selectSql, sqlConn);
            double b = 0;
            double c = 0;
            using (SqlDataReader read = Com.ExecuteReader())
            {
                while (read.Read())
                {
                    b += Convert.ToDouble(read["NAVANT"]);
                    c++;
                }
            }
            double d = b / c;
            add_login1_Copy4.Text = d.ToString();

            sqlConn.Close();


        }
        private void login_butt_Click6(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            string a = add_login1_Copy3.Text;
            string selectSql = "select * from person  WHERE PLACE='" + a + "' AND POSADA = 'Доцент'";
            Com = new SqlCommand(selectSql, sqlConn);
            phonesList.Items.Clear();
            someList.Clear();
            using (SqlDataReader read = Com.ExecuteReader())
            {
                while (read.Read())
                {
                    phonesList.Items.Add(read["FULLNAME"].ToString());
                    someList.Add(Convert.ToInt32(read["IPN"]));
                }
            }
            sqlConn.Close();
        }
     
        private void phonesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sqlConn.Open();
            String strQ;
            int a = someList[phonesList.SelectedIndex];
            Data = new SqlDataAdapter("SELECT name FROM disc WHERE Id='" + a + "'", sqlConn);
            dT = new DataTable("USERS");
            Data.Fill(dT);
            dataGrid.ItemsSource = dT.DefaultView;
            LenTable = dT.Rows.Count;
            UsersLogins.ItemsSource = dT.DefaultView;
            sqlConn.Close();
        }
        private void AdminMode_Click(object sender, RoutedEventArgs e)
        {
            DodMozh administration = new DodMozh(); 
            Hide();
            administration.Show();
        }
        private void login_butt_Click7(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            
            string selectSql = "select * from person";
            Com = new SqlCommand(selectSql, sqlConn);
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            int f = 0;

            using (SqlDataReader read = Com.ExecuteReader())
            {
                while (read.Read())
                {
                    if(read["POSADA"].ToString() == "Доцент")
                    {
                        a++;
                    }
                    if (read["POSADA"].ToString() == "Асистент")
                    {
                        b++;
                    }
                    if (read["POSADA"].ToString() == "Асистент к.н.")
                    {
                        c++;
                    }
                    if (read["POSADA"].ToString() == "Професор")
                    {
                        d++;
                    }
                    if (read["POSADA"].ToString() == "Старший викладач")
                    {
                        f++;
                    }

                }
            }
            add_login1_Copy5.Text = a.ToString();
            add_login1_Copy6.Text = b.ToString();
            add_login1_Copy7.Text = c.ToString();
            add_login1_Copy8.Text = d.ToString();
            add_login1_Copy9.Text = f.ToString();
            sqlConn.Close();
        }
    }
}
