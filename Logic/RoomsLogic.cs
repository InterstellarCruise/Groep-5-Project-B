using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
public class RoomsLogic
{
    private List<RoomModel> _rooms;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself

    static public RoomModel? CurrentRoom { get; private set; }

    public RoomsLogic()
    {
        _rooms = RoomsAccess.LoadAll();
    }


    public void UpdateList(RoomModel room)
    {
        //Find if there is already an model with the same id
        int index = _rooms.FindIndex(s => s.Id == room.Id);

        if (index != -1)
        {
            //update existing model
            _rooms[index] = room;
        }
        else
        {
            //add new model
            _rooms.Add(room);
        }
        RoomsAccess.WriteAll(_rooms);

    }
    public void ValidRoom(string index)
    {

    }

    public static bool AvailableCheck(List<ShowModel> showsondate, string time)
    {
        foreach (ShowModel loopedshow in showsondate)
        {
            FilmsLogic filmsLogic = new FilmsLogic();
            FilmModel Film = filmsLogic.GetById(loopedshow.FilmId);

            double filmLengthInHours = Convert.ToDouble(Film.Length);
            TimeSpan filmLength = TimeSpan.FromHours(filmLengthInHours);

            TimeSpan timeSpan = TimeSpan.Parse(loopedshow.Time);
            TimeSpan endTime = timeSpan.Add(filmLength);
            TimeSpan parsedtime = TimeSpan.Parse(time);

            if (parsedtime >= timeSpan && parsedtime <= endTime)
            {
                return false;
            }
        }
        return true;
    }

    public static bool ValidTime(int[] hm, bool roomcheck)
    {
        if (hm[0] >= 0 && hm[0] <= 23 && hm[1] >= 0 && hm[1] <= 59 && roomcheck == true)
        {
            return true;
        }
        return false;
    }


    public static void AddShow(int ID, int MovieId, int RoomId, string inputdate, string time)
    {
        ShowModel show = new ShowModel(ID, MovieId, RoomId, inputdate, time);
        ShowsAccess.Add(show);
    }
    public RoomModel GetById(int id)
    {
        return _rooms.Find(i => i.Id == id);
    }
    public void DeleteRoom(RoomModel room)
    {

        _rooms.Remove(room);
        RoomsAccess.WriteAll(_rooms);
    }
}
