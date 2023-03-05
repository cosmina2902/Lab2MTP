using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercitiul7_lab2
{
    internal class Persoana
    {
        string cnp;
        string nume;
        string post;
        public Persoana(string cnp, string nume, string adresa)
        {
            this.cnp = cnp;
            this.nume = nume;
            this.post = adresa;
        }
        public string Cnp { get => cnp; set => cnp = value; }
        public string Nume { get => nume; set => nume = value; }
        public string Post { get => post; set => post = value; }

    }
}
