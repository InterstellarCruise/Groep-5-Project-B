public class ChangeShows
{
    public static void Start()
    {   
        var show = new ShowsLogic();
        Console.WriteLine("\nThese are all the shows in the system right now\n");
        show.GetAllShows();
        Console.WriteLine("\nWhat Show would you like to change? Please select a Show");
        int show_id = Convert.ToInt32(Console.ReadLine());
        show.ShowSpecifShow(show_id);
        Console.WriteLine("\nWhat Would you like to change about the show? Please select a number\n");
        Console.WriteLine("[1] Show date\n-----------------------------");
        Console.WriteLine("[2] Show time\n-----------------------------");
        Console.WriteLine("[3] Title\n-----------------------------");
        Console.WriteLine("[4] Age Limit\n-----------------------------");
        Console.WriteLine("[5] Description\n-----------------------------");
        Console.WriteLine("[6] Genre\n-----------------------------");
        Console.WriteLine("[7] Room\n-----------------------------");
        int choice = Convert.ToInt32(Console.ReadLine());

        if(choice == 1 || choice == 2 || choice == 7 )
        {
            show.ChangeShowFeatures(show_id, choice);
        }
        else if(choice == 3 || choice == 4 || choice == 5 || choice == 6)
        {
            show.ShowToFilm(show_id, choice);
        }
        else
        {
            Console.WriteLine("Wrong Choice");
        }
    }
}