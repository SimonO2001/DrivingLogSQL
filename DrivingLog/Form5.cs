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
    public partial class Form5 : Form
    {



        string sqlQuery;
        SqlCommand sqlcmd = new SqlCommand();

        
        SqlDataReader sqlRd;
        

        SqlConnection sqlconn = new SqlConnection(@"Server=tcp:simon140401.database.windows.net,1433;Initial Catalog=DrivingLogDB;Persist Security Info=False;User ID=AdminSimon;Password=Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        public Form5()
        {
            InitializeComponent();
        }

        private void upLoadData()
        {
            sqlconn.Open();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "SELECT * FROM [User]";

            sqlRd = sqlcmd.ExecuteReader();

            sqlRd.Close();
            sqlconn.Close();

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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconn.Open();
                //sqlQuery = "UPDATE [User] SET [Name] ='" + textBox1.Text + "'Where [Name] ='" + textBox2.Text + "'";

                sqlQuery = "DELETE FROM [User] WHERE NAME ='" + textBox2.Text + "';";

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
            }

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
