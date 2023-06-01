public class AdminReservations
{
    private static ReservationModel _reservation = new ReservationModel(0, 0, 0, null, 0);
    public static ReservationModel reservation
    {
        get { return _reservation; }
        set { _reservation = value; }
    }
    private static string CurrentShow = "";
    static FilmsLogic filmLogic = new FilmsLogic();
    private static FilmModel _film = new FilmModel(0, null, null, 0, 0, null);

    static ShowsLogic showLogic = new ShowsLogic();
    static ReservationsLogic reservationLogic = new ReservationsLogic();
    private static ShowModel _show = new ShowModel(0, 0, 0, null, null);
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
        ListOfShows();
        Display();
    }
    public static void Display()
    {
        if (show != null)
        {
            film = filmLogic.GetById(show.FilmId);
            // ShowInformation();

            List<MenuItem> items = new List<MenuItem>();
            items.Add(new MenuItem(CurrentShow, null));
            items.Add(new MenuItem("Reservations per show", ListOfShows));
            items.Add(new MenuItem("Occupied seats per show", OccupiedSeatsShow));
            // items.Add(new MenuItem("Occupied seats per rank", OccupiedSeatsRank));
            items.Add(new MenuItem("Back", Menu.Start));
            items.Add(new MenuItem("Quit", Menu.Quit));
            MenuBuilder menu = new MenuBuilder(items);
            menu.DisplayMenu();
        }
    }

    public static void ShowInformation()
    {
        Console.WriteLine($"Show ID: {show.Id}");
        Console.WriteLine($"Room: {show.RoomId}");
        Console.WriteLine($"Film Title: {film.Name}");
        CurrentShow = $"Show ID: {show.Id} \nRoom: {show.RoomId} \nFilm Title: {film.Name} \n-------------------------------";


    }
    public static void ListOfShows()
    {
        Console.Clear();
        Console.WriteLine("These are all the current shows");
        List<ShowModel> shows = ShowsLogic.AllCurrentShows();
        List<MenuItem> items = new List<MenuItem>();
        foreach (ShowModel show in shows)
        {
            FilmsLogic filmlogic = new FilmsLogic();
            FilmModel film1 = filmlogic.GetById(show.FilmId);
            MenuItem item = new MenuItem($"--------------------------------\nShow ID: {show.Id}\nRoom: {show.RoomId}\nFilm: {film1.Name}", Display);
            item.show = show;
            item.changeshow = true;
            items.Add(item);
        }
        MenuItem lastshow = items.Last();
        lastshow.DisplayText = lastshow.DisplayText + "\n--------------------------------\n";
        items.Add(new MenuItem("Back", AdminFeatures.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }

    public static void ListOfReservations(int id)
    {
        if (show != null)
        {
            show = showLogic.GetById(id);
            reservation = reservationLogic.GetByShowId(show.Id);
            Console.WriteLine($"{reservation.Showid}, {reservation.Id}");

        }
    }

    public static void OccupiedSeatsShow()
    {
        Console.Clear();
        Console.WriteLine("These are all the current shows");
        List<ShowModel> shows = ShowsLogic.AllCurrentShows();
        List<MenuItem> items = new List<MenuItem>();
        foreach (ShowModel show in shows)
        {
            FilmsLogic filmlogic = new FilmsLogic();
            FilmModel film1 = filmlogic.GetById(show.FilmId);
            MenuItem item = new MenuItem($"--------------------------------\nShow ID: {show.Id}\nRoom: {show.RoomId}\nFilm: {film1.Name}", Display);
            item.show = show;
            item.changeshow = true;
            items.Add(item);
        }
        MenuItem lastshow = items.Last();
        lastshow.DisplayText = lastshow.DisplayText + "\n--------------------------------\n";
        items.Add(new MenuItem("Back", AdminFeatures.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
        SeatShow(show.Id);
    }

    // public static void OccupiedSeatsRank()
    // {
    //     Console.WriteLine("These are all the current shows");
    //     ShowsLogic.AllCurrShows();
    //     Console.WriteLine("Enter the ID of the show you want to view \n-------------------------------");
    //     int id = Convert.ToInt32(Console.ReadLine());
    //     show = showLogic.GetById(id);
    //     Console.WriteLine("Please enter a rank you want to see(1-3)");
    //     int rank = Convert.ToInt32(Console.ReadLine());
    //     if (show == null)
    //     {
    //         Console.WriteLine("There is no film with this ID");
    //         int miliseconds = 2000;
    //         Thread.Sleep(miliseconds);
    //         Console.Clear();
    //         AdminFeatures.Start();
    //     }
    //     SeatRank(id, rank);
    // }

    public static void SeatRank(int id, int rank)
    {
        
        List<ReservationModel> Reservation = ReservationsLogic.AllReservation();
        List<int> chairs = new List<int>();
        List<int> rankChair = new List<int>();
        foreach (ReservationModel res in Reservation)
        {
            if (id == res.Showid)
            {
                chairs = res.Ressedchairs;
                ChairLogic chairLogic = new ChairLogic();
                foreach (var chairid in chairs)
                {
                    var chair = chairLogic.GetById(chairid);

                    if (chair.Rank == rank)
                    {
                        if (rank == 1)
                        {
                            rankChair.Add(chair.Id);
                        }
                        if (rank == 2)
                        {

                            rankChair.Add(chair.Id);

                        }
                        if (rank == 3)
                        {
                            rankChair.Add(chair.Id);

                        }
                    }
                }

            }
        }
        Console.WriteLine($"The amount of seats occupied in this rank is {rankChair.Count}");
        int miliseconds = 2000;
        Thread.Sleep(miliseconds);
        Console.Clear();
        AdminFeatures.Start();
    }

    public static void SeatShow(int id)
    {
        List<int> chairs = new List<int>();
        List<ReservationModel> Reservation = ReservationsLogic.AllReservation();
        foreach (ReservationModel res in Reservation)
        {
            if (id == res.Showid)
            {
                chairs = res.Ressedchairs;
            }
        }
        Console.WriteLine($"The amount of seats occupied in this show is {chairs.Count}");
        int miliseconds = 2000;
        Thread.Sleep(miliseconds);
        Console.Clear();
        AdminFeatures.Start();
    }
}
