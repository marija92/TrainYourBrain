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
    public partial class CstYes : Form
    {
        
        public CstYes()
        {
            InitializeComponent();
        }

        static CstYes msgBox;  static DialogResult result=DialogResult.No;

        public static DialogResult Show (string text, string Caption)
        {
            msgBox = new CstYes();
            msgBox.textBox1.Text = text;
            msgBox.Text = Caption;
            result = DialogResult.No;
            msgBox.ShowDialog();
            return result;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            msgBox.Close();
            
            

        }

        private void CstYes_Load(object sender, EventArgs e)
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
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
