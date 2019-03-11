using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;

namespace Lab2
{
    public partial class Form1 : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlDataAdapter da2 = new SqlDataAdapter();
        DataSet ds2 = new DataSet();
        public static string connection = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        public static SqlConnection cs = new SqlConnection(connection);

        public Form1()
        {
            InitializeComponent();
        }

        private void populate_Button_Click(object sender, EventArgs e)
        {
            string selectC = ConfigurationManager.AppSettings["SelectChild"];
            da.SelectCommand = new SqlCommand(selectC, cs);
            da.Fill(ds);
            ChildGridView.DataSource = ds.Tables[0];

            string selectS = ConfigurationManager.AppSettings["SelectParent"];
            da2.SelectCommand = new SqlCommand(selectS, cs);
            da2.Fill(ds2);
            ParentGridView.DataSource = ds2.Tables[0];
            cs.Close();

            //string select = ConfigurationSettings.AppSettings["SelectChild"];
            //da.SelectCommand = new SqlCommand(select, cs);
            ////da.SelectCommand = new SqlCommand("Select * from Client", cs);    
            //ds.Clear();
            //da.Fill(ds);
            //ChildGridView.DataSource = ds.Tables[0];
        }

        private void insert_Button_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> ColumnNamesList = new List<string>(ConfigurationManager.AppSettings["ChildColumnNames"].Split(','));
                SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["InsertQuerry"], cs);
                foreach (string column in ColumnNamesList)
                {
                    TextBox textBox = (TextBox)panel1.Controls[column];
                    cmd.Parameters.AddWithValue("@" + column, textBox.Text);
                }
                cs.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted Succesfull to the Database");
                ds.Clear();
                da.Fill(ds);
                cs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cs.Close();
            }
        }

        private void delete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> ColumnNamesList = new List<string>(ConfigurationManager.AppSettings["ChildColumnNames"].Split(','));
                SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["DeleteQuerry"], cs);

                TextBox textBox = (TextBox)panel1.Controls[ColumnNamesList[0]];
                cmd.Parameters.AddWithValue("@" + ColumnNamesList[0], textBox.Text);
    
                cs.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Succesfull from the Database");
                ds.Clear();
                da.Fill(ds);
                cs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cs.Close();
            }
        }

        private void update_Button_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> ColumnNamesList = new List<string>(ConfigurationManager.AppSettings["ChildColumnNames"].Split(','));
                SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["UpdateQuerry"], cs);
                foreach (string column in ColumnNamesList)
                {
                    TextBox textBox = (TextBox)panel1.Controls[column];
                    cmd.Parameters.AddWithValue("@" + column, textBox.Text);
                }
                cs.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Succesfull to the Database");
                ds.Clear();
                da.Fill(ds);
                cs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cs.Close();
            }
        }

        private void generate_Button_Click(object sender, EventArgs e)
        {
            int ChildNumberOfColumns = int.Parse(ConfigurationManager.AppSettings["ChildNumberOfColumns"]);
            //string ChildColumnNames = ConfigurationManager.AppSettings["ChildColumnNames"];
            List<string> ColumnNamesList = new List<string>(ConfigurationManager.AppSettings["ChildColumnNames"].Split(','));
            int xAxis = 15;
            int yAxis = 20;
            panel1.Controls.Clear();
            for (int i = 0; i < ChildNumberOfColumns; i++)
            {
                TextBox a = new TextBox();
                a.Width = 120;
                a.Name = ColumnNamesList[i].ToString();
                a.Text = ColumnNamesList[i].ToString();
                a.Location = new Point(xAxis, yAxis);
                panel1.Controls.Add(a);
                panel1.Show();
                yAxis += 40;
            }
        }

        private void select_Button_Click(object sender, EventArgs e)
        {
            int index = ParentGridView.CurrentCell.RowIndex;
            DataGridViewRow row = ParentGridView.Rows[index];
            string ClubName = row.Cells["ClubName"].Value.ToString();
            string selectQuerry = ConfigurationManager.AppSettings["SelectQuerry"];
            da.SelectCommand = new SqlCommand(selectQuerry, cs);
            da.SelectCommand.Parameters.Add("@ClubName", SqlDbType.VarChar).Value = ClubName;
            //da.SelectCommand.Parameters.AddWithValue("@ClubName", ClubName);
            ds.Clear();
            da.Fill(ds);
            ChildGridView.DataSource = ds.Tables[0];
        }
    }    
}