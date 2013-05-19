using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
