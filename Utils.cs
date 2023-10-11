namespace VerzioKezelo {
    internal partial class Program
    {
        static bool InicializalvaVanE(string mappa)
        {
            return Directory.Exists(Path.Combine(mappa, ".dusza"));
        }

        static List<Commit> CommitokBeolvasasa(string mappa)
        {
            string[] commitMappak = Directory.GetDirectories(Path.Combine(mappa, ".dusza"));

            List<Commit> commitok = new List<Commit>();
            foreach (string commitMappa in commitMappak)
            {
                string id = Path.GetFileName(commitMappa).Split('.')[0];
                string fajl = File.ReadAllText(Path.Combine(commitMappa, "commit.details"));
                commitok.Add(new Commit(fajl, Convert.ToInt32(id)));
            }

            return commitok;
        }

        static int KovetkezoSorszam(string mappa) {
            List<Commit> commitok = CommitokBeolvasasa(mappa);
            return commitok.Max(x => x.Id) + 1;
        }

        static int AktivSorszam(string mappa)
        {
            return Convert.ToInt32(File.ReadAllText(Path.Combine(mappa, ".dusza", "head.txt")));
        }

        static string AktivCommitMappa(string mappa)
        {
            int id = AktivSorszam(mappa);
            return Path.Combine(mappa, ".dusza", $"{id}.commit");
        }

        static void UjCommit(string mappa, int sorszam, int szulo, string leiras, string szerzo)
        {
            //TODO: valtozasok
            List<Valtozas> valtozasok = sorszam == 1 ? new List<Valtozas>() : Valtozasok(mappa);

            Commit commit = new Commit(sorszam, szulo, szerzo, DateTime.Now, leiras, valtozasok);

            string commitMappa = Path.Combine(mappa, ".dusza", $"{sorszam}.commit");
            Directory.CreateDirectory(commitMappa);
            //TODO: fájlok másolása
            File.WriteAllText(Path.Combine(commitMappa, "commit.details"), commit.ToString());
            File.WriteAllText(Path.Combine(mappa, ".dusza", "head.txt"), Convert.ToString(sorszam));
        }

        static void Inicializalas(string mappa, string szerzo)
        {
            Directory.CreateDirectory(Path.Combine(mappa, ".dusza"));
            File.WriteAllText(Path.Combine(mappa, ".dusza", "head.txt"), "1");
            UjCommit(mappa, 1, -1, "Initial commit", szerzo);
        }

        static void UjCommitMenu(string mappa, string szerzo)
        {
            Console.Clear();
            Console.Write("A commit leírása: ");
            string leiras = Console.ReadLine();

            int sorszam = KovetkezoSorszam(mappa);
            int szulo = AktivSorszam(mappa);

            UjCommit(mappa, sorszam, szulo, leiras, szerzo);
        }

        static void CommitokListazasa(string mappa) {
            Console.Clear();
            List<Commit> commitok = CommitokBeolvasasa(mappa);
            foreach (Commit c in commitok)
            {
                Console.WriteLine(new String('-', 20));
                Console.WriteLine($"Commit: {c.Id}");
                Console.WriteLine(c.ToString());
            }

            Console.ReadKey();
        }
    }
}