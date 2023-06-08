using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;



public class ChairLogic : BaseLogic<ChairModel>
{


    public ChairLogic()
    {
        _items = ChairsAccess.LoadAll();

        ChairsAccess.WriteAll(_items);
    }

    public override void UpdateList(ChairModel c)
    {
        //Find if there is already an model with the same id
        int index = _items.FindIndex(s => s.Id == c.Id);

        if (index != -1)
        {
            //update existing model
            _items[index] = c;
        }
        else
        {
            //add new model
            _items.Add(c);
        }
        ChairsAccess.WriteAll(_items);

    }
    //public ChairModel GetById(int id)
    //{
    //    return _items.Find(i => i.Id == id);
    //}

    public ChairModel GetByCol(int id)
    {
        return _items.Find(i => i.Id == id);
    }
    public List<ChairModel> GetByRoomId(int roomId)
    {
        List<ChairModel> roomschairs = new List<ChairModel>();
        foreach(ChairModel c in _items)
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
    public static void DeleteChair(int chairid)
    {
        var currchair = _items.FirstOrDefault(i => i.Id == chairid);
        _items.Remove(currchair);
        ChairsAccess.WriteAll(_items);
        _items = ChairsAccess.LoadAll();
    }

    public static int OccupiedSeats(int id, int rank)
    {
        List<ReservationModel> Reservation = ReservationsLogic.AllReservation();
        List<int> chairs = new List<int>();
        List<int> rankChair = new List<int>();
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
                            rankChair.Add(chair.Id);
                        }
                        if (rank == 2)
                        {

                            rankChair.Add(chair.Id);

                        }
                        if (rank == 3)
                        {
                            rankChair.Add(chair.Id);

                        }
                    }
                }

            }
        }
        return rankChair.Count;
    }

}