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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace B_Validation_ByDataErrorInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory + "\\RecordDB.mdf;Integrated Security=True;Connect Timeout=30");
        private DataTable dt;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From [Table] Where Usr ='" + usernameTextbox.Text.Trim() + "' AND Ps ='" + passwordTextbox.Text.Trim() + "'";
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            sd.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {

                navbarGrid.Visibility = Visibility.Visible;
                var ui = new afterlogin();
                ui.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Bad Credentials");
                usernameTextbox.Text = "";
                passwordTextbox.Text = "";
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            loginbutton.Cursor = Cursors.Hand;
        }

        private void loginbutton_MouseLeave(object sender, MouseEventArgs e)
        {
            loginbutton.Cursor = Cursors.Arrow;
        }
    }
}
