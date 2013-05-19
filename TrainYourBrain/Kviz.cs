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
        
        
        LinkedList<Prasanje> kviz = new LinkedList<Prasanje>();
        bool odg;
        int br = 0;
        int brT = 0;
        public int rezultat = 0;

        private static readonly int TIME = 30;
        private int timeElapsed;

        
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
                    rezultat = 100;
                    disabled();
                    return true;
                }
                else
                {
                    rezultat=20*brT;
                    MessageBox.Show("Честитки!");
                    win.Play();
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
            
            timeElapsed = 0;
           // updateTime();
           ;
            timer1.Start(); 
           
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
           timeElapsed++;
           if (timeElapsed == TIME)
           {
               MessageBox.Show("Вашето време истече!!!");
               lose.Play();
               rezultat = 0;
               timer1.Stop();
               disabled();
            
           }
           
       
        }
    }
}
