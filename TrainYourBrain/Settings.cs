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
    public partial class Settings : Form
    {
        List<CustomTheme> mozniTemi;
        CustomTheme odbrana;
        public Settings()
        {
            InitializeComponent();
            mozniTemi = new List<CustomTheme>();
            string temi = TrainYourBrain.Properties.Resources.temi;
            string[] temiNiza = temi.Split(new char[] { '\n', '\r' });
            for (int i = 0; i < temiNiza.Length; i+=4)
            {
                comboBox1.Items.Add(temiNiza[i]);
                mozniTemi.Add(new CustomTheme(temiNiza[i+2]));
            }
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            
            odbrana=mozniTemi[index];
            btnMojZbor.BackColor = System.Drawing.ColorTranslator.FromHtml(odbrana.btn);
            btnMojZbor.FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml(odbrana.btnText);
            btnMojZbor.FlatAppearance.MouseOverBackColor = System.Drawing.ColorTranslator.FromHtml(odbrana.back);
            btnMojZbor.FlatAppearance.MouseDownBackColor = System.Drawing.ColorTranslator.FromHtml(odbrana.btnText);
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(odbrana.back);
            btnMojZbor.ForeColor = System.Drawing.ColorTranslator.FromHtml(odbrana.btnText);
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml(odbrana.btnText);
            label2.BackColor = System.Drawing.ColorTranslator.FromHtml(odbrana.back);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sr = new StreamWriter("../../theme.txt");
            sr.WriteLine(odbrana.textMode);
            sr.Close();
            this.Close();
        }
    }
}
