using System;

public class Reservation
{
    private static double totalprice = 0;
    public static void Main()
    {
        RoomOne();
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
    }
    public static void Continue()
    {
        Console.Clear();
        Console.WriteLine("To be continued");
        Thread.Sleep(2000);
        Environment.Exit(0);
    }
    public static void RoomOne()
    {
        List<Chair> chairs = new List<Chair>();
        List<MenuItem> items = new List<MenuItem>();
        for (int i = 0; i < 3; i++)
        {
            string row = Chair.GetRow(i);
            for (int j = 1; j < 13; j++)
            {
                if (i == 0 && j <= 2 || i == 0 && j > 10)
                {
                    Chair nochair = TempChair();
                    chairs.Add(nochair);
                }
                else if (i == 0)
                {
                    Chair tempchair = new Chair(3, j, row);
                    tempchair.Available = false;
                    chairs.Add(tempchair);
                }

                if (i == 1 && j <= 1 || i == 1 && j > 11 || i == 2 && j <= 1 || i == 2 && j > 11)
                {
                    Chair nochair = TempChair();
                    chairs.Add(nochair);
                }
                else if (i == 1 || i == 2)
                {
                    Chair tempchair = new Chair(3, j, row);
                    chairs.Add(tempchair);
                }
            }
        }
        for (int i = 3; i < 11; i++)
        {
            string row = Chair.GetRow(i);
            for (int j = 1; j < 13; j++)
            {
                if (i == 3 && j > 5 && j < 8)
                {
                    Chair tempchair = new Chair(2, j, row);
                    chairs.Add(tempchair);
                }
                else if (i == 4 && j > 4 && j < 9)
                {
                    Chair tempchair = new Chair(2, j, row);
                    chairs.Add(tempchair);
                }
                else if (i > 4 && i < 9 && j > 3 && j < 10)
                {
                    if (j > 5 && j < 8)
                    {
                        Chair tempchair = new Chair(1, j, row);
                        chairs.Add(tempchair);
                    }
                    else
                    {
                        Chair tempchair = new Chair(2, j, row);
                        chairs.Add(tempchair);
                    }
                }
                else if (i == 9 && j > 4 && j < 9)
                {
                    Chair tempchair = new Chair(2, j, row);
                    chairs.Add(tempchair);
                }
                else if (i == 10 && j > 5 && j < 8)
                {
                    Chair tempchair = new Chair(2, j, row);
                    chairs.Add(tempchair);
                }

                else
                {
                    Chair tempchair = new Chair(3, j, row);
                    chairs.Add(tempchair);
                }
            }
        }
        for (int i = 11; i < 14; i++)
        {
            string row = Chair.GetRow(i);
            for (int j = 1; j < 13; j++)
            {
                if (i == 11 && j == 1 || i == 11 && j == 12 || i > 11 && j <= 2 || i > 11 && j >= 11)
                {
                    Chair nochair = TempChair();
                    chairs.Add(nochair);
                }
                else
                {
                    Chair tempchair = new Chair(3, j, row);
                    chairs.Add(tempchair);
                }
            }
        }
        foreach (Chair chair in chairs)
        {
            items.Add(new MenuItem(chair, Print));
        }
        for (int l = 0; l < 13; l++)
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
        for (int k = 1; k < 13; k++)
        {
            if (k == 6)
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
        ReservationScreenBuilder.MultipleChoice(items, 2);


    }
    public static Chair TempChair()
    {
        Chair nochair = new Chair(0, 0, null);
        return nochair;
    }
}