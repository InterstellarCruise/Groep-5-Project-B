static class DatePicker
{
    static public void Start()
    {
        Console.WriteLine("Type a date you want to see the shows from like: year-month-day");
        string date = Console.ReadLine();
        List<ShowModel> shows = ShowsAccess.LoadAll();
        bool emptyOrNot = false;
        //Display every show thats from the given date.
        emptyOrNot = ShowsLogic.MoviesByDate(shows, date, emptyOrNot);

        //Check to see if theres any shows at that date or not.
        //if so to be able to choose a show otherwise ask for another date.
        if (emptyOrNot == true)
        {
            showChoose(shows, date);
        }
        else
        {
            Console.WriteLine("No movies for this date, please choose another date \n");
            Start();
        }
    }

    public static void showChoose(List<ShowModel> shows, string date)
    {
        Console.WriteLine("To select the specific show you want to see the details of, or reserve seats for. Type (Room number + Time):");
        string movie = Console.ReadLine() + " " + date;
        ShowModel show = ShowsLogic.ChooseShow(shows, movie);
        //Checks if show exists or not, if not ask again, if yes give specific data to the display page of that show/movie..
        if (show == null)
        {
            Console.WriteLine("At this room / time combination is no movie, try again.");
            showChoose(shows, date);
        }
        else
        {
            MoviePicker.Start(movie);
        }
    }
}