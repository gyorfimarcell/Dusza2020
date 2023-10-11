using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerzioKezelo
{
    internal partial class Program
    {
        static List<Valtozas> Valtozasok(string mappa) {
            List<Valtozas> valtozasok = new List<Valtozas>();

            string[] fajlok = Directory.GetFiles(mappa);
            string[] commitFajlok = Directory.GetFiles(AktivCommitMappa(mappa));
            commitFajlok = commitFajlok.Except(new string[] {"commit.details"}).ToArray();

            foreach (string fajl in fajlok.Except(commitFajlok))
            {
                //Todo: datum
                valtozasok.Add(new Valtozas(ValtozasTipus.Uj, fajl, DateTime.Now));
            }

            return valtozasok;
        }

        static bool FileCompare(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read);
            fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read);

            if (fs1.Length != fs2.Length)
            {
                fs1.Close();
                fs2.Close();

                return false;
            }

            do
            {
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            fs1.Close();
            fs2.Close();

            return ((file1byte - file2byte) == 0);
        }
    }
}
