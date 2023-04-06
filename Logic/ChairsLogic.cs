using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
class ChairsLogic
{
    private List<ChairModel> _chairs;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself

    static public ChairModel? CurrentChair { get; private set; }

    public ChairsLogic()
    {
        _chairs = ChairsAccess.LoadAll();
    }


    public void UpdateList(ChairModel chair)
    {
        //Find if there is already an model with the same id
        int index = _chairs.FindIndex(s => s.Id == chair.Id);

        if (index != -1)
        {
            //update existing model
            _chairs[index] = chair;
        }
        else
        {
            //add new model
            _chairs.Add(chair);
        }
        ChairsAccess.WriteAll(_chairs);

    }

    public ChairModel GetById(int id)
    {
        return _chairs.Find(i => i.Id == id);
    }
    public void DeleteChair(ChairModel chair)
    {

        _chairs.Remove(chair);
        ChairsAccess.WriteAll(_chairs);
    }
}
