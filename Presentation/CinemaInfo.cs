static class CinemaInfo
{
    public static void start()
    {
        Console.Clear();
        Console.WriteLine("Information about the cinema \n");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Cinema name: (idk)");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Cinema description: (idk)");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Cinema Location: Wijnhaven 107, 3011 WN in Rotterdam");
        Console.WriteLine("--------------------------------");
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Information about the cinema \n--------------------------------\nCinema name: (idk) \n--------------------------------\nCinema description: (idk) \n--------------------------------\nCinema Location: Wijnhaven 107, 3011 WN in Rotterdam \n--------------------------------\n", null));
        items.Add(new MenuItem("Back", Menu.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void back(string input)
    {

        if (input.ToUpper() == "B")
        {
            Console.Clear();
            Menu.Start();
        }
        else
        {
            Console.WriteLine("Invalid input");
            int milliseconds = 1000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            start();

        }
    }
}