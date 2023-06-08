using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
public class BarLogic : BaseLogic<BarModel>
{

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    static public AccountModel? CurrentAccount { get; private set; }

    public BarLogic()
    {
        _items = BarAccess.LoadAll();
    }


    public override void UpdateList(BarModel acc)
    {

        int index = _items.FindIndex(s => s.Id == acc.Id);

        if (index != -1)
        {
            //update existing model
            _items[index] = acc;
        }
        else
        {
            //add new model
            _items.Add(acc);
        }
        BarAccess.WriteAll(_items);
    }

    public static List<BarModel> BarReservationsByAccount(int id)
    {
        List<BarModel> reservations = BarAccess.LoadAll();
        List<BarModel> MyReservations = new List<BarModel>();
        foreach (BarModel reservation in reservations)
        {

            if (reservation.Accountid == id)
            {
                MyReservations.Add(reservation);
            }
        }
        return MyReservations;

    }
    public BarModel GetById(int id)
    {
        return _items.Find(i => i.Id == id);
    }
    public void DeleteReservation(ReservationModel reservation,ShowModel show)
    {
        BarModel z = _items.Find(x => x.Accountid == reservation.Accountid && x.Start_Time == show.Time);
        BarModel newest = z;
        var numeral = reservation.Ressedchairs.Count();
        string stringy = $"{z.Amount}";
        int stringer = Convert.ToInt32(stringy);
        if(stringer - numeral<=0)
        {
            newest.Amount = 0;
            _items.RemoveAll(x => x.Accountid == reservation.Accountid);
            _items.Add(newest);
        }
        else{
        newest.Amount = (stringer - numeral);
        _items.RemoveAll(x => x.Accountid == reservation.Accountid);
        _items.Add(newest);
        }
        BarAccess.WriteAll(_items);
    }
    }

