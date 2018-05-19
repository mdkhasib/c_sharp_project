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
    public partial class Form1 : Form
    {
        int ct;
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void startNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 ob = new Form2();
            ob.Show();
            this.Hide();

        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            thisCommand.CommandText =
                "SELECT * FROM member ";

            OracleDataReader thisReader = thisCommand.ExecuteReader();

            ct = 0;

            while (thisReader.Read())
            {
               

                ListViewItem lsvItem = new ListViewItem(thisReader["name"].ToString());

                ct++;

                lsvItem.SubItems.Add(thisReader["cash"].ToString());
                listView1.Items.Add(lsvItem);
            }


            CN.thisConnection.Close();

            label1.Text = ct.ToString();


        



        }

        private void listView1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            dailymeal ob = new dailymeal();
            ob.Show();

        }

        private void editMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editmember ob = new Editmember();
            ob.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addbalance ob = new addbalance();
            ob.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            adddailybazar ob = new adddailybazar();
            ob.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            viewmonth ob = new viewmonth();
            ob.Show();
            this.Hide();
        }

      



       
        }
    }

