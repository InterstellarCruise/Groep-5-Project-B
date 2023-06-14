using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Globalization;


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
    public List<BarModel> allbarseat = BarAccess.LoadAll();


    public void UpdateList(string date,string Time, int chairs)

    {
        List<ReservationModel> reservations = ReservationsAccess.LoadAll();
        ReservationsLogic rlogic = new ReservationsLogic();
        ShowsLogic sowlogic = new ShowsLogic();
        int resrvenumber = reservations.Count();
        int account_id = UserLogin.CurrentAccount.Id;
        ReservationModel start = rlogic.GetById(resrvenumber);
        int indexen = _items.Count + 1;
        var start_time = sowlogic.GetById(start.Showid);
        BarModel acc = new BarModel(indexen,date,account_id,resrvenumber,start_time.Time,start.Ressedchairs.Count());

        //Find if there is already an model with the same id
        int index = _items.FindIndex(s => s.Accountid == acc.Accountid&& s.Date== acc.Date&& s.Start_Time == s.Start_Time );
        //Find if there is already an model with the same accountid

        if (index != -1)
        {
            //update existing model
            acc.Id = _items[index].Id;
            _items[index] = acc;
            BarAccess.WriteAll(_items);
        }
        else
        {
        
            //add new model
        _items.Add(acc);
        BarAccess.WriteAll(_items);
        }
    }
    public override void UpdateList(BarModel barmodel)
    {
        //Find if there is already an model with the same id
        int index = _items.FindIndex(s => s.Id == barmodel.Id);

        if (index != -1)
        {
            //update existing model
            _items[index] = barmodel;
        }
        else
        {
            //add new model
            _items.Add(barmodel);
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
    //public BarModel GetById(int id)
    //{
    //    return _items.Find(i => i.Id == id);
    //}
    public void DeleteReservation(ReservationModel reservation,ShowModel show)
    {
        BarModel z = _items.Find(x => x.Accountid == reservation.Accountid && x.Start_Time == show.Time&& x.Reservationid == reservation.Id );
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


    public int? timecheck(string Time,string date,double lenght)
    {
        int account_id = UserLogin.CurrentAccount.Id;
        List<ReservationModel> reservations = ReservationsAccess.LoadAll();
        List<BarModel> barreservations = BarAccess.LoadAll();
        List<ShowModel> showmodels = ShowsAccess.LoadAll();
        List<FilmModel> filmmodels = FilmsAccess.LoadAll();
        int? places = 40;
        int number = 1;
        foreach(BarModel l in barreservations)
        { 
            if(l.Date==date)
            {
            
            IFormatProvider provider = CultureInfo.InvariantCulture;
            number = number + 1;
            var splits = Time.Split(":");
            if(splits[1].Count()==1 )
            {
                Time = Time + "0";
            }
            if(splits[1].Count()==0 )
            {
                Time = Time + "00";
            }
            if(Time.Count()<2 || Time.Count()>5)
            {
                return 40;
            }
            DateTime current_time = DateTime.ParseExact(Time, "H:mm",provider);
            DateTime time = DateTime.ParseExact(l.Start_Time, "H:mm",provider);
            TimeSpan span = current_time.Subtract (time);
            if(reservations.Find(x => x.Id == l.Reservationid) == null){places = places;}
            else{
                var first_step = reservations.Find(x => x.Id == l.Reservationid);
                if(reservations.Find(x => x.Id == l.Reservationid) == null)
                    {places = places;}
                else
                {
                    var second_step = showmodels.Find(x => x.Id == first_step.Showid);
                    if(filmmodels.Find(x => x.Id == second_step.FilmId) == null)
                        {places =places;}
                    else{
                        var last_step = filmmodels.Find(x => x.Id == second_step.FilmId);
                        double spans = span.Hours - last_step.Length + lenght;

                        if(spans>=0 & spans<=lenght)
                        {
                            if(l.Amount > 0){
                            places = places - l.Amount;
                            }
                        }
                                    
                        }
        
                }
                }
            
        }
        
    }
    return places;
    }
}

