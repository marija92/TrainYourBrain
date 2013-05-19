using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Prasanje
    {
        public string prasanje {get; set;}
        public bool odgovor { get; set; }

        public Prasanje(string p, bool o)
        {
            prasanje = p;
            odgovor = o;
        }
    }
}
