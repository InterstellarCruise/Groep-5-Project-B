public class CheckOut
{
    private static List<int> _chairs = new List<int>();
    private static ShowModel? _show {  get; set; }
    public static void Start(List<ChairModel> chairs, double amount, ShowModel show)
    {
        Console.Clear();
        List<MenuItem> menuItems = new List<MenuItem>();
        _show = show;
        string selecchairs = "Current selected chairs:";
        foreach (ChairModel chair in chairs )
        {
            selecchairs = selecchairs + $" {ChairLogic.RowNumber(chair)}";
            _chairs.Add(chair.Id);
        }
        menuItems.Add(new MenuItem($"-------------------------\n{selecchairs}\n-------------------------\nTotal price: {amount} EUR\n-------------------------\n", null));
        menuItems.Add(new MenuItem("Check-out", checkout));
        menuItems.Add(new MenuItem("Back", Reservation.Main));
        menuItems.Add(new MenuItem("Main menu", Menu.Start));
        MenuBuilder menu = new MenuBuilder(menuItems);
        
        menu.DisplayMenu();
    }
    public static void checkout()
    {
        AccountModel acc = UserLogin.CurrentAccount;
        ReservationsLogic reservationlogic  = new ReservationsLogic();
        reservationlogic.AddReservation(_show.Id, acc.Id, _chairs);
        Console.WriteLine("Succesfully checked-out");
        Thread.Sleep(2000);
        Menu.Start();
    }
}
