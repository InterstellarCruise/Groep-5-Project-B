public class MenuBuilder
{
    public static int selectedIndex = 0;
    private List<MenuItem> _items = new List<MenuItem>();
    private bool _running = true;
    public MenuBuilder(List<MenuItem> items)
    {
        _items = items;
        selectedIndex = 0;
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(_items[i].DisplayText);
                    Console.ResetColor();
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
                _items[selectedIndex].Execute();
                _running = false;
            }
        }
    }
}
