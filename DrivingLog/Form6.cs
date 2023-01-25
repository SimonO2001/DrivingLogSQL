using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLog
{
    public partial class Form6 : Form
    {



        string sqlQuery;
        SqlCommand sqlcmd = new SqlCommand();


        SqlDataReader sqlRd;


        SqlConnection sqlconn = new SqlConnection(@"Server=tcp:simon140401.database.windows.net,1433;Initial Catalog=DrivingLogDB;Persist Security Info=False;User ID=AdminSimon;Password=Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in panel1.Controls)
                {
                    if (c is TextBox)
                    {
                        ((TextBox)c).Clear();
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form6_Load(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("Select Id, Name from [User]", sqlconn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            da.Fill(table1);
            comboBox1.DataSource= table1;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

        }

        private void upLoadData()
        {
            sqlconn.Open();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "SELECT * FROM[Log]";

            sqlRd = sqlcmd.ExecuteReader();

            sqlRd.Close();
            sqlconn.Close();

        }
            
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconn.Open();
                sqlQuery = "INSERT INTO [Log] ([Name], [Nrplade], [Km], [Dato]) VALUES(" + "'" + comboBox1.Text + "', " + "'" + textBox1.Text + "', " + "'" + textBox3.Text + "', " + "'" + textBox4.Text + "')";

                sqlcmd = new SqlCommand(sqlQuery, sqlconn);
                sqlRd = sqlcmd.ExecuteReader();
                sqlconn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { 

                sqlconn.Close();
            }
            upLoadData();

            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }

            }
        }
    }
}
