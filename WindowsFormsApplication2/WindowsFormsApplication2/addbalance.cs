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
    public partial class addbalance : Form
    {
        double cash;
        double total;
        public addbalance()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();
            textBox2.Text = "";
            
            thisCommand.CommandText =
            "SELECT * from member where id = '" + textBox1.Text + "'";

            OracleDataReader thisReader = thisCommand.ExecuteReader();


            while (thisReader.Read())
            {


                textBox3.Text = thisReader["name"].ToString();
                cash =  Convert.ToDouble(thisReader["cash"].ToString()) ;

               // MessageBox.Show(cash.ToString());
              

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

        private void button1_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();

            OracleCommand thisCommand = sv.thisConnection.CreateCommand();

            thisCommand.CommandText =
                "update member set cash='" + label5.Text + "'  where id= '" + textBox1.Text + "'";

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           // textBox2.Text = "0";
            double cas = Convert.ToDouble(textBox2.Text);
          
           total  = cash + cas;

            label5.Text = total.ToString();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {

                textBox4.Enabled = true;
                textBox2.Enabled = false;

            }
        }

        private void addbalance_Load(object sender, EventArgs e)
        {
            textBox4.Enabled = false;
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            thisCommand.CommandText =
                "SELECT * FROM member ";

            OracleDataReader thisReader = thisCommand.ExecuteReader();


            while (thisReader.Read())
            {


                ListViewItem lsvItem = new ListViewItem(thisReader["name"].ToString());
                lsvItem.SubItems.Add(thisReader["id"].ToString());
                lsvItem.SubItems.Add(thisReader["cash"].ToString());
              
                listView1.Items.Add(lsvItem);






            }


            CN.thisConnection.Close();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           // textBox4.Text = "0";
            double cas = Convert.ToDouble(textBox4.Text);

             total = cash - cas;

            label5.Text = total.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ob = new Form1();
            ob.Show();
            this.Hide();
        }
    }
}
