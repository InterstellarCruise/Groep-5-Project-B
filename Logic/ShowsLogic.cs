using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
class ShowsLogic
{
    private List<ShowModel> _shows;
    public static string Lines = "--------------------------------";
    public static Dictionary<string, string> ShowInfo = new Dictionary<string, string> { };

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself

    // static public FilmModel? CurrentFilm { get; private set; }

    public ShowsLogic()
    {
        _shows = ShowsAccess.LoadAll();
    }


    public void UpdateList(ShowModel show)
    {
        //Find if there is already an model with the same id
        int index = _shows.FindIndex(s => s.Id == show.Id);

        if (index != -1)
        {
            //update existing model
            _shows[index] = show;
        }
        else
        {
            //add new model
            _shows.Add(show);
        }
        ShowsAccess.WriteAll(_shows);

    }

    public static bool MoviesByDate(List<ShowModel> shows, string date, bool emptyOrNot)
    {
        foreach (ShowModel show in shows)
        {

            if (show.Date == date)
            {
                emptyOrNot = true;
                FilmsLogic filmsLogic = new FilmsLogic();
                FilmModel film = filmsLogic.GetById(show.FilmId);
                string key = $"Room: {show.RoomId}, Date: {show.Date}, Time: {show.Time}, Movie name: {film.Name}.";
                string value = $"{show.RoomId} {show.Time} {show.Date}";
                if (!ShowInfo.ContainsKey(key))
                {
                    ShowInfo.Add(key, value);
                }

            }
        }
        return emptyOrNot;

    }

    public static ShowModel ChooseShow(List<ShowModel> shows, string movie)
    {
        string[] input = movie.Split(' ');



        //Put the chosen movie into a variable called show.
        ShowModel show = null;
        try
        {
            show = shows.Find(i => i.RoomId == Convert.ToDouble(input[0]) && i.Time == input[1]);
        }
        catch (Exception)
        {
            shows = null;
        }
        return show;

    }

    public ShowModel GetById(int id)
    {
        return _shows.Find(i => i.Id == id);
    }

    public ShowModel GetByFilmId(int id)
    {
        return _shows.Find(i => i.FilmId == id);
    }

    public void DeleteShow(ShowModel show)
    {

        _shows.Remove(show);
        ShowsAccess.WriteAll(_shows);
    }

    public bool ValidShowDate(string date)
    {
        DateTime tempObject;

        return DateTime.TryParseExact(date, "yyyy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempObject);
    }

    public bool ValidShowTime(string time)
    {
        DateTime tempObject;

        return DateTime.TryParseExact(time, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempObject);
    }

    public static int LastID()
    {
        List<ShowModel> _shows = ShowsAccess.LoadAll();
        int ID = _shows.Count;
        return ID;
    }
    public static List<ShowModel> AllCurrentShows()
    {
        // List<ShowModel> Shows = ShowsAccess.LoadAll();
        // foreach (ShowModel show in Shows)
        // {
        //     Console.WriteLine("--------------------------------");
        //     Console.WriteLine($"Show ID: {show.Id}");
        //     Console.WriteLine($"Room: {show.RoomId}");
        //     Console.WriteLine($"Film: {show.FilmId}");
        //     Console.WriteLine("--------------------------------");
        // }
        List<ShowModel> Shows = ShowsAccess.LoadAll();
        return Shows;
    }

    public static void AllCurrShows()
    {
        List<ShowModel> Shows = ShowsAccess.LoadAll();
        foreach (ShowModel show in Shows)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Show ID: {show.Id}");
            Console.WriteLine($"Room: {show.RoomId}");
            Console.WriteLine($"Film: {show.FilmId}");
            Console.WriteLine("--------------------------------");
        }
    }
}





