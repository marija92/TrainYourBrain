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
using System.IO;
using TrainYourBrain;

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
        Pen p;
        Brush b = new SolidBrush(Color.IndianRed);
        public float ci = 5;
        int flag = 1;
        
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
          //  p = new Prasanje("Игричката ни е супер.Чиста 10ка ;)", true);
           // kviz.AddLast(p);
            p = new Prasanje("Грипот уште се нарекува инфлуенца", true);
            kviz.AddLast(p);
            p = new Prasanje("Бројот PI уште се нарекува Лудолфов број", true);
            kviz.AddLast(p);
            p = new Prasanje("Филателист е колекционер на стари монети", false);
            kviz.AddLast(p);
            p = new Prasanje("Логото на 'Apple' е гризнато јаболко", true);
            kviz.AddLast(p);
            p = new Prasanje("Октоподот има три срца.", true);
            kviz.AddLast(p);
            p = new Prasanje("Лејкерси од НБА лигата доаѓаат од Вашингтон", false);
            kviz.AddLast(p);
            p = new Prasanje("Пат околу светот за 80 дена е дело на Виктор Иго", false);
            kviz.AddLast(p);
            p = new Prasanje("Грофот Дракула е од Трансилванија", true);
            kviz.AddLast(p);
            p = new Prasanje("Текила е Мексикански пијалок", true);
            kviz.AddLast(p);
            p = new Prasanje("Губитокот на памтењето уште се нарекува анестезија", false);
            kviz.AddLast(p);
            p = new Prasanje("Хемискиот симбол за сребро е Ag", true);
            kviz.AddLast(p);
            p = new Prasanje("Еден километар има 100 метри", false);
            kviz.AddLast(p);
            p = new Prasanje("Првата светска војна траела 5 години", false);
            kviz.AddLast(p);

        }

        public void Novo() //generiranje na novo prasanje
        {
            Random r = new Random(); 
            int pr=r.Next(0,kviz.Count);
            textBox1.Text = kviz.ElementAt(pr).prasanje;
            odg = kviz.ElementAt(pr).odgovor;
            kviz.Remove(kviz.ElementAt(pr));
        }
        public bool isEnd() //proveruva dali e kraj na igrata
        {
            if (br == 10) 
            {
                if (brT == 10)
                {
                    timer1.Stop();
                    win.Play();
                    rezultat = 100;
                    //  lblRez.Text = 100.ToString();
                    disabled();
                    TrainYourBrain.CstYes.Show("Точно одговоривте на сите прашања", "Браво!");
                    this.Close();
                    return true;
                   
                }
                else
                {
                     timer1.Stop();
                    win.Play();
                   // lblRez.Text = rezultat.ToString();
                    disabled();
                    rezultat=10*brT;
                    TrainYourBrain.CstYes.Show("Ги одговоривте прашањата во предвиденото време", "Браво!");
                    this.Close();
                    return true;
                }
            }
            return false;
           
        }

        
        public void isTrue(bool b) //dali prasanjeto e tocno
        {
            if (odg == b)
            {
                rezultat += 10;
                br++;
                brT++;
                tocno.Play();
                tocni.Text = brT.ToString();
                poeni.Text = rezultat.ToString();
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
                        }
                        else if (c is Label)
                        {
                            c.BackColor = System.Drawing.ColorTranslator.FromHtml(momentalnaTema.back);
                            c.ForeColor = System.Drawing.ColorTranslator.FromHtml(momentalnaTema.btn);
                        }
                    }
                    BackColor = System.Drawing.ColorTranslator.FromHtml(momentalnaTema.back);
                }
                sr.Close();
            }
            catch (FileNotFoundException excep)
            {
            }
            
            Novo();
            textBox1.Select(0, 0);
            timeElapsed = 0;
           // updateTime();
           
            timer1.Start(); 
           
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
           Brush b1 = new SolidBrush(Color.Wheat);
           p = new Pen(Color.White, 2);

           ci = ci + 5;
           g = this.CreateGraphics();
           g.FillPie(b1, 150, 250, 95, 95, -90, ci);
           g.DrawEllipse(p, 150, 250, 95, 95);
           if (ci == 360)
           {
               timer1.Stop();
               lose.Play();
               rezultat = 0;
               disabled();
               
               TrainYourBrain.CstYes.Show("Вашeто време истече", ":(");
               this.Close();
           }

           
       
        }

        private void Kviz_Paint(object sender, PaintEventArgs e)
        {
            if (flag==1)
            {
                g = this.CreateGraphics();
                g.FillEllipse(b, 150, 250, 95, 95);
                flag = 0;
            }
           
        }

        private void Kviz_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
