public class CheckOut
{
    private static List<int> _chairs = new List<int>();
    static FilmsLogic filmLogic = new FilmsLogic();
    private static ShowModel? _show {  get; set; }
    public static bool BackMenu = false;
    private static double _amount {get; set;}
    private static string _selecchairs {get; set;}
    public static void Start(List<ChairModel> chairs, double amount, ShowModel show)
    {
        Console.Clear();
        List<MenuItem> menuItems = new List<MenuItem>();
        _show = show;
        _amount = amount;
        string selecchairs = "Current selected chairs:";
        foreach (ChairModel chair in chairs )
        {
            selecchairs = selecchairs + $" {ChairLogic.RowNumber(chair)}";
            _chairs.Add(chair.Id);
        }
        menuItems.Add(new MenuItem($"-------------------------\n{selecchairs}\n-------------------------\nTotal price: {amount} EUR\n-------------------------\n", null));
        menuItems.Add(new MenuItem("Check-out", checkout));
        menuItems.Add(new MenuItem("Back", Reservation.Main));
        menuItems.Add(new MenuItem("Main menu", BackToMenu));
        MenuBuilder menu = new MenuBuilder(menuItems);
        
        menu.DisplayMenu();
        selecchairs = "Current selected chairs:";
    }
    public static void checkout()
    {
        AccountModel acc = UserLogin.CurrentAccount;
        ReservationsLogic reservationlogic  = new ReservationsLogic();
        film = filmLogic.GetById(_show.FilmId);
        reservationlogic.AddReservation(_show.Id, acc.Id, _chairs, _amount);
        Console.WriteLine("Transaction Receipt from Shinema");
        Console.WriteLine("------------------------------");
        Console.WriteLine($"Movie: {film.Name}");
        Console.WriteLine($"Number of Chairs: {_selecchairs} ");
        Console.WriteLine($"Room: {_show.RoomId}");
        Console.WriteLine($"Total: {_amount} EUR");
        Console.WriteLine("------------------------------");
        Console.WriteLine("Thank you for choosing " + "Shinema"+ "!");
        Thread.Sleep(2000);
        Menu.Start();
    }
    public static void BackToMenu()
    {
        BackMenu = true;
        Menu.Start();
    }
}
