using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;
using System.Media;


namespace TYB_Slagalica
{
    public partial class Slagalica : Form
    {
        SoundPlayer win = new SoundPlayer(TrainYourBrain.Properties.Resources.win);
        SoundPlayer lose = new SoundPlayer(TrainYourBrain.Properties.Resources.lose);
        SoundPlayer cl = new SoundPlayer(TrainYourBrain.Properties.Resources.click);
        Graphics g;
        Pen p;
        Brush b = new SolidBrush(Color.IndianRed);
        public float ci = 5;
        Brush b1;
        public int rezultat = 0;
        int flag = 1;
        List<Button> list;
        Dictionary<Button, List<Button>> sosedi;
        TrainYourBrain.CstYes y = new TrainYourBrain.CstYes();
        public Slagalica()
        {
            InitializeComponent();
           
            list = new List<Button>();
            sosedi = new Dictionary<Button, List<Button>>();
            g = this.CreateGraphics();
            g.FillEllipse(b, 230, 320, 90, 90);
        }



        private void Form1_Load(object sender, EventArgs e)
        {

                timer1.Start();
                list.Add(btn1);
                list.Add(btn2);
                list.Add(btn3);
                list.Add(btn4);
                list.Add(btn5);
                list.Add(btn6);
                list.Add(btn7);
                list.Add(btn8);
                list.Add(btn9);
                List<char> brojki = new List<char>();
                for (int i = 1; i < 10; i++)
                {
                    brojki.Add((char)('0' + i));
                }
                 Shuffle(brojki);
               
                 for(int i=0;i<list.Count;i++){
                list[i].Text = brojki[i].ToString();

                
                btn1.Visible = false;
               sosedi[btn1]=new List<Button>(new Button[]{btn2,btn4});
               sosedi[btn2] = new List<Button>(new Button[] { btn1, btn3, btn5 });
               sosedi[btn3] = new List<Button>(new Button[] { btn2,btn6 });
               sosedi[btn4] = new List<Button>(new Button[] { btn1, btn5, btn7 });
               sosedi[btn5] = new List<Button>(new Button[] { btn2, btn4, btn6, btn8 });
               sosedi[btn6] = new List<Button>(new Button[] { btn3, btn5, btn9 });
               sosedi[btn7] = new List<Button>(new Button[] { btn4, btn8 });
               sosedi[btn8] = new List<Button>(new Button[] { btn7, btn9, btn5 });
               sosedi[btn9] = new List<Button>(new Button[] { btn8, btn6 });

               g = this.CreateGraphics();
               g.FillEllipse(b, 230, 320, 90, 90);
            }

        }
        private Boolean isPobeda()
        {
            Boolean win = true;
            for (int i = 1; i <= list.Count; i++)
            {
                if (!list[i-1].Text.Equals("" + i))
                {
                    win = false;
                    break;
                }
            }
            return win;
        }
        public static class ThreadSafeRandom
        {
            [ThreadStatic]
            private static Random Local;

            public static Random ThisThreadsRandom
            {
                get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
            }
        }
        
        public static void Shuffle<T>( IList<T> list)
        {
            Random r = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            List<Button> sos = sosedi[b];
            cl.Play();
            for (int i = 0; i < sos.Count; i++)
            {
                if (sos[i].Visible ==false)
                {
                    sos[i].Visible = true;
                    string ss = sos[i].Text;
                    sos[i].Text = b.Text;
                    b.Visible = false;
                    b.Text = ss;
                    break;
                }
            }
            
        }
        private void Disabled()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            b1 = new SolidBrush(Color.Wheat);
            p = new Pen(Color.White, 2);
            ci = ci + 5;
            g = this.CreateGraphics();

            g.FillPie(b1, 230, 320, 90, 90, -90, ci);
            g.DrawEllipse(p, 230, 320, 90, 90);
           // Invalidate();


            if (ci == 360)
            {
                timer1.Stop();
                lose.Play();
                lblRez.Text = "0";
                rezultat = 0;
                lblRez.Text = rezultat.ToString();
                Disabled();
                TrainYourBrain.CstYes.Show("Вашето време истече", ":(");
                this.Close();
                
            }


                

            
        }

        


        private void Slagalica_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void btnKraj_Click_1(object sender, EventArgs e)
        {
            if (isPobeda())
            {
                timer1.Stop();
                win.Play();
                lblRez.Text = 100.ToString();
                rezultat = 100;              
                Disabled();
                TrainYourBrain.CstYes.Show("Честитки!", "Браво!");
                this.Close();

            }
            else
            {
                timer1.Stop();
                lose.Play();
                lblRez.Text = 0.ToString();
                rezultat = 0;
                Disabled();
                TrainYourBrain.CstYes.Show("Повеќе срееќа следниот пат", ":(");
                this.Close();

            }

        }

        private void Slagalica_Paint(object sender, PaintEventArgs e)
        {
            //g = this.CreateGraphics();
            //g.FillEllipse(b, 230, 320, 90, 90);
           
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (flag == 1)
            {
                g = this.CreateGraphics();
                g.FillEllipse(b, 230, 320, 90, 90);
                flag = 0;
            }
           
        }

       




        }

    }

