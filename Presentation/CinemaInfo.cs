static class CinemaInfo
{
    public static void start()
    {
        // Console.WriteLine("\n");
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Information about the cinema \n--------------------------------\nCinema name: Shinema \n--------------------------------\nCinema description: Welkom in onze prachtige bioscoop. Ingericht voor u de beste filmervaring te geven.\n Blijf gerust hangen voor een drankje aan de bar om de film na te bespreken met je vrienden. \n--------------------------------\nCinema Location: Wijnhaven 107, 3011 WN in Rotterdam \n--------------------------------\n", null));
        items.Add(new MenuItem("Back", Menu.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
    }
}