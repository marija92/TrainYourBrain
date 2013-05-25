using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TrainYourBrain;

namespace Mastermind
{
    public partial class PogodiMe : Form
    {
        SoundPlayer win = new SoundPlayer(TrainYourBrain.Properties.Resources.win);
        SoundPlayer lose = new SoundPlayer(TrainYourBrain.Properties.Resources.lose);
        SoundPlayer cl = new SoundPlayer(TrainYourBrain.Properties.Resources.click);
        Graphics g;
        Pen p;
        Brush b = new SolidBrush(Color.IndianRed);
        Brush b1 = new SolidBrush(Color.Wheat);
        public float ci = 5;

        LinkedList<LinkedList<Button>> btns;
        int[][] pomosna = new int[6][];

        public int rezultat = 0;
   
        int rows = 0;
        Button nextEmpty = new Button();
                

        public PogodiMe()
        {
            InitializeComponent();
            
            nextEmpty = btn11;
            btns = new LinkedList<LinkedList<Button>>();
            LinkedList<Button>  btns1 = new LinkedList<Button>();
            btns1.AddLast(btn11);
            btns1.AddLast(btn12);
            btns1.AddLast(btn13);
            btns1.AddLast(btn14);
            LinkedList<Button> btns2 = new LinkedList<Button>();
            btns2.AddLast(btn21);
            btns2.AddLast(btn22);
            btns2.AddLast(btn23);
            btns2.AddLast(btn24);
            LinkedList<Button> btns3 = new LinkedList<Button>();
            btns3.AddLast(btn31);
            btns3.AddLast(btn32);
            btns3.AddLast(btn33);
            btns3.AddLast(btn34);
            LinkedList<Button> btns4 = new LinkedList<Button>();
            btns4.AddLast(btn41);
            btns4.AddLast(btn42); 
            btns4.AddLast(btn43);
            btns4.AddLast(btn44);
            LinkedList<Button> btns5 = new LinkedList<Button>();
            btns5.AddLast(btn51);
            btns5.AddLast(btn52);
            btns5.AddLast(btn53);
            btns5.AddLast(btn54);
            LinkedList<Button> btns6 = new LinkedList<Button>();
            btns6.AddLast(btn61);
            btns6.AddLast(btn62);
            btns6.AddLast(btn63);
            btns6.AddLast(btn64);
            btns.AddLast(btns1);
            btns.AddLast(btns2);
            btns.AddLast(btns3);
            btns.AddLast(btns4);
            btns.AddLast(btns5);
            btns.AddLast(btns6);

            
            for (int i = 0; i < pomosna.Length; i++)
            {
                pomosna[i]= new int[4];
            }

            newGame();
                       
        }

        int[] komb = new int[4];

        private void newGame()
        {
            Random r = new Random();
                       
            komb[0] = r.Next(1, 7);
            komb[1] = r.Next(1, 7);
            komb[2] = r.Next(1, 7);
            komb[3] = r.Next(1, 7);

            enabled();           
            timer1.Start();            
        }

        private void endGame(int i)
        {
            timer1.Stop();
            if (i == 1)
            {
                lose.Play();
                string pom="Вашето време истече.Точната комбинација е " +TocnaKombinacija();
                TrainYourBrain.CstYes.Show( pom, ":(");
               // MessageBox.Show("Вашето време истече. Точната комбинација е: " + TocnaKombinacija());
                this.Close();
            
            }


            if (i == 2)
            {
                lose.Play();
                string pom = "Не погодивте.Точната комбинација е " + TocnaKombinacija();
                TrainYourBrain.CstYes.Show(pom, ":(");
                this.Close();
               // timer1.Stop();
            } 
            if (i == 3)
            {
                win.Play();
                string pom = "Ја погодивте комбинациајта."+ TocnaKombinacija();
                TrainYourBrain.CstYes.Show(pom, "Браво!"); ;
                rezultat = 100;
                this.Close();
               // timer1.Stop();
               
            }

            
            btnSubmit.Enabled = false;
            pb1.Enabled = false;
            pb2.Enabled = false;
            pb3.Enabled = false;
            pb4.Enabled = false;
            pb5.Enabled = false;
            pb6.Enabled = false;
        }

        int kolona = 0;
        public void Niza(int broj)  //f-ja koja sto vo pomosna niza go smestuva dadeniot simbol(broj) za proverka
        {
           //kolona %= 4;
           pomosna[rows][kolona] = broj;
        }

        int tocni = 0;
        int ima = 0;

        public void Check(LinkedList<Button> b) //fja za proverka na kombinacijata
        {
            int[] proveri = new int[4];
            for (int i = 0; i < 4; i++)
            {
                proveri[i]=komb[i];
            }
            tocni = 0;
            ima = 0;
            for (int i = 0; i < 4; i++)
            {
                if (komb[i] == pomosna[rows][i])
                {
                    tocni++;
                    proveri[i] = 0;
                    pomosna[rows][i] = 10;
                }
            }
            for (int k = 0; k < 4; k++)
                {
                    for(int j=0;j<proveri.Length;j++)
                    {
                        
                        if (proveri[j] == pomosna[rows][k])
                        {
                            ima++;
                            proveri[j] = 0;
                            break;
                        }
                    }
                }
            
        }
        

           
       private void pb1_Click(object sender, EventArgs e)
       {
           Button tmp = popolni();
           tmp.BackgroundImage = global::TrainYourBrain.Properties.Resources.slika1;
           Niza(1);
          // kolona++;
           CanSubmit();
           cl.Play();
       }

       private void pb2_Click(object sender, EventArgs e)
       {
          Button tmp = popolni();
          tmp.BackgroundImage = global::TrainYourBrain.Properties.Resources.slika2;
          Niza(2);
         // kolona++;
          CanSubmit();
          cl.Play();
       }

       private void pb3_Click(object sender, EventArgs e)
       {
           Button tmp = popolni();
           tmp.BackgroundImage = global::TrainYourBrain.Properties.Resources.slika3;
           Niza(3);
          // kolona++;
           CanSubmit();
           cl.Play();
       }

       private void pb4_Click(object sender, EventArgs e)
       {
           Button tmp = popolni();
           tmp.BackgroundImage = global::TrainYourBrain.Properties.Resources.slika4;
           Niza(4);
          // kolona++;
           CanSubmit();
           cl.Play();
       }

       private void pb5_Click(object sender, EventArgs e)
       {
           Button tmp = popolni();
           tmp.BackgroundImage = global::TrainYourBrain.Properties.Resources.slika5;
           Niza(5);
           //kolona++;
           CanSubmit();
           cl.Play();
       }

       private void pb6_Click(object sender, EventArgs e)
       {
           Button tmp = popolni();
           tmp.BackgroundImage = global::TrainYourBrain.Properties.Resources.slika6;
           Niza(6);
          // kolona++;
           CanSubmit();
           cl.Play();
       }

    

       private void timer1_Tick(object sender, EventArgs e)
       {
          
           
           Brush b1;
           if (LoadedTheme.odbranaTema != null)
           {
               b1 = new SolidBrush(System.Drawing.ColorTranslator.FromHtml(LoadedTheme.odbranaTema.back));
               p = new Pen(System.Drawing.ColorTranslator.FromHtml(LoadedTheme.odbranaTema.btnText));
           }
           else
           {
               b1 = new SolidBrush(Color.Wheat);
               p = new Pen(Color.White, 2);
           }
           ci = ci + 5;
           g.FillPie(b1, 187, 387, 70, 70, -90, ci);
           g.DrawEllipse(p, 187, 387, 70, 70);


           if (ci == 360)
           {
               timer1.Stop();
               lose.Play();
               endGame(1);
               rezultat = 0;
              
           }
       }

      

       public Button popolni() //f-ja za naogjanje na sledno slobdno pole pri popolnuvanjeto
       {
           for (int i = 0; i<4; i++)
           {
               if (btns.ElementAt(rows).ElementAt(i).BackgroundImage == null)
               {
                   nextEmpty = btns.ElementAt(rows).ElementAt(i);
                   kolona = i;
                   break;
               }
           }           
            return nextEmpty;   
       }

       
       private void btn11_Click(object sender, EventArgs e)
       {
           btn11.BackgroundImage = null;
          // kolona=0;
           CanSubmit();
           cl.Play();
       }

       private void btn12_Click(object sender, EventArgs e)
       {
           btn12.BackgroundImage = null;
          // kolona=1;
           CanSubmit();
           cl.Play();
       }

       private void btn13_Click(object sender, EventArgs e)
       {
           btn13.BackgroundImage = null;
          // kolona=2;
           CanSubmit();
           cl.Play();
       }

       private void btn14_Click(object sender, EventArgs e)
       {
           btn14.BackgroundImage = null;
          // kolona=3;
           CanSubmit();
           cl.Play();
       }

       private void btn21_Click(object sender, EventArgs e)
       {
           btn21.BackgroundImage = null;
          // kolona=0;
           CanSubmit();
           cl.Play();
       }

       private void btn22_Click(object sender, EventArgs e)
       {
           btn22.BackgroundImage = null;
           //kolona=1;
           CanSubmit();
           cl.Play();
       }

       private void btn23_Click(object sender, EventArgs e)
       {
           btn23.BackgroundImage = null;
           //kolona=2;
           CanSubmit();
           cl.Play();
       }

       private void btn24_Click(object sender, EventArgs e)
       {
           btn24.BackgroundImage = null;
          // kolona=3;
           cl.Play();
           CanSubmit();
       }

       private void btn31_Click(object sender, EventArgs e)
       {
           btn31.BackgroundImage = null;
          // kolona=0;
           CanSubmit();
           cl.Play();
       }

       private void btn32_Click(object sender, EventArgs e)
       {
           btn32.BackgroundImage = null;
         //  kolona=1;
           CanSubmit();
           cl.Play();
       }

       private void btn33_Click(object sender, EventArgs e)
       {
           btn33.BackgroundImage = null;
         //  kolona=2;
           cl.Play();
           CanSubmit();

       }

       private void btn34_Click(object sender, EventArgs e)
       {
           cl.Play();
           btn34.BackgroundImage = null;
          // kolona=3;
           CanSubmit();
       }

       private void btn41_Click(object sender, EventArgs e)
       {
           cl.Play();
           btn41.BackgroundImage = null;
          // kolona=0;
           CanSubmit();
       }

       private void btn42_Click(object sender, EventArgs e)
       {
           cl.Play();
           btn42.BackgroundImage = null;
         //  kolona=1;
           CanSubmit();
       }

       private void btn43_Click(object sender, EventArgs e)
       {
           cl.Play();
           btn43.BackgroundImage = null;
         //  kolona=2;
           CanSubmit();
       }

       private void btn44_Click(object sender, EventArgs e)
       {
           cl.Play();
           btn44.BackgroundImage = null;
         //  kolona=3;
           CanSubmit();
       }

       private void btn51_Click(object sender, EventArgs e)
       {
           cl.Play();
           btn51.BackgroundImage = null;
         //  kolona=0;
           CanSubmit();
       }

       private void btn52_Click(object sender, EventArgs e)
       {
           cl.Play();
           btn52.BackgroundImage = null;
          // kolona=1;
           CanSubmit();
       }

       private void btn53_Click(object sender, EventArgs e)
       {
           cl.Play();
           btn53.BackgroundImage = null;
          // kolona=2;
           CanSubmit();
       }

       private void btn54_Click(object sender, EventArgs e)
       {
           cl.Play();
           btn54.BackgroundImage = null;
          // kolona=3;
           CanSubmit();
       }

       private void btn61_Click(object sender, EventArgs e)
       {
           cl.Play();
           btn61.BackgroundImage = null;
         //  kolona=0;
           CanSubmit();
       }

       private void btn62_Click(object sender, EventArgs e)
       {
           cl.Play();
           btn62.BackgroundImage = null;
          // kolona=1;
           CanSubmit();
       }

       private void btn63_Click(object sender, EventArgs e)
       {
           cl.Play();
           btn63.BackgroundImage = null;
          // kolona=2;
           CanSubmit();
       }

       private void btn64_Click(object sender, EventArgs e)
       {
           cl.Play();
           btn64.BackgroundImage = null;
          // kolona=3;
           CanSubmit();
       }

       public void enabled() //gi pravi aktivni kopcinjata od tekovnata redica
       {
           for (int i = 0; i < 4; i++)
           {
               Button b =btns.ElementAt(rows).ElementAt(i);
               b.Enabled = true;
           }
       }

       public void disabled() //gi pravi neaktivni kopcinjata od veke proverenata redica
       {
           for (int i = 0; i < 4; i++)
           {
               Button b = btns.ElementAt(rows).ElementAt(i);
               b.Enabled = false;
           }
       }

       public void CanSubmit() //dali kopceto prati da bide aktivno ili ne
       {
           int count = 0;
           for (int i = 0; i<4; i++)
           {
               if (btns.ElementAt(rows).ElementAt(i).BackgroundImage == null)
               {
                   break;
               }
               else count++;
           }
           if (count == 4) btnSubmit.Enabled = true;
           else btnSubmit.Enabled=false;
       }

      

       public void PaintBall(bool t, bool n,int brT, int brN) // iscrtuvanje na krugcinja za rezultatot
       {
           Graphics g; 
           if (rows == 0)
           {
                g = label2.CreateGraphics();
           }
           else if (rows == 1)
           {
                g = label3.CreateGraphics();
           }
           else if (rows == 2)
           {
                g = label4.CreateGraphics();
           }
           else if (rows == 3)
           {
                g = label5.CreateGraphics();
           }
           else if (rows == 4)
           {
                g = label6.CreateGraphics();
           }
           else
           {
                g = label7.CreateGraphics();
           }
           
           SolidBrush brBlack = new SolidBrush(Color.Black);
           SolidBrush brWhite = new SolidBrush(Color.White);

           int startX = 10;
           if (t)
           {
               for (int i = 0; i < brT; i++)
               {
                   g.FillEllipse(brBlack, startX, 10, 10, 10);
                   startX += 15;
               }
               
           }
           if (n)
           {
               for (int i = 0; i < brN; i++)
               {
                   g.FillEllipse(brWhite, startX, 10, 10, 10);
                   startX += 15;
               }
               
           }

          


       }

       public string TocnaKombinacija() //pomosen string za pecatenje na tocnata kombinacija
       {
           string a="\n";
           for (int i = 0; i < komb.Length; i++)
           {
               if (komb[i] == 1) a += "ЛИСТ ";
               else if (komb[i] == 2) a += "ДЕТЕЛИНА ";
               else if (komb[i] == 3) a += "СРЦЕ ";
               else if (komb[i] == 4) a += "БАКЛАВА ";
               else if (komb[i] == 5) a += "ЅВЕЗДА ";
               else a += "СМАЈЛИ ";               
           }
           return a;
       }

       

       

      
       private void PogodiMe_Paint_1(object sender, PaintEventArgs e)
       {
           g = this.CreateGraphics();
           g.FillEllipse(b, 187, 387, 70, 70);
          //  g.FillPie(b1, 187, 387, 70, 70, 0, ci);
          // g.DrawEllipse(p, 187, 387, 70, 70);
       }

       private void btnSubmit_Click(object sender, EventArgs e)
       {
           Check(btns.ElementAt(rows));
           PaintBall((tocni > 0), (ima > 0), tocni, ima);
           disabled();
           rows++;
           btnSubmit.Enabled = false;
           if (tocni == 4) endGame(3);
           else if (rows == 6) endGame(2);
           else enabled();
           cl.Play();
       }

       private void PogodiMe_FormClosed(object sender, FormClosedEventArgs e)
       {
           timer1.Stop();
       }

       private void PogodiMe_Load(object sender, EventArgs e)
       {
           try
           {
               StreamReader sr = new StreamReader("../../theme.txt");
               LoadedTheme.odbranaTema = new CustomTheme(sr.ReadLine());
               CustomTheme momentalnaTema = LoadedTheme.odbranaTema;
               Color backC = System.Drawing.ColorTranslator.FromHtml(momentalnaTema.back);
               Color btnTextC = System.Drawing.ColorTranslator.FromHtml(momentalnaTema.btnText);
               Color btnC = System.Drawing.ColorTranslator.FromHtml(momentalnaTema.btn);
               if (momentalnaTema != null)
               {
                   foreach (Control c in this.Controls)
                   {
                       if (c is Button || c is TextBox || c is PictureBox)
                       {
                           c.BackColor = btnC;
                           c.ForeColor = btnTextC;
                           if (c is Button)
                           {
                               Button cb = (Button)c;
                               cb.FlatAppearance.MouseOverBackColor = backC;
                               cb.FlatAppearance.BorderColor = btnTextC;
                               cb.FlatAppearance.MouseDownBackColor = btnTextC;
                           }
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
           if (LoadedTheme.odbranaTema == null)
           {
               b = new SolidBrush(Color.IndianRed);
           }
           else
           {
               b = new SolidBrush(System.Drawing.ColorTranslator.FromHtml(LoadedTheme.odbranaTema.btn));
           }
       }

       private void label3_Click(object sender, EventArgs e)
       {

       }

      
      

      
      

     

  
       

             

      
    }
}
