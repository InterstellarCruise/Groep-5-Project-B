public class ReservationDetail
{
    public static void detailReservation(TheReservationModel reservation)
    {
        Console.Clear();
        int showid = reservation.Showid;
        ShowsLogic showsLogic = new ShowsLogic();
        FilmsLogic filmsLogic = new FilmsLogic();
        ShowModel Show = showsLogic.GetById(reservation.Showid);
        FilmModel Film = filmsLogic.GetById(Show.FilmId);

        Console.WriteLine($"Reservation");
        Console.WriteLine("=============================================\n");
        Console.WriteLine($"General information:");
        Console.WriteLine("\n");
        Console.WriteLine($"Total cost: {reservation.Amount} EUR");
        Console.WriteLine(string.Format("Chairs reserved: ({0}).", string.Join(", ", reservation.Ressedchairs)));
        Console.WriteLine('\n');
        // Console.WriteLine($"Chairs reserved:");
        // foreach (int i in reservation.Ressedchairs)
        Console.WriteLine("=============================================");
        Console.WriteLine("Information about the show:");
        Console.WriteLine("\n");
        Console.WriteLine($"Room number: {Show.RoomId}");
        Console.WriteLine($"Date of the show: {Show.Date}");
        Console.WriteLine($"Time of the show: {Show.Time}");
        Console.WriteLine('\n');
        Console.WriteLine("=============================================");
        Console.WriteLine("Information about the movie:");
        Console.WriteLine($"\n");
        Console.WriteLine($"Film name: {Film.Name}");
        Console.WriteLine($"Film description: {Film.Description}");
        Console.WriteLine($"Age limit: {Film.AgeLimit}");
        Console.WriteLine($"Film length: {Film.Length}");
        Console.WriteLine(string.Format("Genres of the movie: ({0}).", string.Join(", ", Film.Genre)));

    }
}

