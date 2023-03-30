public class MenuItem
{
    public string DisplayText;
    public Action Action;
    private string _roomTimeDate;
    public string RoomTimeDate
    {
        get { return _roomTimeDate; }
        set { _roomTimeDate = value; }
    }

    public MenuItem(string displayText, Action action)
    {
        DisplayText = displayText;
        Action = action;
        _roomTimeDate = "";
    }
    public void Execute() => Action();
}