using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smsnew
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //
            customizeDesign();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            new teach().Show();
            //
            hideSubmenu();
        }

        private void button_std_Click(object sender, EventArgs e)
        {
            //
            showSubmenu(panel_stdsubmenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {//
            hideSubmenu();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void customizeDesign()
        {
            panel_stdsubmenu.Visible = false;
            panel1.Visible = false;
            
        }
        private void hideSubmenu()
        {
            if (panel_stdsubmenu.Visible == true)
                panel_stdsubmenu.Visible = false;
            if (panel1.Visible == true)
                panel1.Visible = false;
           



        }
        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;



        }


        private void button5_Click(object sender, EventArgs e)
        {
            showSubmenu(panel1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new reg().Show();
            hideSubmenu();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            new _5a().Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            hideSubmenu();
            new _5b().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult iQuit;
            iQuit = MessageBox.Show("Confirm if you went to Exit ", "Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iQuit == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
            new login().Show();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
