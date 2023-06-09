using Microsoft.Win32;
using System.ComponentModel.Design;
using static System.Net.Mime.MediaTypeNames;

static class Menu
{
    public static bool LoggedIn = false;
    public static bool AdminLogged = false;
    public static Tuple<string, string, string, string, string, string> menuItems = Tuple.Create("Login/register", "Account", "Shows", "Cinema Info", "Admin Features", "Quit");
    static public void Start()
    {

        Console.CursorVisible = false;
        MenuBuilder menu = new MenuBuilder(Items());
        menu.DisplayMenu();
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
            items.Add(new MenuItem(menuItems.Item1, UserLogin.Start));
        }
        else if (LoggedIn)
        {
            items.Add(new MenuItem(menuItems.Item2, AccountPage.start));
        }
        items.Add(new MenuItem(menuItems.Item3, DatePicker.Start));
        items.Add(new MenuItem(menuItems.Item4, CinemaInfo.start));
        if (AdminLogged)
        {
            items.Add(new MenuItem(menuItems.Item5, AdminFeatures.Start));
        }
        items.Add(new MenuItem(menuItems.Item6, Quit));
        return items;
    }
}