public static class RemoveShows
{
    static ShowsLogic showLogic = new ShowsLogic();
    static FilmsLogic filmLogic = new FilmsLogic();
    public static void Start()
    {
        Console.WriteLine("WARNING");
        Console.WriteLine("This may have grave consequences.");
        Console.WriteLine("Are you sure you want to proceed with this action?");
        Console.WriteLine("[1]: Yes\n-----------------------------");
        Console.WriteLine("[2]: No\n-----------------------------");
        int ans = Convert.ToInt32(Console.ReadLine());
        if (ans == 1)
        {
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            Menu.LoggedIn = true;
            DeleteItem();
        }
        else if (ans == 2)
        {
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            Menu.LoggedIn = true;
            Menu.Start();
        }
        else
        {
            Console.WriteLine("Wrong input please try again.");
            Start();
        }
    }
    public static void DeleteItem()
    {
        Console.WriteLine("Enter show id you want to delete");
        int id = Convert.ToInt32(Console.ReadLine());
        ShowModel show = showLogic.GetById(id);
        showLogic.DeleteShow(show);
        // FilmModel film = filmLogic.GetById(id);
        // filmLogic.DeleteShow(film);
        Console.WriteLine("The show has been removed");
        Menu.Start();
    }

}