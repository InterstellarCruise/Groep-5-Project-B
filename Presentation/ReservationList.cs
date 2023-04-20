public class ReservationList
{
    private static ShowModel? _show { get; set; }
    private static TheReservationModel? _res { get; set; }
    public static void listReservations()
    {
        Console.Clear();
        // Console.CursorVisible = false;
        Console.WriteLine($"Reservations\n");
        int id = AccountsLogic.CurrentAccount.Id;
        List<TheReservationModel> reslist = ReservationsLogic.ReservationsByAccount(id);
        foreach (TheReservationModel res in reslist)
        {
            _res = res;
            ShowModel show = ShowsLogic.GetById(_res.Showid);
            _show = show;
            Console.WriteLine($"{_show.Id}");
        }
        // items.Add(new MenuItem("\nBack", Start));
        // MenuBuilder menu = new MenuBuilder(items);
        // menu.DisplayMenu();
    }
}

