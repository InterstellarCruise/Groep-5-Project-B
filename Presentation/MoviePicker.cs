static class MoviePicker

{
    static private AccountsLogic accountLogic = new AccountsLogic();

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start(string movie)
    {
        //Given data: The room number of the show and the date and time of the show.
        string[] data = movie.Split();
        int room = Convert.ToInt32(data[0]);



        ShowsLogic filmsLogic = new ShowsLogic();
        List<ShowModel> shows = ShowsAccess.LoadAll();
    

        foreach (ShowModel show in shows)
        {
            if(show.RoomId == room & show.Date==data[2] & show.Time ==data[1]){
                FilmsLogic filmsLogic_picker = new FilmsLogic();
                List<FilmModel> films = FilmsAccess.LoadAll();
                var film = filmsLogic_picker.GetById(show.FilmId);
                Console.WriteLine($"\n-----------------------------\nMovie name: {film.Name}");
                Console.WriteLine($"Description: {film.Description}");
                Console.WriteLine($"Age limit: {film.AgeLimit}\n-----------------------------");
                List<MenuItem> items = new List<MenuItem>();
                if (!Menu.LoggedIn)
                {
                    items.Add(new MenuItem("if you have read the age limit and are agreeing to the terms and conditions you may login to verify your account", movielogin));
                }
                else
                {
                    items.Add(new MenuItem("Make reservation", Menu.NotImplemented));
                }
                items.Add(new MenuItem("Main menu", Menu.Start));
                MenuBuilder menu = new MenuBuilder(items);
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);
                Console.Clear();
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
            Console.WriteLine("\nWelcome back " + acc.FullName);
            if(acc.FullName == "Admin")
            {
                Menu.AdminLogged = true;
            }
            Menu.LoggedIn = true;
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            List<MenuItem> items = new List<MenuItem>();
            items.Add(new MenuItem("Make reservation", Menu.NotImplemented));
            items.Add(new MenuItem("Main menu", Menu.Start));
            MenuBuilder menu = new MenuBuilder(items);
            menu.DisplayMenu();
            }
        else
        {
            Console.WriteLine("\n-----------------------------\nNo account found with that email and password");
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            List<MenuItem> items = new List<MenuItem>();
            items.Add(new MenuItem("Try aigan", movielogin));
            items.Add(new MenuItem("Main menu", Menu.Start));
            MenuBuilder menu = new MenuBuilder(items);
            menu.DisplayMenu();
        }

        }
    }


        
        
}
