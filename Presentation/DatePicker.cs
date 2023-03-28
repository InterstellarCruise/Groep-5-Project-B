static class DatePicker
{
    static public void Start()
    {
        Console.WriteLine("Date picker for shows.\n");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Type a date you want to see the shows from like: year-month-day");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Press 'B' to go to the homepage.");
        Console.WriteLine("--------------------------------");
        string date = Console.ReadLine();
        if (date.ToUpper() == "B")
        {
            Console.Clear();
            Menu.Start();
        }
        List<ShowModel> shows = ShowsAccess.LoadAll();
        bool emptyOrNot = false;
        //Display every show thats from the given date.
        Console.Clear();
        // Console.WriteLine($"Movies on the date: {date} \n");
        emptyOrNot = ShowsLogic.MoviesByDate(shows, date, emptyOrNot);
        Console.WriteLine("\n");
        //Check to see if theres any shows at that date or not.
        //if so to be able to choose a show otherwise ask for another date.
        if (emptyOrNot == true)
        {
            showChoose(shows, date, emptyOrNot);
        }
        else
        {
            Console.WriteLine("No movies for this date, please choose another date \n");
            int milliseconds = 1500;
            Thread.Sleep(milliseconds);
            Console.Clear();
            Start();
        }
    }

    public static void showChoose(List<ShowModel> shows, string date, bool emptyOrNot)
    {
        Console.Clear();
        Console.WriteLine($"Movies plaing on {date}\n");
        ShowsLogic.MoviesByDate(shows, date, emptyOrNot);
        Console.WriteLine("\nTo select the specific show you want to see the details of, or reserve seats for. Type (Room number + Time):");
        string movie = Console.ReadLine() + " " + date;
        ShowModel show = ShowsLogic.ChooseShow(shows, movie);

        //Checks if show exists or not, if not ask again, if yes give specific data to the display page of that show/movie..
        if (show == null)
        {
            Console.WriteLine("At this room / time combination is no movie, try again.");
            int milliseconds = 1500;
            Thread.Sleep(milliseconds);
            Console.Clear();
            Console.WriteLine($"Movies plaing on {date}\n");
            showChoose(shows, date, emptyOrNot);
        }
        else
        {
            MoviePicker.Start(movie);
        }

    }

}