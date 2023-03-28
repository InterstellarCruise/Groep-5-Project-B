public static class AdminFeatures
{
    public static void Start()
    {
        Display();
        string input = Console.ReadLine();
        Choices(input);
    }

    public static void Display()
    {
        Console.WriteLine("[1] Change show details\n-----------------------------");
        Console.WriteLine("[2] Remove shows\n-----------------------------");
        Console.WriteLine("[3] Return to menu\n-----------------------------");
        Console.WriteLine("[Q] Quit\n-----------------------------");
    }

     public static void Choices(string input)
    {
        if (input == "1")
        {
            ChangeShows.Start();
        }
        else if (input == "2")
        {
            Console.WriteLine("This feature is not yet implemented\n");
            int milliseconds = 3000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            Start();
        }
        else if (input == "3")
        {
            MenuAdmin.Start();
        }
        else if (input.ToUpper() == "Q")
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Invalid input");
            Start();
        }
    }
}