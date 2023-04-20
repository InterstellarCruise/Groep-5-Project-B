﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class ReservationsLogic
{
    private List<TheReservationModel> _reservations;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in reservation from anywhere in the program
    //private set, so this can only be set by the class itself

    public ReservationsLogic()
    {
        _reservations = ReservationsAccess.LoadAll();
    }


    public TheReservationModel GetById(int id)
    {
        return _reservations.Find(i => i.Id == id);
    }
    public List<TheReservationModel> GetByShowId(int showId, int roomId)
    {
        List<TheReservationModel> theReservationModels = new List<TheReservationModel>();
        foreach(var model in _reservations)
        {
            if (model.Showid == showId)
            {
                ShowsLogic showlogic = new ShowsLogic();
                ShowModel show = showlogic.GetById(model.Showid);
                if (show.RoomId == roomId)
                {
                    theReservationModels.Add(model);
                }

            }
        }
        return theReservationModels;
    }
    public void AddReservation(int showid, int accountid, List<int> chairids)
    {
        int id = _reservations.Count() + 1;
        TheReservationModel model = new TheReservationModel(id, showid, accountid, chairids);
        UpdateList(model);
    }
    public void UpdateList(TheReservationModel reservation)
    {
        //Find if there is already an model with the same id
        int index = _reservations.FindIndex(s => s.Id == reservation.Id);

        if (index != -1)
        {
            //update existing model
            _reservations[index] = reservation;
        }
        else
        {
            //add new model
            _reservations.Add(reservation);
        }
        ReservationsAccess.WriteAll(_reservations);

    }
}




