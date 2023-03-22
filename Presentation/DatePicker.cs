static class DatePicker
{

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start()
    {
        Console.WriteLine("Type a date you want to see the shows from like: year-month-day");
        string date = Console.ReadLine();
        List<ShowModel> shows = ShowsAccess.LoadAll();
        //put this in the logic layer
        // get the films
        // add hours
        foreach (ShowModel show in shows)
        {
            if (show.Date == date)
            {
                FilmsLogic filmsLogic = new FilmsLogic();
                FilmModel film = filmsLogic.GetById(show.FilmId);
                Console.WriteLine($"Room: {show.RoomId}, Date: {show.Date}, Time: {show.Time}, Movie name: {film.Name}.");
            }
        }
        showChoose(shows, date);



        // else
        // {
        //     Console.WriteLine("Invalid input");
        //     Start();
        // }

    }
    public static void showChoose(List<ShowModel> shows, string date)
    {
        Console.WriteLine("To select the specific show you want to see the details of, or reserve seats for. Type (Room number + Time):");
        string movie = Console.ReadLine() + " " + date;
        string[] input = movie.Split(' ');
        Console.WriteLine(Convert.ToInt32(input[0]));
        Console.WriteLine(input[1]);
        ShowModel show = shows.Find(i => i.RoomId == Convert.ToInt32(input[0]) && i.Time == input[1]);
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