using System.ComponentModel.Design;
using static System.Net.Mime.MediaTypeNames;

static class Menu
{
<<<<<<< HEAD

=======
>>>>>>> main
    public static bool LoggedIn = false;
    public static bool AdminLogged = false;
    static public void Start()
    {
        MenuBuilder menu = new MenuBuilder(Items());
        menu.DisplayMenu();
    }
    public static void NotImplemented()
    {
<<<<<<< HEAD
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
=======
        Console.WriteLine("This feature is not yet implemented\n");
        int milliseconds = 3000;
        Thread.Sleep(milliseconds);
        Console.Clear();
        Start();
>>>>>>> main
    }
    public static void Quit()
    {
        Environment.Exit(0);
    }
    public static List<MenuItem> Items()
    {
        List<MenuItem> items = new List<MenuItem>();
        if (!LoggedIn)
        {
            items.Add(new MenuItem("Login/register", UserLogin.Start));
        }
        else if (LoggedIn)
        {
<<<<<<< HEAD
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
=======
            items.Add(new MenuItem("Account", NotImplemented));
>>>>>>> main
        }
        items.Add(new MenuItem("Shows", NotImplemented));
        items.Add(new MenuItem("Cinema Info", NotImplemented));
        if (AdminLogged)
        {
            items.Add(new MenuItem("Admin Features", AdminFeatures.Start));
        }
        items.Add(new MenuItem("Quit", Quit));
        return items;
    }
}