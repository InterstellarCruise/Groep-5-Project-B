public class MenuItem
{
    public string DisplayText;
    public Action Action;
    public ChairModel chair;
    public string RoomTimeDate
    { get; set; }
    public ShowModel show { get; set; }

    public MenuItem(ChairModel chair1, Action action) : this(ChairLogic.RowNumber(chair1), action) => chair = chair1;
    public MenuItem(string displayText, Action action)
    {
        DisplayText = displayText;
        Action = action;
        RoomTimeDate = "";

    }

    public void Execute() => Action();
}
