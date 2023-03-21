static class UserLogin
{
    static private AccountsLogic accountsLogic = new AccountsLogic();


    public static void Start()
    {
        Console.WriteLine("\nLogin [1] or register [2]\n-----------------------------");
        string choice_string = Console.ReadLine();
        int choice = int.Parse(choice_string);
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
            Console.WriteLine("\nWelcome back " + acc.FullName);
            Console.WriteLine("Your email number is " + acc.EmailAddress);
            int milliseconds = 3000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            Menu.LoggedIn = true;
            Menu.Start();
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
            
        }
    }
    public static void Doregister()
    {
        Console.WriteLine("First name:");
        string fname = Console.ReadLine();
        Console.WriteLine("Last name:");
        string lname = Console.ReadLine();
        Console.WriteLine("Email address:");
        string email = Console.ReadLine();
        Console.WriteLine("Password:");
        string password = Console.ReadLine();
        string fullname = $"{fname} {lname}";
        AccountsLogic acc = new AccountsLogic();
        acc.NewAcc(email, password, fullname);
        Console.WriteLine("Succesfully registered");
        Dologin();
    }
}