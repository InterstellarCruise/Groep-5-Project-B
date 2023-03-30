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
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            Menu.LoggedIn = true;
            ChangeShows.Start();
        }
        else if (input == "2")
        {
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            Menu.LoggedIn = true;
            RemoveShows.Start();
        }
        else if (input == "3")
        {
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            Menu.LoggedIn = true;
            Menu.Start();
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