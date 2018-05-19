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
    public partial class viewmonth : Form
    {
        int totalmeal=0;
        int totalbazar = 0;
        string[] cname = new string[9];
        double[] tmeal = new double[9];
        string cost;
        string extra;
        int xx;

        double mealrate;
        public viewmonth()
        {
            InitializeComponent();
        }

        private void viewmonth_Load(object sender, EventArgs e)
        {
///////////////////total meal from meal table
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            thisCommand.CommandText =
                "SELECT name , sum(meal) FROM meal group by name ";

            OracleDataReader thisReader = thisCommand.ExecuteReader();
            int i = 0;
           

                while (thisReader.Read())
                {


                    ListViewItem lsvItem = new ListViewItem(thisReader["name"].ToString());



                    lsvItem.SubItems.Add(thisReader["sum(meal)"].ToString());
                    /////// meal2 table update

                    cname[i] = thisReader["name"].ToString();
                    tmeal[i] = Convert.ToDouble(thisReader["sum(meal)"].ToString());

                   // MessageBox.Show(cname[i]+tmeal[i]);

                    /////
                    i++;




                    totalmeal = totalmeal + Convert.ToInt32(thisReader["sum(meal)"].ToString());

                    listView1.Items.Add(lsvItem);
                }

            

            xx = listView1.Items.Count;
            CN.thisConnection.Close();

        label1.Text = totalmeal.ToString();

            ///////////////////////////////////

            //totalbazar from bazar table 
        connection CNN = new connection();
        CNN.thisConnection.Open();

        OracleCommand thisCommand1 = CNN.thisConnection.CreateCommand();

        thisCommand1.CommandText =
            "SELECT name , cost FROM bazar ";

        OracleDataReader thisReader1 = thisCommand1.ExecuteReader();



        while (thisReader1.Read())
        {


            ListViewItem lsvItem = new ListViewItem(thisReader1["name"].ToString());



            lsvItem.SubItems.Add(thisReader1["cost"].ToString());
            totalbazar = totalbazar + Convert.ToInt32(thisReader1["cost"].ToString());

            listView2.Items.Add(lsvItem);
        }


        CN.thisConnection.Close();

        label2.Text = totalbazar.ToString();


        mealrate = Convert.ToDouble(label2.Text)/Convert.ToDouble(label1.Text);

        label3.Text = mealrate.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {


            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            thisCommand.CommandText =
                "SELECT * FROM member ";

            OracleDataReader thisReader = thisCommand.ExecuteReader();

           
            
            while (thisReader.Read())
            {      
                ///

                for (int i = 0; i < xx;i++ )
                {

                    if (thisReader["name"].ToString() == cname[i])
                    {
                        double a = tmeal[i] * Convert.ToDouble(label3.Text);
                        cost = a.ToString();
                        double given = Convert.ToDouble(thisReader["cash"].ToString());

                        double ex = given - a;

                        extra = ex.ToString();

                        ///
                        //


                        ListViewItem lsvItem = new ListViewItem(thisReader["name"].ToString());
                        lsvItem.SubItems.Add(given.ToString());
                        lsvItem.SubItems.Add(cost.ToString());
                        lsvItem.SubItems.Add(extra.ToString());

                        listView3.Items.Add(lsvItem);
                        /*
                                               listView3.Items[i].SubItems[0].Text = nam;
                                                listView3.Items[i].SubItems[1].Text = given.ToString();
                                                listView3.Items[i].SubItems[2].Text = cost.ToString();
                                               listView3.Items[i].SubItems[3].Text = extra.ToString();
                                                */

                    }
                    else
                    {

                    }

                }
                //////
                }
                

                ///

            


            CN.thisConnection.Close();








        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ob = new Form1();
            ob.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
                connection sv = new connection();
                sv.thisConnection.Open();

                OracleCommand thisCommand = sv.thisConnection.CreateCommand();

                thisCommand.CommandText =
                    "delete FROM meal";

                thisCommand.Connection = sv.thisConnection;
                thisCommand.CommandType = CommandType.Text;
                //For Insert Data Into Oracle//
                try
                {
                    thisCommand.ExecuteNonQuery();
                    MessageBox.Show("Updated meal");
                    this.Hide();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                sv.thisConnection.Close();
                this.Close();
            

            
                connection sv1 = new connection();
                sv1.thisConnection.Open();

                OracleCommand thisCommand1 = sv1.thisConnection.CreateCommand();

                thisCommand1.CommandText =
                    "delete FROM member";

                thisCommand1.Connection = sv1.thisConnection;
                thisCommand1.CommandType = CommandType.Text;
                //For Insert Data Into Oracle//
                try
                {
                    thisCommand1.ExecuteNonQuery();
                    MessageBox.Show("Updated member");
                    this.Hide();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                sv1.thisConnection.Close();
                this.Close();

            

            
                connection svv = new connection();
                svv.thisConnection.Open();

                OracleCommand thisCommand2 = svv.thisConnection.CreateCommand();

                thisCommand2.CommandText =
                    "delete FROM bazar";

                thisCommand2.Connection = svv.thisConnection;
                thisCommand2.CommandType = CommandType.Text;
                //For Insert Data Into Oracle//
                try
                {
                    thisCommand2.ExecuteNonQuery();
                    MessageBox.Show("Updated bazar");
                    this.Hide();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                svv.thisConnection.Close();
                this.Close();


                this.Hide();
                Form1 ob = new Form1();
                ob.Show();
            }
        }
    }

