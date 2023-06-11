public class MenuItem
{
    public string DisplayText;
    public Action Action;
    public ChairModel chair;
    public string RoomTimeDate
    { get; set; }
    public ShowModel show { get; set; }
    public ReservationModel reservation { get; set; }
    public bool changeshow = false;
    public bool changefilm = false;
    public bool ListOfReservations = false;

    public bool SeatShow = false;
    public bool SeatRank = false;

    public bool IncomePerShow = false;
    public bool IncomePerRank = false;

    public FilmModel film { get; set; }
    public bool ChangeFilm = false;


    public MenuItem(ChairModel chair1, Action action) : this(ChairLogic.RowNumber(chair1), action) => chair = chair1;
    public MenuItem(string displayText, Action action)
    {
        DisplayText = displayText;
        Action = action;
        RoomTimeDate = "";

    }
    private int _movieId;
    public int MovieId
    {
        get { return _movieId; }
        set { _movieId = value; }
    }

    public void Execute() => Action();
}
