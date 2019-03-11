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

namespace Practic
{
    public partial class Form1 : Form
    {
            SqlConnection connection = new SqlConnection("Data Source = JARVIS\\SQLEXPRESS; Initial Catalog = WaterPark; Integrated Security = True");
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlDataAdapter da2 = new SqlDataAdapter();
            DataSet ds2 = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void populate_Button_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new SqlCommand("SELECT * FROM Tickets", connection);
            ds.Clear();
            da.Fill(ds);
            TicketsGridView.DataSource = ds.Tables[0];
        }


        private void select_Button_Click(object sender, EventArgs e)
        {
            int index = TicketsGridView.CurrentCell.RowIndex;
            DataGridViewRow row = TicketsGridView.Rows[index];
            string TicketID = row.Cells["TIID"].Value.ToString();
            da2.SelectCommand = new SqlCommand("SELECT * FROM Adults WHERE TIID = @tid", connection);
            da2.SelectCommand.Parameters.Add("@tid", SqlDbType.Int).Value = TicketID;
            ds2.Clear();
            da2.Fill(ds2);
            AdultsGridView.DataSource = ds2.Tables[0];
        }

        private void delete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                da.DeleteCommand = new SqlCommand("DELETE FROM Adults WHERE AID = @aid", connection);
                da.DeleteCommand.Parameters.Add("@aid", SqlDbType.Int).Value = Int32.Parse(textBox9.Text);

                connection.Open();
                da.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("Deleted Succesfull from the Database");
                connection.Close();
                da.Fill(ds);
                TicketsGridView.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void update_Button_Click(object sender, EventArgs e)
        {
            try
            {
                da.UpdateCommand = new SqlCommand("UPDATE Adults SET AName = @an, Age = @ag WHERE AID = @aid", connection);
                da.UpdateCommand.Parameters.Add("@aid", SqlDbType.Int).Value = Int32.Parse(textBox6.Text);
                da.UpdateCommand.Parameters.Add("@an", SqlDbType.VarChar).Value = textBox7.Text;
                da.UpdateCommand.Parameters.Add("@ag", SqlDbType.Int).Value = Int32.Parse(textBox8.Text);

                connection.Open();
                da.UpdateCommand.ExecuteNonQuery();
                MessageBox.Show("Updated Succesfull to the Database");
                connection.Close();
                da.Fill(ds);
                TicketsGridView.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void insert_Button_Click(object sender, EventArgs e)
        {
            try
            {
                da.InsertCommand = new SqlCommand("INSERT INTO Adults(AID, AName, Age, TIID, RID) VALUES(@aid, @an, @ag, @tiid, @rid)", connection);
                da.InsertCommand.Parameters.Add("@aid", SqlDbType.Int).Value = Int32.Parse(textBox1.Text);
                da.InsertCommand.Parameters.Add("@an", SqlDbType.VarChar).Value = textBox2.Text;
                da.InsertCommand.Parameters.Add("@ag", SqlDbType.Int).Value = Int32.Parse(textBox3.Text);
                da.InsertCommand.Parameters.Add("@tiid", SqlDbType.Int).Value = Int32.Parse(textBox4.Text);
                da.InsertCommand.Parameters.Add("@rid", SqlDbType.Int).Value = Int32.Parse(textBox5.Text);

                connection.Open();
                da.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Inserted Succesfull to the Database");
                connection.Close();
                da.Fill(ds);
                TicketsGridView.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
    }
}
