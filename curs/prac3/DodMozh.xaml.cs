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
    /// Логика взаимодействия для DodMozh.xaml
    /// </summary>
    public partial class DodMozh : Window
    {
        static SqlConnection sqlConn = new SqlConnection("Data Source=DESKTOP-6LIBL55;Initial Catalog=curs;" + "Integrated Security=true;");
        static SqlCommand Com;
        static SqlDataAdapter Data;
        static DataTable dT = new DataTable();
        static DataGrid dataGrid = new DataGrid();
        static int LenTable;
        static int index = 0;
        public DodMozh()
        {
            InitializeComponent();
        }
        private void login_butt_Click(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            String strQ;
            DateTime a = (DateTime)datePicker5_Copy.SelectedDate;
            
            strQ = "SELECT * FROM person ";
            Com = new SqlCommand(strQ, sqlConn);
            dT = new DataTable("USERS");
            string c;
            string b;
            dT.Columns.Add("Column1");
            using (SqlDataReader read = Com.ExecuteReader())
            {
                while (read.Read())
                {
                    b = read["DATESTART"].ToString();
                    c = read["DATEEND"].ToString();
                    if(DateTime.Compare(DateTime.Parse(b), a)<0 && DateTime.Compare(a, DateTime.Parse(c))<0)
                    {
                        dT.Rows.Add(new Object[] { read["FULLNAME"].ToString() });
                        
                    }
                }
            }
            dataGrid.ItemsSource = dT.DefaultView;
            LenTable = dT.Rows.Count;
            UsersLogins.ItemsSource = dT.DefaultView;


            sqlConn.Close();


        }
        private void login_butt_Click1(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            String strQ;
            

            strQ = "SELECT * FROM person ";
            Com = new SqlCommand(strQ, sqlConn);
            dT = new DataTable("USERS");
            
            string b;
            dT.Columns.Add("Column1");
            using (SqlDataReader read = Com.ExecuteReader())
            {
                while (read.Read())
                {
                    b = read["CONTREND"].ToString();
                    
                    if (DateTime.Compare(DateTime.Parse(b), DateTime.Now) < 0 )
                    {
                        dT.Rows.Add(new Object[] { read["FULLNAME"].ToString() });

                    }
                }
            }
            dataGrid.ItemsSource = dT.DefaultView;
            LenTable = dT.Rows.Count;
            UsersLogins.ItemsSource = dT.DefaultView;


            sqlConn.Close();


        }
        private void login_butt_Click2(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            String strQ;


            strQ = "SELECT * FROM nagr WHERE name = 'За оборону Ленінграда' ";
            Com = new SqlCommand(strQ, sqlConn);
            dT = new DataTable("USERS");

            List<int> someList = new List<int>();
            dT.Columns.Add("Column1");
            using (SqlDataReader read = Com.ExecuteReader())
            {
                while (read.Read())
                {
                    someList.Add(Convert.ToInt32(read["ID"]));
                }
            }
            strQ = "SELECT * FROM person  ";
            Com = new SqlCommand(strQ, sqlConn);
            using (SqlDataReader read = Com.ExecuteReader())
            {
                while (read.Read())
                {
                    for (int i = 0; i < someList.Count; i++)
                    {
                        if (Convert.ToInt32(read["IPN"]) == someList[i])
                        {
                            dT.Rows.Add(new Object[] { read["FULLNAME"].ToString() });
                        }
                    }
                }
                

                
            }
            dataGrid.ItemsSource = dT.DefaultView;
            LenTable = dT.Rows.Count;
            UsersLogins.ItemsSource = dT.DefaultView;


            sqlConn.Close();


        }
        private void login_butt_Click3(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            String strQ;

            string a = add_login1_Copy3.Text;
            strQ = "SELECT * FROM disc WHERE name = '" + a + " ' ";
            Com = new SqlCommand(strQ, sqlConn);
            dT = new DataTable("USERS");

            List<int> someList = new List<int>();
            dT.Columns.Add("Column1");
            using (SqlDataReader read = Com.ExecuteReader())
            {
                while (read.Read())
                {
                    someList.Add(Convert.ToInt32(read["Id"]));
                }
            }
            strQ = "SELECT * FROM person  ";
            Com = new SqlCommand(strQ, sqlConn);
            using (SqlDataReader read = Com.ExecuteReader())
            {
                while (read.Read())
                {
                    for (int i = 0; i < someList.Count; i++)
                    {
                        if (Convert.ToInt32(read["IPN"]) == someList[i])
                        {
                            dT.Rows.Add(new Object[] { read["FULLNAME"].ToString() });
                        }
                    }
                }



            }
            dataGrid.ItemsSource = dT.DefaultView;
            LenTable = dT.Rows.Count;
            UsersLogins.ItemsSource = dT.DefaultView;


            sqlConn.Close();


        }
        private void login_butt_Click4(object sender, RoutedEventArgs e)
        {
            sqlConn.Open();
            String strQ;


            strQ = "SELECT * FROM person ";
            Com = new SqlCommand(strQ, sqlConn);
            dT = new DataTable("USERS");
            int a = Convert.ToInt32(add_login1_Copy.Text);
            string b;
            dT.Columns.Add("Column1");
            TimeSpan c;
            using (SqlDataReader read = Com.ExecuteReader())
            {
                while (read.Read())
                {
                    b = read["DATE"].ToString();
                    c = DateTime.Now - DateTime.Parse(b);
                    if (c.Days > a*365)
                    {
                        dT.Rows.Add(new Object[] { read["FULLNAME"].ToString() });

                    }
                }
            }
            dataGrid.ItemsSource = dT.DefaultView;
            LenTable = dT.Rows.Count;
            UsersLogins.ItemsSource = dT.DefaultView;


            sqlConn.Close();


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Administration administration = new Administration(); 
            Hide();
            administration.Show();
        }
    }
}
