static class MoviePicker

{
    static private AccountsLogic accountLogic = new AccountsLogic();

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    public static string movie { get; set; }
    public static ShowModel CurrentShow { get; set; }
    public static MenuItem CurrentMovie = null;
    private static string[] data;
    private static int room;
    static public void Start()
    {
        //Given data: The room number of the show and the date and time of the show.
        if (movie.Length > 0)
        {
            data = movie.Split();
            room = Convert.ToInt32(data[0]);
        }

        ShowsLogic showlogic = new ShowsLogic();
        List<ShowModel> shows = ShowsLogic.AllCurrentShows();


        foreach (ShowModel show in shows)
        {
            if (show.RoomId == room & show.Date == data[2] & show.Time == data[1]) {

                List<MenuItem> items = new List<MenuItem>();
                MenuBuilder menu = new MenuBuilder(items);
                FilmsLogic films_logic = new FilmsLogic();
                List<FilmModel> films = FilmsLogic.AllCurrentFilms();
                var film = films_logic.GetById(show.FilmId);
                CurrentMovie = new MenuItem($"-----------------------------\nMovie name: {film.Name} \nDescription: {film.Description} \nAge limit: {film.AgeLimit}\nfilm duration: {film.Length} \n-----------------------------", null);
                items.Add(CurrentMovie);
                CurrentShow = show;
                if (!Menu.LoggedIn)
                {
                    items.Add(new MenuItem("If you have read the age limit and are agreeing to the terms and conditions you may login to verify your account.", movielogin));
                    items.Add(new MenuItem("if you do not have an account you may register", Movieregister));
                }
                else
                {
                    var Reservationoption = new MenuItem("Make reservation", Reservation.Main);
                    Reservationoption.show = show;
                    items.Add(Reservationoption);
                }
                items.Add(new MenuItem("Back", DatePicker.showChoose));
                items.Add(new MenuItem("Main menu", Menu.Start));
                menu.DisplayMenu();

            }
        }
    }
    static void movielogin()
    {
        Console.CursorVisible = true;
        string email = "";
        do
        {
            Console.WriteLine("Welcome to the login page\n-----------------------------");
            Console.WriteLine("Please enter your email address or type 'B' to go back");
            email = Console.ReadLine().ToLower();
            if (email == "b")
                    Start();
            if (!email.ToLower().Contains("@") && email != "admin")
            {
                Console.WriteLine("\nPlease enter a valid email address\n-----------------------------");
                Thread.Sleep(2000);
                Console.Clear();
            }
        } while (email != "admin" && !email.ToLower().Contains("@"));
        Console.WriteLine("Please enter your password");
        var password = string.Empty;
        ConsoleKey key;
        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && password.Length > 0)
            {
                Console.Write("\b \b");
                password = password[0..^1];
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                password += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);
            AccountModel acc = accountLogic.CheckLogin(email, password);
        if (acc != null)
        {
            Console.WriteLine("\n-----------------------------\nWelcome back " + acc.FullName);
            if(acc.FullName == "Cinema Admin")
            {
                Menu.AdminLogged = true;
            }
            UserLogin.CurrentAccount = acc;
            Menu.LoggedIn = true;
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            List<MenuItem> items = new List<MenuItem>();
            items.Add(CurrentMovie);

            var Reservationoption = new MenuItem("Make reservation", Reservation.Main);
            Reservationoption.show = CurrentShow;
            items.Add(Reservationoption);
            items.Add(new MenuItem("Back", DatePicker.showChoose));
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
            items.Add(new MenuItem("Try again", movielogin));
            items.Add(new MenuItem("Back", DatePicker.showChoose));
            items.Add(new MenuItem("Main menu", Menu.Start));
            MenuBuilder menu = new MenuBuilder(items);
            menu.DisplayMenu();
        }

        }
    static void Movieregister()
    {
        Console.CursorVisible = true;
        Console.WriteLine("\nFirst name:");
        string fname = Console.ReadLine();
        string fname_after = fname.Substring(0, 1).ToUpper() + fname.Substring(1);
        Console.WriteLine("Last name:");
        string lname = Console.ReadLine();
        string lname_after = lname.Substring(0, 1).ToUpper() + lname.Substring(1);
        string email = "";
        do
        {
            Console.WriteLine("Email address: ");
            email = Console.ReadLine().ToLower();
            if (!email.ToLower().Contains("@"))
            {
                Console.WriteLine("\nenter a valid email address\n-----------------------------");
            }
        } while (!email.ToLower().Contains("@"));
        email = email.ToLower();
        string password = "";
        string password1 = " ";
        do
        {
            Console.WriteLine("Password:");
            password = Console.ReadLine();
            Console.WriteLine("Repeat the password");
            password1 = Console.ReadLine();
            if (password != password1)
            {
                Console.WriteLine("The passwords aren't matching");
                Console.WriteLine("Please try again");
                Thread.Sleep(1000);
                Console.Clear();
            }
        } while (password != password1);
        string fullname = $"{fname_after} {lname_after}";
        AccountsLogic acc = new AccountsLogic();
        bool exists = acc.NewAcc(email, password, fullname);
        if (!exists) DuplicateEmailRegister(email);
        acc.NewAcc(email, password, fullname);
        Console.WriteLine("Succesfully registered");
        Thread.Sleep(1000);
        Console.Clear();
        movielogin();

    }
    public static void DuplicateEmailRegister(string email)
    {
        Console.WriteLine($"\nThe emailaddress: {email} already exists");
        Console.WriteLine("\nPlease contact the cinema if you have trouble loggin in");
        Console.WriteLine("\nYou can find the contact information under Cinema Info at the main menu");
        int milliseconds = 5000;
        Thread.Sleep(milliseconds);
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Try again", Movieregister));
        items.Add(new MenuItem("Main menu", Menu.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }





}
