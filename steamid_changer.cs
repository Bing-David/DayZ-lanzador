

//Herramientas y depenncias usadas
using DayZ_Launcher;
using DayZ_Launcher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DayZ_Launcher
{
  

    public partial class steamid_changer : Form
    {
        public steamid_changer()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string text = File.ReadAllText(".Chernarus.ini");  //sv
            string text2 = File.ReadAllText(".Chernarus_two.ini"); //pvp

            string nombre = File.ReadAllText(@"config\Nombre.ini");


            if (textBox1.Text == "")
            {
                string myStringVariable1 = string.Empty;
                MessageBox.Show("Ingresa un apodo");
                return;
            }
            text = text.Replace("CHANGEME", textBox1.Text); //Remplaca de Chernarus.ini(survival) el valor CHANGAME Por lo que pongas en el campo.
            text2 = text2.Replace("CHANGEME", textBox1.Text);    //asi Mismo con el Chernarus_two.ini(PVP).
            nombre = nombre.Replace("CHANGEME", textBox1.Text);

            File.WriteAllText(".Chernarus.ini", text); //sv
            File.WriteAllText(".Chernarus_two.ini", text2); //pvp
            File.WriteAllText(@"config\Nombre.ini", nombre);
            MessageBox.Show("Tu apodo ha sido establecido");
            this.Close();
        }


        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) { e.Handled = true; }  // only numbers

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)

        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void steamid_changer_Load(object sender, EventArgs e)

        {
            //Sobre escribe el archivo añadiendo Los datos que allas Puesto en Steamid_Chancher
            //--->Osa añade el nombre xd.
            File.WriteAllText(".Chernarus.ini", Resources._Chernarus); //Testing server
            File.WriteAllText(".Chernarus_two.ini", Resources._Chernarus_two); //Survival main
            File.WriteAllText(@"config\Nombre.ini", Resources.Nombre);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
