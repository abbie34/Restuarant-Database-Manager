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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
            {
                flag = true;
            }
            else
            {
                MessageBox.Show("You have to pick a payment method!", "Error message");
            }

            if (flag = true && !String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text)
                && !String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text)
                && !String.IsNullOrEmpty(textBox5.Text) && !String.IsNullOrEmpty(textBox6.Text)
                && !String.IsNullOrEmpty(textBox7.Text))
            {
                try
                {
                    MessageBox.Show("Congratulations! You have successfully completed your order! " +
                   "Your delivery is on the way! Your receipt will be handed to you with your delivery"
                   , "PAYMENT SUCCESSFUL", MessageBoxButtons.OK);
                    Application.Exit();
                    /*
                    string connectionString = "dataresource=127.0.0.1;port=3306;username=root;password=ibk;database=Abby-Clay's Diner;";
                    string query = "INSERT INTO food VALUES (' " + food[0] + " ', ' " + food[1] + " ')";

                    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.CommandTimeout = 60;
                    MySqlDataReader reader;
                    */
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Go back and fill all the required fields!", "Error message");
            }
        }

        
    }
}
