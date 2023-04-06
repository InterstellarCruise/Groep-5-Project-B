using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;



public class ChairLogic
{


    private List<ChairModel> _chairs;
    public ChairLogic()
    {
        _chairs = ChairsAccess.LoadAll();

        int counter = 1;
        foreach (ChairModel c in _chairs)
        {
            c.Id = counter;
            //UpdateList(c);
            counter++;
        }
        ChairsAccess.WriteAll(_chairs);
    }

    public void UpdateList(ChairModel c)
    {
        //Find if there is already an model with the same id
        int index = _chairs.FindIndex(s => s.Id == c.Id);

        if (index != -1)
        {
            //update existing model
            _chairs[index] = c;
        }
        else
        {
            //add new model
            _chairs.Add(c);
        }
        ChairsAccess.WriteAll(_chairs);

    }
    public ChairModel GetById(int id)
    {
        return _chairs.Find(i => i.Id == id);
    }
    public List<ChairModel> GetByRoomId(int roomId)
    {
        List<ChairModel> roomschairs = new List<ChairModel>();
        foreach(ChairModel c in _chairs)
        {
            if (c.Roomid == roomId)
            {
                roomschairs.Add(c);
            }
        }
        return roomschairs;
    }


}