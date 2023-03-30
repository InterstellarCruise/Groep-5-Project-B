public static class RemoveShows
{
    static ShowsLogic showLogic = new ShowsLogic();
    static FilmsLogic filmLogic = new FilmsLogic();
    private static string _warning = "WARNING\nThis may have grave consequences.\nAre you sure you want to proceed with this action?\n";
    public static void Start()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem(_warning, null));
        items.Add(new MenuItem("Yes", DeleteItem));
        items.Add(new MenuItem("No", AdminFeatures.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void DeleteItem()
    {
        Console.WriteLine("Enter show id you want to delete");
        int id = Convert.ToInt32(Console.ReadLine());
        ShowModel show = showLogic.GetById(id);
        showLogic.DeleteShow(show);
        // FilmModel film = filmLogic.GetById(id);
        // filmLogic.DeleteShow(film);
        Console.WriteLine("The show has been removed");
        int miliseconds = 3000;
        Thread.Sleep(miliseconds);
        AdminFeatures.Start();
    }

}