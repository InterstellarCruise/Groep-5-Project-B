using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
public class FilmsLogic : BaseLogic<FilmModel>
{

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself

    static public FilmModel? CurrentFilm { get; private set; }
    public static string Lines = "--------------------------------";
    public static Dictionary<string, int> FilmInfo = new Dictionary<string, int> { };

    public FilmsLogic()
    {
        _items = FilmsAccess.LoadAll();
    }


    public override void UpdateList(FilmModel film)
    {
        //Find if there is already an model with the same id
        int index = _items.FindIndex(s => s.Id == film.Id);

        if (index != -1)
        {
            //update existing model
            _items[index] = film;
        }
        else
        {
            //add new model
            _items.Add(film);
        }
        FilmsAccess.WriteAll(_items);

    }

    //public FilmModel GetById(int id)
    //{
    //    return _items.Find(i => i.Id == id);
    //}
    public void DeleteFilm(FilmModel film)
    {

        _items.Remove(film);
        FilmsAccess.WriteAll(_items);
        _items = FilmsAccess.LoadAll();
    }
    public List<FilmModel> GetFilms()
    {
        _items = FilmsAccess.LoadAll();
        return _items;
    }

    public static int LastID()
    {
        List<FilmModel> _films = FilmsAccess.LoadAll();
        int ID = _films.Count;
        return ID;
    }

    public static void AllFilms(List<FilmModel> films)
    {
        foreach (FilmModel film in films)
        {


            FilmsLogic filmsLogic = new FilmsLogic();
            string key = $"Film name: {film.Name}.";
            int value = film.Id;
            if (!FilmInfo.ContainsKey(key))
            {
                FilmInfo.Add(key, value);
            }
        }
    }
    public static List<FilmModel> AllCurrentFilms()
    {
        _items = FilmsAccess.LoadAll();
        return _items;

    }

    public static void AddFilm(int ID, string Name, string Description, int AgeLimit, double length, List<string> Genres)
    {
        FilmModel film = new FilmModel(ID, Name, Description, AgeLimit, length, Genres);
        FilmsAccess.Add(film);

    }




}