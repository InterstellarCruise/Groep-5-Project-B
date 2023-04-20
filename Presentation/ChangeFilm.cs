public static class ChangeFilm
{

    static FilmsLogic filmLogic = new FilmsLogic();
    private static FilmModel _film = new FilmModel(0, null, null, 0, 0, null);
    private static string CurrentFilm = "";
    public static FilmModel film
    {
        get { return _film; }
        set { _film = value; }
    }

    private static int _movieId;
    public static int MovieId
    {
        get { return _movieId; }
        set { _movieId = value; }
    }
    public static void Start()
    {
        SearchByID();
        MenuDisplay();
    }
    public static void MenuDisplay()
    {
        if (film != null)
        {
            film = filmLogic.GetById(film.Id);
            ShowInformation();

            List<MenuItem> items = new List<MenuItem>();
            items.Add(new MenuItem(CurrentFilm, null));
            items.Add(new MenuItem("Length", EditLength));
            items.Add(new MenuItem("Title", EditTitle));
            items.Add(new MenuItem("Description", EditDescription));
            items.Add(new MenuItem("Age Limit", EditAgeLimit));
            items.Add(new MenuItem("Back", AdminFeatures.Start));
            items.Add(new MenuItem("Main menu", Menu.Start));
            MenuBuilder menu = new MenuBuilder(items);
            menu.DisplayMenu();
        }
    }
    public static void EditTitle()
    {
        Console.WriteLine("\n-------------------------------\nEnter a new title");
        string title = Console.ReadLine();
        film.Name = title;
        filmLogic.UpdateList(film);
        film = filmLogic.GetById(film.Id);
        Console.WriteLine("\nThe title has been updated, here is the result:\n");
        ShowInformation();
        int milliseconds = 3000;
        Thread.Sleep(milliseconds);
        Console.Clear();
        MenuDisplay();
    }


    public static void EditAgeLimit()
    {
        Console.WriteLine("\n-------------------------------\nEnter a new age limit");
        int ageLimit = Convert.ToInt32(Console.ReadLine());
        if (ageLimit <= 6 || ageLimit >= 18)
        {
            Console.WriteLine("This is an incorrect age limit, please put an age limit between 6 and 18 years");
            EditAgeLimit();
        }
        else
        {
            film.AgeLimit = ageLimit;
            filmLogic.UpdateList(film);
            film = filmLogic.GetById(film.Id);
            Console.WriteLine("\nThe age limit has been updated, here is the new result:\n");
            ShowInformation();
            int milliseconds = 3000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            MenuDisplay();
        }
    }

    public static void EditLength()
    {
        Console.WriteLine("\n-------------------------------\nEnter a new length of the film (Format: hour.minute)");
        double lenght = Convert.ToDouble(Console.ReadLine());
        if (lenght <= 0 || lenght >= 4)
        {
            Console.WriteLine("This is an incorrect format of time, please put a time between 0.0 and 4.0 ");
            EditLength();
        }
        else
        {
            film.Length = lenght;
            filmLogic.UpdateList(film);
            film = filmLogic.GetById(film.Id);
            Console.WriteLine("\nThe film length has been updated, here is the new result:\n");
            ShowInformation();
            int milliseconds = 3000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            MenuDisplay();
        }
    }

    public static void EditDescription()
    {
        Console.WriteLine("\n-------------------------------\nEnter a new description\n");
        string descrption = Console.ReadLine();
        film.Description = descrption;
        filmLogic.UpdateList(film);
        film = filmLogic.GetById(film.Id);
        Console.WriteLine("\nThe description has been updated, here is the new result:\n");
        ShowInformation();
        int milliseconds = 3000;
        Thread.Sleep(milliseconds);
        Console.Clear();
        MenuDisplay();
    }

    public static void ShowInformation()
    {
        Console.WriteLine($"Film ID: {film.Id}");
        Console.WriteLine($"Film Title: {film.Name}");
        Console.WriteLine($"Film Description: {film.Description}");
        Console.WriteLine($"Film AgeLimit: {film.AgeLimit}");
        Console.WriteLine($"Length: {film.Length}");
        CurrentFilm = $"Film ID: {film.Id}  \nFilm Title: {film.Name} \nFilm Description: {film.Description} \nFilm Age Limit: {film.AgeLimit} \nLength: {film.Length}\n-------------------------------";


    }
    public static void SearchByID()
    {
        Console.Clear();
        Console.WriteLine("These are all the current films");
        FilmsLogic.AllCurrentFilms();
        Console.WriteLine("Enter the ID of the film you want to view \n-------------------------------");
        int id = Convert.ToInt32(Console.ReadLine());
        film = filmLogic.GetById(id);
        if (film == null)
        {
            Console.WriteLine("There is no film with this ID");
            int miliseconds = 2000;
            Thread.Sleep(miliseconds);
            Console.Clear();
            AdminFeatures.Start();
        }

    }
}