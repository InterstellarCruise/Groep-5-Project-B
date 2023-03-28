public class MenuItem
{
    public string DisplayText;
    Action Action;
    public MenuItem(string displayText, Action action)
    {
        DisplayText = displayText;
        Action = action;
    }
    public void Execute() => Action();
}