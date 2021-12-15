using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Fast_food_Project
{
    public partial class Form4 : Form
    {
        public List<string> food = new List<string>();
        
        public Form4(List<String> order, int price)
        {
            InitializeComponent();
            foreach(string val in order)
            {
                food.Add(val);
            }
            label3.Text = "N" + Convert.ToString(price);
            label12.Text = "N" + Convert.ToString(price);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var message = string.Join(Environment.NewLine, food);
            MessageBox.Show(message, "ORDER SUMMARY", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            string lname = textBox2.Text;
            string email = textBox3.Text;
            string Telno = textBox4.Text;
            string method;

            try
            {
                if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text)
                    || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) 
                    || checkBox1.Checked)
                {
                    if (radioButton1.Checked && radioButton2.Checked)
                    {
                        MessageBox.Show("You can only use one method of payment", "ERROR MESSGAE", MessageBoxButtons.OK);
                    }
                    else if (!radioButton1.Checked && !radioButton2.Checked)
                    {
                        MessageBox.Show("Pick a payment method", "ERROR MESSAGE", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (radioButton1.Checked)
                        {
                            method = "Pay on delivery";
                        }

                        else 
                        {
                            method = "Pay online";
                        }

                        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password='';database=abby-clay's diner; SSL mode =none";
                        
                        string query = "INSERT INTO customerinfo VALUES (' " + fname + " ', ' " + lname + " ', ' " + email + " ', ' " + Telno + " ', ' " + method + " ')";

                        
                        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                        MySqlCommand insertData = new MySqlCommand(query, databaseConnection);
                        //commandDatabase.CommandTimeout = 60;
                        MySqlDataReader reader;

                        try
                        {
                            databaseConnection.Open();
                            reader = insertData.ExecuteReader();
                            //Successfully updated
                            databaseConnection.Close();
                        }
                        catch (Exception ex)
                        {
                            //Oops, maybe the id doesn't exist
                            MessageBox.Show(ex.Message);
                        }

                        if (radioButton2.Checked)
                        {
                            this.Hide();
                            Form5 frm = new Form5();
                            frm.ShowDialog();
                        }

                        MessageBox.Show("Your order is successful! It will be delivered to you shortly!");
                        Application.Exit();
                        /*this.Hide();
                        Form5 frm2 = new Form5();
                        frm2.ShowDialog(); */
                    }
                }
                else
                {
                    MessageBox.Show("Go back and fill all required fields");
                }
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
            //Application.Exit();
        }
    }
}
