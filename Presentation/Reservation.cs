﻿using System;
using System.Security.Claims;

public class Reservation
{
    public static double totalprice = 0;
    public static ShowModel CurrentShow { get; set; }
    public static void Main()
    {
        switch (CurrentShow.RoomId)
        {
            case 1:
                RoomOne();
                break;
            case 2:
                RoomTwo();
                break;
            case 3:
                RoomThree();
                break;
            default:
                break;
        }

    }
    public static double Total(int rank)
    {
        switch (rank)
        {
            case 1:
                totalprice += 8;
                break;
            case 2:
                totalprice += 10;
                break;
            case 3:
                totalprice += 12;
                break;

        }
        return totalprice;
    }
    public static double RemoveTotal(int rank)
    {
        switch (rank)
        {
            case 1:
                totalprice -= 8;
                break;
            case 2:
                totalprice -= 10;
                break;
            case 3:
                totalprice -= 12;
                break;

        }
        return totalprice;
    }
    public static double Total(string nothing)
    {
        return totalprice;
    }
    public static void Print() { }
    public static void RoomOne()
    {
        List<MenuItem> items = new List<MenuItem>();
        ChairLogic chairLogic = new ChairLogic();
        List<ChairModel> chairs = chairLogic.GetByRoomId(1);
        ReservationScreenBuilder.show = CurrentShow;
        List<ChairModel> ressedchairs = GetReservations(1);
        foreach (ChairModel chair in chairs)
        {
            foreach (ChairModel ressedchair in ressedchairs)
            {
                if (ChairLogic.RowNumber(ressedchair) == ChairLogic.RowNumber(chair))
                {
                    chair.Available = false;
                }

            }
        }
        foreach (ChairModel chair in chairs)
        {
            items.Add(new MenuItem(chair, Print));
        }
        ReservationScreenBuilder.MultipleChoice(items, 2, 12);


    }
    
    public static void RoomTwo()
    {
        List<MenuItem> items = new List<MenuItem>();
        ChairLogic chairLogic = new ChairLogic();
        List<ChairModel> chairs = chairLogic.GetByRoomId(2);
        ReservationScreenBuilder.show = CurrentShow;
        List<ChairModel> ressedchairs = GetReservations(2);
        foreach (ChairModel chair in chairs)
        {
            foreach (ChairModel ressedchair in ressedchairs)
            {
                if (ChairLogic.RowNumber(ressedchair) == ChairLogic.RowNumber(chair))
                {
                    chair.Available = false;
                }
            }
        }
        foreach (ChairModel chair in chairs)
        {
            items.Add(new MenuItem(chair, Print));
        }
        ReservationScreenBuilder.MultipleChoice(items, 1, 18);
    }
    public static void RoomThree()
    {
        List<MenuItem> items = new List<MenuItem>();
        ChairLogic chairLogic = new ChairLogic();
        List<ChairModel> chairs = chairLogic.GetByRoomId(3);
        ReservationScreenBuilder.show = CurrentShow;
        List<ChairModel> ressedchairs = GetReservations(3);
        foreach (ChairModel chair in chairs)
        {
            foreach (ChairModel ressedchair in ressedchairs)
            {
                if (ChairLogic.RowNumber(ressedchair) == ChairLogic.RowNumber(chair))
                {
                    chair.Available = false;
                }

            }
        }
        foreach (ChairModel chair in chairs)
        {
            items.Add(new MenuItem(chair, Print));
        }
        ReservationScreenBuilder.MultipleChoice(items, 5, 30);
    }
    public static List<ChairModel> GetReservations(int roomId)
    {
        ReservationsLogic reservationsLogic = new ReservationsLogic();
        List<ReservationModel> reservations = reservationsLogic.GetByShowId(CurrentShow.Id, roomId);
        List<ChairModel> chairs = new List<ChairModel>();
        foreach(ReservationModel theReservation in reservations)
        {
            foreach(int i in theReservation.Ressedchairs)
            {
                ChairLogic chairlogic = new ChairLogic();
                ChairModel chair = chairlogic.GetById(i);
                chairs.Add(chair);
            }
        }
        return chairs;
    }
}