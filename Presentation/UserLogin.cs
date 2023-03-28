static class UserLogin
{
    static private AccountsLogic accountsLogic = new AccountsLogic();


    public static void Start()
    {
<<<<<<< HEAD
        Console.WriteLine("\nLogin [1] or register [2]\n-----------------------------");
        string choice_string = Console.ReadLine();
        int choice = Convert.ToInt32(choice_string);
        if (choice == 1)
        {
            Dologin();
        }
        else if (choice == 2)
        {
            Doregister();
        }
        else
        {
            Console.WriteLine("Invalid input\n-----------------------------");
            Start();
        }

=======
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Login", Dologin));
        items.Add(new MenuItem("Register", Doregister));
        items.Add(new MenuItem("Quit", Menu.Quit));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
>>>>>>> main
    }
    public static void Dologin()
    {
        Console.WriteLine("\nWelcome to the login page\n-----------------------------");
        Console.WriteLine("Please enter your email address");
        string email = Console.ReadLine();
        Console.WriteLine("Please enter your password");
        string password = Console.ReadLine();
        AccountModel acc = accountsLogic.CheckLogin(email, password);
        if (acc != null)
        {
<<<<<<< HEAD
            Console.WriteLine("\nWelcome back " + acc.FullName);

            if (acc.EmailAddress == "admin")
            {

                int milliseconds = 2000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                Menu.LoggedIn = true;
                MenuAdmin.Start();
            }
            else
            {
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                Menu.LoggedIn = true;
                Menu.Start();
            }

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
                Start();
            }
            else if (choice == "2")
            {
                int milliseconds = 2000;
                Thread.Sleep(milliseconds);
                Console.Clear();
                Menu.Start();
            }

=======
            Console.WriteLine("\n-----------------------------\nWelcome back " + acc.FullName);
            if (acc.FullName == "Admin")
            {
                Menu.AdminLogged = true;
            }
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            Menu.LoggedIn = true;
            Menu.Start();
        }
        else
        {
            Console.WriteLine("\n-----------------------------\nNo account found with that email and password");
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            List<MenuItem> items = new List<MenuItem>();
            items.Add(new MenuItem("Try aigan", Start));
            items.Add(new MenuItem("Main menu", Menu.Start));
            MenuBuilder menu = new MenuBuilder(items);
            menu.DisplayMenu();
>>>>>>> main
        }
    }
    public static void Doregister()
    {
        Console.WriteLine("\nFirst name");
        string fname = Console.ReadLine();
        string fname_after = fname.Substring(0, 1).ToUpper() + fname.Substring(1);
        Console.WriteLine("Last name:");
        string lname = Console.ReadLine();
        string lname_after = lname.Substring(0, 1).ToUpper() + lname.Substring(1);
        Console.WriteLine("Email address:");
        string email = Console.ReadLine();
        email = email.ToLower();
        Console.WriteLine("Password:");
        string password = Console.ReadLine();
        string fullname = $"{fname_after} {lname_after}";
        AccountsLogic acc = new AccountsLogic();
        acc.NewAcc(email, password, fullname);
        Console.WriteLine("Succesfully registered");
        int milliseconds = 2000;
        Thread.Sleep(milliseconds);
        Console.Clear();
        Dologin();
    }
    public static void DuplicateEmail(string email)
    {
        Console.WriteLine($"\nThe emailaddress: {email} already exists");
        Console.WriteLine("\nPlease contact the cinema if you have trouble loggin in");
        Console.WriteLine("\nYou can find the contact information under Cinema Info at the main menu");
        int milliseconds = 5000;
        Thread.Sleep(milliseconds);
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Try aigan", Start));
        items.Add(new MenuItem("Main menu", Menu.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
}