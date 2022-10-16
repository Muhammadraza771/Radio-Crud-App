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

namespace B_Validation_ByDataErrorInfo
{
    /// <summary>
    /// Interaction logic for afterlogin.xaml
    /// </summary>
    public partial class afterlogin : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory + "\\RecordDB.mdf;Integrated Security=True;Connect Timeout=30");
        private DataTable dt;
        int id; //for updation
        string nm;
        string p;
        string em;
        DataRowView dataRowView;
        int hostcount, programcount;
       

        public void countrecords()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From [host] ";
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            sd.Fill(dt);
            con.Close();



            con.Open();
            SqlCommand cd = con.CreateCommand();
            cd.CommandType = CommandType.Text;
            cd.CommandText = "Select * From [program] ";
            cd.ExecuteNonQuery();
           DataTable dtt = new DataTable();
            SqlDataAdapter sdd = new SqlDataAdapter(cd);
            sdd.Fill(dtt);
            con.Close();

            

            hostcount = dt.Rows.Count;
            programcount = dtt.Rows.Count;
        }
        public afterlogin()
        {
            InitializeComponent();


            countrecords();
            dp();
            homeGrid.Visibility = Visibility.Visible;
            populatehomegrid();
           

        }
        public void dp()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Id, hostname as Presentator_Naam, hostphone as Presentator_Nummer, hostemail as Presentator_Email  From [host] ";
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            sd.Fill(dt);
            con.Close();
            dataGridhost.DataContext = dt.DefaultView;
        }

        private void homeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            homeButton.Cursor = Cursors.Hand;
            homeButton.FontWeight = FontWeights.Bold;
        }

        private void homeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            homeButton.Cursor = Cursors.Arrow;
            homeButton.FontWeight = FontWeights.Normal;
        }

        private void hostButton_MouseEnter(object sender, MouseEventArgs e)
        {
            hostButton.Cursor = Cursors.Hand;
            hostButton.FontWeight = FontWeights.Bold;
        }

        private void hostButton_MouseLeave(object sender, MouseEventArgs e)
        {
            hostButton.Cursor = Cursors.Arrow;
            hostButton.FontWeight = FontWeights.Normal;
        }

        private void programButton_MouseEnter(object sender, MouseEventArgs e)
        {
            programButton.Cursor = Cursors.Hand;
            hostButton.FontWeight = FontWeights.Bold;
        }

        private void programButton_MouseLeave(object sender, MouseEventArgs e)
        {

            programButton.Cursor = Cursors.Arrow;
            hostButton.FontWeight = FontWeights.Normal;
        }

        private void Addbutton_Click(object sender, RoutedEventArgs e)
        {


            if (hostnametextbox.Text == "" || hostphonetextbox.Text == "" || hostemailtextbox.Text == ""){
                MessageBox.Show("Make sure required fields are not empty");
            }
            else
            {


                string name = hostnametextbox.Text.Trim();
                string email = hostemailtextbox.Text.Trim();
                string phone = hostphonetextbox.Text.Trim();

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT into  [host] (hostname,hostphone,hostemail) values (@name,@phone,@email)";
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@phone", phone));
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Success");
                dp();
                cleartextfields();


               

            }


           
        }
        public void cleartextfields()
        {
            hostnametextbox.Text = null;
            hostemailtextbox.Text = null;
            hostphonetextbox.Text = null;
            recordid.Content = "-";
        }

       
        public void updateRecords()
        {



            con.Open();
            SqlCommand cd = con.CreateCommand();
            cd.CommandType = CommandType.Text;
            cd.CommandText = " Update [host] SET hostname =  @hostname, hostphone= @phone, hostemail = @hostemail  WHERE Id = @hostid";
            cd.Parameters.Add(new SqlParameter("@hostname", hostnametextbox.Text.Trim()));
            cd.Parameters.Add(new SqlParameter("@phone", hostphonetextbox.Text.Trim()));
            cd.Parameters.Add(new SqlParameter("@hostemail", hostemailtextbox.Text.Trim()));
            cd.Parameters.Add(new SqlParameter("@hostid", id));
            cd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update Successful");
            dp();
            cleartextfields();



          



        }
        public void updaterecordswithprogramadd(int dd)
        {



            con.Open();
            SqlCommand cd = con.CreateCommand();
            cd.CommandType = CommandType.Text;
            cd.CommandText = " Update [host] SET hostname =  @hostname, hostphone= @phone, hostemail = @hostemail , prid =@programid  WHERE Id = @hostid";
            cd.Parameters.Add(new SqlParameter("@hostname", hostnametextbox.Text.Trim()));
            cd.Parameters.Add(new SqlParameter("@phone", hostphonetextbox.Text.Trim()));
            cd.Parameters.Add(new SqlParameter("@hostemail", hostemailtextbox.Text.Trim()));
            cd.Parameters.Add(new SqlParameter("@programid",dd));
            cd.Parameters.Add(new SqlParameter("@hostid", id));
            cd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update Successful");
            dp();
            cleartextfields();
        }

        private void Addbutton_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (hostnametextbox.Text == "" || hostphonetextbox.Text == "" || hostemailtextbox.Text == "")
            {
                MessageBox.Show("Make sure required fields are not empty");
            }
            else
            {
               
                Addbutton.IsEnabled = true;
                Addbutton_Copy.IsEnabled = false;
                Addbutton_Copy1.IsEnabled = false;
                comboBox.IsEnabled = false;

                if (comboBox.SelectedIndex == -1)
                {
                    updateRecords();
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Id from [program] where programname = '"+ comboBox.SelectedItem.ToString()+"';";
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    sd.Fill(dt);
                    con.Close();

                    int i = Convert.ToInt32 (dt.Rows[0][0]);

                   

                    updaterecordswithprogramadd(i);
                }



            }

          
        }

        private void dataGridhost_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Addbutton_Copy.IsEnabled = true;
            Addbutton_Copy1.IsEnabled = true;

            dataRowView = (DataRowView)dataGridhost.SelectedItem;
            id = Convert.ToInt32(dataRowView.Row[0]);
            nm = dataRowView.Row[1].ToString();
            p = dataRowView.Row[2].ToString();
            em = dataRowView.Row[3].ToString();



            hostnametextbox.Text = nm;
            hostphonetextbox.Text = p;
            hostemailtextbox.Text = em;
            recordid.Content = id;
            Addbutton.IsEnabled = false;
            comboBox.IsEnabled = true;

            assignprogram();

        }
        public void assignprogram()
        {
            comboBox.Items.Clear();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select programname from [program] ";
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            sd.Fill(dt);
            con.Close();


            
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                comboBox.Items.Add( dt.Rows[i][0].ToString());

            }

            



        }
        private void Addbutton_Copy1_Click(object sender, RoutedEventArgs e)
        {

            con.Open();
            SqlCommand cd = con.CreateCommand();
            cd.CommandType = CommandType.Text;
            cd.CommandText = "Delete From [host] where Id = @hostid ";
            cd.Parameters.Add(new SqlParameter("@hostid", id));
            cd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Records Deleted");
            dp();
            cleartextfields();


            Addbutton_Copy.IsEnabled = false;
            Addbutton_Copy1.IsEnabled = false;
            Addbutton.IsEnabled = true;



            
        }

        private void searchtextboxhost_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchtextboxhost.Text == "")
            {
                dp();
            }

            else
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * From [host] where hostname like '" +searchtextboxhost.Text.Trim()+"%'";
                cmd.ExecuteNonQuery();
                dt = new DataTable();
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                sd.Fill(dt);
                con.Close();
                dataGridhost.DataContext = dt.DefaultView;
            }
            


        }

        private void homeButton_Click(object sender, RoutedEventArgs e)
        {

            countrecords();
            homeGrid.Visibility = Visibility.Visible;
            hostGrid.Visibility = Visibility.Hidden;
            programgrid.Visibility = Visibility.Hidden;




            populatehomegrid();
        


        }
        public void populatehomegrid()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select hostname as Presentator_Naam ,hostphone as Presentator_Nummer,programname as Programma_Naam,programdescription as Programma_Beschrijving from [host] Inner Join [program] ON host.prid = program.Id; ";
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            sd.Fill(dt);
            con.Close();
            homedatagrid.DataContext = dt.DefaultView;

            hostnumberlabelhome.Content = hostcount.ToString();
            programnumberlabelhome.Content = programcount.ToString();
        }

        private void programButton_Click(object sender, RoutedEventArgs e)
        {
            programgrid.Visibility = Visibility.Visible;
            hostGrid.Visibility = Visibility.Hidden;
            homeGrid.Visibility = Visibility.Hidden;

            refreshprogramgrid();
            programupdatebutton.IsEnabled = false;
            programdeletebutton.IsEnabled = false;
            countrecords();
        }

        private void hostButton_Click(object sender, RoutedEventArgs e)
        {
            countrecords();
            homeGrid.Visibility = Visibility.Hidden;
            programgrid.Visibility = Visibility.Hidden;
            hostGrid.Visibility = Visibility.Visible;

            dp();
        }

        private void programdatagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           DataRowView dataRowView2 = (DataRowView)programdatagrid.SelectedItem;
            programnametextbox.Text = dataRowView2.Row[1].ToString();    
            string desc = dataRowView2.Row[2].ToString();
            programdescriptiontextbox.Text = desc;
            programidlabel.Content = dataRowView2.Row[0].ToString();
            ProgramAdd.IsEnabled = false;
            programupdatebutton.IsEnabled = true;
            programdeletebutton.IsEnabled = true;



        }

        private void programupdatebutton_Click(object sender, RoutedEventArgs e)
        {

            con.Open();
            SqlCommand cd = con.CreateCommand();
            cd.CommandType = CommandType.Text;
            cd.CommandText = " Update [program] SET programname =  @programname, programdescription= @programdescription  WHERE Id = @programid";
            cd.Parameters.Add(new SqlParameter("@programname", programnametextbox.Text.Trim()));
            cd.Parameters.Add(new SqlParameter("@programdescription", programdescriptiontextbox.Text.Trim()));
            cd.Parameters.Add(new SqlParameter("@programid", programidlabel.Content));
            cd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update Successful");
           
            refreshprogramgrid();
            programentryfieldsclear();
            programupdatebutton.IsEnabled = false;
            programdeletebutton.IsEnabled = false;
            ProgramAdd.IsEnabled = true;


        







        }

        private void ProgramAdd_Click(object sender, RoutedEventArgs e)
        {

            if(string.IsNullOrEmpty(programnametextbox.Text.Trim()) || string.IsNullOrEmpty(programdescriptiontextbox.Text.Trim())){
                MessageBox.Show("Make sure fields are not empty");
            }
            else
            {


                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into [program] (programname,programdescription) values(@programname,@programdescription)";
                cmd.Parameters.Add(new SqlParameter("@programname", programnametextbox.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@programdescription", programdescriptiontextbox.Text.Trim()));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Program Added");
                refreshprogramgrid();
                programentryfieldsclear();
            }
            


         


          
        }
        public void programentryfieldsclear()
        {
            programdescriptiontextbox.Text = null;
            programnametextbox.Text = null;
            ProgramAdd.IsEnabled = true;
            programidlabel.Content = "-";
        }
        public void refreshprogramgrid()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Id as id, programname as Programma_Name, Programdescription as Programma_Beschrijving From [program] ";
            cmd.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            sd.Fill(dt2);
            con.Close();
            programdatagrid.DataContext = dt2.DefaultView;
        }

        private void programdeletebutton_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cd = con.CreateCommand();
            cd.CommandType = CommandType.Text;
            cd.CommandText = "Delete From [program] where Id = @programid ";
            cd.Parameters.Add(new SqlParameter("@programid", programidlabel.Content));
            cd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Records Deleted");
            programentryfieldsclear();
            refreshprogramgrid();
            programdeletebutton.IsEnabled = false;
            programupdatebutton.IsEnabled = false;
        }
    }
}
