public class ReservationList
{
    public static void listReservations()
    {
        Console.Clear();
        // Console.CursorVisible = false;
        Console.WriteLine($"Reservations\n");
        int id = AccountsLogic.CurrentAccount.Id;
        List<TheReservationModel> reslist = ReservationsLogic.ReservationsByAccount(id);
        foreach (TheReservationModel res in reslist)
        {
            ShowModel show = ShowsLogic.GetById(res.Showid);
            Console.WriteLine($"{res.Id}");
        }
        // items.Add(new MenuItem("\nBack", Start));
        // MenuBuilder menu = new MenuBuilder(items);
        // menu.DisplayMenu();
    }
}

