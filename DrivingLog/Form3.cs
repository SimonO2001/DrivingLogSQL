using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace DrivingLog
{
    public partial class Form3 : Form
    {
        Bitmap Bitmap;


        SqlCommand sqlcmd = new SqlCommand();

        string sqlQuery;
        SqlDataAdapter Dta = new SqlDataAdapter();
        SqlDataReader sqlRd;
        DataSet DS = new DataSet();

        SqlConnection sqlconn = new SqlConnection(@"Server=tcp:simon140401.database.windows.net,1433;Initial Catalog=DrivingLogDB;Persist Security Info=False;User ID=AdminSimon;Password=Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        private void upLoadData()
        {
            sqlconn.Open();
            sqlcmd.Connection = sqlconn;
            sqlcmd.CommandText = "SELECT * FROM[User]";

            sqlRd = sqlcmd.ExecuteReader();

            sqlRd.Close();
            sqlconn.Close();

        }


        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

                foreach (Control c in panel4.Controls)
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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconn.Open();
                sqlQuery = "UPDATE [User] SET [Name] ='" + textBox2.Text + "'Where [Name] ='" + textBox1.Text + "'";
                //sqlQuery = "INSERT INTO [User] ([Name], [NrPlade]) VALUES(" + "'" + textBox2.Text + "'" + ", " + "'" + textBox3.Text + "'" + ")";

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
            foreach (Control c in panel4.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }

            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
