using System.Security.Principal;

public class AccountInfo
{
    public static void Accountinfo()
    {
        string[] fullname = AccountPage.Account.FullName.Split(' ');
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem($"First Name: {fullname[0]}\nLast Name: {fullname[1]}\nEmail:{AccountPage.Account.EmailAddress}\nPassword:{AccountPage.Account.Password}\n--------------------------------", null));
        items.Add(new MenuItem("Change information", ChangeInfo));
        items.Add(new MenuItem("Back", AccountPage.start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void ChangeInfo()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Change Name", ChangeName));
        items.Add(new MenuItem("Change Email", ConfirmEmail));
        items.Add(new MenuItem("Change Password", ConfirmPassword));
        items.Add(new MenuItem("Back", Accountinfo));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void ChangeName()
    {
        string[] fullname = AccountPage.Account.FullName.Split(' ');
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem($"First Name: {fullname[0]}\nLast Name: {fullname[1]}\n--------------------------------", null));
        items.Add(new MenuItem("Change First Name", ChangeFname));
        items.Add(new MenuItem("Change Last Name", ChangeLname));
        items.Add(new MenuItem("Back", ChangeInfo));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void ChangeFname()
    {
        Console.Clear();
        Console.CursorVisible = true;
        AccountsLogic accountslogic = new AccountsLogic();
        string[] fullname;
        string fname = null;
        do
        {
            fullname = AccountPage.Account.FullName.Split(' ');
            Console.WriteLine($"First Name: {fullname[0]}\nLast Name: {fullname[1]}\n--------------------------------");
            Console.WriteLine("Enter a new first name");
            fname = Console.ReadLine();
            if (fname.ToLower() == fullname[0].ToLower())
            {
                Console.WriteLine("Not a new first name");
                Thread.Sleep(1500);
                Console.Clear();
            }
        } while (fname.ToLower() == fullname[0].ToLower());

        string Fullname = $"{fname} {fullname[1]}";
        AccountPage.Account.FullName = Fullname;
        accountslogic.UpdateList(AccountPage.Account);
        Console.WriteLine("Successfully changed your first name");
        Thread.Sleep(3000);
        Console.CursorVisible = false;
        AccountPage.start();
    }
    public static void ChangeLname()
    {
        Console.Clear();
        Console.CursorVisible = true;
        AccountsLogic accountslogic = new AccountsLogic();
        string[] fullname;
        string lname = null;
        do
        {
            fullname = AccountPage.Account.FullName.Split(' ');
            Console.WriteLine($"First Name: {fullname[0]}\nLast Name: {fullname[1]}\n--------------------------------");
            Console.WriteLine("Enter a new last name");
            lname = Console.ReadLine();
            if (lname.ToLower() == fullname[1].ToLower())
            {
                Console.WriteLine("Not a new last name");
                Thread.Sleep(1500);
                Console.Clear();
            }
                
        } while (lname.ToLower() == fullname[1].ToLower());
        
        string Fullname = $"{fullname[0]} {lname}";
        AccountPage.Account.FullName = Fullname;
        accountslogic.UpdateList(AccountPage.Account);
        Console.WriteLine("Successfully changed your last name");
        Thread.Sleep(3000);
        Console.CursorVisible = false;
        AccountPage.start();
    }
    public static void ConfirmEmail()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Are you sure?", null));
        items.Add(new MenuItem("Yes", ChangeEmail));
        items.Add(new MenuItem("No", ChangeInfo));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void ChangeEmail()
    {
        Console.CursorVisible = true;
        Console.Clear();
        AccountsLogic accountsLogic = new AccountsLogic();
        string email1 = "";
        string email2 = "";
        do
        {
            email1 = "";
            email2 = "";
            Console.WriteLine("Enter a new Email");
            email1 = Console.ReadLine();
            Console.WriteLine("Enter new email again");
            email2 = Console.ReadLine();
            if (email1 != email2)
            {
                Console.WriteLine("Not the same email");
                Thread.Sleep(3000);
            }
            if (accountsLogic.CheckEmail(email1))
            {
                Console.WriteLine("An account with that email already exists");
                Thread.Sleep(3000);
                email1 = "";
            }
            Console.Clear();
        } while (email1 != email2 || !email1.ToLower().Contains("@") || email1 == AccountPage.Account.EmailAddress);
        
        AccountPage.Account.EmailAddress = email1.ToLower();
        accountsLogic.UpdateList(AccountPage.Account);
        Console.WriteLine("Email successfully changed");
        Thread.Sleep(3000);
        Console.CursorVisible = false;
        AccountPage.start();
    }
    public static void ChangePassword()
    {
        Console.CursorVisible = true;
        Console.Clear();
        string pw1 = "";
        string pw2 = "";
        do
        {
            pw1 = "";
            pw2 = "";
            Console.WriteLine("Enter a new Password");
            pw1 = Console.ReadLine();
            Console.WriteLine("Enter new Password again");
            pw2 = Console.ReadLine();
            if (pw1 != pw2)
            {
                Console.WriteLine("Not the same password");
                Thread.Sleep(3000);
            }
            if (pw1 == AccountPage.Account.Password)
            {
                Console.WriteLine("Not a new password");
                Thread.Sleep(3000);
            }
            Console.Clear();
        } while (pw1 != pw2 || pw1 == AccountPage.Account.Password);
        AccountsLogic accountsLogic = new AccountsLogic();
        AccountPage.Account.Password = pw1;
        accountsLogic.UpdateList(AccountPage.Account);
        Console.WriteLine("Password successfully changed");
        Thread.Sleep(3000);
        Console.CursorVisible = false;
        AccountPage.start();
    }
    public static void ConfirmPassword()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Are you sure?", null));
        items.Add(new MenuItem("Yes", ChangePassword));
        items.Add(new MenuItem("No", ChangeInfo));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
}