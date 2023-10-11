using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerzioKezelo
{
    enum ValtozasTipus { 
        Torolt,
        Uj,
        Valtozott
    }

    internal class Valtozas
    {
        ValtozasTipus tipus;
        string fajlnev;
        DateTime datum;

        public Valtozas(ValtozasTipus tipus, string fajlnev, DateTime datum)
        {
            this.tipus = tipus;
            this.fajlnev = fajlnev;
            this.datum = datum;
        }

        public Valtozas(string sor)
        {
            string[] mezok = sor.Split(' ');

            this.tipus = mezok[0] == "torolt" ? ValtozasTipus.Torolt : (mezok[0] == "uj" ? ValtozasTipus.Uj : ValtozasTipus.Valtozott);
            this.fajlnev = mezok[1];
            this.datum = DateTime.Parse(mezok[2]);
        }

        public override string ToString() {
            string tipusString = tipus == ValtozasTipus.Torolt ? "torolt" : (tipus == ValtozasTipus.Uj ? "uj" : "valtozott");
            return $"{tipusString} {fajlnev} {datum.ToString("yyyy.MM.dd HH:mm:ss")}";
        }

        public string Fajlnev { get => fajlnev; }
        public DateTime Datum { get => datum; }
        public ValtozasTipus Tipus { get => tipus; }
    }
}
