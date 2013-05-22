using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TrainYourBrain
{
    public partial class Pravila : Form
    {
        public Pravila()
        {
            InitializeComponent();
        }

        private void Pravila_Load(object sender, EventArgs e)
        {
            textBox1.Select(0, 0);
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
        }
    }
}
