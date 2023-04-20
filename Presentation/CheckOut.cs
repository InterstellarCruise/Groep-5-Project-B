﻿public class CheckOut
{
    private static List<int> _chairs = new List<int>();
    static ShowsLogic showLogic = new ShowsLogic();
    static FilmsLogic filmLogic = new FilmsLogic();
    private static FilmModel _film = new FilmModel(0, null, null, 0, 0, null);
    private static string CurrentFilm = "";
    private static double _amount {get; set;}
    private static string _selecchairs {get; set;}
    public static FilmModel film
    {
        get { return _film; }
        set { _film = value; }
    }

    private static int _movieId;
    public static int MovieId
    {
        get { return _movieId; }
        set { _movieId = value; }
    }
    private static ShowModel? _show {  get; set; }
    public static bool BackMenu = false;

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
        menuItems.Add(new MenuItem($"-------------------------\n{selecchairs}\n-------------------------\nTotal price: {amount} EUR\n-------------------------", null));
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
        Bar.barplace(acc.Id,_show.Date,_show.Time);
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
