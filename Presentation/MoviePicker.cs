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
                Console.WriteLine(film.Name);
                Console.WriteLine(film.Description);
                Console.WriteLine(film.AgeLimit);
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
            Console.WriteLine("\ngreat your reservation has been made " + acc.FullName);
            if(acc.FullName == "Admin")
            {
                Menu.LoggedIn = true;
                Menu.AdminLogged = true;
                Menu.Start();
            }
            else
            {
                Menu.LoggedIn = true;
                Menu.Start();
            }
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            

        }
        else
        {
            Console.WriteLine("\nNo account found with that email and password\n-----------------------------");
            Console.WriteLine("[1] Try aigan \n[2] Main menu");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                movielogin();
            }
            else if (choice == "2") 
            {
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                Menu.Start();
            }
            
        }
    }


        
        
    }
}