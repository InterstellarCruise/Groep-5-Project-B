public static class ChangeShows
{

    static ShowsLogic showLogic = new ShowsLogic();
    static FilmsLogic filmLogic = new FilmsLogic();
    public static void Start()
    {

        ShowModel show = SearchByID();
        if (show != null)
        {
            FilmModel film = filmLogic.GetById(show.Id);
            ShowInformation(show, film);
            Console.WriteLine("What do you want to edit about the show?");
            Console.WriteLine("[1]: Date\n-----------------------------");
            Console.WriteLine("[2]: Time\n-----------------------------");
            Console.WriteLine("[3]: Title\n-----------------------------");
            Console.WriteLine("[4]: Description\n-----------------------------");
            Console.WriteLine("[5]: Age Limit\n-----------------------------");
            Console.WriteLine("[6]: Go back\n-----------------------------");
            int ans = Convert.ToInt32(Console.ReadLine());
            if (ans == 1)
            {
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                EditDate(show);

            }
            else if (ans == 2)
            {
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                EditTTime(show);

            }
            else if (ans == 3)
            {
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                EditTitle(film);

            }
            else if (ans == 4)
            {
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                EditDescription(film);

            }
            else if (ans == 5)
            {
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                EditAgeLimit(film);

            }
            else if (ans == 6)
            {
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                Menu.Start();

            }
            else
            {
                Console.WriteLine("Wrong input");
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                Start();
            }

        }
        else
        {
            Console.WriteLine("No show found with this ID");
            Menu.Start();
        }
    }

    public static void EditTitle(FilmModel film)
    {
        Console.WriteLine("Enter a new title");
        string title = Console.ReadLine();
        film.Name = title;
        filmLogic.UpdateList(film);
        ShowModel show = showLogic.GetById(film.Id);
        Console.WriteLine("\nThe title has been updated, here is the result:\n");
        ShowInformation(show, film);
        int milliseconds = 3000;
        Thread.Sleep(milliseconds);
        Console.Clear();
        Menu.Start();
    }

    public static void EditDate(ShowModel show)
    {
        Console.WriteLine("Enter a new date (Format: year-month-day)");
        string date = Console.ReadLine();
        show.Date = date;
        showLogic.UpdateList(show);
        FilmModel film = filmLogic.GetById(show.Id);
        Console.WriteLine("\nThe date has been updated, here is the new result:\n");
        ShowInformation(show, film);
        int milliseconds = 3000;
        Thread.Sleep(milliseconds);
        Console.Clear();
        Menu.Start();
    }

    public static void EditTTime(ShowModel show)
    {
        Console.WriteLine("Enter a new time (Format: hour:minute)");
        string time = Console.ReadLine();
        show.Time = time;
        showLogic.UpdateList(show);
        FilmModel film = filmLogic.GetById(show.Id);
        Console.WriteLine("\nThe time has been updated, here is the new result:\n");
        ShowInformation(show, film);
        int milliseconds = 3000;
        Thread.Sleep(milliseconds);
        Console.Clear();
        Menu.Start();
    }

    public static void EditAgeLimit(FilmModel film)
    {
        Console.WriteLine("Enter a new age limit");
        int ageLimit = Convert.ToInt32(Console.ReadLine());
        film.AgeLimit = ageLimit;
        filmLogic.UpdateList(film);
        ShowModel show = showLogic.GetById(film.Id);
        Console.WriteLine("\nThe age limit has been updated, here is the new result:\n");
        ShowInformation(show, film);
        int milliseconds = 3000;
        Thread.Sleep(milliseconds);
        Console.Clear();
        Menu.Start();
    }


    public static void EditDescription(FilmModel film)
    {
        Console.WriteLine("\nEnter a new descrption\n");
        string descrption = Console.ReadLine();
        film.Description = descrption;
        filmLogic.UpdateList(film);
        ShowModel show = showLogic.GetById(film.Id);
        Console.WriteLine("\nThe description has been updated, here is the new result:\n");
        ShowInformation(show, film);
        int milliseconds = 3000;
        Thread.Sleep(milliseconds);
        Console.Clear();
        Menu.Start();
    }

    public static void ShowInformation(ShowModel show, FilmModel film)
    {
        Console.WriteLine($"Show ID: {show.Id}");
        Console.WriteLine($"Date: {show.Date}");
        Console.WriteLine($"Time: {show.Time}");
        Console.WriteLine($"Film Title: {film.Name}");
        Console.WriteLine($"Film Description: {film.Description}");
        Console.WriteLine($"Film AgeLimit: {film.AgeLimit}");

    }

    public static ShowModel SearchByID()
    {
        Console.WriteLine("Enter the ID of the show you want to view");
        int id = Convert.ToInt32(Console.ReadLine());
        ShowModel show = showLogic.GetById(id);
        if (show == null)
        {
            Console.WriteLine("There is no show with this ID");
        }
        return show;
    }


}


