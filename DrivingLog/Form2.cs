using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace DrivingLog
{
    public partial class Form2 : Form
    {
        SqlCommand sqlcmd = new SqlCommand();

        string sqlQuery;
        SqlDataAdapter Dta = new SqlDataAdapter();
        SqlDataReader sqlRd;
        DataSet DS = new DataSet();

        SqlConnection sqlconn = new SqlConnection (@"Server=tcp:simon140401.database.windows.net,1433;Initial Catalog=DrivingLogDB;Persist Security Info=False;User ID=AdminSimon;Password=Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


        public Form2()
        {
            InitializeComponent();
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                sqlconn.Open();
                sqlQuery = "INSERT INTO [User] ([Name]) VALUES(" + "'" + textBox2.Text + "'" + ")";

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

        private void upLoadData()
        {
            sqlconn.Open();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "SELECT * FROM[User]";

            sqlRd = sqlcmd.ExecuteReader();

            sqlRd.Close();
            sqlconn.Close();

        }

    }

        


    
}
