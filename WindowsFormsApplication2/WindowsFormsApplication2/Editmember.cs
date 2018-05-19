using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace WindowsFormsApplication2
{
    public partial class Editmember : Form
    {
        public Editmember()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            connection sv = new connection();
            sv.thisConnection.Open();
            
            OracleCommand thisCommand = sv.thisConnection.CreateCommand();

            thisCommand.CommandText =
                "update member set name = '" + textBox2.Text + "',cash='" + textBox3.Text + "'  where id= '" + textBox1.Text + "'";

            thisCommand.Connection = sv.thisConnection;
            thisCommand.CommandType = CommandType.Text;
            //For Insert Data Into Oracle//
            try
            {
                thisCommand.ExecuteNonQuery();
                MessageBox.Show("Updated");
                this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sv.thisConnection.Close();
            this.Close();

            Form1 ob = new Form1();
            ob.Show();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();
            textBox2.Text = "";
            textBox3.Text = "";

            thisCommand.CommandText =
            "SELECT * FROM member where id = '" + textBox1.Text + "'";

            OracleDataReader thisReader = thisCommand.ExecuteReader();


            while (thisReader.Read())
            {
                
             
                textBox2.Text = thisReader["name"].ToString();
                textBox3.Text = thisReader["cash"].ToString();
                

                try
                {
                    // string filePath = thisReader["picture"].ToString();
                    // this.pb_profilepics.Image = Image.FromFile(filePath);
                }
                catch
                { MessageBox.Show("Failure"); }


            }
            CN.thisConnection.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ob = new Form1();
            ob.Show();

        }
    }
}
