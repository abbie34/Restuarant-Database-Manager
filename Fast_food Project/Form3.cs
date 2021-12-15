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
    public partial class Form3 : Form
    {
        public List<string> food = new List<string>();
        public List<int> prices = new List<int>();
        int price;
        public Form3(List<String> Result, int total, List<int> cost)
        {
            InitializeComponent();
            foreach(string val in Result)
            {
                foodBox.Text += val + "\n";
                food.Add(val);
            }

            label5.Text = "N" + Convert.ToString(total);
            price = total;

            foreach(int val in cost)
            {
                prices.Add(val);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //System.Random random = new System.Random();
            //string message = "Customer" + Convert.ToString(random.Next(10));

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password='';database=abby-clay's diner; SSL mode =none";

            //string query3 = "CREATE TABLE " + message + "(Food char(50), Price char(50), Order_Number char(50))";

            for (int i = 0; i < food.Count; i++)
            {
                string query = "INSERT INTO food VALUES (' " + food[i] + " ', ' " + prices[i] + " ', ' " + i + " ')";
                
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                //MySqlCommand createTable = new MySqlCommand(query3, databaseConnection);
                MySqlCommand insertData = new MySqlCommand(query, databaseConnection);
                //MySqlCommand createTable = new MySqlCommand(query3, databaseConnection);
                //commandDatabase.CommandTimeout = 60;
                MySqlDataReader reader;
                

                try
                {
                    databaseConnection.Open(); 
                    reader = insertData.ExecuteReader();
                    //reader4 = createTable.ExecuteReader();
                    //Successfully updated
                    databaseConnection.Close();
                }

                catch (Exception ex)
                {
                    //Oops, maybe the id doesn't exist
                    MessageBox.Show(ex.Message);
                }
            }
            //databaseConnection.Close();
            this.Hide();
            Form4 frm = new Form4(food, price);
            frm.ShowDialog();
        }
    }
}
