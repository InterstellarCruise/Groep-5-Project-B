using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
public class RoomsLogic : BaseLogic<RoomModel>
{
    private List<RoomModel> _items;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself

    static public RoomModel? CurrentRoom { get; private set; }

    public RoomsLogic()
    {
        _items = RoomsAccess.LoadAll();
    }


    public override void UpdateList(RoomModel room)
    {
        //Find if there is already an model with the same id
        int index = _items.FindIndex(s => s.Id == room.Id);

        if (index != -1)
        {
            //update existing model
            _items[index] = room;
        }
        else
        {
            //add new model
            _items.Add(room);
        }
        RoomsAccess.WriteAll(_items);

    }

    //public RoomModel GetById(int id)
    //{
    //    return _items.Find(i => i.Id == id);
    //}
    public void DeleteRoom(RoomModel room)
    {

        _items.Remove(room);
        RoomsAccess.WriteAll(_items);
    }
}
