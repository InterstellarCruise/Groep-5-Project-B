public static class MenuAdmin
{
    public static void Start()
    {
        Console.WriteLine("S: Shows");
        Console.WriteLine("A: Admin Features");
        string input = Console.ReadLine().ToUpper();

        if (input == "A")
        {
            AdminFeatures.Start();
        }
        else
        {
            Console.WriteLine("Invalid Input");
        }


    }
}