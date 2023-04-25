public class AdminIncome
{
    static ShowsLogic showLogic = new ShowsLogic();
    static FilmsLogic filmLogic = new FilmsLogic();
    private static ShowModel _show = new ShowModel(0, 0, 0, null, null);
    private static FilmModel _film = new FilmModel(0, null, null, 0, 0, null);
    private static string CurrentShow = "";
    public static ShowModel show
    {
        get { return _show; }
        set { _show = value; }
    }
    public static FilmModel film
    {
        get { return _film; }
        set { _film = value; }
    }
    public static void Main()
    {
        
    }

    public void Display()
    {
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Income per show", IncomePerShow));
        items.Add(new MenuItem("Back", Menu.Start));
        items.Add(new MenuItem("Quit", Menu.Quit));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }

    public void IncomePerShow()
    {
        Console.WriteLine("These are all the current shows");
        ShowsLogic.AllCurrentShows();
        Console.WriteLine("Enter the ID of the show you want to view \n-------------------------------");
        int id = Convert.ToInt32(Console.ReadLine());
        show = showLogic.GetById(id);
        if (show == null)
        {
            Console.WriteLine("There is no show with this ID");
            int miliseconds = 2000;
            Thread.Sleep(miliseconds);
            Console.Clear();
            AdminFeatures.Start();
        }




        // List<double> dblList = new List<double> { 22.3, 44.5, 88.1 };

        // Console.WriteLine(string.Format("Here's the list: ({0}).", string.Join(", ", dblList)));

        // Output: Here's the list: (22.3, 44.5, 88.1). 
    }
}