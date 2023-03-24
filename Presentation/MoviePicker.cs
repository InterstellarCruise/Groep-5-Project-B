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


        Console.WriteLine($"Room: {data[0]}, Date: {data[2]}, Time: {data[1]},");
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
                Console.WriteLine("if you have read the age limit and are agreeing to the terms and conditions you may login to verify your account[1] /n .if not please fo back to menu[2]");
                string answer = Console.ReadLine();
                if(answer == "1")
                {
                    movielogin();
                }
                else
                {
                    int milliseconds = 2000;
                    Thread.Sleep(milliseconds);
                    Console.Clear();
                    Menu.Start();
                }


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
            Console.WriteLine("\ngreat your reservation has been made" + acc.FullName);
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Console.Clear();
            Menu.Start();


            //Write some code to go back to the menu
            //Menu.Start();
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