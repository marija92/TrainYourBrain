﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;


namespace TYB_MojZbor
{
    public partial class MojZbor : Form
    {
        SoundPlayer win = new SoundPlayer(TrainYourBrain.Properties.Resources.win);
        SoundPlayer lose = new SoundPlayer(TrainYourBrain.Properties.Resources.lose);
        SoundPlayer cl = new SoundPlayer(TrainYourBrain.Properties.Resources.click);

        Graphics g;
        Pen p;
        Brush b = new SolidBrush(Color.IndianRed);
        Stack<Button> st;
        List<string> klik;
        string s;
        string NAJdolg;
        Random r = new Random();
        public float ci = 5;
        public int rezultat =     0;
        public List<Button> Buk;
   
        
        

        
       // int vreme;
        public MojZbor()
        {
            InitializeComponent();
            s = "";
            st=new Stack<Button>();
            klik = new List<string>();
            Buk = new List<Button>();
            btnKraj.Focus();

            
             
        }

        private char[] dajMiBukvi()
        {
            char[] bukvi = new char[] { 'А', 'А', 'А', 'А', 'А', 'А', 'А', 'А', 'А', 'А', 'А', 'А', 
                'О', 'О' ,'О' ,'О' ,'О' ,'О' ,'О' ,'О' ,'О' ,'О' ,'О' ,'О' ,
            'И' ,'И' ,'И' ,'И' ,'И' ,'И' ,'И' ,'И' ,'И' ,'И' ,
            'Е' ,'Е' ,'Е' ,'Е' ,'Е' ,'Е' ,'Е' ,'Е' ,'Е' ,'Е' ,
            'Т' ,'Т' ,'Т' ,'Т' ,'Т' ,'Т' ,'Т' ,
            'Н' ,'Н' ,'Н' ,'Н' ,'Н' ,'Н' ,'Н' ,
            'Р' ,'Р' ,'Р' ,'Р' ,'Р' ,'Р' ,
            'С' ,'С' ,'С' ,'С' ,'С' ,
            'К' ,'К' ,'К' ,'К' ,
            'В' ,'В' ,'В' ,'В' ,
            'Д' ,'Д' ,'Д' ,'Д' ,
            'П' ,'П' ,'П' ,
            'М' ,'М' ,'М' ,
            'Л' ,'Л' ,'Л' ,
            'У' ,'У' ,
            'Ј' ,'Ј' ,
            'З' ,'З' ,
            'Г' ,'Г' ,
            'Б' ,'Б' ,
            'Ч' , 'Ц' , 'Ш' , 'Ж' , 'Ф' , 'Њ' , 'Ќ' , 'Х' , 'Ѓ' ,'Ѕ' ,'Љ', 'Џ' };

            Shuffle<char>(bukvi);
            return bukvi;
        }
        public static void Shuffle<T>(T[] lista)
        {
            int n = lista.Length;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                T value = lista[k];
                lista[k] = lista[n];
                lista[n] = value;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
           
            
            
            char[] bukvi = dajMiBukvi();
            
            char []desetBukvi=new char[10];
            int poz = r.Next(0, bukvi.Length);
            char c = Convert.ToChar(desetBukvi[0]=bukvi[poz]);
            btnL1.Text = c.ToString();
            poz = r.Next(0, bukvi.Length);
            c = Convert.ToChar(desetBukvi[1] = bukvi[poz]);
            btnL2.Text = c.ToString();
            poz = r.Next(0, bukvi.Length);
            c = Convert.ToChar(desetBukvi[2] = bukvi[poz]);
            btnL3.Text = c.ToString();
            poz = r.Next(0, bukvi.Length);
            c = Convert.ToChar(desetBukvi[3] = bukvi[poz]);
            btnL4.Text = c.ToString();
            poz = r.Next(0, bukvi.Length);
            c = Convert.ToChar(desetBukvi[4] = bukvi[poz]);
            btnL5.Text = c.ToString();
            poz = r.Next(0, bukvi.Length);
            c = Convert.ToChar(desetBukvi[5] = bukvi[poz]);
            btnL6.Text = c.ToString();
            poz = r.Next(0, bukvi.Length);
            c = Convert.ToChar(desetBukvi[6] = bukvi[poz]);
            btnL7.Text = c.ToString();
            poz = r.Next(0, bukvi.Length);
            c = Convert.ToChar(desetBukvi[7] = bukvi[poz]);
            btnL8.Text = c.ToString();
            poz = r.Next(0, bukvi.Length);
            c = Convert.ToChar(desetBukvi[8] = bukvi[poz]);
            btnL9.Text = c.ToString();
            poz = r.Next(0, bukvi.Length);
            c = Convert.ToChar(desetBukvi[9] = bukvi[poz]);
            btnL10.Text = c.ToString();


            NAJdolg= najdiNajdolg(TrainYourBrain.Properties.Resources.baza, desetBukvi);

            Buk.Add(btnL1);
            Buk.Add(btnL2);
            Buk.Add(btnL3);
            Buk.Add(btnL4);
            Buk.Add(btnL5);
            Buk.Add(btnL6);
            Buk.Add(btnL7);
            Buk.Add(btnL8);
            Buk.Add(btnL9);
            Buk.Add(btnL10);
           
            
        }
        static bool daliSeSodrzi(string zbor, char[] voBukvi)
        {
            
            List<char> tmp = new List<char>(voBukvi);
            for (int i = 0; i < zbor.Length; i++)
            {
                if (tmp.Contains(zbor[i]))
                {
                    tmp.Remove(zbor[i]);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        static string najdiNajdolg(string path, char[] bukvi)
        {
            string []redovi=path.Split(new char[]{'\n','\r'});
            string najgolem = "";
            try
            {

                for (int i = 0; i < redovi.Length; i++)
                {
                    string s = redovi[i];
                    s = s.ToUpper();

                    if (s.Length <= najgolem.Length || s.Length > bukvi.Length)
                    {
                        continue;
                    }
                    else
                    {
                        if (daliSeSodrzi(s, bukvi))
                        {
                            najgolem = s;
                        }
                    }
                }
                       
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            return najgolem;
        }
        private void btnL1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            cl.Play();  
            s+= b.Text;                        
            b.Enabled = false;
            lblVas.Text = s;
            st.Push(b);
            btnKraj.Focus();

        }


        public void Bukva()
        {
            
        
        }

        private void btnKraj_Click(object sender, EventArgs e)
        {
          
            if(TrainYourBrain.CstYes.Show("Дали сте сигурни?", "???")==System.Windows.Forms.DialogResult.Yes)
            {
                Disabled();
                string ime = lblVas.Text;
                string path = TrainYourBrain.Properties.Resources.baza;
                
                string[] redovi=path.Split(new char[]{'\n','\r'});
                int flag = 0;
                timer1.Stop();
                try
                {
                    
                        flag = 0;
                        for (int i = 0; i < redovi.Length; i++)
                        {
                            string s = redovi[i];
                            s = s.ToUpper();

                            if (ime.Equals(s))
                            {
                                flag = 1;
                                
                                break;
                            }
                        }
                        
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The process failed: {0}", ex.ToString());
                }
                if (flag == 1)
                {
                    win.Play();
                    TrainYourBrain.CstYes.Show("Вашиот збор е точен","Браво!"); ;
                    lblNas.Text = NAJdolg;
                    int brN = 0;
                    timer1.Stop();
                    foreach (char c in lblNas.Text)
                    {
                        brN++;
                    }
                    int brO = 0;
                    foreach (char c in lblVas.Text)
                    {
                        brO++;
                    }
                    int razlika = brN - brO;
                    rezultat = Math.Abs( 100 - razlika * 10);
                    lblRez.Text = rezultat.ToString();
                   
                    timer1.Stop();
                }
                else
                {
                    lose.Play();
                    TrainYourBrain.CstYes.Show("Вашиот збор е нточен", ":(");
                    lblRez.Text = "0";
                    timer1.Stop();
                    lblNas.Text = NAJdolg;
                    timer1.Stop();
                }
            }
        

    }
        private void Disabled()
        {
            btnL1.Enabled = false;
            btnL2.Enabled = false;
            btnL3.Enabled = false;
            btnL4.Enabled = false;
            btnL5.Enabled = false;
            btnL6.Enabled = false;
            btnL7.Enabled = false;
            btnL8.Enabled = false;
            btnL9.Enabled = false;
            btnL10.Enabled = false;
            btnKraj.Enabled = false;
            btnIzb.Enabled = false;

        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {
                                
           
            Brush b1 = new SolidBrush(Color.Wheat);
            p = new Pen(Color.White, 2);         
           
                ci = ci + 5;
                g.FillPie(b1, 190, 125, 70, 70, 0, ci);
                g.DrawEllipse(p, 190, 125, 70, 70);              
            
             
            if (ci == 360)
            {
                timer1.Stop();
                lose.Play();
                TrainYourBrain.CstYes.Show("Вашето време истече", ":(");
                lblRez.Text = "0";
               
                rezultat = 0;
                lblNas.Text = NAJdolg;
                Disabled();
            }

            btnKraj.Focus();
            
        }

        
        private void btnIzb_Click(object sender, System.EventArgs e)
        {
            if (lblVas.Text.Length > 0)
            {
                lblVas.Text = lblVas.Text.Remove(lblVas.Text.Length - 1, 1);
                s=s.Remove(s.Length - 1, 1);               
              

                Button b= st.Peek();
                b.Enabled = true;
                st.Pop();

            }
                

            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = this.CreateGraphics();            
            g.FillEllipse(b, 190, 125, 70, 70);
           
        }
        private string convertLatinskaToKiri(String bukva)
        {
            bukva = bukva.ToUpper();
            if (bukva[0] >= 'А' && bukva[0] <= 'Ш')
            {
                return bukva;
            }
            else
            {// {Ш }Ѓ [ш ]ѓ \ж |Ж ;ч :Ч 'ќ "Ќ q w
                char c = bukva[0];
                if (c == '[') c = '{';
                if (c == ']') c = '}';
                if (c == '\\') c = '|';
                if (c == ';') c = ':';
                if (c == '\'') c = '\"';
                string mak = "АБВГДЃЕЖЗЅИЈКЛЉМНЊОПРСТЌУФХЦЧЏШ";
                string lat = "ABVGD}E|ZYIJKLQMNWOPRST\"UFHC:X{";
                if (lat.IndexOf(c) >= 0)
                {
                    return mak[lat.IndexOf(c)].ToString();
                }
                return "";
            }
        }
        private void btnL1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar.Equals('\b')){
                btnIzb_Click(btnIzb,null);
                return;
            }
            string pressed = convertLatinskaToKiri(e.KeyChar.ToString());
            if (!pressed.Equals(""))
            {
                for (int i = 0; i < Buk.Count; i++)
                {
                    if (pressed.Equals(Buk[i].Text) && Buk[i].Enabled)
                    {
                        this.btnL1_Click(Buk[i], null);
                        break;
                    }
                }
            }
            
        }

        private void MojZbor_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

       
      
   
    }

        
    }
