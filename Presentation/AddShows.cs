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
            MenuItem item = new MenuItem($"{FilmsLogic.Lines}\n{filmname}", RoomInput);
            item.MovieId = FilmId;
            items.Add(item);

        }
        items.Add(new MenuItem("\nBack", Menu.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }


    public static void RoomInput()
    {
        Console.Clear();
        Console.WriteLine("Type the room number this movie will play in (1 to 3): ");
        string room = "";
        room = Console.ReadLine();

        while (room != "1" && room != "2" && room != "3")
        {
            Console.WriteLine("Only a room between 1 to 3");
            int milliseconds = 1500;
            Thread.Sleep(milliseconds);
            Console.Clear();
            RoomInput();
        }
        int RoomId = Convert.ToInt32(room);
        DateInput(RoomId);
    }


    public static void DateInput(int RoomId)
    {
        int[] daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        Console.Clear();
        int LastID = ShowsLogic.LastID();
        int ID = LastID += 1;
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
                int milliseconds = 1500;
                Thread.Sleep(milliseconds);
                Console.Clear();
                DateInput(RoomId);
            }
            if (date?.Year >= DateTime.Now.Year && date?.Year <= DateTime.Now.Year + 5)
            {
                validyear = true;
            }
            else
            {
                Console.WriteLine("The date needs to be between the current year and 5 years from now.");
                int milliseconds = 1500;
                Thread.Sleep(milliseconds);
                Console.Clear();
                DateInput(RoomId);
            }
            validInputDate = true;
        } while (!validInputDate || !validyear);


        Console.Clear();
        TimeInput(inputdate, ID, MovieId, RoomId);
    }



    public static void TimeInput(string inputdate, int ID, int MovieId, int RoomId)
    {
        Console.WriteLine("Type the time this show will start like (Hour:Minutes) Or B to go back: ");
        int[] hm = new int[0];
        string time;
        bool timecheck = false;

        do
        {
            time = Console.ReadLine();
            if (time == "b" || time == "B")
            {
                DateInput(RoomId);
            }
            List<ShowModel> showsondate = ShowsLogic.ShowsByDate(inputdate);
            bool roomcheck = true;
            try
            {
                hm = time.Split(":").Select(int.Parse).ToArray();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid date format. Please enter the date in the format Hour:Minutes");
                int milliseconds = 1500;
                Thread.Sleep(milliseconds);
                Console.Clear();
                TimeInput(inputdate, ID, MovieId, RoomId);
            }

            if (hm.Length != 2)
            {
                Console.WriteLine("Input is not a valid time, please try again.");
                int milliseconds = 1500;
                Thread.Sleep(milliseconds);
                Console.Clear();
                TimeInput(inputdate, ID, MovieId, RoomId);
            }

            if (showsondate.Count > 0)
            {
                roomcheck = RoomsLogic.AvailableCheck(showsondate, time);
                //New LogicLayer function
            }

            if (roomcheck is false)
            {
                Console.WriteLine("Room is reserved on this time!");
                int milliseconds = 1500;
                Thread.Sleep(milliseconds);
                Console.Clear();
                TimeInput(inputdate, ID, MovieId, RoomId);
            }

            else if (RoomsLogic.ValidTime(hm, roomcheck) == true)
            {
                timecheck = RoomsLogic.ValidTime(hm, roomcheck);
                //New LogicLayer function
            }

            else
            {
                Console.WriteLine("Input is not a valid time, please try again.");
                int milliseconds = 1500;
                Thread.Sleep(milliseconds);
                Console.Clear();
                TimeInput(inputdate, ID, MovieId, RoomId);
            }
        }
        while (!timecheck);
        Add(ID, MovieId, RoomId, inputdate, time);
    }


    public static void Add(int ID, int MovieID, int RoomId, string inputdate, string time)
    {
        Console.Clear();
        Console.WriteLine("Show added on " + inputdate + ".");
        int milliseconds = 1500;
        Thread.Sleep(milliseconds);
        Console.Clear();
        ShowsLogic.AddShow(ID, MovieID + 1, RoomId, inputdate, time);
        //New LogicLayer function
        Menu.Start();
    }


}
