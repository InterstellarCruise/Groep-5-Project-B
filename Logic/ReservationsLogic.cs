using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class ReservationsLogic
{
    private List<TheReservationModel> _reservations;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in reservation from anywhere in the program
    //private set, so this can only be set by the class itself
    static public TheReservationModel? CurrentReservation { get; private set; }

    public ReservationsLogic()
    {
        _reservations = ReservationsAccess.LoadAll();
    }


    public TheReservationModel GetById(int id)
    {
        return _reservations.Find(i => i.Id == id);
    }

}





