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
    public static ShowModel SeatRanks;
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
        ShowsLogic showlogic = new ShowsLogic();
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
        ShowsLogic showslogic = new ShowsLogic();
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
        ShowsLogic showslogic = new ShowsLogic();
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
        int id = SeatRanks.Id;
        ShowsLogic showsLogic = new ShowsLogic();
        ShowModel currentshow = showsLogic.GetById(id);
        int optionsperline = 0;
        int curpos = 0;
        int roomid = currentshow.RoomId;
        switch (roomid)
        {
            case 1:
                curpos = 2;
                optionsperline = 12;
                break;
            case 2:
                curpos = 1;
                optionsperline = 18;
                break;
            case 3:
                curpos = 5;
                optionsperline = 30;
                break;
        }


        ChairLogic chairlogic = new ChairLogic();
        List<ChairModel> options = chairlogic.GetByRoomId(currentshow.RoomId);
        Reservation.CurrentShow = currentshow;
        List<ChairModel> ressedchairs = Reservation.GetReservations(currentshow.RoomId);
        foreach (ChairModel chair in options)
        {
            foreach (ChairModel ressedchair in ressedchairs)
            {
                if (ChairLogic.RowNumber(ressedchair) == ChairLogic.RowNumber(chair))
                {
                    chair.Available = false;
                }

            }
        }
        Console.Clear();
        RoomMap(options, curpos, optionsperline);
        Console.WriteLine("What rank would you want to see?");
        int rank = Convert.ToInt32(Console.ReadLine());
        if(rank < 1 || rank > 3)
        {
            Console.WriteLine("This is not a rank, please choose between 1 and 3");
            SeatRank();
        }
        int rankChairs = ChairLogic.OccupiedSeats(id, rank);
        Console.WriteLine($"The amount of seats occupied in this rank is {rankChairs}");
        int miliseconds = 2000;
        Thread.Sleep(miliseconds);
        Console.Clear();
        AdminFeatures.Start();
    }

    public static void SeatShow()
    {
        int id = SeatShows.Id;
        List<int> chairs = new List<int>();
        List<ReservationModel> Reservationmodel = ReservationsAccess.LoadAll();
        foreach (ReservationModel res in Reservationmodel)
        {
            if (id == res.Showid)
            {
                List<int> reservedchairs = res.Ressedchairs;
                foreach (int chairid in reservedchairs)
                {
                    chairs.Add(chairid);
                }
            }
        }
        ShowsLogic showsLogic = new ShowsLogic();
        ShowModel currentshow = showLogic.GetById(id);
        int optionsperline = 0;
        int curpos = 0;
        int roomid = currentshow.RoomId;
        switch (roomid)
        {
            case 1:
                curpos = 2;
                optionsperline = 12;
                break;
            case 2:
                curpos = 1;
                optionsperline = 18;
                break;
            case 3:
                curpos = 5;
                optionsperline = 30;
                break;
        }


        ChairLogic chairlogic = new ChairLogic();
        List<ChairModel> options = chairlogic.GetByRoomId(currentshow.RoomId);
        Reservation.CurrentShow = currentshow;
        List<ChairModel> ressedchairs = Reservation.GetReservations(currentshow.RoomId);
        foreach (ChairModel chair in options)
        {
            foreach (ChairModel ressedchair in ressedchairs)
            {
                if (ChairLogic.RowNumber(ressedchair) == ChairLogic.RowNumber(chair))
                {
                    chair.Available = false;
                }

            }
        }
        Console.Clear();
        RoomMap(options, curpos, optionsperline);
        Console.WriteLine($"The amount of seats occupied in this show is {chairs.Count}");
        int miliseconds = 5000;
        Thread.Sleep(miliseconds);
        Console.Clear();
        AdminFeatures.Start();
    }

    public static void RoomMap(List<ChairModel> options, int curpos, int optionsperline)
    {
        Console.SetCursorPosition(0, 0);
        const int startX = 5;
        const int startY = 0;
        int optionsPerLine = optionsperline;
        const int spacingPerLine = 4;

        int currentSelection = curpos;
        for (int i = 0; i < options.Count; i++)
        {
            Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

            if (i == currentSelection)
            {
                if (options[i].Rank == 1)
                    Console.ForegroundColor = ConsoleColor.Magenta;
                else if (options[i].Rank == 2)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (options[i].Rank == 3)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                if (!options[i].Available)
                {

                    if (options[i].takeseat)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                }
            }
            else
            {
                if (options[i].Rank == 1)
                    Console.ForegroundColor = ConsoleColor.Magenta;
                else if (options[i].Rank == 2)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (options[i].Rank == 3)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                if (!options[i].Available)
                {

                    if (options[i].takeseat)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                }
            }

            Console.WriteLine(ChairLogic.RowNumber(options[i]));

            Console.ResetColor();
        }
        Console.WriteLine();
    }
}
