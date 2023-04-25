public class ReservationList
{
    public static void listReservations()
    {
        int counter = 0;
        Console.Clear();
        int id = AccountsLogic.CurrentAccount.Id;
        List<TheReservationModel> reservations = ReservationsLogic.ReservationsByAccount(id);
        ShowsLogic showsLogic = new ShowsLogic();
        FilmsLogic filmsLogic = new FilmsLogic();
        Console.WriteLine($"Reservations\n");
        Console.WriteLine("=============================================");
        foreach (TheReservationModel reservation in reservations)
        {
            counter++;
            ShowModel Show = showsLogic.GetById(reservation.Showid);
            FilmModel Film = filmsLogic.GetById(Show.FilmId);
            Console.WriteLine($"{counter}: Reservation for {Film.Name} at {Show.Date}");
            Console.WriteLine("=============================================");
        }
        Console.WriteLine("Type the number of the reservation you want to see the details of: ");
        int choice = Convert.ToInt32(Console.ReadLine()) - 1;
        TheReservationModel res = reservations[choice];
        ReservationDetail.detailReservation(res);
    }
}

