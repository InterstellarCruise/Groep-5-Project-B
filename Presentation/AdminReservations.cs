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
    }

    public static void SeatRank(int id, int rank)
    {

    }
}
