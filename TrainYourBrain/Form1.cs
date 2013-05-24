using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TYB_Slagalica;
using Calculate;
using Mastermind;
using TYB_MojZbor;
using Quiz;
using System.IO;

namespace TrainYourBrain
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MojZbor mz = new MojZbor();
            mz.ShowDialog();
            btnMojZbor.Enabled = false;
            lblMojZbor.Text=mz.rezultat.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MojBroj1 mb = new MojBroj1();
            mb.ShowDialog();
            btnMojBroj.Enabled = false;
            lblMojBroj.Text = mb.rezultat.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PogodiMe m = new PogodiMe();
            m.ShowDialog();
            btnX.Enabled = false;
            lblX.Text = m.rezultat.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Slagalica slaga = new Slagalica();
            slaga.ShowDialog();
            btnSlagalica.Enabled = false;
            lblSlagalica.Text = slaga.rezultat.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Kviz q = new Kviz();
            q.ShowDialog();
            btnKviz.Enabled = false;
            lblKviz.Text = q.rezultat.ToString();
        }

        private void lblVkupno_Click(object sender, EventArgs e)
        {
            
        }

        
        public void proveri()
        {
            if (btnMojBroj.Enabled == false && btnMojZbor.Enabled == false &&
                btnSlagalica.Enabled == false && btnX.Enabled == false &&
                btnKviz.Enabled==false)
            {
               HighScore hs = new HighScore();
               hs.vkupno = int.Parse(lblVkupno.Text);
               hs.ShowDialog();
               
            }
        }

        

         public void Calculate()
        {
            int r1;
            int.TryParse(lblMojZbor.Text, out r1);
            int r2;
            int.TryParse(lblMojBroj.Text, out r2);
            int r3;
            int.TryParse(lblX.Text, out r3);
            int r4;
            int.TryParse(lblSlagalica.Text, out r4);
            int r5;
            int.TryParse(lblKviz.Text, out r5);
            int vk=r1+r2+r3+r4+r5;
            lblVkupno.Text = vk.ToString();
            
        }

        private void lblMojZbor_TextChanged(object sender, EventArgs e)
        {
            Calculate();
            proveri();
   
        }

        private void lblMojBroj_TextChanged(object sender, EventArgs e)
        {
            Calculate();
            proveri();
        }

        private void lblX_TextChanged(object sender, EventArgs e)
        {
            Calculate();
            proveri();
        }

        private void lblSlagalica_TextChanged(object sender, EventArgs e)
        {
            Calculate();
            proveri();
        }

        private void lblKviz_TextChanged(object sender, EventArgs e)
        {
            Calculate();
            proveri();
        }

        private void lblMojBroj_Click(object sender, EventArgs e)
        {
            //lblMojBroj.Text()
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showSplash();
            changeTheme();   
        }
        private void showSplash()
        {
            this.Visible = false;
            SplashScreen ss = new SplashScreen();
            ss.ShowDialog();
            this.Visible = true;
        }
        private void новаИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnMojBroj.Enabled = true;
            btnMojZbor.Enabled = true;
            btnX.Enabled = true;
            btnSlagalica.Enabled = true;
            btnKviz.Enabled = true;
            lblSlagalica.Text = 0.ToString();
            lblMojZbor.Text = 0.ToString();
            lblMojBroj.Text = 0.ToString();
            lblKviz.Text = 0.ToString();
            lblX.Text = 0.ToString();
            lblVkupno.Text = 0.ToString();

        }

        private void lblVkupno_TextChanged(object sender, EventArgs e)
        {
          //  proveri();
        }

        private void резултатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighScore hs = new HighScore();
            hs.vkupno = int.Parse(lblVkupno.Text);
            hs.disabled();
            hs.ShowDialog();
            
        }

        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pravila pr = new Pravila();
            pr.ShowDialog();
        }

        private void подесувањаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.ShowDialog();
            changeTheme();
        }
        private void changeTheme()
        {
            try
            {
                StreamReader sr = new StreamReader("../../theme.txt");
                LoadedTheme.odbranaTema = new CustomTheme(sr.ReadLine());
                CustomTheme momentalnaTema = LoadedTheme.odbranaTema;
                if (momentalnaTema != null)
                {
                    foreach (Control c in this.Controls)
                    {
                        if (c is Button || c is TextBox)
                        {
                            c.BackColor = System.Drawing.ColorTranslator.FromHtml(momentalnaTema.btn);
                            c.ForeColor = System.Drawing.ColorTranslator.FromHtml(momentalnaTema.btnText);
                            if (c is Button)
                            {
                                Button cb = (Button)c;
                                cb.FlatAppearance.MouseOverBackColor = System.Drawing.ColorTranslator.FromHtml(momentalnaTema.back);
                                cb.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml(momentalnaTema.btnText);
                                cb.FlatAppearance.MouseDownBackColor = System.Drawing.ColorTranslator.FromHtml(momentalnaTema.btnText);
                            }
                        }
                        else if (c is Label)
                        {
                            c.BackColor = System.Drawing.ColorTranslator.FromHtml(momentalnaTema.back);
                            c.ForeColor = System.Drawing.ColorTranslator.FromHtml(momentalnaTema.btn);
                            Label l = (Label)c;
                        }
                    }
                    BackColor = System.Drawing.ColorTranslator.FromHtml(momentalnaTema.back);
                }
                sr.Close();
            }
            catch (FileNotFoundException excep)
            {
                Console.WriteLine(excep.Data);
            }
        }
        

        
    }
}
