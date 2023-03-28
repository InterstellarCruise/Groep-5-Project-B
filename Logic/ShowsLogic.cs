using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
class ShowsLogic
{
    private List<ShowModel> _shows;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself

    static public ShowModel? CurrentShow { get; private set; }

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
                Console.WriteLine($"Room: {show.RoomId}, Date: {show.Date}, Time: {show.Time}, Movie name: {film.Name}.");
            }
        }
        return emptyOrNot;

    }

    public static ShowModel ChooseShow(List<ShowModel> shows, string movie)
    {
        string[] input = movie.Split(' ');
        Console.WriteLine(Convert.ToInt32(input[0]));
        Console.WriteLine(input[1]);

        //Put the chosen movie into a variable called show.
        ShowModel show = shows.Find(i => i.RoomId == Convert.ToInt32(input[0]) && i.Time == input[1]);
        return show;

    }

    public ShowModel GetById(int id)
    {
        return _shows.Find(i => i.Id == id);
    }

    public void GetAllShows()
    {  
        foreach(var i in _shows)
        {
           Console.WriteLine($"Show: {i.Id}, Date: {i.Date}, Film-Id: {i.FilmId}");
        }
    }

    public void ShowSpecifShow(int id)
    {
        foreach(var i in _shows)
        {
            if(id == i.Id)
            {
                int film_id = i.FilmId;

                var film = new FilmsLogic();
                film.ShowFilm(film_id);
                Console.WriteLine($"Show: {i.Id}, Date: {i.Date}, Time: {i.Time}, Room: {i.RoomId}");
            }
        }
    }

    public void ShowToFilm(int id, int choice)
    {
        foreach(var i in _shows)
        {
            if(id == i.Id)
            {
                int film_id = i.FilmId;
                var film = new FilmsLogic();
                film.ChangeFilmFeatures(film_id, choice);
            }
        }
    }

    public void ChangeShowFeatures(int id, int choice)
    {
        if(choice == 1)
        {
            _shows.Find(i => i.Id == id);
            Console.WriteLine("Please fill in a new date");
            string newDate = Console.ReadLine();
            
        }

        if(choice == 2)
        {

        }
        
        if(choice == 7)
        {

        }
    }
}




