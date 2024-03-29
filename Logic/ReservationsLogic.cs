﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ReservationsLogic : BaseLogic<ReservationModel>
{

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in reservation from anywhere in the program
    //private set, so this can only be set by the class itself

    public ReservationsLogic()
    {
        _items = ReservationsAccess.LoadAll();
    }


    //public ReservationModel GetById(int id)
    //{
    //    return _items.Find(i => i.Id == id);
    //}
    public List<ReservationModel> GetByShowId(int showId, int roomId)
    {
        List<ReservationModel> theReservationModels = new List<ReservationModel>();
        foreach (var model in _items)
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

    public override void UpdateList(ReservationModel reservation)
    {
        //Find if there is already an model with the same id
        int index = _items.FindIndex(s => s.Id == reservation.Id);

        if (index != -1)
        {
            //update existing model
            _items[index] = reservation;
        }
        else
        {
            //add new model
            _items.Add(reservation);
        }
        ReservationsAccess.WriteAll(_items);

    }

    public static List<ReservationModel> ReservationsByAccount(int id)
    {
        List<ReservationModel> reservations = ReservationsAccess.LoadAll();
        List<ReservationModel> MyReservations = new List<ReservationModel>();
        foreach (ReservationModel reservation in reservations)
        {

            if (reservation.Accountid == id)
            {
                MyReservations.Add(reservation);
            }
        }
        return MyReservations;
    }

    public void DeleteReservation(ReservationModel reservation)
    {
        ReservationModel x = GetById(reservation.Id);
        _items.Remove(x);
        ReservationsAccess.WriteAll(_items);
    }

    public IEnumerable<ReservationModel> GetByShowIdList(int id)
    {
        var reservation = _items.Where(i => i.Showid == id);
        return reservation;

    }
    public ReservationModel FindByShowId(int id)
    {
        return _items.Find(i => i.Showid == id);
    }

    public static double IncomeShow(int id)
    {
        double totalAmount = 0;
        foreach (ReservationModel res in _items)
        {
            if (id == res.Showid)
            {
                double amount = res.Amount;
                totalAmount += amount;

            }
        }
        return totalAmount;

    }


    public static double IncomeRank(int id, int rank)
    {
        List<ReservationModel> Reservation = ReservationsAccess.LoadAll();
        List<int> chairs = new List<int>();

        double totalAmount = 0;
        foreach (ReservationModel res in Reservation)
        {
            if (id == res.Showid)
            {
                chairs = res.Ressedchairs;
                ChairLogic chairLogic = new ChairLogic();
                foreach (var chairid in chairs)
                {
                    var chair = chairLogic.GetById(chairid);

                    if (chair.Rank == rank)
                    {
                        if (rank == 1)
                        {
                            double rankAmount = 12;
                            totalAmount += rankAmount;


                        }
                        if (rank == 2)
                        {
                            double rankAmount = 10;
                            totalAmount += rankAmount;
                            

                        }
                        if (rank == 3)
                        {
                            double rankAmount = 8;
                            totalAmount += rankAmount;
                            

                        }
                    }
                }

            }
        }
        return totalAmount;

    }

    public static double IncomeDate(string date)
    {
        ReservationsLogic reservationsLogic = new ReservationsLogic();
        double totalAmount = 0;
        List<ShowModel> Shows = ShowsAccess.LoadAll();
        foreach (ShowModel show in Shows)
        {
            if (date == show.Date)
            {
                int resid = show.Id;
                var res = reservationsLogic.FindByShowId(resid);
                double amount = res.Amount;
                totalAmount += amount;

            }
        }
        return totalAmount;
    }
    public static List<ReservationModel> AllReservation()
    {
        
        return _items;
    }

}





