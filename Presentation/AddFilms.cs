using System.Text.RegularExpressions;
public static class AddFilms
{
    static FilmsLogic filmlogic = new FilmsLogic();
    private static string _warning = "WARNING\nThis may have grave consequences.\nAre you sure you want to proceed with this action?\n";
    private static string _option = "Do you want to add a show or film?";
    public static string Name = "";
    public static string Description = "";
    public static int AgeLimit = 0;

    public static double length = 0;
    private static List<string> _genres = new List<string>();
    public static int ID = 0;
    public static void Start()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem(_warning, null));
        items.Add(new MenuItem("Yes", AddShows.Options));
        items.Add(new MenuItem("No", AdminFeatures.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }

    public static void NameInput()
    {
        Console.Clear();
        int LastID = FilmsLogic.LastID();
        ID = LastID += 1;
        Console.WriteLine("Type the name of the movie: ");
        Name = Console.ReadLine();
        Console.Clear();
        DescrInput();
    }

    public static void DescrInput()
    {
        Console.WriteLine("Type the description of the movie: ");
        Description = Console.ReadLine();
        Console.Clear();
        AgeLimitInput();
    }

    public static void AgeLimitInput()
    {
        Console.WriteLine("Type the age-limit of the movie (If no age-limit leave empty)");
        string Limit = Console.ReadLine();
        // int AgeLimit;

        if (!int.TryParse(Limit, out AgeLimit))
        {
            AgeLimit = 0;
        }
        else if (Convert.ToInt32(Limit) < 7 || Convert.ToInt32(Limit) > 18)
        {
            AgeLimit = 0;
        }
        Console.Clear();
        TimeInput();
    }



    public static void TimeInput()
    {
        Console.WriteLine("Type the length of the movie like (Hour.Minutes): ");
        string Length = Console.ReadLine();
        Regex regex = new Regex(@"^\d+\.\d{1,2}$");
        if (!regex.IsMatch(Length))
        {
            Console.WriteLine("Invalid time format. Please use the format 'h.mm' with at least one digit after the dot.");
            TimeInput();
        }
        string[] parts = Length.Split('.');
        int i1 = int.Parse(parts[0]);
        int i2 = int.Parse(parts[1]);
        if (i2 < 0 || i2 > 59)
        {
            Console.WriteLine("Invalid minutes.");
            int millisecondsmin = 1500;
            Thread.Sleep(millisecondsmin);
            Console.Clear();
            TimeInput();
        }
        if (i1 > 4)
        {
            Console.WriteLine("Invalid hours.");
            int millisecondsmin = 1500;
            Thread.Sleep(millisecondsmin);
            Console.Clear();
            TimeInput();
        }
        double hourperc = Convert.ToDouble(i2) / 60;
        length = i1 + hourperc;
        Console.Clear();
        GenreInput();
    }

    public static void GenreInput()
    {
        Console.WriteLine("Type a genre of the movie: ");
        bool genrecheck = false;
        while (!genrecheck)
        {
            string _genre = Console.ReadLine();
            _genres.Add(_genre);
            Console.WriteLine("Do you want to add another genre? Y / N");
            string YN = Console.ReadLine();
            Console.Clear();
            if (YN.ToUpper() == "N")
            {
                genrecheck = true;
            }
            else
            {
                Console.WriteLine("The name of the other genre:");
            }
        }
        Add();

    }

    public static void Add()
    {
        Console.WriteLine(Name + " added to database");
        int milliseconds = 1500;
        Thread.Sleep(milliseconds);
        Console.Clear();

        FilmsLogic filmlogic = new FilmsLogic();
        FilmModel film = new(ID, Name, Description, AgeLimit, length, _genres);
        filmlogic.UpdateList(film);

        //New LogicLayer function
        Menu.Start();
    }

}
