using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;

namespace smsnew
{
    public partial class _5a : Form
    {
        public _5a()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=school;username=root;password=");
        MySqlCommand command;
        public void populateDGV()
        {
            // populate the datagridview
            string selectQuery = "SELECT * FROM 5a";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);
            guna2DataGridView1.DataSource = table;
        }
        public void searchData(String valueToSearch)
        {
            String query = "SELECT * FROM 5a WHERE CONCAT (Student_id,Name) like '%" + valueToSearch + "%'";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            guna2DataGridView1.DataSource = table;
        }
        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public void executeMyQuery(string query)
        {
            try
            {
                openConnection();
                command = new MySqlCommand(query, connection);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Query Executed");
                }

                else
                {
                    MessageBox.Show("Query Not Executed");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            new login().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int num1;
            int num2;
            int num3;
            int num4;
            int num5;
            int ans;
            int avg;
            num1 = Convert.ToInt32(a.Text);
            num2 = Convert.ToInt32(b.Text);
            num3 = Convert.ToInt32(c.Text);
            num4 = Convert.ToInt32(d.Text);
            num5 = Convert.ToInt32(h.Text);
            ans = num1+num2 + num3 + num4+num5;
            lb1.Text=Convert.ToString(ans);
            avg=ans/5;
            lb2.Text = Convert.ToString(avg);



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            st.Text = "";
            nm.Text = "";
            a.Text = "";
            b.Text = "";
            c.Text = "";
            d.Text = "";
            h.Text = "";
            lb1.Text = "";
            lb2.Text = "";
            textBox1.Text = "";
            String valueToSearch = textBox1.Text.ToString();

            searchData(valueToSearch);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my connection string i have assigned the database file address path
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=";
                //This is my update query in which i am taking input from the user through windows forms and update the record.
                string Query = "update school.5a set Student_id='" + this.st.Text + "',Name='" + this.nm.Text + "', Sinhala='" + this.a.Text + "',English='" + this.b.Text + "',Mathematics='" + this.c.Text+ "',Environment='" + this.d.Text + "',Realign='" + this.h.Text + "',Total='" + this.lb1.Text + "',Average='" + this.lb2.Text+"'  where Student_id='" + this.st.Text + "';";
                //This is  MySqlConnection here i have created the object and pass my connection string.
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                st.Text = "";
                nm.Text = "";
                a.Text = "";
                b.Text = "";
                c.Text = "";
                d.Text = "";
                h.Text = "";
                lb1.Text = "";
                lb2.Text = "";
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();//Connection closed here
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            
            populateDGV();

        
    }

        private void button1_Click(object sender, EventArgs e)
        {
            if (a.Text != "" && st.Text != "" && b.Text != "")
            {
                try
                {
                    //This is my connection string i have assigned the database file address path
                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=";
                    //This is my insert query in which i am taking input from the user through windows forms
                    string Query = "insert into school.5a(Student_id,Name,Sinhala,English,Mathematics,Environment,Realign,Total,Average) values('"+ this.st.Text + "','"+this.nm.Text+"','"+ this.a.Text + "','" + this.b.Text + "','" + this.c.Text + "','" + this.d.Text + "','" + this.h.Text + "','" + this.lb1.Text + "','" + this.lb2.Text + "');";
                    //This is  MySqlConnection here i have created the object and pass my connection string.
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    //This is command class which will handle the query and connection object.
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.`
                    MessageBox.Show("Save Data");
                    st.Text = "";
                    nm.Text = "";
                    a.Text = "";
                    b.Text = "";
                    c.Text = "";
                    d.Text = "";
                    h.Text = "";
                    lb1.Text = "";
                    lb2.Text = "";
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                populateDGV();

            }
            else
            {
                MessageBox.Show("please fill form");
            }
        }
            private void show()
            {
                MySqlConnection con = new MySqlConnection("datasource= localhost; database=school;port=3306; username = root; password= "); //open connection
                con.Open();
                guna2DataGridView1.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter("select * from 5a", con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                guna2DataGridView1.Columns[0].Width = 100;
                guna2DataGridView1.Columns[1].Width = 100;
                guna2DataGridView1.Columns[2].Width = 100;
                guna2DataGridView1.Columns[3].Width = 100;
                guna2DataGridView1.Columns[4].Width = 100;
                guna2DataGridView1.Columns[5].Width = 100;
                guna2DataGridView1.Columns[6].Width = 100;

                con.Close();
                populateDGV();
            }

        private void a_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            st.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            nm.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            a.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            b.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            //dob1.Value = Convert.ToDateTime(guna2DataGridView1.CurrentRow.Cells[3].Value);
            c.Text = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
            d.Text = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
            h.Text = guna2DataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void _5a_Load(object sender, EventArgs e)
        {

            show();
            populateDGV();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (st.Text != "" && nm.Text !="" && a.Text != "" && b.Text != "" && c.Text != "" && d.Text != "" && h.Text != "")
            {
                string deleteQuery = "DELETE FROM `5a` WHERE `5a`.`Student_id` = " + Int32.Parse(st.Text);
                executeMyQuery(deleteQuery);
                populateDGV();
                st.Text = "";
                nm.Text = "";
                a.Text = "";
                b.Text = "";
                c.Text = "";
                d.Text = "";
                h.Text = "";
                lb1.Text = "";
                lb2.Text = "";
            }
            else
            {
                MessageBox.Show("Enter complete data for delete");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            place obj = new place();
            obj.Show();
            this.Close();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {

            String valueToSearch = textBox1.Text.ToString();
            searchData(valueToSearch);
        }
    }
    }

