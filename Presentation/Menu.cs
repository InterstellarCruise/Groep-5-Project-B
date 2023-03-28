using System.ComponentModel.Design;
using static System.Net.Mime.MediaTypeNames;

static class Menu
{
    public static bool LoggedIn = false;
    public static bool AdminLogged = false;
    static public void Start()
    {
        MenuBuilder menu = new MenuBuilder(Items());
        menu.DisplayMenu();
    }
    public static void NotImplemented()
    {
        Console.WriteLine("This feature is not yet implemented\n");
        int milliseconds = 3000;
        Thread.Sleep(milliseconds);
        Console.Clear();
        Start();
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
<<<<<<< HEAD
            if (input == "1")
            {
                Console.Clear();
                UserLogin.Start();
            }
            else if (input == "2")
            {
                Console.Clear();
                DatePicker.Start();
            }
            else if (input == "3")
            {
                Console.Clear();
                CinemaInfo.start();
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
=======
            items.Add(new MenuItem("Login/register", UserLogin.Start));
>>>>>>> main
        }
        else if (LoggedIn)
        {
            items.Add(new MenuItem("Account", NotImplemented));
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