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

    public ShowModel GetById(int id)
    {
        return _shows.Find(i => i.Id == id);
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
}




