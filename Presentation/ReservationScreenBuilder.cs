﻿public class ReservationScreenBuilder
{
    private static bool _running = true;
    private static List<Chair> _selectedchairs = new List<Chair>();
    public static string selchairs = "";
    protected static int origRow;
    protected static int origCol;
    public static void MultipleChoice(List<MenuItem> options)
    {
        const int startX = 15;
        const int startY = 12;
        const int optionsPerLine = 11;
        const int spacingPerLine = 4;
        origRow = 0;
        origCol = Console.CursorLeft;
        string legendred = "  [RED] --> Not available";
        string legendorange = "  [ORANGE] --> Already selected";


        int currentSelection = 0;

        ConsoleKey key;

        Console.CursorVisible = false;

        while (_running)
        {


            Console.Clear();
            Console.WriteLine("---------------------------------------------------             -------------------------------------");
            Console.WriteLine($"  Navigate using the arrow-keys\t\t\t\t\t  Total price: {Reservation.Total("nothing")} EUR\n  Select/Deselect chairs with [ENTER]\n  To continue use the down arrow-key on column [6]");
            Console.WriteLine("---------------------------------------------------             -------------------------------------");
            Console.WriteLine($"  [MAGENTA] --> Available\t\t\t\t\t  Selected Chairs:{selchairs}");
            Console.WriteLine(legendorange);
            Console.WriteLine(legendred);
            Console.WriteLine("---------------------------------------------------             -------------------------------------");
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
                    WriteAt("+", 50, j);
                else
                    WriteAt("|", 50, j);
            }
            for (int k = 0; k < 9; k++)
            {
                if (k == 0 || k == 4 || k == 8)
                    WriteAt("+", 64, k);
                else
                    WriteAt("|", 64, k);
            }
            for (int l = 0; l < 9; l++)
            {
                if (l == 0 || l == 4 || l == 8)
                    WriteAt("+", 101, l);
                else
                    WriteAt("|", 101, l);
            }


            for (int i = 0; i < options.Count; i++)
            {
                Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                if (i == currentSelection)
                {

                    if (!options[currentSelection].chair.Available)
                    {

                        if (options[currentSelection].chair.takeseat)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                Console.Write(options[i].chair.RowNumber());

                Console.ResetColor();
            }

            key = Console.ReadKey(true).Key;

            switch (key)
            {
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
                            if (!options[currentSelection].chair.Available && !options[currentSelection].chair.takeseat)
                            {
                                Console.WriteLine($"\n\n\t\t\t\b\b\b<<Chair: {options[currentSelection].chair.RowNumber()} is not available>>");
                                Thread.Sleep(1500);
                            }
                            else
                            {
                                if (!_selectedchairs.Contains(options[currentSelection].chair))
                                {
                                    if (options[currentSelection].chair.RowNumber() == "Continue")
                                    {
                                        options[currentSelection].Execute();
                                        _running = false;
                                    }
                                    else
                                    {
                                        options[currentSelection].Execute();
                                        if (options[currentSelection].chair.Row != "Selected Chairs: " && options[currentSelection].chair.Row != "screen" && options[currentSelection].chair.Row != "Total cost: ")
                                        {
                                            _selectedchairs.Add(options[currentSelection].chair);
                                            options[currentSelection].chair.TakeSeat();
                                            int le = legendorange.Length;
                                            int re = legendred.Length;
                                            if (selchairs.Length < 17)
                                                selchairs = selchairs + $"{options[currentSelection].chair.RowNumber()}/";
                                            else if (le > 40 && le < 70)
                                            {
                                                legendorange = legendorange + $"{options[currentSelection].chair.RowNumber()}/";
                                            }
                                            else if (le > 70 && re < 30)
                                            {
                                                legendred = legendred + $"\t\t\t\t\t  {options[currentSelection].chair.RowNumber()}/";
                                            }
                                            else if (re > 30 && re < 70)
                                                legendred = legendred + $"{options[currentSelection].chair.RowNumber()}/";
                                            else if (selchairs.Length > 17)
                                                legendorange = legendorange + $"\t\t\t\t\t  {options[currentSelection].chair.RowNumber()}/";


                                        }


                                    }

                                }
                                else
                                {
                                    if (options[currentSelection].chair.Row != "screen" && options[currentSelection].chair.Row != "Total cost: ")
                                    {
                                        _selectedchairs.Remove(options[currentSelection].chair);
                                        string rownumb = options[currentSelection].chair.RowNumber();
                                        options[currentSelection].chair.RemoveSeat();
                                        selchairs = selchairs.Replace($"{rownumb}/", "");
                                        Console.WriteLine($"\n\n\t\t        <<Chair: {rownumb} deselected>>");
                                        Thread.Sleep(1500);
                                    }

                                }
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
}