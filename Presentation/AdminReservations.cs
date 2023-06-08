public class AdminReservations
{
    private static List<string> _allChair = new List<string>();
    private static ChairModel _chair = new ChairModel(0, 0, 0, 0, null);
    public static ChairModel chair
    {
        get { return _chair; }
        set { _chair = value; }
    }
    private static ReservationModel _reservation = new ReservationModel(0, 0, 0, null, 0);
    public static ReservationModel reservation
    {
        get { return _reservation; }
        set { _reservation = value; }
    }
    private static string CurrentShow = "";
    public static ShowModel ListOfReservationsShow;
    public static ShowModel SeatShows;
    public static ChairModel SeatRanks;
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

    public static void Display()
    {


        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Reservations per show", ListOfShows));
        items.Add(new MenuItem("Occupied seats per show", OccupiedSeatsShow));
        items.Add(new MenuItem("Occupied seats per rank", OccupiedSeatsRank));
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
            MenuItem item = new MenuItem($"--------------------------------\nShow ID: {show.Id}\nRoom: {show.RoomId}\nFilm: {film1.Name}", ListOfReservations);
            item.show = show;
            item.ListOfReservations = true;
            items.Add(item);
        }
        MenuItem lastshow = items.Last();
        lastshow.DisplayText = lastshow.DisplayText + "\n--------------------------------\n";
        items.Add(new MenuItem("Back", AdminFeatures.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();

    }

    public static void ListOfReservations()
    {

        Console.Clear();
        var reservation = reservationLogic.GetByShowIdList(ListOfReservationsShow.Id);
        ChairLogic chairsLogic = new ChairLogic();
        foreach (var res in reservation)

        {
            List<int> reschair = res.Ressedchairs;
            foreach (var Wholechair in reschair)
            {
                chair = chairsLogic.GetById(Wholechair);
                string colInt = Convert.ToString(chair.Column);
                string chairs = colInt + "-" + chair.Row;
                _allChair.Add(chairs);
            }
            string y = string.Format("Chairs reserved: ({0}).", string.Join(", ", _allChair));
            Console.WriteLine($" Show ID: {res.Showid} \n Reservation ID: {res.Id} \nAccount: {res.Accountid} \nChairs: {y}");
        }
        int miliseconds = 2000;
        Thread.Sleep(miliseconds);
        Console.Clear();
        AdminFeatures.Start();

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
            MenuItem item = new MenuItem($"--------------------------------\nShow ID: {show.Id}\nRoom: {show.RoomId}\nFilm: {film1.Name}", SeatShow);
            item.show = show;
            item.SeatShow = true;
            items.Add(item);
        }
        MenuItem lastshow = items.Last();
        lastshow.DisplayText = lastshow.DisplayText + "\n--------------------------------\n";
        items.Add(new MenuItem("Back", AdminFeatures.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
        
    }

    public static void OccupiedSeatsRank()
    {
        Console.Clear();
        Console.WriteLine("These are all the current shows");
        List<ShowModel> shows = ShowsLogic.AllCurrentShows();
        List<MenuItem> items = new List<MenuItem>();
        foreach (ShowModel show in shows)
        {
            FilmsLogic filmlogic = new FilmsLogic();
            FilmModel film1 = filmlogic.GetById(show.FilmId);
            MenuItem item = new MenuItem($"--------------------------------\nShow ID: {show.Id}\nRoom: {show.RoomId}\nFilm: {film1.Name}", SeatRank);
            item.show = show;
            item.SeatRank = true;
            items.Add(item);
        }
        MenuItem lastshow = items.Last();
        lastshow.DisplayText = lastshow.DisplayText + "\n--------------------------------\n";
        items.Add(new MenuItem("Back", AdminFeatures.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }

    public static void SeatRank()
    {

        List<ReservationModel> Reservation = ReservationsLogic.AllReservation();
        int id = SeatShows.Id;
        int rank = SeatRanks.Rank;
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

    public static void SeatShow()
    {
        List<int> chairs = new List<int>();
        int id = SeatShows.Id;
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
