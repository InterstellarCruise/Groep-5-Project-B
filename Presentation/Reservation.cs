public class Reservation
{
    private static double totalprice = 0;
    public static void Main()
    {
        List<Chair> chairs = new List<Chair>();
        List<MenuItem> items = new List<MenuItem>();
        int rankcounter = 1;
        for (int i = 0; i <= 3; i++)
        {
            string row = Chair.GetRow(i);
            for (int j = 1; j <= 11; j++)
            {
                if (row == "D")
                {
                    if (j > 3 && j < 9)
                    {
                        Chair tempchair = new Chair(rankcounter, j, row);
                        tempchair.Available = false;
                        chairs.Add(tempchair);
                    }
                    else
                    {
                        Chair nochair = new Chair(0, 0, null);
                        chairs.Add(nochair);
                    }


                }
                else
                {
                    Chair tempchair = new Chair(rankcounter, j, row);
                    chairs.Add(tempchair);
                }

            }
            rankcounter++;
        }
        foreach (Chair chair in chairs)
        {
            items.Add(new MenuItem(chair, Print));
        }
        for (int l = 0; l < 9; l++)
        {
            if (l == 5)
            {
                Chair continue1 = new Chair(0, 0, "Continue");
                items.Add(new MenuItem(continue1, Continue));
            }
            else
            {
                Chair dummychair = new Chair(0, 0, null);
                items.Add(new MenuItem(dummychair, Nothing));
            }

        }
        for (int k = 0; k < 10; k++)
        {
            if (k == 5)
            {
                Chair screen = new Chair(0, 0, "screen");
                items.Add(new MenuItem(screen, Nothing));
            }
            else
            {

                Chair dummychair = new Chair(0, 0, null);
                items.Add(new MenuItem(dummychair, Nothing));
            }
        }
        ReservationScreenBuilder.MultipleChoice(items);


    }
    public static void Nothing() { }
    public static double Total(int rank)
    {
        switch (rank)
        {
            case 1:
                totalprice += 7.50;
                break;
            case 2:
                totalprice += 10.50;
                break;
            case 3:
                totalprice += 12.50;
                break;

        }
        return totalprice;
    }
    public static double RemoveTotal(int rank)
    {
        switch (rank)
        {
            case 1:
                totalprice -= 7.50;
                break;
            case 2:
                totalprice -= 10.50;
                break;
            case 3:
                totalprice -= 12.50;
                break;

        }
        return totalprice;
    }
    public static double Total(string nothing)
    {
        return totalprice;
    }
    public static void Print()
    {
        Console.WriteLine("\n\n\t\t\t   <<Chair selected>>");

        Thread.Sleep(1500);
    }
    public static void Continue()
    {
        Console.Clear();
        Console.WriteLine("To be continued");
        Thread.Sleep(2000);
        Environment.Exit(0);
    }
}