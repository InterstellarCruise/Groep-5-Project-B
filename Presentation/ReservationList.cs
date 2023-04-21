public class ReservationList
{
    // private static ShowModel _show = new ShowModel(0, 0, 0, null, null);
    // private static FilmModel _film = new FilmModel(0, null, null, 0, 0, null);
    // static ShowsLogic showLogic = new ShowsLogic();
    // static FilmsLogic filmLogic = new FilmsLogic();
    // public static ShowModel Show
    // {
    //     get { return _show; }
    //     set { _show = value; }
    // }
    // public static FilmModel film
    // {
    //     get { return _film; }
    //     set { _film = value; }
    // }
    static ReservationsLogic resLogic = new ReservationsLogic();
    private static TheReservationModel? _res { get; set; }
    public static void listReservations()
    {
        int id = AccountsLogic.CurrentAccount.Id;
        List<TheReservationModel> reservations = ReservationsLogic.ReservationsByAccount(id);
        ShowsLogic showsLogic = new ShowsLogic();
        FilmsLogic filmsLogic = new FilmsLogic();
        Console.WriteLine($"Reservations\n");
        foreach (TheReservationModel reservation in reservations)
        {
            ShowModel Show = showsLogic.GetById(reservation.Showid);
            FilmModel Film = filmsLogic.GetById(Show.FilmId);
            Console.WriteLine($"Reservation for {Film.Name} at {Show.Date}");
        }
    }
}

