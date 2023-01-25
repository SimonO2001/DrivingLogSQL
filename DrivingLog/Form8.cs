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
    public partial class Form8 : Form
    {

        string sqlQuery;
        SqlConnection sqlconn = new SqlConnection(@"Server=tcp:simon140401.database.windows.net,1433;Initial Catalog=DrivingLogDB;Persist Security Info=False;User ID=AdminSimon;Password=Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        SqlDataAdapter adpt;
        DataTable dt;
        SqlCommand sqlcmd = new SqlCommand();
        SqlDataReader sqlRd;

        public Form8()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconn.Open();
                

                sqlQuery = "DELETE FROM [Log] WHERE Id ='" + textBox1.Text + "';";

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
                upLoadData();
                sqlconn.Close();
                showdata();
            }

            foreach (Control c in panel4.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            showdata();
        }

        public void showdata()
        {
            adpt = new SqlDataAdapter("Select * from [Log]", sqlconn);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void upLoadData()
        {
            sqlconn.Open();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "SELECT * FROM [Log]";

            sqlRd = sqlcmd.ExecuteReader();

            sqlRd.Close();
            sqlconn.Close();

        }
    }
}
