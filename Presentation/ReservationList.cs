public class ReservationList
{
    public static void listReservations()
    {
        Console.Clear();
        int id = AccountsLogic.CurrentAccount.Id;
        List<TheReservationModel> reservations = ReservationsLogic.ReservationsByAccount(id);
        ShowsLogic showsLogic = new ShowsLogic();
        FilmsLogic filmsLogic = new FilmsLogic();
        Console.WriteLine($"Reservations\n");
        Console.WriteLine("=============================================");
        foreach (TheReservationModel reservation in reservations)
        {
            ShowModel Show = showsLogic.GetById(reservation.Showid);
            FilmModel Film = filmsLogic.GetById(Show.FilmId);
            Console.WriteLine($"Reservation for {Film.Name} at {Show.Date}");
            Console.WriteLine("=============================================");
        }
    }
}

