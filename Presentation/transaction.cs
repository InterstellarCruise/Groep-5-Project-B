static class Bar
{
    static ReservationsLogic reservationsLogic = new ReservationsLogic();
    static BarLogic barLogic = new BarLogic();

    static public void barplace(int account_id ,string date, string Time)
    {
        List<TheReservationModel> reservations = ReservationsAccess.LoadAll();
        List<BarModel> barreservations = BarAccess.LoadAll();
        int places = 40;
        int number = 1;
        foreach(BarModel l in barreservations)
        {
            number = number + 1;
            DateTime current_time = DateTime.ParseExact(Time, "HH:mm",System.Globalization.CultureInfo.CurrentCulture);
            if(l.Date == date)
            {   
                
                DateTime time = DateTime.ParseExact(l.Start_Time, "HH:mm",System.Globalization.CultureInfo.CurrentCulture);
                var hours = (current_time - time).TotalHours;
            
                var hourz = (time - current_time ).TotalHours;

                if(hours>=0 & hours<=2 | hourz >=0 & hourz<=2)
                {
                    places = places - 1;
                }
            }
        }
        if(places>=1)
        {
            Console.WriteLine("you can make a bar reservation do you wish to make one y/n");
            string? answer = Console.ReadLine();
            if(answer == "y")
            {
                var new_bar = new BarModel(number,date ,account_id,Time);
                barLogic.UpdateList(new_bar);
            }
        
        }
        List<MenuItem> items = new List<MenuItem>();
        items.Add(new MenuItem("Back", DatePicker.showChoose));
        items.Add(new MenuItem("Main menu", Menu.Start));
        MenuBuilder menu = new MenuBuilder(items);
        menu.DisplayMenu();
        int milliseconds = 2000;
        Thread.Sleep(milliseconds);
        Console.Clear();
    }
    
}