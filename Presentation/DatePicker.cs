static class DatePicker
{
    public static List<ShowModel> Shows = ShowsAccess.LoadAll();
    public static bool emptyOrNot = false;
    public static string Date = "";
    static public void Start()
    {
        MenuBuilder menu = new MenuBuilder(Items());
        menu.DisplayMenu();
        Console.WriteLine("Date picker for shows.\n");

        static List<MenuItem> Items()
        {
            List<MenuItem> items = new List<MenuItem>();
            items.Add(new MenuItem("Choose date", chooseDate));
            items.Add(new MenuItem("Back", Menu.Start));
            return items;
        }
        static void chooseDate()
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Type a date you want to see the shows from like: year-month-day");
            Console.WriteLine("Type 'B' to go back");
            Console.WriteLine("--------------------------------");
            Date = Console.ReadLine();
            if (Date.ToUpper() == "B")
            {
                Console.Clear();
                Menu.Start();
            }
            
            //Display every show thats from the given date.
            Console.Clear();
            // Console.WriteLine($"Movies on the date: {date} \n");
            emptyOrNot = ShowsLogic.MoviesByDate(Shows, Date, emptyOrNot);
            Console.WriteLine("\n");
            //Check to see if theres any shows at that date or not.
            //if so to be able to choose a show otherwise ask for another date.
            if (emptyOrNot == true)
            {
                showChoose();
            }
            else
            {
                Console.WriteLine("No movies for this date, please choose another date \n");
                int milliseconds = 1500;
                Thread.Sleep(milliseconds);
                Console.Clear();
                Start();
            }
        }
    }
    public static void showChoose()
    {
        Console.Clear();
        Console.CursorVisible = false;
        Console.WriteLine($"Movies playing on {Date}\n");
        ShowsLogic.MoviesByDate(Shows, Date, emptyOrNot);
        List<MenuItem> items = new List<MenuItem>();
        for (int i = 0; i < ShowsLogic.ShowInfo.Count;i++)
        {
            string showinfo = ShowsLogic.ShowInfo.Keys.ElementAt(i);

            MenuItem item = new MenuItem($"{ShowsLogic.Lines}\n{showinfo}", MoviePicker.Start);
            item.RoomTimeDate = ShowsLogic.ShowInfo.Values.ElementAt(i);
            items.Add(item);
        }
        items.Add(new MenuItem("\nBack", Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
}