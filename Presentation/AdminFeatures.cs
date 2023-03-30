public static class AdminFeatures
{
    public static void Start()
    {
        Choices();
    }


    public static void Choices()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Change show details", ChangeShows.Start));
        items.Add(new MenuItem("Remove shows or films", RemoveShows.Start));
        items.Add(new MenuItem("Back", Menu.Start));
        items.Add(new MenuItem("Quit", Menu.Quit));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();

    }
}