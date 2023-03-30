public static class RemoveShows
{
    static ShowsLogic showLogic = new ShowsLogic();
    static FilmsLogic filmLogic = new FilmsLogic();
    private static string _warning = "WARNING\nThis may have grave consequences.\nAre you sure you want to proceed with this action?\n";
    private static string _option = "Do you want to delete a show or film?";
    public static void Start()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem(_warning, null));
        items.Add(new MenuItem("Yes", Options));
        items.Add(new MenuItem("No", AdminFeatures.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }

    public static void Options()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem(_option, null));
        items.Add(new MenuItem("Show", DeleteShow));
        items.Add(new MenuItem("Film", DeleteFilm));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void DeleteShow()
    {
        Console.WriteLine("Enter show id you want to delete");
        int id = Convert.ToInt32(Console.ReadLine());
        ShowModel show = showLogic.GetById(id);
        showLogic.DeleteShow(show);
        Console.WriteLine("The show has been removed");
        int miliseconds = 3000;
        Thread.Sleep(miliseconds);
        AdminFeatures.Start();
    }
    public static void DeleteFilm()
    {
        Console.WriteLine("Enter film id you want to delete");
        int id = Convert.ToInt32(Console.ReadLine());
        FilmModel film = filmLogic.GetById(id);
        filmLogic.DeleteFilm(film);
        Console.WriteLine("The film has been removed");
        int miliseconds = 3000;
        Thread.Sleep(miliseconds);
        AdminFeatures.Start();
    }

}