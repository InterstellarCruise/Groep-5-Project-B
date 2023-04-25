public class AccountPage
{
    public static AccountModel Account { get; set; }
    public static void start()
    {
        Account = UserLogin.CurrentAccount;
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Account information", AccountInfo.Accountinfo));
        items.Add(new MenuItem("Reservations", ReservationList.listReservations));
        items.Add(new MenuItem("Back", Menu.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    
}

