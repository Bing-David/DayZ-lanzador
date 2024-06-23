using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using New_Test_Launcher;

namespace DayZ_Launcher
{
    public partial class nucleos : Form
    {
        public nucleos()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText(".Chernarus.ini");
            string text2 = File.ReadAllText(".Chernarus_two.ini");

            if (textBox1.Text == "")
            {
                string myStringVariable1 = string.Empty;
                MessageBox.Show("Ingresa tus configuraciones");
                return;
            }
            if (textBox2.Text == "")
            {
                string myStringVariable1 = string.Empty;
                MessageBox.Show("Ingresa tus configuraciones");
                return;
            }
            if (textBox3.Text == "")
            {
                string myStringVariable1 = string.Empty;
                MessageBox.Show("Ingresa tus configuraciones");
                return;
            }

            text = text.Replace("¡", textBox1.Text);
            text2 = text2.Replace("¡", textBox1.Text);

            File.WriteAllText(".Chernarus.ini", text);
            File.WriteAllText(".Chernarus_two.ini", text2);


            text = text.Replace("!", textBox2.Text);
            text2 = text2.Replace("!", textBox2.Text);


            File.WriteAllText(".Chernarus.ini", text);
            File.WriteAllText(".Chernarus_two.ini", text2);


            text = text.Replace("2048", textBox3.Text);
            text2 = text2.Replace("2048", textBox3.Text);


            File.WriteAllText(".Chernarus.ini", text);
            File.WriteAllText(".Chernarus_two.ini", text2);



            MessageBox.Show("Tus configuraciones han sido guardadas");
            this.Hide();
            
        }

        public void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void nucleos_Load(object sender, EventArgs e)
        {
            steamid_changer newform = new steamid_changer();
                newform.ShowDialog();
                return;
           

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void nucleos_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void nucleos_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }

}
