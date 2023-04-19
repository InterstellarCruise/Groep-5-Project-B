public static class UserLogin
{
    static private AccountsLogic accountsLogic = new AccountsLogic();
    public static AccountModel CurrentAccount { get; private set; }


    public static void Start()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Login", Dologin));
        items.Add(new MenuItem("Register", Doregister));
        items.Add(new MenuItem("Back", Menu.Start));
        items.Add(new MenuItem("Quit", Menu.Quit));

        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void Dologin()
    {
        Console.CursorVisible = true;
        string email = "";
        do
        {
            Console.WriteLine("\nWelcome to the login page\n-----------------------------");
            Console.WriteLine("Please enter your email address or type 'B' to go back");
            email = Console.ReadLine().ToLower();
            if (email == "b")
                Start();
            if (!email.ToLower().Contains("@") && email != "admin")
            {
                Console.WriteLine("\nenter a valid email address\n-----------------------------");
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
        AccountModel acc = accountsLogic.CheckLogin(email, password);
        if (acc != null)
        {
            Console.WriteLine("\n-----------------------------\nWelcome back " + acc.FullName);
            if (acc.FullName == "Admin")
            {
                Menu.AdminLogged = true;
            }
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            Menu.LoggedIn = true;
            CurrentAccount = acc;
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
        }
    }
    public static void Doregister()
    {
        Console.CursorVisible = true;
        Console.WriteLine("\nFirst name");
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