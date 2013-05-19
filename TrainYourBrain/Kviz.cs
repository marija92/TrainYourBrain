using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Quiz
{
    public partial class Kviz : Form
    {

        SoundPlayer win = new SoundPlayer(TrainYourBrain.Properties.Resources.win);
        SoundPlayer lose = new SoundPlayer(TrainYourBrain.Properties.Resources.lose);
        SoundPlayer cl = new SoundPlayer(TrainYourBrain.Properties.Resources.click);
        SoundPlayer tocno = new SoundPlayer(TrainYourBrain.Properties.Resources.tocno);
        SoundPlayer greska = new SoundPlayer(TrainYourBrain.Properties.Resources.greska);

        Graphics g;
        Pen p = new Pen(Color.White,2);
        Brush b = new SolidBrush(Color.IndianRed);
        Brush b1 = new SolidBrush(Color.Wheat);
        public float ci = 5;
        
        LinkedList<Prasanje> kviz = new LinkedList<Prasanje>();
        bool odg;
        int br = 0;
        int brT = 0;
        public int rezultat = 0;

        
        public Kviz()
        {
            InitializeComponent();
            
            Prasanje p = new Prasanje("Скопје е главен град на Македонија", true); 
            kviz.AddLast(p);
            p = new Prasanje("ФИНКИ е факултет за туризам", false);
            kviz.AddLast(p);
            p = new Prasanje("'Трето Полувреме' е македонски филм номиниран за оскар", true);
            kviz.AddLast(p); 
            p = new Prasanje("'Дигитална тврдина' е дело на Пауло Коелјо", false);
            kviz.AddLast(p);
            p = new Prasanje("Македонски претставници на Евросонг 2012 беа Влатко и Есма", false);
            kviz.AddLast(p);
            p = new Prasanje("Иван Исцелител е од Куманово", true);
            kviz.AddLast(p);
            p = new Prasanje("Дали Данче Марија и Даринка се царици и зашо да?", true);
            kviz.AddLast(p);
        }

        public void Novo()
        {
            Random r = new Random(); 
            int pr=r.Next(0,kviz.Count);
            textBox1.Text = kviz.ElementAt(pr).prasanje;
            odg = kviz.ElementAt(pr).odgovor;
            kviz.Remove(kviz.ElementAt(pr));
        }
        public bool isEnd()
        {
            if (br == 5) 
            {
                
                if (brT == 5)
                {
                    MessageBox.Show("Браво! Точно одговоривте на сите прашања");
                    win.Play();
                    timer1.Stop();
                    rezultat = 100;
                    disabled();
                    return true;
                }
                else
                {
                    rezultat=20*brT;
                    win.Play();
                    MessageBox.Show("Честитки!");
                    timer1.Stop();
                    disabled();
                    return (true);
                }
                
            }
            return false;
           
        }

        
        public void isTrue(bool b)
        {
            if (odg == b)
            { 
                br++; 
                brT++;
                tocno.Play();
            }
            else 
            { 
                br++;
                greska.Play();
            }
        }


        private void btnNo_Click(object sender, EventArgs e)
        {
            cl.Play();
            isTrue(false);
            if (!isEnd())
            {
                Novo();
            }
                
            
        }

        public void disabled()
        {
            btnNo.Enabled=false;
            btnYes.Enabled = false;
            textBox1.Text = "";

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            cl.Play();
            isTrue(true);
            if (!isEnd())
            {
                Novo();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Novo();
            
           // updateTime();
           ;
            timer1.Start(); 
           
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            p = new Pen(Color.White, 2);

            ci = ci + 5;
            g.FillPie(b1, 290, 210, 95, 95, 0, ci);
            g.DrawEllipse(p, 290, 210, 95, 95);
            if (ci == 360)
            {
                lose.Play();
                MessageBox.Show("Вашето време истече!");
                rezultat = 0;
                disabled();
                timer1.Stop();
            }

       
        }

        private void Kviz_Paint(object sender, PaintEventArgs e)
        {
            g = this.CreateGraphics();
            g.FillEllipse(b, 290, 210, 95, 95);
            g.FillPie(b1, 290, 210, 95, 95, 0, ci);
            g.DrawEllipse(p, 290, 210, 95, 95);
        }

        private void Kviz_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
    }
}
