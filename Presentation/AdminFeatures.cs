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
        items.Add(new MenuItem("Change film", ChangeFilm.Start));
        items.Add(new MenuItem("Remove shows or films", RemoveShows.Start));
        items.Add(new MenuItem("Add show or film", AddShows.Start));
        // items.Add(new MenuItem("Income", AdminIncome.Main));
        items.Add(new MenuItem("Reservations", AdminReservations.Display));
        items.Add(new MenuItem("Back", Menu.Start));
        items.Add(new MenuItem("Quit", Menu.Quit));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();

    }
}