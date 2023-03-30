using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
public class FilmsLogic
{
    private List<FilmModel> _films  = new List<FilmModel>();

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself

    static public FilmModel? CurrentFilm { get; private set; }

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
    // public AccountModel CheckLogin(string email, string password)
    // {
    //     if (email == null || password == null)
    //     {
    //         return null;
    //     }
    //     CurrentAccount = _accounts.Find(i => i.EmailAddress == email && i.Password == password);
    //     return CurrentAccount;
    // }

    public void ShowFilm(int id)
    {
        foreach(var i in _films)
        {
            if(id == i.Id)
            {
                Console.WriteLine($"\nMovie Name: {i.Name}\nDescription: {i.Description}\nAge limit: {i.AgeLimit}");
                foreach(var gen in i.Genre)
                {
                    Console.WriteLine($"Genres: {gen}");
                }
            }
        }
    }

    // public void DeleteShow(FilmModel film)
    // {
    //     _films.Remove(film);
    //     ShowsAccess.WriteAll(_films);
    // }

}




