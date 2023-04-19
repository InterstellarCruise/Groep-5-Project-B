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
    public static string RowNumber(ChairModel chair)
    {
        switch (chair.Row)
        {
            case "screen":
                if (chair.Roomid == 1)
                {
                    return "\t\t\tScreen\n    -----------------------------------------------";
                }
                else if (chair.Roomid == 2)
                {
                    return "\t\t\t\t    Screen\n    ------------------------------------------------------------------------";
                }
                else
                {
                    return "\t\t\t\t\t\t\t     Screen\n    ------------------------------------------------------------------------------------------------------------------------";
                }
                
            case "Continue":
                return "\n\n\n\n\r\t\t\t\b\b\b<<Continue>>";
            default:
                if (chair.Rank != 0 && chair.Column != 0)
                {
                    return $"{chair.Row}{chair.Column}";
                }
                else
                {
                    return null;
                }
        }
    }
    public static void TakeSeat(ChairModel chair)
    {
        chair.takeseat = true;
        chair.Available = false;
        Reservation.Total(chair.Rank);
    }
    public static void RemoveSeat(ChairModel chair)
    {
        if (chair.takeseat)
        {
            chair.takeseat = false;
            chair.Available = true;
            Reservation.RemoveTotal(chair.Rank);
        }

    }

}