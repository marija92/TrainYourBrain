using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;


namespace Calculate
{
    public partial class MojBroj1 : Form
    {
        SoundPlayer win = new SoundPlayer(TrainYourBrain.Properties.Resources.win);
        SoundPlayer lose = new SoundPlayer(TrainYourBrain.Properties.Resources.lose);
        SoundPlayer cl = new SoundPlayer(TrainYourBrain.Properties.Resources.click);
        Graphics g;
        Pen p;
        Brush b = new SolidBrush(Color.IndianRed);
        public int rezultat = 0;
        public float ci = 5;
        public MojBroj1()
        {
            InitializeComponent();
        }

        
            Stack<Button> stack = new Stack<Button>();



            TrainYourBrain.CstYes y = new TrainYourBrain.CstYes();
        Random rnd = new Random();
        private void button1_Click_1(object sender, EventArgs e)
        {
            cl.Play();
            decimal d;
            timer1.Stop();
            if (Evaluator.TryParse(textBox1.Text, out d))
            {
                label1.Text = d.ToString();
            }
            else
            {
                label1.Text = "";
            }

            if (label1.Text.Equals(textBox2.Text))
            {
                win.Play();
                y.Show();
                //MessageBox.Show("Честитки! Вашиот резултат е точен!");
                timer1.Stop();
                label9.Text = "100";
                rezultat = 100;
                
            }
            else 
            {

                lose.Play();
                y.Show();
               // MessageBox.Show(" Вашиот резултат е неточен!");
                label9.Text = "0";
                timer1.Stop();
                rezultat = 0;

            }
            
        

        
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            textBox1.Text = "";
            
           
        }
        Button c;
        Button d;
        private void button2_Click_1(object sender, EventArgs e)
        {

            checkIf(button2);
            cl.Play();
                        
        }

        private void button3_Click(object sender, EventArgs e)
        {

            checkIf(button3);
            cl.Play();
            
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkIf(button4);
             cl.Play();
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkIf(button5);
            cl.Play();
            
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            checkIf(button6);
            cl.Play();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            checkIf(button7);
            cl.Play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button6.Text = rnd.Next(1, 99).ToString();
            button5.Text = rnd.Next(1, 9).ToString();
            button4.Text = rnd.Next(1, 9).ToString();
            button3.Text = rnd.Next(1, 9).ToString();
            button2.Text = rnd.Next(1, 9).ToString();
            button7.Text = rnd.Next(1, 999).ToString();
            textBox2.Text = rnd.Next(100, 999).ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            checkIf2(button8);
            cl.Play();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            checkIf2(button9);
            cl.Play();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            checkIf2(button10);
            cl.Play();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            checkIf2(button11);
            cl.Play();
        }

        private void button12_Click(object sender, EventArgs e)
        {
          
            cl.Play();
            if (stack.Count > 0)
            {
                c = stack.Peek();

                if (Convert.ToChar(c.Text) == '+' || Convert.ToChar(c.Text) == '-' || Convert.ToChar(c.Text) == '*' || Convert.ToChar(c.Text) == '/' || Convert.ToChar(c.Text) == '(')
                {
                    textBox1.Text = textBox1.Text + button12.Text.ToString();

                    d = button12;
                    stack.Push(d);

                }
                
             
            }
            else
            {
                d = button12;
                stack.Push(d);
                textBox1.Text = textBox1.Text + button12.Text;

            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            checkIf2(button13);
            cl.Play();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            cl.Play();
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            textBox1.Text = "";
            
            
            label9.Text = "";
            label1.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, System.EventArgs e)
        {
            button6.Text = rnd.Next(1, 99).ToString();
            button5.Text = rnd.Next(1, 9).ToString();
            button4.Text = rnd.Next(1, 9).ToString();
            button3.Text = rnd.Next(1, 9).ToString();
            button2.Text = rnd.Next(1, 9).ToString();
            button7.Text = rnd.Next(1, 999).ToString();
            textBox2.Text = rnd.Next(100, 999).ToString();
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            textBox1.Text = "";
            
            
            label9.Text = "";
            label1.Text = "";
        }

        private void back_Click(object sender, EventArgs e)
        {
            cl.Play();

            if (textBox1.Text.Length > 0)
            {
                c = stack.Peek();
                if (c.Text.Length == 1)
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                }
                else if (c.Text.Length == 2)
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 2, 2);
                }
                else if (c.Text.Length == 3)
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 3, 3);
                }





                if (c == button2)
                {
                   
                        button2.Enabled = true;
                    
                }
                else  if (c == button3)
                {
                   
                            button3.Enabled = true;
                    
                }
                else if (c == button4)
                {
                   
                        button4.Enabled = true;
                    
                }
                else if (c == button5)
                 {
                   
                         button5.Enabled = true;
                     
                 }
                 else if (c == button6)
                {
                   
                        button6.Enabled = true;
                    
                }
                else  if (c == button7)
                 {
                    
                         button7.Enabled = true;
                     
                 }

                 stack.Pop();

                 
            }
            
        }


        public void checkIf2(Button b)
        {
            if (stack.Count > 0)
            {
                c = stack.Peek();




                if  (c.Text==')'.ToString() || IsNumber(c.Text)==true)
                
                {
                    textBox1.Text = textBox1.Text + b.Text;

                    d = b;
                    stack.Push(d);

                }
                
            }
            else
            {
                d = b;
                stack.Push(d);
                textBox1.Text = textBox1.Text + b.Text;


            }
            
        }
             public void checkIf(Button b)
        {
            if (stack.Count > 0)
            {
                c = stack.Peek();




               if (c.Text!=')'.ToString() && IsNumber(c.Text)==false)
                {
                    textBox1.Text = textBox1.Text + b.Text;
                    b.Enabled = false;
                    d = b;
                    stack.Push(d);

                }
            }
            else
            {
                d = b;
                stack.Push(d);
                textBox1.Text = textBox1.Text + b.Text;
                b.Enabled = false;

            }}
            public bool IsNumber(string s)
             {
                 foreach (char c in s)
                 {
                     if (!Char.IsDigit(c))
                         return false;
                 }
                 return true;
             }

            
                private void timer1_Tick(object sender, System.EventArgs e)
        {
            Brush b1 = new SolidBrush(Color.Wheat);
            p = new Pen(Color.White, 2);
            ci = ci + 5;
            g.FillPie(b1, 210, 235, 90, 90, 0, ci);
            g.DrawEllipse(p, 210, 235, 90, 90);

            if (ci == 360)
            {
                timer1.Stop();
                lose.Play();
                MessageBox.Show("Вашето време истече!");
                label9.Text = "0";
                rezultat = 0;             
                Disabled();
            }
           
                
                
              

            
        }

                private void Disabled()
                {
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    button9.Enabled = false;
                    button10.Enabled = false;
                    button11.Enabled = false;
                    button12.Enabled = false;
                    button13.Enabled = false;

                }

               

                

                private void MojBroj1_Paint_1(object sender, PaintEventArgs e)
                {
                    g = this.CreateGraphics();
                    g.FillEllipse(b, 210, 235, 90, 90);

                }

                private void MojBroj1_FormClosed(object sender, FormClosedEventArgs e)
                {
                    timer1.Stop();
                }

               

               

               
                 

        }
}

       

        

       

      
 