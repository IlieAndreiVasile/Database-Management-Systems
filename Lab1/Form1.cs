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

namespace Lab1
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection("Data Source = JARVIS\\SQLEXPRESS; Initial Catalog = Soccerstats; Integrated Security = True");
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
            da.SelectCommand = new SqlCommand("SELECT * FROM Clubs", connection);
            ds.Clear();
            da.Fill(ds);
            ClubsGridView.DataSource = ds.Tables[0];
        }

        private void select_Button_Click(object sender, EventArgs e)
        {
            int index = ClubsGridView.CurrentCell.RowIndex;
            DataGridViewRow row = ClubsGridView.Rows[index];
            string ClubName = row.Cells["ClubName"].Value.ToString();
            da2.SelectCommand = new SqlCommand("SELECT * FROM Players WHERE ClubName = @cn", connection);
            da2.SelectCommand.Parameters.Add("@cn", SqlDbType.VarChar).Value = ClubName;
            ds2.Clear();
            da2.Fill(ds2);
            PlayersGridView.DataSource = ds2.Tables[0];
        }

        private void insert_Button_Click(object sender, EventArgs e)
        {
            try
            { 
            da.InsertCommand = new SqlCommand("INSERT INTO Players(Pid, Name, BirthDate, Nationality, KitNr, Position, BootsName, ClubName, NTName) VALUES(@pid, @nam, @bd, @nat, @kn, @pos, @bn, @cn, @nt)", connection);
            da.InsertCommand.Parameters.Add("@pid", SqlDbType.Int).Value = Int32.Parse(textBox1.Text);
            da.InsertCommand.Parameters.Add("@nam", SqlDbType.VarChar).Value = textBox2.Text;
            da.InsertCommand.Parameters.Add("@bd", SqlDbType.Date).Value = textBox3.Text;
            da.InsertCommand.Parameters.Add("@nat", SqlDbType.VarChar).Value = textBox4.Text;
            da.InsertCommand.Parameters.Add("@kn", SqlDbType.Int).Value = Int32.Parse(textBox5.Text);
            da.InsertCommand.Parameters.Add("@pos", SqlDbType.VarChar).Value = textBox6.Text;
            da.InsertCommand.Parameters.Add("@bn", SqlDbType.VarChar).Value = textBox7.Text;
            da.InsertCommand.Parameters.Add("@cn", SqlDbType.VarChar).Value = textBox8.Text;
            da.InsertCommand.Parameters.Add("@nt", SqlDbType.VarChar).Value = textBox9.Text;
            
            connection.Open();
            da.InsertCommand.ExecuteNonQuery();
            MessageBox.Show("Inserted Succesfull to the Database");
            connection.Close();
            da.Fill(ds);
            ClubsGridView.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void delete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                da.DeleteCommand = new SqlCommand("DELETE FROM Players WHERE Pid = @pid", connection);
                da.DeleteCommand.Parameters.Add("@pid", SqlDbType.Int).Value = Int32.Parse(textBox10.Text);

                connection.Open();
                da.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("Deleted Succesfull from the Database");
                connection.Close();
                da.Fill(ds);
                ClubsGridView.DataSource = ds.Tables[0];
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
                da.UpdateCommand = new SqlCommand("UPDATE Players SET KitNr = @kn, BootsName = @bn, ClubName = @cn WHERE Pid = @pid", connection);
                da.UpdateCommand.Parameters.Add("@pid", SqlDbType.Int).Value = Int32.Parse(textBox11.Text);
                da.UpdateCommand.Parameters.Add("@kn", SqlDbType.Int).Value = Int32.Parse(textBox12.Text);
                da.UpdateCommand.Parameters.Add("@bn", SqlDbType.VarChar).Value = textBox13.Text;
                da.UpdateCommand.Parameters.Add("@cn", SqlDbType.VarChar).Value = textBox14.Text;

                connection.Open();
                da.UpdateCommand.ExecuteNonQuery();
                MessageBox.Show("Updated Succesfull to the Database");
                connection.Close();
                da.Fill(ds);
                ClubsGridView.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
    }
}
