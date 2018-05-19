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
    public partial class dailymeal : Form
    {
        int daycount;
        public dailymeal()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dailymeal_Load(object sender, EventArgs e)
        {
           //meal table
            connection cd = new connection();
            cd.thisConnection.Open();

            OracleCommand thisCommand1 = cd.thisConnection.CreateCommand();

            thisCommand1.CommandText =
                "SELECT * FROM meal ";

            OracleDataReader thisReader1 = thisCommand1.ExecuteReader();

            Boolean x;
            if (x = thisReader1.Read())
            {


                while (thisReader1.Read())
                {

                    daycount = Convert.ToInt32(thisReader1["day"].ToString());
                }


                cd.thisConnection.Close();
                daycount++;

            }else
            {
                daycount = 1;
            
            }


            label1.Text = daycount.ToString();
/// member table
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
                lsvItem.SubItems.Add(label1.Text);
                lsvItem.SubItems.Add(textBox1.Text);
               
                listView1.Items.Add(lsvItem);

            }
            CN.thisConnection.Close();

            

        }



        private void button1_Click(object sender, EventArgs e)
        {
            /////
            for (int x = 0; x < listView1.Items.Count; x++)
            //    ListView1.Items.Count - 1; x++)
            {
                connection sv = new connection();
                sv.thisConnection.Open();

                OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM meal", sv.thisConnection);

                OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "meal");

                DataRow thisRow = thisDataSet.Tables["meal"].NewRow();
                try
                {

                    //MessageBox.Show(listView1.Items[x].SubItems[0].Text);


                    thisRow["id"] = listView1.Items[x].SubItems[1].Text;
                    thisRow["name"] = listView1.Items[x].SubItems[0].Text;
                    thisRow["day"] = listView1.Items[x].SubItems[2].Text;
                    thisRow["meal"] = listView1.Items[x].SubItems[3].Text;
                    

                    thisDataSet.Tables["meal"].Rows.Add(thisRow);



                    thisAdapter.Update(thisDataSet, "meal");
                   
                }



                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sv.thisConnection.Close();
            }


            //////

            MessageBox.Show("Submitted");
            Form1 ob = new Form1();
            ob.Show();
            this.Hide();


        }
    

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
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
                lsvItem.SubItems.Add(label1.Text);
                lsvItem.SubItems.Add(textBox1.Text);

                listView1.Items.Add(lsvItem);

            }
            CN.thisConnection.Close();

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            label3.Text = listView1.SelectedItems[0].SubItems[0].Text;
           textBox2.Text =  listView1.SelectedItems[0].SubItems[3].Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listView1.SelectedItems[0].SubItems[3].Text = textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ob = new Form1();
            ob.Show();
        }
        
    }
}
