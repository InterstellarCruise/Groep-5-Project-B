public static class ChangeShows
{

    static ShowsLogic showLogic = new ShowsLogic();
    static FilmsLogic filmLogic = new FilmsLogic();
    private static ShowModel _show = new ShowModel(0, 0, 0, null, null);
    private static FilmModel _film = new FilmModel(0, null, null, 0, 0, null);
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
            film = filmLogic.GetById(show.FilmId);
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
        if (showLogic.ValidShowDate(date) == false)
        {
            Console.WriteLine("This is an invalid date, please fill in a date in the format of year-month-day");
            EditDate();
        }
        else
        {
            showLogic.UpdateList(show);
            film = filmLogic.GetById(show.Id);
            Console.WriteLine("\nThe date has been updated, here is the new result:\n");
            ShowInformation();
            int milliseconds = 3000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            MenuDisplay();
        }
    }

    public static void EditTTime()
    {
        Console.WriteLine("\n-------------------------------\nEnter a new time (Format: hour:minute)");
        string time = Console.ReadLine();
        if (showLogic.ValidShowTime(time) == false)
        {
            Console.WriteLine("This is an invalid time, please put a time in anywhere between 00:00 and 23:59");
            EditTTime();
        }
        else
        {
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
            show = showLogic.GetById(film.Id);
            Console.WriteLine("\nThe age limit has been updated, here is the new result:\n");
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
        // Console.Clear();
        // Console.WriteLine("These are all the current shows");
        // List<ShowModel> shows = ShowsLogic.AllCurrentShows();
        // List<MenuItem> items = new List<MenuItem>();
        // foreach (ShowModel show in shows)
        // {
        //     FilmsLogic filmlogic = new FilmsLogic();
        //     FilmModel film1 = filmlogic.GetById(show.FilmId);
        //     MenuItem item = new MenuItem($"--------------------------------\nShow ID: {show.Id}\nRoom: {show.RoomId}\nFilm: {film1.Name}", MenuDisplay);
        //     item.show = show;
        //     item.changeshow = true;
        //     items.Add(item);
        // }
        // MenuItem lastshow = items.Last();
        // lastshow.DisplayText = lastshow.DisplayText + "\n--------------------------------\n";
        // items.Add(new MenuItem("Back", Start));
        // MenuBuilder menu = new MenuBuilder(items);
        // menu.DisplayMenu();

    }
}


