public class ReservationDetail
{
    public static TheReservationModel reservation { get; set; }
    public static void detailReservation()
    {
        Console.Clear();
        int showid = reservation.Showid;
        ShowsLogic showsLogic = new ShowsLogic();
        FilmsLogic filmsLogic = new FilmsLogic();
        ShowModel Show = showsLogic.GetById(reservation.Showid);
        FilmModel Film = filmsLogic.GetById(Show.FilmId);
<<<<<<< HEAD
        // <<<<<<< HEAD
=======
>>>>>>> d12acdfada01a4c49e2386a63f5078afed564422
        List<MenuItem> items = new List<MenuItem>();
        string chairs = string.Format("Chairs reserved: ({0}).", string.Join(", ", reservation.Ressedchairs));
        string x = string.Format("Genres of the movie: ({0}).", string.Join(", ", Film.Genre));
        string info = $"Reservation\n=============================================\nGeneral information:\nTotal cost: {{reservation.Amount}} EUR\n{chairs}\n=============================================\nInformation about the show:\nRoom number: {Show.RoomId}\nDate of the show: {Show.Date}\nTime of the show: {Show.Time}\n=============================================\nInformation about the movie:\nFilm name: {Film.Name}\nFilm description: {Film.Description}\nAge limit: {Film.AgeLimit}\nFilm length: {Film.Length}\n{x}\n";
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
<<<<<<< HEAD
        // =======

        //         Console.WriteLine($"Reservation");
        //         Console.WriteLine("=============================================");
        //         Console.WriteLine($"General information:");
        //         Console.WriteLine("\n");
        //         Console.WriteLine($"Total cost: {reservation.Amount} EUR");
        //         Console.WriteLine(string.Format("Chairs reserved: ({0})", string.Join(", ", reservation.Ressedchairs)));
        //         Console.WriteLine('\n');
        //         // Console.WriteLine($"Chairs reserved:");
        //         // foreach (int i in reservation.Ressedchairs)
        //         Console.WriteLine("=============================================");
        //         Console.WriteLine("Information about the show:");
        //         Console.WriteLine("\n");
        //         Console.WriteLine($"Room number: {Show.RoomId}");
        //         Console.WriteLine($"Date of the show: {Show.Date}");
        //         Console.WriteLine($"Time of the show: {Show.Time}");
        //         Console.WriteLine('\n');
        //         Console.WriteLine("=============================================");
        //         Console.WriteLine("Information about the movie:");
        //         Console.WriteLine($"\n");
        //         Console.WriteLine($"Film name: {Film.Name}");
        //         Console.WriteLine($"Film description: {Film.Description}");
        //         Console.WriteLine($"Age limit: {Film.AgeLimit}");
        //         Console.WriteLine($"Film length: {Film.Length}");
        //         Console.WriteLine(string.Format("Genres of the movie: ({0})", string.Join(", ", Film.Genre)));

        // >>>>>>> Roomavailable
=======
>>>>>>> d12acdfada01a4c49e2386a63f5078afed564422
    }
}

