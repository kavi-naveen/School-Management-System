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
    public partial class teach : Form
    {
        public teach()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=school;username=root;password=");
        MySqlCommand command;
        public void populateDGV()
        {
            // populate the datagridview
            string selectQuery = "SELECT * FROM teacher";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);
            guna2DataGridView1.DataSource = table;
        }
        public void searchData(String valueToSearch)
        {
            String query = "SELECT * FROM teacher WHERE  CONCAT (Teacher_id,Name) like '%" + valueToSearch + "%'";
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
        private void teach_Load(object sender, EventArgs e)
        {
            show();
            populateDGV();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (nm.Text != "" && si.Text != "" && add.Text != "")
            {
                try
                {
                    //This is my connection string i have assigned the database file address path
                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=";
                    //This is my insert query in which i am taking input from the user through windows forms
                    string Query = "insert into school.teacher(Teacher_id,Name,Phone,Dob,Gender,Address) values('"+this.si.Text+"','" + this.nm.Text + "','" + this.pn.Text + "','" + this.dob1.Value.ToString("yyyy.MM.dd") + "','" + this.gen.Text + "','" + this.add.Text + "');";
                    //This is  MySqlConnection here i have created the object and pass my connection string.
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    //This is command class which will handle the query and connection object.
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.`
                    MessageBox.Show("Save Data");
                    nm.Text = "";
                    si.Text = "";
                    add.Text = "";
                    pn.Text = "";


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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void show()
        {
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=school;port=3306; username = root; password= "); //open connection
            con.Open();
            guna2DataGridView1.DataSource = null;
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from teacher", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            guna2DataGridView1.Columns[0].Width = 100;
            guna2DataGridView1.Columns[1].Width = 100;
            guna2DataGridView1.Columns[2].Width = 100;
            guna2DataGridView1.Columns[3].Width = 100;
            guna2DataGridView1.Columns[4].Width = 100;
            guna2DataGridView1.Columns[5].Width = 100;

            con.Close();
            populateDGV();
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            si.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            nm.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            pn.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            //dob1.Value = Convert.ToDateTime(guna2DataGridView1.CurrentRow.Cells[3].Value);
            dob1.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            gen.Text = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
            add.Text = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (si.Text != "" && nm.Text != "" && pn.Text != "" && dob1.Text != "" && gen.Text != "" && add.Text != "")
            {
                string deleteQuery = "DELETE FROM `teacher` WHERE `teacher`.`Teacher_id` = " + Int32.Parse(si.Text);
                executeMyQuery(deleteQuery);
                populateDGV();
                si.Text = "";
                nm.Text = "";
                pn.Text = "";
                dob1.Text = "";
                gen.Text = "";
                add.Text = "";
            }
            else
            {
                MessageBox.Show("Enter complete data for delete");
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            nm.Text = "";
            si.Text = "";
            add.Text = "";
            pn.Text = "";
            dob1.Text = "";
            gen.Text = "";
            textBox1.Text = "";
            String valueToSearch = textBox1.Text.ToString();

            searchData(valueToSearch);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my connection string i have assigned the database file address path
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=";
                //This is my update query in which i am taking input from the user through windows forms and update the record.
                string Query = "update school.teacher set Teacher_id='" + this.si.Text + "',name='" + this.nm.Text + "',Phone='" + this.pn.Text + "',Dob='" + this.dob1.Value.ToString("yyyy.MM.dd") + "',Gender='" + this.gen.Text + "',Address='" + this.add.Text + "' where Teacher_id='" + this.si.Text + "';";
                //This is  MySqlConnection here i have created the object and pass my connection string.
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                nm.Text = "";
                si.Text = "";
                add.Text = "";
                pn.Text = "";
                dob1.Text = "";
                gen.Text = "";
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
            

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dob1_ValueChanged(object sender, EventArgs e)
        {
            dob1.Format = DateTimePickerFormat.Custom;
            dob1.CustomFormat = "yyyy.MM.dd";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            String valueToSearch = textBox1.Text.ToString();
            searchData(valueToSearch);
        }
    }
    }

    
   

