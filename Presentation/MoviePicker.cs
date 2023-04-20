static class MoviePicker

{
    static private AccountsLogic accountLogic = new AccountsLogic();

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    private static string _movie = "";
    public static string movie
    {
        get { return _movie; }
        set { _movie = value; }
    }
    public static MenuItem CurrentMovie = null;
    public static ShowModel theshow =null;
    static ReservationsLogic reservationsLogic = new ReservationsLogic();
    public static List<int> chiars =null;
    static public void Start()
    {
        //Given data: The room number of the show and the date and time of the show.
        string[] data = movie.Split();
        int room = Convert.ToInt32(data[0]);



        ShowsLogic filmsLogic = new ShowsLogic();
        List<ShowModel> shows = ShowsAccess.LoadAll();
    

        foreach (ShowModel show in shows)
        {
            if(show.RoomId == room & show.Date==data[2] & show.Time ==data[1]){
                theshow = show;
                List<MenuItem> items = new List<MenuItem>();
                MenuBuilder menu = new MenuBuilder(items);
                FilmsLogic filmsLogic_picker = new FilmsLogic();
                List<FilmModel> films = FilmsAccess.LoadAll();
                var film = filmsLogic_picker.GetById(show.FilmId);
                CurrentMovie = new MenuItem($"-----------------------------\nMovie name: {film.Name} \nDescription: {film.Description} \nAge limit: {film.AgeLimit}\nfilm duration: {film.Length} \n-----------------------------", null);
                items.Add(CurrentMovie);
                if (!Menu.LoggedIn)
                {
                    items.Add(new MenuItem("If you have read the age limit and are agreeing to the terms and conditions you may login to verify your account.", movielogin));
                    items.Add(new MenuItem("if you do not have an account you may register", Movieregister));
                }
                else
                {
                    items.Add(new MenuItem("Make reservation", Menu.NotImplemented));
                }
                items.Add(new MenuItem("Back", DatePicker.showChoose));
                items.Add(new MenuItem("Main menu", Menu.Start));
                menu.DisplayMenu();

            }
        }

     static void movielogin()
    {
        
        Console.WriteLine("\nWelcome to the login page\n-----------------------------");
        Console.WriteLine("Please enter your email address");
        string email = Console.ReadLine();
        Console.WriteLine("Please enter your password");
        string password = Console.ReadLine();
        AccountModel acc = accountLogic.CheckLogin(email, password);
        if (acc != null)
        {
            Console.WriteLine("-----------------------------\nWelcome back " + acc.FullName);
            if(acc.FullName == "Admin")
            {
                Menu.AdminLogged = true;
            }
            Menu.LoggedIn = true;
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            List<MenuItem> items = new List<MenuItem>();
            List<int> chiar = new List<int>{1,3};
            chiar = chiars;
            items.Add(CurrentMovie);
            items.Add(new MenuItem("Make reservation", Transaction.Start));
            items.Add(new MenuItem("Back", DatePicker.showChoose));
            items.Add(new MenuItem("Main menu", Menu.Start));
            MenuBuilder menu = new MenuBuilder(items);
            menu.DisplayMenu();
            }
        else
        {
            Console.WriteLine("-----------------------------\nNo account found with that email and password");
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            List<MenuItem> items = new List<MenuItem>();
            items.Add(new MenuItem("Try aigan", movielogin));
            items.Add(new MenuItem("Back", DatePicker.showChoose));
            items.Add(new MenuItem("Main menu", Menu.Start));
            MenuBuilder menu = new MenuBuilder(items);
            menu.DisplayMenu();
        }

        }
         static void Movieregister()
    {
        Console.WriteLine("\nwhat is you're First name");
        string fname = Console.ReadLine();
        string fname_after = fname.Substring(0, 1).ToUpper() + fname.Substring(1);
        Console.WriteLine("what is you're Last name:");
        string lname = Console.ReadLine();
        string lname_after = lname.Substring(0, 1).ToUpper() + lname.Substring(1);
        Console.WriteLine("what is you're Email address:");
        string email = Console.ReadLine();
        email = email.ToLower();
        Console.WriteLine("what would you like to be you're Password:");
        string password = Console.ReadLine();
        string fullname = $"{fname_after} {lname_after}";
        AccountsLogic acc = new AccountsLogic();
        acc.NewAcc(email, password, fullname);
        Console.WriteLine("you have Succesfully registered");
        AccountModel ac = accountLogic.CheckLogin(email, password);
        Menu.LoggedIn = true;
        int millisecond = 2000;
        Thread.Sleep(millisecond);
        Console.Clear();
        List<MenuItem> items = new List<MenuItem>();
        List<int> chiar = new List<int>{1,3};
        chiar = chiars;
        
        items.Add(CurrentMovie);
        items.Add(new MenuItem("Make reservation", Transaction.Start));
        items.Add(new MenuItem("Back", DatePicker.showChoose));
        items.Add(new MenuItem("Main menu", Menu.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
        int milliseconds = 2000;
        Thread.Sleep(milliseconds);
        Console.Clear();

        
    }
    }


        
        
}
