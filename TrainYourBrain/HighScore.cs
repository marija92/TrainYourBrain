using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace TrainYourBrain
{
    public partial class HighScore : Form
    {
       public int vkupno;
        
       List<int> rezultati = new List<int>();
       List<string> iminja=new List<string>();
       
        
        public HighScore()
        {
            InitializeComponent();
                      
        }

        List<string> pom = new List<string>();
       
       

        public void procitaj()
        {
            //Stream stream = (Stream)TrainYourBrain.Properties.Resources.highscore;

            StreamReader sr = new StreamReader("../../highscore.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                pom.Add(line); // Add to list.                
            }

            for (int i = 0; i < pom.Count; i++)
            {
                string[] p;
                p=pom.ElementAt(i).Split('\t');
                iminja.Add(p[0]);
                rezultati.Add(int.Parse(p[1]));
            }
            iminja.Add(textBox1.Text);
            rezultati.Add(vkupno);

            bubblesort();

            sr.Dispose();
            StreamWriter sw = new StreamWriter("../../highscore.txt");
            string pom1;
            for (int i = 0; i < iminja.Count; i++)
            {
                pom1=iminja.ElementAt(i) + "\t" + rezultati.ElementAt(i).ToString();
                sw.WriteLine(pom1);
            }
            sw.Dispose();
        }

        public void Clear()
        {
            for (int i = 0; i < rezultati.Count; i++)
            {
                rezultati.RemoveAt(i);
                iminja.RemoveAt(i);
            }
        }

        public void bubblesort()
        {
            int temp;
            string tmp;
            // foreach(int i in a)
            for (int i = 1; i <= rezultati.Count; i++)
                for (int j = 0; j < rezultati.Count - i; j++)
                    if (rezultati[j] < rezultati[j + 1])
                    {
                        temp = rezultati[j];
                        tmp = iminja[j];
                        rezultati[j] = rezultati [j + 1];
                        iminja[j] = iminja[j + 1];
                        rezultati[j + 1] = temp;
                        iminja[j + 1] = tmp;
                    }
            
        }          

        

        private void HighScore_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("../../highscore.txt");
            textBox2.Text = sr.ReadToEnd();
            sr.Dispose();
            Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            procitaj();
            StreamReader sr = new StreamReader("../../highscore.txt");
            textBox2.Text = sr.ReadToEnd();
            sr.Dispose();
            Clear();
            disabled();
           
        }

        public void disabled()
        {
            textBox1.ReadOnly = true;
            button1.Enabled = false;
        }

        

      


    }
}
