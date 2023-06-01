public class ReservationScreenBuilder
{
    private static bool _running = true;
    private static List<ChairModel> _selectedchairs = new List<ChairModel>();
    public static string selchairs = "";
    protected static int origRow;
    protected static int origCol;
    public static string legendred = "  [BLUE] --> 8.00 EUR";
    public static string legendorange = "  [GREEN] --> 10.00 EUR";
    public static ShowModel show { get; set; }
    public static void MultipleChoice(List<MenuItem> options, int curpos, int optionsperline)
    {
        if (!CheckOut.BackMenu)
        {
            if (_selectedchairs.Count != 0)
            {
                foreach (MenuItem item in options)
                {
                    foreach (ChairModel chair in _selectedchairs)
                    {
                        if (ChairLogic.RowNumber(item.chair) == ChairLogic.RowNumber(chair))
                        {
                            item.chair.Available = false;
                            item.chair.takeseat = true;
                        }
                    }
                }
            }
        }
        else
        {
            _selectedchairs.Clear();
            Reservation.totalprice = 0;
            CheckOut.BackMenu = false;
        }
            

        Console.SetCursorPosition(0, 0);
        const int startX = 5;
        const int startY = 10;
        int optionsPerLine = optionsperline;
        const int spacingPerLine = 4;
        origRow = Console.CursorTop;
        origCol = Console.CursorLeft;

        int currentSelection = curpos;

        ConsoleKey key;

        Console.CursorVisible = false;

        while (_running)
        {


            if (!Console.IsOutputRedirected)
                Console.Clear();
            DisplayInfo();

            for (int i = 0; i < options.Count; i++)
            {
                Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                if (i == currentSelection)
                {

                    if (!options[currentSelection].chair.Available)
                    {

                        if (options[currentSelection].chair.takeseat)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    if (options[i].chair.Rank == 1)
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    else if (options[i].chair.Rank == 2)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (options[i].chair.Rank == 3)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (!options[i].chair.Available)
                    {

                        if (options[i].chair.takeseat)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                    }
                }

                Console.Write(ChairLogic.RowNumber(options[i].chair));

                Console.ResetColor();
            }
            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.Escape:
                    Reservation.totalprice = 0;
                    _selectedchairs.Clear();
                    MoviePicker.Start();
                    break;
                case ConsoleKey.Spacebar:
                    double amount = Reservation.Total("nothing");
                    CheckOut.Start(_selectedchairs, amount, show);
                    break;
                case ConsoleKey.LeftArrow:
                    {
                        try
                        {
                            if (options[currentSelection - 1].chair.Row != null)
                            {
                                if (currentSelection % optionsPerLine > 0)
                                    currentSelection--;
                            }
                        }
                        catch (IndexOutOfRangeException) { }
                        catch (ArgumentOutOfRangeException) { }
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        try
                        {
                            if (options[currentSelection + 1].chair.Row != null)
                            {
                                if (currentSelection % optionsPerLine < optionsPerLine - 1)
                                    currentSelection++;
                            }
                        }
                        catch (IndexOutOfRangeException) { }
                        catch (ArgumentOutOfRangeException) { }
                        break;

                    }
                case ConsoleKey.UpArrow:
                    {
                        try
                        {
                            if (options[currentSelection - optionsPerLine].chair.Row != null)
                                if (currentSelection >= optionsPerLine)
                                    currentSelection -= optionsPerLine;
                        }
                        catch (IndexOutOfRangeException) { }
                        catch (ArgumentOutOfRangeException) { }
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        try
                        {
                            if (options[currentSelection + optionsPerLine].chair.Row != null)
                            {
                                if (currentSelection + optionsPerLine < options.Count)
                                    currentSelection += optionsPerLine;
                            }
                        }
                        catch (ArgumentOutOfRangeException) { }
                        catch (IndexOutOfRangeException) { }
                        break;
                    }
                case ConsoleKey.Enter:
                    {
                        if (options[currentSelection].chair.Row != null)
                        {
                            if (options[currentSelection].chair.Available && !options[currentSelection].chair.takeseat)
                            {
                                options[currentSelection].Execute();
                                if (!_selectedchairs.Contains(options[currentSelection].chair))
                                {
                                    options[currentSelection].Execute();
                                    _selectedchairs.Add(options[currentSelection].chair);
                                    ChairLogic.TakeSeat(options[currentSelection].chair);
                                }
                            }
                            else
                            {
                                _selectedchairs.Remove(options[currentSelection].chair);
                                ChairLogic.RemoveSeat(options[currentSelection].chair);

                            }
                            
                            
                        }
                        break;
                    }
            }
        }
    }
    protected static void WriteAt(string s, int x, int y)
    {
        try
        {
            Console.SetCursorPosition(origCol + x, origRow + y);
            Console.Write(s);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }
    }
    static void DisplayInfo()
    {
        Console.WriteLine("---------------------------------------------------------       -------------------------------------");
        Console.WriteLine($"  Navigate using the arrow-keys\t\t\t\t\t  Total price: {Reservation.Total("nothing")} EUR\n  Select/Deselect chairs with [ENTER]\n  Press [SPACE] to check-out and Press [ESC] to go back");
        Console.WriteLine("---------------------------------------------------------       -------------------------------------");
        Console.WriteLine($"  [MAGENTA] --> 12.00 EUR");
        Console.WriteLine(legendorange);
        Console.WriteLine(legendred);
        Console.WriteLine("---------------------------------------------------------");
        for (int i = 0; i < 9; i++)
        {
            if (i == 0 || i == 4 || i == 8)
                WriteAt("+", 0, i);
            else
                WriteAt("|", 0, i);
        }
        for (int j = 0; j < 9; j++)
        {
            if (j == 0 || j == 4 || j == 8)
                WriteAt("+", 56, j);
            else
                WriteAt("|", 56, j);
        }
        for (int k = 0; k < 5; k++)
        {
            if (k == 0 || k == 4)
                WriteAt("+", 64, k);
            else
                WriteAt("|", 64, k);
        }
        for (int l = 0; l < 5; l++)
        {
            if (l == 0 || l == 4)
                WriteAt("+", 101, l);
            else
                WriteAt("|", 101, l);
        }

    }
}