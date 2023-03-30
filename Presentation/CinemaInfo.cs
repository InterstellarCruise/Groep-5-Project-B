static class CinemaInfo
{
    public static void start()
    {
        // Console.WriteLine("\n");
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Information about the cinema \n--------------------------------\nCinema name: (idk) \n--------------------------------\nCinema description: (idk) \n--------------------------------\nCinema Location: Wijnhaven 107, 3011 WN in Rotterdam \n--------------------------------\n", null));
        items.Add(new MenuItem("Back", Menu.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
}