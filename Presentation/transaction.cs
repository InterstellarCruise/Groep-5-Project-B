static class Transaction
{
    static ReservationsLogic reservationsLogic = new ReservationsLogic();
    static public System.Action reservation(int accountid, int showid, List<int> ressedchiars)
    {
        reservationsLogic.Newreservation(accountid, showid, ressedchiars);
        return default;

    }

    static public System.Action Bar()
    {
        

    }
    
}