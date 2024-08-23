using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace smsnew
{
    public partial class login : Form
    {
        public bool Admin { get; private set; }

        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            add.PasswordChar = '●';
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (cb1.Text == "Admin" && add.Text == "123")
            {
                new Form1().Show();
                add.Text = "";
                this.Hide();
            }
            else if(cb1.Text == "5A Teacher" && add.Text == "123")
            {
                new _5a().Show();
                add.Text = "";
                this.Hide();
            }
            else if (cb1.Text == "5B Teacher" && add.Text == "123")
            {
                new _5b().Show();
                add.Text = "";
                this.Hide();
            }
            else
            {
                MessageBox.Show("invalid password or username", "Error");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ch1.Checked)
            {
                add.PasswordChar = '\0';


            }
            else { add.PasswordChar = '●'; }
        }

        private void guna2Button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void guna2Button1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
