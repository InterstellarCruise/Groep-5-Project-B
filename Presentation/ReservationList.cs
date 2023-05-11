public class ReservationList
{
    public static void listReservations()
    {
        Console.Clear();
        List<MenuItem> items = new List<MenuItem>();
        int id = AccountsLogic.CurrentAccount.Id;
        List<ReservationModel> reservations = ReservationsLogic.ReservationsByAccount(id);
        ShowsLogic showsLogic = new ShowsLogic();
        FilmsLogic filmsLogic = new FilmsLogic();
        items.Add(new MenuItem($"Reservations\n=============================================", null));
        foreach (ReservationModel reservation in reservations)
        {
            ShowModel Show = showsLogic.GetById(reservation.Showid);
            FilmModel Film = filmsLogic.GetById(Show.FilmId);
            MenuItem item = new MenuItem($"Reservation for {Film.Name} at {Show.Date}", ReservationDetail.detailReservation);
            item.reservation = reservation;
            items.Add(item);
            items.Add(new MenuItem("=============================================\n", null));
        }
        items.Add(new MenuItem("\nBack", AccountPage.start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
}

