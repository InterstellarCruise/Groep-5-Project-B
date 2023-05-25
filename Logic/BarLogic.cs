using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
public class BarLogic
{
    private List<BarModel> _bar;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    static public AccountModel? CurrentAccount { get; private set; }

    public BarLogic()
    {
        _bar = BarAccess.LoadAll();
    }
    public List<BarModel> allbarseat = BarAccess.LoadAll();


    public void UpdateList(BarModel acc)
    {
        //Find if there is already an model with the same id
        int index = _bar.FindIndex(s => s.Id == acc.Id);
        //Find if there is already an model with the same accountid
        int add = _bar.FindIndex(s => s.Accountid == acc.Accountid);
        int add2 = _bar.FindIndex(s => s.Start_Time == acc.Start_Time);
        if (add != -1 & add2 != -1 )
        {   
           var adjust = _bar.Find(x => x.Accountid == acc.Accountid && x.Start_Time == acc.Start_Time);
           acc.Amount = acc.Amount-adjust.Amount;
            _bar.RemoveAll(x => x.Accountid == acc.Accountid);
            _bar.Add(acc);
        }
        else
        {
            //add new model
            _bar.Add(acc);
        }
        BarAccess.WriteAll(_bar);
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
        return _bar.Find(i => i.Id == id);
    }
    public void DeleteReservation(ReservationModel reservation,ShowModel show)
    {
        BarModel z = _bar.Find(x => x.Accountid == reservation.Accountid && x.Start_Time == show.Time&& x.Reservationid == reservation.Id );
        BarModel newest = z;
        var numeral = reservation.Ressedchairs.Count();
        string stringy = $"{z.Amount}";
        int stringer = Convert.ToInt32(stringy);
        if(stringer - numeral<=0)
        {
            newest.Amount = 0;
            _bar.RemoveAll(x => x.Accountid == reservation.Accountid);
            _bar.Add(newest);
        }
        else{
        newest.Amount = (stringer - numeral);
        _bar.RemoveAll(x => x.Accountid == reservation.Accountid);
        _bar.Add(newest);
        }
        BarAccess.WriteAll(_bar);
    }
    }

