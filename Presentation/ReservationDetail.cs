public class ReservationDetail
{
    private static List<string> _allChair = new List<string>();
    public static ReservationModel reservation { get; set; }
    private static ChairModel _chair = new ChairModel(0, 0, 0, 0, null);
    public static ChairModel chair
    {
        get { return _chair; }
        set { _chair = value; }
    }
    public static void detailReservation()
    {
        Console.Clear();
        int showid = reservation.Showid;
        ShowsLogic showsLogic = new ShowsLogic();
        FilmsLogic filmsLogic = new FilmsLogic();
        ChairLogic chairsLogic = new ChairLogic();
        ShowModel Show = showsLogic.GetById(reservation.Showid);
        FilmModel Film = filmsLogic.GetById(Show.FilmId);
        List<MenuItem> items = new List<MenuItem>();
        List<int> reschair = reservation.Ressedchairs;
        foreach (var Wholechair in reschair)
        {
            chair = chairsLogic.GetById(Wholechair);
            string colInt = Convert.ToString(chair.Column);
            string chairs = colInt + "-" + chair.Row;
            _allChair.Add(chairs);
            

        }
        string y = string.Format("Chairs reserved: ({0}).", string.Join(", ", _allChair));
        string x = string.Format("Genres of the movie: ({0}).", string.Join(", ", Film.Genre));
        string info = $"Reservation\n=============================================\nGeneral information:\nTotal cost: {reservation.Amount} EUR\n{y}\n=============================================\nInformation about the show:\nRoom number: {Show.RoomId}\nDate of the show: {Show.Date}\nTime of the show: {Show.Time}\n=============================================\nInformation about the movie:\nFilm name: {Film.Name}\nFilm description: {Film.Description}\nAge limit: {Film.AgeLimit}\nFilm length: {Film.Length}\n{x}\n";

        items.Add(new MenuItem(info, null));
        items.Add(new MenuItem("Cancel reservation", ConfirmCancel));
        items.Add(new MenuItem("Back", ReservationList.listReservations));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void ConfirmCancel()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Are you sure?", null));
        items.Add(new MenuItem("Yes", CancelReservation));
        items.Add(new MenuItem("No", detailReservation));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void CancelReservation()
    {
        Console.Clear();
        ReservationsLogic reslogic = new ReservationsLogic();
        reslogic.DeleteReservation(reservation);
        Console.WriteLine("Reservation successfully canceled");
        Thread.Sleep(3000);
        AccountPage.start();

    }
}

