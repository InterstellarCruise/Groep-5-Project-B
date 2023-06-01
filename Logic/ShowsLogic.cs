using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
public class ShowsLogic : BaseLogic<ShowModel>
{
    public static string Lines = "--------------------------------";
    public static Dictionary<string, string> ShowInfo = new Dictionary<string, string> { };

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself

    // static public FilmModel? CurrentFilm { get; private set; }

    public ShowsLogic()
    {
        _items = ShowsAccess.LoadAll();
    }


    public override void UpdateList(ShowModel show)
    {
        //Find if there is already an model with the same id
        int index = _items.FindIndex(s => s.Id == show.Id);

        if (index != -1)
        {
            //update existing model
            _items[index] = show;
        }
        else
        {
            //add new model
            _items.Add(show);
        }
        ShowsAccess.WriteAll(_items);

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

    //public ShowModel GetById(int id)
    //{
    //    return _shows.Find(i => i.Id == id);
    //}

    public ShowModel GetByFilmId(int id)
    {
        return _items.Find(i => i.FilmId == id);
    }

    public void DeleteShow(ShowModel show)
    {

        _items.Remove(show);
        ShowsAccess.WriteAll(_items);
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
    public static List<ShowModel> ShowsByDate(string date)
    {
        List<ShowModel> shows = new List<ShowModel>();
        shows = ShowsAccess.LoadAll();
        List<ShowModel> showsondate = new List<ShowModel>();
        foreach (ShowModel show in shows)
        {

            if (show.Date == date)
            {
                showsondate.Add(show);

            }
        }
        return showsondate;

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





