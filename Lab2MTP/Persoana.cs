using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2MTP
{
    internal class Persoana
    {
        string cnp;
        string nume;
        string adresa;
        public Persoana(string cnp, string nume, string adresa)
        {
            this.cnp = cnp;
            this.nume = nume;
            this.adresa = adresa;
        }
        public string Cnp { get => cnp; set => cnp = value; }
        public string Nume { get => nume; set => nume = value; }
        public string Adresa { get => adresa; set => adresa = value; }

    }

}
