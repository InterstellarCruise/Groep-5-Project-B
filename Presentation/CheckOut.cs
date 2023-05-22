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
        reservationlogic.AddReservation(_show.Id, acc.Id, _chairs, _amount);
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
    
        ///try{
        string date = show.Date;
        string Time =show.Time;
        //}
        ///catch(NullReferenceException){
            //var date = "2023-03-15";
            //string Time = "11:00";
        //}
        ///if(date == null)
        //{
           // string date = "2023-03-15";
           // string Time = "11:00";
        //}

        int account_id = UserLogin.CurrentAccount.Id;
        List<ReservationModel> reservations = ReservationsAccess.LoadAll();
        List<BarModel> barreservations = BarAccess.LoadAll();
        int places = 40;
        int number = 1;
        foreach(BarModel l in barreservations)
        {   List<BarModel> barreservationss = BarAccess.LoadAll();
            if(l == null)
            {
                places = 40;
            }
            else{
            if(l.Start_Time!=null){
            IFormatProvider provider = CultureInfo.InvariantCulture;
            number = number + 1;
            DateTime current_time = DateTime.ParseExact(Time, "HH:mm",provider);
            DateTime time = DateTime.ParseExact(l.Start_Time, "HH:mm",provider);
            var hours = (current_time - time).TotalHours;
        
            var hourz = (time - current_time ).TotalHours;

            if(hours>=0 & hours<=2 | hourz >=0 & hourz<=2)
            {
                places = places - l.Amount;
            }
            }
            }
            
        }
        if(places>=1)
        {
            Console.WriteLine($"there are {places} left. you can make a bar reservation do you wish to make one y/n");
            string? answer = Console.ReadLine().ToLower();
            if(answer == "y" || answer == "yes")
            {
                var new_bar = new BarModel(number ,date ,account_id,Time,_chairs.Count());
                barLogic.UpdateList(new_bar);
                _answer = "yes";

            }
            else
            {
                _answer = "no";
            }
        
        }
        
    }
    
}

