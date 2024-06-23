using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayZ_Launcher
{
    public partial class please_wait : Form
    {
        public please_wait()
        {
            InitializeComponent();
        }

        Timer t1 = new Timer();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private void please_wait_Load(object sender, EventArgs e)
        {
            Opacity = 0;      //first the opacity is 0

            t1.Interval = 50;  //we'll increase the opacity every 10ms
            t1.Tick += new EventHandler(fadeIn);  //this calls the function that changes opacity 
            t1.Start();
        }

        void fadeIn(object sender, EventArgs e)
        {
            if (Opacity >= 1)
                t1.Stop();   //this stops the timer if the form is completely displayed
            else
                Opacity += 0.05;

            timer.Interval = 20000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }
       void timer_Tick(object sender, EventArgs e)
       {
        this.Close();
        Environment.Exit(0);
       }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
