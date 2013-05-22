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
    public partial class Pravila : Form
    {
        public Pravila()
        {
            InitializeComponent();
        }

        private void Pravila_Load(object sender, EventArgs e)
        {
            textBox1.Select(0, 0);
        }
    }
}
