static class CinemaInfo
{
    public static void start()
    {
        Console.WriteLine("Information about the cinema \n");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Cinema name: (idk)");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Cinema Location: (idk)");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Cinema description: (idk)");
        Console.WriteLine("--------------------------------");
        // Console.WriteLine("\n");
        Console.WriteLine("Press 'B' to go back.");
        string input = Console.ReadLine();
        if (input.ToUpper() == "B")
        {
            Console.Clear();
            Menu.Start();
        }

    }
}