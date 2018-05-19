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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ob = new Form1();
            ob.Show();
            this.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();

            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM member", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "member");

            DataRow thisRow = thisDataSet.Tables["member"].NewRow();
            try
            {

                thisRow["id"] = textBox1.Text;
                thisRow["name"] = textBox2.Text;
                thisRow["cash"] = textBox3.Text;
             


                thisDataSet.Tables["member"].Rows.Add(thisRow);



                thisAdapter.Update(thisDataSet, "member");
                MessageBox.Show("Submitted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";


            
        }
    }
}
