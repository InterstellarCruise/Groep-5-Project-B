public static class ChangeShows
{

    static ShowsLogic showLogic = new ShowsLogic();
    static FilmsLogic filmLogic = new FilmsLogic();
    private static ShowModel _show = new ShowModel(0, 0, 0, null, null);
    private static FilmModel _film = new FilmModel(0, null, null, 0, 0.0, null);
    private static string CurrentShow = "";
    public static ShowModel show
    {
        get { return _show; }
        set { _show = value; }
    }
    public static FilmModel film
    {
        get { return _film; }
        set { _film = value; }
    }
    public static void Start()
    {
        SearchByID();
        MenuDisplay();
    }
    public static void MenuDisplay()
    {
        if (show != null)
        {
            film = filmLogic.GetById(show.Id);
            ShowInformation();

            List<MenuItem> items = new List<MenuItem>();
            items.Add(new MenuItem(CurrentShow, null));
            items.Add(new MenuItem("Date", EditDate));
            items.Add(new MenuItem("Time", EditTTime));
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
        show = showLogic.GetById(film.Id);
        Console.WriteLine("\nThe title has been updated, here is the result:\n");
        ShowInformation();
        int milliseconds = 3000;
        Thread.Sleep(milliseconds);
        Console.Clear();
        MenuDisplay();
    }

    public static void EditDate()
    {
        Console.WriteLine("\n-------------------------------\nEnter a new date (Format: year-month-day)");
        string date = Console.ReadLine();
        show.Date = date;
        showLogic.UpdateList(show);
        film = filmLogic.GetById(show.Id);
        Console.WriteLine("\nThe date has been updated, here is the new result:\n");
        ShowInformation();
        int milliseconds = 3000;
        Thread.Sleep(milliseconds);
        Console.Clear();
        MenuDisplay();
    }

    public static void EditTTime()
    {
        Console.WriteLine("\n-------------------------------\nEnter a new time (Format: hour:minute)");
        string time = Console.ReadLine();
        show.Time = time;
        showLogic.UpdateList(show);
        film = filmLogic.GetById(show.Id);
        Console.WriteLine("\nThe time has been updated, here is the new result:\n");
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
        film.AgeLimit = ageLimit;
        filmLogic.UpdateList(film);
        show = showLogic.GetById(film.Id);
        Console.WriteLine("\nThe age limit has been updated, here is the new result:\n");
        ShowInformation();
        int milliseconds = 3000;
        Thread.Sleep(milliseconds);
        Console.Clear();
        MenuDisplay();
    }


    public static void EditDescription()
    {
        Console.WriteLine("\n-------------------------------\nEnter a new description\n");
        string descrption = Console.ReadLine();
        film.Description = descrption;
        filmLogic.UpdateList(film);
        show = showLogic.GetById(film.Id);
        Console.WriteLine("\nThe description has been updated, here is the new result:\n");
        ShowInformation();
        int milliseconds = 3000;
        Thread.Sleep(milliseconds);
        Console.Clear();
        MenuDisplay();
    }

    public static void ShowInformation()
    {
        Console.WriteLine($"Show ID: {show.Id}");
        Console.WriteLine($"Date: {show.Date}");
        Console.WriteLine($"Time: {show.Time}");
        Console.WriteLine($"Film Title: {film.Name}");
        Console.WriteLine($"Film Description: {film.Description}");
        Console.WriteLine($"Film AgeLimit: {film.AgeLimit}");
        CurrentShow = $"Show ID: {show.Id} \nDate: {show.Date} \nTime: {show.Time} \nFilm Title: {film.Name} \nFilm Description: {film.Description} \nFilm Age Limit: {film.AgeLimit} \n-------------------------------";


    }

    public static void SearchByID()
    {
        Console.Clear();
        Console.WriteLine("Enter the ID of the show you want to view \n-------------------------------");
        int id = Convert.ToInt32(Console.ReadLine());
        show = showLogic.GetById(id);
        if (show == null)
        {
            Console.WriteLine("There is no show with this ID");
            int miliseconds = 2000;
            Thread.Sleep(miliseconds);
            Console.Clear();
            AdminFeatures.Start();
        }

    }
}


