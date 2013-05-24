using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainYourBrain
{
    public partial class SplashScreen : Form
    {
        int step = 100;
        int stoj = 3;
        int prozirnost = 255;
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            timer1.Interval = 200;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stoj > 0)
            {
                stoj--;
            }
            else
            {
                if (prozirnost >0)
                {
                    prozirnost = prozirnost - 25;
                    string proz = prozirnost.ToString("X");
                    label1.BackColor = System.Drawing.ColorTranslator.FromHtml("#" + proz + "FFFFFF");
                    
                }
                else
                {
                    
                   
                    timer1.Stop();
                    this.Dispose();
                }
            }
        }
    }
}
