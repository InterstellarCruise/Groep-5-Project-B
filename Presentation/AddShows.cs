public static class AddShows
{
    static ShowsLogic showLogic = new ShowsLogic();
    private static int _movieId;
    public static int MovieId
    {
        get { return _movieId; }
        set { _movieId = value; }
    }

    static FilmsLogic filmLogic = new FilmsLogic();
    private static string _warning = "WARNING\nThis may have grave consequences.\nAre you sure you want to proceed with this action?\n";
    private static string _option = "Do you want to add a show or film?";
    public static List<FilmModel> Films = FilmsAccess.LoadAll();

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
        items.Add(new MenuItem("Show", AddShow));
        items.Add(new MenuItem("Film", AddFilm));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void AddShow()
    {
        Console.Clear();
        Console.WriteLine($"Select the movie that plays on this show:\n");
        FilmsLogic.AllFilms(Films);
        List<MenuItem> items = new List<MenuItem>();
        for (int i = 0; i < FilmsLogic.FilmInfo.Count; i++)
        {
            string filmname = FilmsLogic.FilmInfo.Keys.ElementAt(i);
            int FilmId = FilmsLogic.FilmInfo.Values.ElementAt(i);
            MenuItem item = new MenuItem($"{FilmsLogic.Lines}\n{filmname}", ShowInput);
            item.MovieId = FilmId;
            items.Add(item);

        }
        items.Add(new MenuItem("\nBack", Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void ShowInput()
    {
        Console.Clear();
        int LastID = ShowsLogic.LastID();
        int ID = LastID += 1;
        Console.WriteLine("Type the room number this movie will play in: ");
        string room = Console.ReadLine();
        int RoomId = Convert.ToInt32(room);
        Console.Clear();
        Console.WriteLine("Type the date this show will play like (Year-Month-Day): ");
        string Date = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Type the time this show will start like (Hour-Minutes): ");
        string Time = Console.ReadLine();
        Console.Clear();
        ShowModel show = new ShowModel(ID, MovieId, RoomId, Date, Time);
        ShowsAccess.Add(show);
    }
    public static void AddFilm()
    {
        // Console.WriteLine("Enter film id you want to delete");
        // int id = Convert.ToInt32(Console.ReadLine());
        // FilmModel film = filmLogic.GetById(id);
        // filmLogic.DeleteFilm(film);
        // Console.WriteLine("The film has been removed");
        // int miliseconds = 3000;
        // Thread.Sleep(miliseconds);
        // AdminFeatures.Start();
    }

}