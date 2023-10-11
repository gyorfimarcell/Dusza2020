namespace VerzioKezelo {
    internal partial class Program
    {
        static string InputPath()
        {
            Console.Clear();
            do
            {
                Console.WriteLine("Add meg a mappa elérési útját!");
                folderPath = Console.ReadLine();
            } while (!Directory.Exists(folderPath));
            return folderPath;
        }

        static string InputSzerzo()
        {
            Console.Write("Szerző: ");
            szerzo = Console.ReadLine();
            return szerzo;
        }

        static int CallMenu(string[] menuOptions)
        {
            ConsoleKeyInfo pressedKey;
            int selectedIndex = 0;
            do
            {
                Console.Clear();
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    string option = menuOptions[i];
                    if (menuOptions[selectedIndex] == option)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.SetCursorPosition((Console.WindowWidth - option.Length)/2, (Console.WindowHeight - menuOptions.Length) / 2 + i);
                    Console.WriteLine(option);
                    Console.ResetColor();
                }
                pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    if (selectedIndex + 1 < menuOptions.Length)
                    {
                        selectedIndex++;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    if (selectedIndex - 1 >= 0)
                    {
                        selectedIndex--;
                    }
                }
            } while (pressedKey.Key != ConsoleKey.Enter);
            return selectedIndex;
        }
    }
}