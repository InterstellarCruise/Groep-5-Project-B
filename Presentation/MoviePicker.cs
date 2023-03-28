static class MoviePicker
{

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start(string movie)
    {
        //Given data: The room number of the show and the date and time of the show.
        string[] data = movie.Split();
        Console.WriteLine($"Room: {data[0]}, Date: {data[2]}, Time: {data[1]},");

    }
}