using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
class FilmsLogic
{
    private List<FilmModel> _films;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself

    static public FilmModel? CurrentFilm { get; private set; }
    public static string Lines = "--------------------------------";
    public static Dictionary<string, int> FilmInfo = new Dictionary<string, int> { };

    public FilmsLogic()
    {
        _films = FilmsAccess.LoadAll();
    }


    public void UpdateList(FilmModel film)
    {
        //Find if there is already an model with the same id
        int index = _films.FindIndex(s => s.Id == film.Id);

        if (index != -1)
        {
            //update existing model
            _films[index] = film;
        }
        else
        {
            //add new model
            _films.Add(film);
        }
        FilmsAccess.WriteAll(_films);

    }

    public FilmModel GetById(int id)
    {
        return _films.Find(i => i.Id == id);
    }
    public void DeleteFilm(FilmModel film)
    {

        _films.Remove(film);
        FilmsAccess.WriteAll(_films);
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
    public static void AllCurrentFilms()
    {
        List<FilmModel> Films = FilmsAccess.LoadAll();
        foreach (FilmModel film in Films)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Film ID: {film.Id}");
            Console.WriteLine($"Film Title: {film.Name} \n");
            Console.WriteLine("--------------------------------");
        }
        
    }
}




