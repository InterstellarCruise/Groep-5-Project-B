using System.ComponentModel.Design;
using static System.Net.Mime.MediaTypeNames;

static class Menu
{

    public static bool LoggedIn = false;
    static public void Start()
    {
        Display();
        string input = Console.ReadLine();
        Choices(input);
    }
    public static void Display()
    {
        if (LoggedIn == false)
        {
        Console.WriteLine("[1] login/register\n-----------------------------");
        Console.WriteLine("[2] Shows\n-----------------------------");
        Console.WriteLine("[3] Cinema information\n-----------------------------");
        Console.WriteLine("[Q] Quit\n-----------------------------");
        }
        else
        {
            Console.WriteLine("[1] Account\n-----------------------------");
            Console.WriteLine("[2] Shows\n-----------------------------");
            Console.WriteLine("[3] Cinema information\n-----------------------------");
            Console.WriteLine("[Q] Quit\n-----------------------------");
        }
    }
    public static void Choices(string input)
    {
        if (LoggedIn == false)
        {
            if (input == "1")
            {
                UserLogin.Start();
            }
            else if (input == "2")
            {
                DatePicker.Start();
            }
            else if (input == "3")
            {
                Console.WriteLine("This feature is not yet implemented\n");
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                Start();
            }
            else if (input == "Q" || input == "q")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid input");
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                Start();
            }
        }
        else
        {
            if (input == "1")
            {
                Console.WriteLine("This feature is not yet implemented\n");
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                Start();
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
                Console.WriteLine("This feature is not yet implemented\n");
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                Start();
            }
            else if (input == "4")
            {
                Console.WriteLine("This feature is not yet implemented\n");
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                Start();
            }
            else if (input == "Q" || input == "q")
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
}