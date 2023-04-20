public class ReservationList
{
    private static ShowModel _show = new ShowModel(0, 0, 0, null, null);
    private static FilmModel _film = new FilmModel(0, null, null, 0, 0, null);
    static ShowsLogic showLogic = new ShowsLogic();
    static FilmsLogic filmLogic = new FilmsLogic();
    public static ShowModel Show
    {
        get { return _show; }
        set { _show = value; }
    }
    public static FilmModel film
    {
        get { return _film; }
        set { _film = value; }
    }
    static ReservationsLogic resLogic = new ReservationsLogic();
    private static TheReservationModel? _res { get; set; }
    public static void listReservations()
    {
        Console.Clear();
        // Console.CursorVisible = false;
        Console.WriteLine($"Reservations\n");
        int id = AccountsLogic.CurrentAccount.Id;
        Console.WriteLine(id);
        ReservationsLogic.AllCurrentRes(id);
        _res = resLogic.GetById(id);
        Show = showLogic.GetById(_res.Showid);
        film = filmLogic.GetById(Show.FilmId);
 
        

    }
}

