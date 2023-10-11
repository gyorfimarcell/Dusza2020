using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerzioKezelo
{
    internal class Commit
    {
        int id;
        int szulo;
        string szerzo;
        DateTime datum;
        string leiras;
        List<Valtozas> valtozasok;

        public Commit(int id, int szulo, string szerzo, DateTime datum, string leiras, List<Valtozas> valtozasok)
        {
            this.id = id;
            this.szulo = szulo;
            this.szerzo = szerzo;
            this.datum = datum;
            this.leiras = leiras;
            this.valtozasok = valtozasok;
        }

        public Commit(string szoveg, int id)
        {
            string[] sorok = szoveg.Split('\n');

            this.id = id;
            this.szulo = Convert.ToInt32(sorok[0].Replace("Szulo: ", ""));
            this.szerzo = sorok[1].Replace("Szerzo: ", "");
            this.datum = DateTime.Parse(sorok[2].Replace("Datum: ", ""));
            this.leiras = sorok[3].Replace("Leiras: ", "");

            valtozasok = new List<Valtozas>();
            foreach (string valtozasSor in sorok.Skip(5))
            {
                valtozasok.Add(new Valtozas(valtozasSor));
            }
        }

        public override string ToString()
        {
            string szoveg =
                $"Szulo: {szulo}\n" +
                $"Szerzo: {szerzo}\n" +
                $"Datum: {datum.ToString("yyyy.MM.dd HH:mm:ss")}\n" +
                $"Leiras: {leiras}\n" +
                "Valtozott:";

            foreach (Valtozas valtozas in valtozasok)
            {
                szoveg += "\n" + valtozas.ToString();
            }

            return szoveg;
        }

        public int Id { get => id; }
        public int Szulo { get => szulo; }
        public string Szerzo { get => szerzo; }
        public DateTime Datum { get => datum; }
        public string Leiras { get => leiras; }
        internal List<Valtozas> Valtozasok { get => valtozasok; }
    }
}
