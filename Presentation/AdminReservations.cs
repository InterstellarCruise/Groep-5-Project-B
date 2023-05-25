public class AdminReservations
{
    private static ReservationModel _reservation = new ReservationModel(0, 0, 0, null, 0);
    public static ReservationModel reservation
    {
        get { return _reservation; }
        set { _reservation = value; }
    }

    static ShowsLogic showLogic = new ShowsLogic();
    static ReservationsLogic reservationLogic = new ReservationsLogic();
    private static ShowModel _show = new ShowModel(0, 0, 0, null, null);
    public static ShowModel show
    {
        get { return _show; }
        set { _show = value; }
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
    public static void ListOfShows()
    {
        Console.WriteLine("These are all the current shows");
        ShowsLogic.AllCurrShows();
        Console.WriteLine("Enter the ID of the show you want to view \n-------------------------------");
        int id = Convert.ToInt32(Console.ReadLine());
        show = showLogic.GetById(id);
        if (show == null)
        {
            Console.WriteLine("There is no film with this ID");
            int miliseconds = 2000;
            Thread.Sleep(miliseconds);
            Console.Clear();
            AdminFeatures.Start();
        }
        ListOfReservations(id);
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
        Console.WriteLine("These are all the current shows");
        ShowsLogic.AllCurrShows();
        Console.WriteLine("Enter the ID of the show you want to view \n-------------------------------");
        int id = Convert.ToInt32(Console.ReadLine());
        show = showLogic.GetById(id);
        if (show == null)
        {
            Console.WriteLine("There is no film with this ID");
            int miliseconds = 2000;
            Thread.Sleep(miliseconds);
            Console.Clear();
            AdminFeatures.Start();
        }
        SeatShow(id);
    }

    public static void OccupiedSeatsRank()
    {
        Console.WriteLine("These are all the current shows");
        ShowsLogic.AllCurrShows();
        Console.WriteLine("Enter the ID of the show you want to view \n-------------------------------");
        int id = Convert.ToInt32(Console.ReadLine());
        show = showLogic.GetById(id);
        Console.WriteLine("Please enter a rank you want to see(1-3)");
        int rank = Convert.ToInt32(Console.ReadLine());
        if (show == null)
        {
            Console.WriteLine("There is no film with this ID");
            int miliseconds = 2000;
            Thread.Sleep(miliseconds);
            Console.Clear();
            AdminFeatures.Start();
        }
        SeatRank(id, rank);
    }

    public static void SeatRank(int id, int rank)
    {
        List<ReservationModel> Reservation = ReservationsAccess.LoadAll();
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
        List<ChairModel> options = chairlogic.GetByRoomId(id);
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        const int startX = 5;
        const int startY = 10;
        int optionsPerLine = optionsperline;
        const int spacingPerLine = 4;
        int origRow = Console.CursorTop;
        int origCol = Console.CursorLeft;

        int currentSelection = curpos;
        for (int i = 0; i < options.Count; i++)
        {
            Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

            if (i == currentSelection)
            {

                if (!options[currentSelection].Available)
                {

                    if (options[currentSelection].takeseat)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
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

            Console.Write(ChairLogic.RowNumber(options[i]));

            Console.ResetColor();
            
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
        List<ReservationModel> Reservation = ReservationsAccess.LoadAll();
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
