using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace smsnew
{
    public partial class place2 : Form
    {
        public place2()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;database=school;username=root;password=");
        MySqlCommand command;
        public void populateDGV()
        {
            // populate the datagridview
            string selectQuery = "SELECT * FROM `5b` ORDER BY `5b`.`Total` DESC";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
            adapter.Fill(table);
            guna2DataGridView1.DataSource = table;
        }
        private void place2_Load(object sender, EventArgs e)
        {
            
        }
        private void show()
        {
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=school;port=3306; username = root; password= "); //open connection
            con.Open();
            guna2DataGridView1.DataSource = null;
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `5b` ORDER BY `5b`.`Total` DESC", con);
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
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            show();
            populateDGV();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new _5b().Show();


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
    }
}
