using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class ReservationsLogic
{
    private List<TheReservationModel> _reservations;


    static public TheReservationModel? CurrentReservation { get; private set; }

    public ReservationsLogic()
    {
        _reservations = ReservationsAccess.LoadAll();
    }


    public TheReservationModel GetById(int id)
    {
        return _reservations.Find(i => i.Id == id);
    }
    public TheReservationModel GetByAccountId(int id)
    {
        return _reservations.Find(i => i.Accountid == id);
    }
    public void UpdateList(TheReservationModel acc)
    {
        //Find if there is already an model with the same id
        int index = _reservations.FindIndex(s => s.Id == acc.Id);

        if (index != -1)
        {
            //update existing model
            _reservations[index] = acc;
        }
        else
        {
            //add new model
            _reservations.Add(acc);
        }
        ReservationsAccess.WriteAll(_reservations);

    }

    public void Newreservation(int accountid , int showid, List<int> ressedchairs)
    {
        var account = _reservations.FirstOrDefault(a => a.Accountid == accountid);
        if (account == null)
        {
            int index = _reservations.Count + 1;
            TheReservationModel newreservation = new TheReservationModel(index,showid, accountid, ressedchairs);
            UpdateList(newreservation);
        }


    }
}
