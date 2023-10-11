namespace VerzioKezelo
{
    internal partial class Program
    {
        static string folderPath;
        static string szerzo;

        static void Main(string[] args)
        {
            InputSzerzo();
            InputPath();

            while (true)
            {
                if (!InicializalvaVanE(folderPath))
                {
                    switch (CallMenu(new string[] { "Mappa verziókövetésre alkalmassá tétele", "Új mappa megadása", "Kilépés" }))
                    {
                        case 0:
                            Inicializalas(folderPath, szerzo);
                            break;
                        case 1:
                            InputPath();
                            break;
                        case 2:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                else {
                    switch (CallMenu(new string[] { "Verzió mentése", "A verziótörténet megjelenítése", "Új mappa megadása", "Kilépés" }))
                    {
                        case 0:
                            UjCommitMenu(folderPath, szerzo);
                            break;                              
                        case 1:
                            CommitokListazasa(folderPath);
                            break;
                        case 2:
                            InputPath();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }

                
            }
        }
    }
}