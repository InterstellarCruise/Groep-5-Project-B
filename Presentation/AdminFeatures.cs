public static class AdminFeatures
{
    public static void Start()
    {
        Choices();
    }


    public static void Choices()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Change show", ChangeShows.Start));
        items.Add(new MenuItem("Remove show or film", RemoveShows.Start));
        items.Add(new MenuItem("Add show or film", AddShows.Start));
        items.Add(new MenuItem("Back", Menu.Start));
        items.Add(new MenuItem("Quit", Menu.Quit));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();

    }
}