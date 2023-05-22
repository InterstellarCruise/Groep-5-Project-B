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


    public void UpdateList(BarModel acc)
    {
        //Find if there is already an model with the same id
        int index = _bar.FindIndex(s => s.Id == acc.Id);
        //Find if there is already an model with the same accountid
        int add = _bar.FindIndex(s => s.Accountid == acc.Accountid);
        int add2 = _bar.FindIndex(s => s.Start_Time == acc.Start_Time);
        if (add != -1 & add2 != -1 )
        {   
           var adjust = _bar.Find(x => x.Accountid == acc.Accountid);
           acc.Amount = acc.Amount + adjust.Amount;
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
}