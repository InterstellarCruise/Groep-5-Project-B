using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
public class CheckOut
{
    static BarLogic barLogic = new BarLogic();
    public static string _answer = "no";
    public static string Time{get;set;}
    public static string date{get;set;}
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

    public static ShowModel? show = _show;
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
        var allres = ReservationsLogic.AllReservation();
        ReservationModel newRes = new(allres.Count + 1, _show.Id, acc.Id, _chairs, _amount);
        reservationlogic.UpdateList(newRes);
        barplace(_show);
        Console.WriteLine("Transaction Receipt from Shinema");
        Console.WriteLine("------------------------------");
        Console.WriteLine($"Movie: {film.Name}");
        Console.WriteLine($"Number of Chairs: {_chairs.Count()} ");
        Console.WriteLine($"Room: {_show.RoomId}");
        Console.WriteLine($"Total: {_amount} EUR");
        Console.WriteLine($"barseat(s) {_answer}");
        Console.WriteLine("------------------------------");
        Console.WriteLine("Thank you for choosing " + "Shinema"+ "!");
        Thread.Sleep(4000);
        BackToMenu();
    }
    public static void BackToMenu()
    {
        BackMenu = true;
        Menu.Start();
    }

    static public void barplace(ShowModel show)
    {

        string date = show.Date;
        string Time =show.Time;
        var len = filmLogic.GetById(show.FilmId);
        var places = barLogic.timecheck(Time,date,len.Length);
        if(places>=_chairs.Count())
        {
            Console.WriteLine($"there are {places} left. you can make a bar reservation do you wish to make one y/n");
            string? answer = Console.ReadLine().ToLower();
            if(answer == "y" || answer == "yes")
            {
                
                barLogic.UpdateList(date,Time,_chairs.Count());
                _answer = "yes";

            }
        }
        else
            {
                Console.WriteLine("there are not enough seats at the bar to ccomodate you're party.");
                Thread.Sleep(3000);
                _answer = "no";
            }
        
        
        
    }
    
}

