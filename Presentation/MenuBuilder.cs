﻿public class MenuBuilder
{
    public static int selectedIndex = 0;
    private List<MenuItem> _items = new List<MenuItem>();
    private bool _running = true;
    private bool AdminLogged;
    public MenuBuilder(List<MenuItem> items)
    {
        _items = items;
        selectedIndex = 0;
        AdminLogged = Menu.AdminLogged;
    }
    public void DisplayMenu()
    {
        while (_running)
        {
            Console.Clear();
            for (int i = 0; i < _items.Count; i++)
            {
                if (i == selectedIndex)
                {
                    if (_items[i].Action == null)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(_items[i].DisplayText);
                        Console.ResetColor();
                    }
                    else if (!AdminLogged)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(_items[i].DisplayText);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(_items[i].DisplayText);
                        Console.ResetColor();
                    }


                }
                else
                {
                    Console.WriteLine(_items[i].DisplayText);
                }
            }
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = _items.Count - 1;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= _items.Count) selectedIndex = 0;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                if (_items[selectedIndex].RoomTimeDate != null)
                {
                    MoviePicker.movie = _items[selectedIndex].RoomTimeDate;
                }
                if (_items[selectedIndex].MovieId != null)
                {
                    AddShows.MovieId = _items[selectedIndex].MovieId;
                }
                if (_items[selectedIndex].Action != null)
                {
                    _items[selectedIndex].Execute();
                    _running = false;
                }



            }
        }
    }
}
