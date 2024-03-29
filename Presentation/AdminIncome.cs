public static class AdminIncome
{
    static ShowsLogic showLogic = new ShowsLogic();
    static FilmsLogic filmLogic = new FilmsLogic();
    static ReservationsLogic reservationLogic = new ReservationsLogic();
    private static ReservationModel _reservation = new ReservationModel(0, 0, 0, null, 0);
    public static ReservationModel reservation
    {
        get { return _reservation; }
        set { _reservation = value; }
    }
    public static ShowModel IncomePerShows;
    public static ShowModel IncomeRanks;
    
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
    public static void Main()
    {
        Display();
    }

    public static void Display()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Income per show", ChooseShow));
        items.Add(new MenuItem("Income per rank", ChooseSR));
        items.Add(new MenuItem("Income per date", ChooseDate));
        items.Add(new MenuItem("Back", Menu.Start));
        items.Add(new MenuItem("Quit", Menu.Quit));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }

    public static void ShowInformation()
    {
        Console.WriteLine($"Show ID: {show.Id}");
        Console.WriteLine($"Room: {show.RoomId}");
        Console.WriteLine($"Film Title: {film.Name}");
        CurrentShow = $"Show ID: {show.Id} \nRoom: {show.RoomId} \nFilm Title: {film.Name} \n-------------------------------";


    }
    public static void ChooseShow()
    {
       
        Console.Clear();
        Console.WriteLine("These are all the current shows");
        ShowsLogic showslogic = new ShowsLogic();
        List<ShowModel> shows = ShowsLogic.AllCurrentShows();
        List<MenuItem> items = new List<MenuItem>();
        foreach (ShowModel show in shows)
        {
            FilmsLogic filmlogic = new FilmsLogic();
            FilmModel film1 = filmlogic.GetById(show.FilmId);
            MenuItem item = new MenuItem($"--------------------------------\nShow ID: {show.Id}\nRoom: {show.RoomId}\nFilm: {film1.Name}", IncomePerShow);
            item.show = show;
            item.IncomePerShow = true;
            items.Add(item);
        }
        MenuItem lastshow = items.Last();
        lastshow.DisplayText = lastshow.DisplayText + "\n--------------------------------\n";
        items.Add(new MenuItem("Back", AdminFeatures.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();

    }

    public static void IncomePerShow()
    {   
        int id = IncomePerShows.Id;
        show = showLogic.GetById(id);
        reservation = reservationLogic.FindByShowId(show.Id);
        if (reservation != null)
        {
            double total = ReservationsLogic.IncomeShow(reservation.Id);
            Console.WriteLine($"The total income of this show is {total} EUR");
        }
        else Console.WriteLine("The total income of this show is 0 EUR");

        int miliseconds = 2000;
        Thread.Sleep(miliseconds);
        Console.Clear();
        AdminFeatures.Start();

    }

    public static void ChooseSR()
    {
        Console.Clear();
        Console.WriteLine("These are all the current shows");
        ShowsLogic showslogic = new ShowsLogic();
        List<ShowModel> shows = ShowsLogic.AllCurrentShows();
        List<MenuItem> items = new List<MenuItem>();
        foreach (ShowModel show in shows)
        {
            FilmsLogic filmlogic = new FilmsLogic();
            FilmModel film1 = filmlogic.GetById(show.FilmId);
            MenuItem item = new MenuItem($"--------------------------------\nShow ID: {show.Id}\nRoom: {show.RoomId}\nFilm: {film1.Name}", IncomePerRank);
            item.show = show;
            item.IncomePerRank = true;
            items.Add(item);
        }
        MenuItem lastshow = items.Last();
        lastshow.DisplayText = lastshow.DisplayText + "\n--------------------------------\n";
        items.Add(new MenuItem("Back", AdminFeatures.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }

    public static void IncomePerRank()
    {
        int id = IncomeRanks.Id;
        Console.WriteLine("Please choose a rank between 1 and 3");
        int rank = Convert.ToInt32(Console.ReadLine());
        if(rank < 1 || rank > 3)
        {
            Console.WriteLine("This is not a rank, please choose between 1 and 3");
            IncomePerRank();
        }
        show = showLogic.GetById(id);
        reservation = reservationLogic.FindByShowId(show.Id);
        if (reservation != null)
        {
            double total = ReservationsLogic.IncomeRank(reservation.Id, rank);
            Console.WriteLine($"The total income of this rank is {total} EUR");
        }
        else Console.WriteLine("The total income of this rank is 0 EUR");
        int miliseconds = 2000;
        Thread.Sleep(miliseconds);
        Console.Clear();
        AdminFeatures.Start();
    }

    public static void ChooseDate()
    {
        Console.WriteLine("Choose a date");
        double totalAmount = 0;
        string date = Console.ReadLine();
        ShowsLogic showslogic = new ShowsLogic();
        ReservationsLogic reslogic = new ReservationsLogic();
        List<ShowModel> Shows = ShowsLogic.AllCurrentShows();
        if (showLogic.ValidShowDate(date) == false)
        {
            Console.WriteLine("This is an invalid date, please fill in a date in the format of year-month-day");
            ChooseDate();
        }
        else
        {
            foreach (ShowModel show in Shows)
            {
                if (date.Equals(show.Date) == true)
                {

                    List<ReservationModel> Reservation = ReservationsLogic.AllReservation();
                    foreach (ReservationModel res in Reservation)
                    {

                        var id = reservationLogic.GetById(res.Id);
                        double amount = id.Amount;
                        totalAmount += amount;

                    }
                    Console.WriteLine($"The total income of this date is {totalAmount} EUR");
                    int miliseconds = 2000;
                    Thread.Sleep(miliseconds);
                    Console.Clear();
                    AdminFeatures.Start();

                }
                else
                {
                    Console.WriteLine("No shows found with this date");
                    int miliseconds = 2000;
                    Thread.Sleep(miliseconds);
                    Console.Clear();
                    AdminFeatures.Start();

                }

            }
        }

    }
}