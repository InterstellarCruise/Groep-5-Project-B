

using System.Globalization;
public static class AddShows
{
    static ShowsLogic showLogic = new ShowsLogic();
    private static int _movieId;
    public static int MovieId
    {
        get { return _movieId; }
        set { _movieId = value; }
    }

    static FilmsLogic filmLogic = new FilmsLogic();
    private static string _warning = "WARNING\nThis may have grave consequences.\nAre you sure you want to proceed with this action?\n";
    private static string _option = "Do you want to add a show or film?";
    public static List<FilmModel> Films = FilmsAccess.LoadAll();

    public static void Start()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem(_warning, null));
        items.Add(new MenuItem("Yes", Options));
        items.Add(new MenuItem("No", AdminFeatures.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }

    public static void Options()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem(_option, null));
        items.Add(new MenuItem("Show", AddShow));
        items.Add(new MenuItem("Film", AddFilms.FilmInput));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void AddShow()
    {
        Console.Clear();
        Console.WriteLine($"Select the movie that plays on this show:\n");
        FilmsLogic.AllFilms(Films);
        List<MenuItem> items = new List<MenuItem>();
        for (int i = 0; i < FilmsLogic.FilmInfo.Count; i++)
        {
            string filmname = FilmsLogic.FilmInfo.Keys.ElementAt(i);
            int FilmId = FilmsLogic.FilmInfo.Values.ElementAt(i);
            MenuItem item = new MenuItem($"{FilmsLogic.Lines}\n{filmname}", ShowInput);
            item.MovieId = FilmId;
            items.Add(item);

        }
        items.Add(new MenuItem("\nBack", Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
    public static void ShowInput()
    {
        int[] daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        Console.Clear();
        int LastID = ShowsLogic.LastID();
        int ID = LastID += 1;
        Console.WriteLine("Type the room number this movie will play in (1 to 3): ");
        string room = "";
        room = Console.ReadLine();

        while (room != "1" && room != "2" && room != "3")
        {
            Console.WriteLine(room);
            Console.WriteLine("Only a room between 1 to 3");
            room = Console.ReadLine();
        }
        int RoomId = Convert.ToInt32(room);
        //-----------------------
        Console.Clear();
        DateTime? date = null;
        bool validInputDate = false;
        string inputdate;
        bool validyear = false;
        Console.WriteLine("Type the date this show will play like (Year-Month-Day): ");

        do
        {
            inputdate = Console.ReadLine();
            try
            {
                date = DateTime.Parse(inputdate);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid date format. Please enter the date in the format yyyy-MM-dd.");
            }
            if (date?.Year >= DateTime.Now.Year && date?.Year <= DateTime.Now.Year + 5)
            {
                validyear = true;
            }
            else
            {
                Console.WriteLine("The date needs to be between the current year and 5 years from now.");
            }
            validInputDate = true;
        } while (!validInputDate || !validyear);

        Console.Clear();
        Console.WriteLine("Type the time this show will start like (Hour:Minutes): ");
        int[] hm = new int[0];
        string time;
        bool timecheck = false;
        do
        {
            time = Console.ReadLine();
            try
            {
                hm = time.Split(":").Select(int.Parse).ToArray();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid date format. Please enter the date in the format Hour:Minutes");
            }
            if (hm.Length != 2)
            {
                Console.WriteLine("Input is not a valid time, please try again.");
            }
            else if (hm[0] >= 0 && hm[0] <= 23 && hm[1] >= 0 && hm[1] <= 59)
            {
                timecheck = true;

            }
            else
            {
                Console.WriteLine("Input is not a valid time, please try again.");
            }
        }
        while (!timecheck);

        Console.Clear();
        ShowModel show = new ShowModel(ID, MovieId, RoomId, inputdate, time);
        ShowsAccess.Add(show);
    }

}