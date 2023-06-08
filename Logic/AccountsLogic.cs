using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
public class AccountsLogic :BaseLogic<AccountModel>
{

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    static public AccountModel? CurrentAccount { get; private set; }

    public AccountsLogic()
    {
        _items = AccountsAccess.LoadAll();
    }


    public override void UpdateList(AccountModel acc)
    {
        //Find if there is already an model with the same id
        int index = _items.FindIndex(s => s.Id == acc.Id);

        if (index != -1)
        {
            //update existing model
            _items[index] = acc;
        }
        else
        {
            //add new model
            _items.Add(acc);
        }
        AccountsAccess.WriteAll(_items);

    }

    //public AccountModel GetById(int id)
    //{
    //    _accounts = AccountsAccess.LoadAll();
    //    return _accounts.Find(i => i.Id == id);
    //}

    public AccountModel CheckLogin(string email, string password)
    {
        _items = AccountsAccess.LoadAll();
        if (email == null || password == null)
        {
            return null;
        }
        CurrentAccount = _items.Find(i => i.EmailAddress == email && i.Password == password);
        return CurrentAccount;
    }

    public bool NewAcc(string email, string password, string fullname)
    {

        var account = _items.FirstOrDefault(a => a.EmailAddress == email);

        if (account == null)
        {
            int index = _items.Count + 1;
            AccountModel newacc = new AccountModel(index, email, password, fullname);
            UpdateList(newacc);
            return true;
        }
        else
        {
            return false;
        }

    }
    public bool CheckEmail(string email)
    {
        var account = _items.FirstOrDefault(a => a.EmailAddress == email);
        if (account == null) return false;
        else return true;
    }
    public void RemoveAcc(string email)
    {
        var account = _items.FirstOrDefault(i => i.EmailAddress == email);
        _items.Remove(account);
        AccountsAccess.WriteAll(_items);
        _items = AccountsAccess.LoadAll();
    }
}




