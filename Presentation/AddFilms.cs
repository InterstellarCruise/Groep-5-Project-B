public static class AddFilms
{
    static FilmsLogic filmlogic = new FilmsLogic();
    private static string _warning = "WARNING\nThis may have grave consequences.\nAre you sure you want to proceed with this action?\n";
    private static string _option = "Do you want to add a show or film?";
    public static List<FilmModel> Films = FilmsAccess.LoadAll();

    public static void Start()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem(_warning, null));
        items.Add(new MenuItem("Yes", AddShows.Options));
        items.Add(new MenuItem("No", AdminFeatures.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void FilmInput()
    {
        List<string> Genres = new List<string>();
        Console.Clear();
        int LastID = FilmsLogic.LastID();
        int ID = LastID += 1;
        Console.WriteLine("Type the name of the movie: ");
        string Name = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Type the description of the movie: ");
        string Description = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Type the age-limit of the movie (If no age-limit leave empty)");
        string Limit = Console.ReadLine();
        int AgeLimit;
        if (!int.TryParse(Limit, out AgeLimit))
        {
            AgeLimit = 0;
        }
        Console.Clear();
        Console.WriteLine("Type the length of the movie like (Hour.Minutes): ");
        double Length = Convert.ToDouble(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Type a genre of the movie: ");
        bool genrecheck = false;
        while (!genrecheck)
        {
            string _genre = Console.ReadLine();
            Genres.Add(_genre);
            Console.WriteLine("Do you want to add another genre? Y / N");
            string YN = Console.ReadLine();
            if (YN.ToUpper() == "N")
            {
                genrecheck = true;
            }
            else
            {
                Console.WriteLine("The name of the other genre:");
            }
        }
        Console.Clear();
        Console.WriteLine(Name + " added to database");
        int milliseconds = 1500;
        Thread.Sleep(milliseconds);
        Console.Clear();
        FilmModel film = new FilmModel(ID, Name, Description, AgeLimit, Length, Genres);
        FilmsAccess.Add(film);
        Menu.Start();
    }

}