using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fast_food_Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a list to contain the items in the checkbox
            List<string> Result = new List<string>();
            List<int> price = new List<int>();
            int totalPrice = 0;

            //Put each item into a list
            if (box1.Checked == true) 
            {
                Result.Add(box1.Text);
                price.Add(Convert.ToInt32(lbl1.Text));
            }

            if(checkBox2.Checked == true)
            {
                Result.Add(checkBox2.Text);
                price.Add(Convert.ToInt32(lbl2.Text));
            }

            if(checkBox3.Checked == true)
            {
                Result.Add(checkBox3.Text);
                price.Add(Convert.ToInt32(lbl3.Text));
            }

            if(checkBox4.Checked == true)
            {
                Result.Add(checkBox4.Text);
                price.Add(Convert.ToInt32(lbl4.Text));
            }

            if(checkBox5.Checked == true)
            {
                Result.Add(checkBox5.Text);
                price.Add(Convert.ToInt32(lbl5.Text));
            }

            if(checkBox6.Checked == true)
            {
                Result.Add(checkBox6.Text);
                price.Add(Convert.ToInt32(lbl6.Text));
            }

            if(checkBox7.Checked == true)
            {
                Result.Add(checkBox7.Text);
                price.Add(Convert.ToInt32(lbl7.Text));
            }

            if(checkBox8.Checked == true)
            {
                Result.Add(checkBox8.Text);
                price.Add(Convert.ToInt32(lbl8.Text));
            }

            if(checkBox9.Checked == true)
            {
                Result.Add(checkBox9.Text);
                price.Add(Convert.ToInt32(lbl9.Text));
            }

            for(int i = 0; i < price.Count; i++)
            {
                totalPrice += price[i];
            }

            try
            {
                this.Hide();
                Form3 frm = new Form3(Result, totalPrice, price);
                frm.ShowDialog();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
