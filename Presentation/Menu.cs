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
            items.Add(new MenuItem("Login/register", UserLogin.Start));
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