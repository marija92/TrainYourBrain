using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace TrainYourBrain
{
    class CustomTheme
    {
      
        public string back { get; set; }
        public string textMode{get;set;}
        public string btn { get; set; }
        public string btnText { get; set; }
        public CustomTheme(string initCodes)
        {
            string[] initHtmlCodes = initCodes.Split('$');
            textMode = initCodes;
            back = initHtmlCodes[0];
            btn =initHtmlCodes[1];
            btnText = initHtmlCodes[2];
        }

    }
}
