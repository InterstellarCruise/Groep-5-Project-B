using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Globalization;


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


    public void UpdateList(string date,string Time, int chairs)

    {
        List<ReservationModel> reservations = ReservationsAccess.LoadAll();
        ReservationsLogic rlogic = new ReservationsLogic();
        ShowsLogic sowlogic = new ShowsLogic();
        int resrvenumber = reservations.Count();
        int account_id = UserLogin.CurrentAccount.Id;
        ReservationModel start = rlogic.GetById(resrvenumber);
        int indexen = _bar.Count + 1;
        var start_time = sowlogic.GetById(start.Showid);
        BarModel acc = new BarModel(indexen,date,account_id,resrvenumber,start_time.Time,start.Ressedchairs.Count());

        //Find if there is already an model with the same id
        int index = _bar.FindIndex(s => s.Id == acc.Id);
        //Find if there is already an model with the same accountid
        
       
    
        
            //add new model
        _bar.Add(acc);
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


    public int? timecheck(string Time,string date,double lenght)
    {
        int account_id = UserLogin.CurrentAccount.Id;
        List<ReservationModel> reservations = ReservationsAccess.LoadAll();
        List<BarModel> barreservations = BarAccess.LoadAll();
        List<ShowModel> showmodels = ShowsAccess.LoadAll();
        List<FilmModel> filmmodels = FilmsAccess.LoadAll();
        FilmsLogic filmsLogic = new FilmsLogic();
        ShowsLogic showsLogic = new ShowsLogic();
        ReservationsLogic reservationsLogic = new ReservationsLogic();
        int? places = 40;
        int number = 1;
        foreach(BarModel l in barreservations)
        { 
            if(l.Date!=date)
            {
            
            IFormatProvider provider = CultureInfo.InvariantCulture;
            number = number + 1;
            DateTime current_time = DateTime.ParseExact(Time, "HH:mm",provider);
            DateTime time = DateTime.ParseExact(l.Start_Time, "HH:mm",provider);
            TimeSpan span = current_time.Subtract (time);
            if(reservations.Find(x => x.Id == l.Reservationid) == null){places =places;}
            else{
                var first_step = reservations.Find(x => x.Id == l.Reservationid);
                if(reservations.Find(x => x.Id == l.Reservationid) == null){places =places;}
                else
                {
                    var second_step = showmodels.Find(x => x.Id == first_step.Showid);
                    if(filmmodels.Find(x => x.Id == second_step.FilmId) == null){places =places;}
                    else{
                        var last_step = filmmodels.Find(x => x.Id == second_step.FilmId);
                        var spans = span.Hours - last_step.Length + lenght;

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

