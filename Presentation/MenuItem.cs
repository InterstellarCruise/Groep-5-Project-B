using System;

public class MenuItem
{
    public string DisplayText;
    public Action Action;
    public Chair chair;
    public string RoomTimeDate
    { get; set; }

    public MenuItem(Chair chair1, Action action) : this(chair1.RowNumber(), action) => chair = chair1;
    public MenuItem(string displayText, Action action)
    {
        DisplayText = displayText;
        Action = action;
        RoomTimeDate = "";

    }

    public void Execute() => Action();
}