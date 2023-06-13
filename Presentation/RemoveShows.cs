public static class RemoveShows
{
    static ShowsLogic showLogic = new ShowsLogic();
    static FilmsLogic filmLogic = new FilmsLogic();
    private static string _warning = "WARNING\nThis may have grave consequences.\nAre you sure you want to proceed with this action?\n";
    private static string _option = "Do you want to delete a show or film?";
    public static FilmModel currentFilm;
    public static ShowModel currentShow;
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
        Console.WriteLine("These are all the current shows");
        ShowsLogic showslogic = new ShowsLogic();
        var shows = ShowsLogic.AllCurrentShows();
        List<MenuItem> items = new List<MenuItem>();
        foreach (ShowModel entry in shows)
        {
            FilmsLogic filmlogic = new FilmsLogic();
            FilmModel film1 = filmlogic.GetById(entry.FilmId);
            MenuItem item = new MenuItem($"--------------------------------\nShow ID: {entry.Id}\nRoom: {entry.RoomId}\nFilm: {film1.Name}", DeleteShowEntry);
            item.show = entry;
            item.RemoveShow = true;
            items.Add(item);
        }
        items.Add(new MenuItem("\nBack", AdminFeatures.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void DeleteFilm()
    {
        Console.WriteLine("These are all the current films");
        var films = FilmsLogic.AllCurrentFilms();
        List<MenuItem> items = new List<MenuItem>();
        foreach (FilmModel entry in films)
        {
            ShowsLogic showsLogic = new ShowsLogic();
            ShowModel entryshow = showsLogic.GetByFilmId(entry.Id);
            MenuItem item = new MenuItem($"--------------------------------\nFilm ID: {entry.Id}\nTitle: {entry.Name}\nDescription: {entry.Description}\nAge Limit{entry.AgeLimit}\nLength: {entry.Length}",DeleteShowAndFilm );
            item.film = entry;
            items.Add(item);
        }
        items.Add(new MenuItem("\nBack", AdminFeatures.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();

    }
    private static void DeleteShowEntry()
    {
        showLogic.DeleteShow(currentShow);
        Console.WriteLine("The show has been removed");
        int miliseconds = 3000;
        Thread.Sleep(miliseconds);
        AdminFeatures.Start();
    }
    private static void DeleteShowAndFilm()
    {
        ShowModel show = showLogic.GetByFilmId(currentFilm.Id);
        filmLogic.DeleteFilm(currentFilm);
        showLogic.DeleteShow(show);
        Console.WriteLine("The film and the shows that were displaying this film have been removed");
        int miliseconds = 3000;
        Thread.Sleep(miliseconds);
        AdminFeatures.Start();
    }

}