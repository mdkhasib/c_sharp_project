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
    public partial class adddailybazar : Form
    {
        public adddailybazar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();

            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM bazar", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "bazar");

            DataRow thisRow = thisDataSet.Tables["bazar"].NewRow();
            try
            {

                
                thisRow["name"] = textBox1.Text;
                thisRow["cost"] = textBox2.Text;



                thisDataSet.Tables["bazar"].Rows.Add(thisRow);



                thisAdapter.Update(thisDataSet, "bazar");
                MessageBox.Show("Submitted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();

            textBox1.Text = "";
            textBox2.Text = "";



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ob = new Form1();
            ob.Show();
            this.Hide();
        }
    }
}
