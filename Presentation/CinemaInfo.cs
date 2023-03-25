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
        back(input);


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