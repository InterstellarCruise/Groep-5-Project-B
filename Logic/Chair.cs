public class Chair
{
    public int Rank, Number;
    public string Row;
    public bool Available;
    public bool takeseat;
    private static List<string> rows = new List<string>
    {
        "A",
        "B",
        "C",
        "D",
        "E",
        "F",
        "G",
        "H",
        "I",
        "J",
        "K",
        "L",
        "M",
        "N",
        "O",
        "P",
        "R",
        "S",
        "T",
        "U",
        "V",
        "W",
        "X",
        "Y",
        "Z"
    };
    public Chair(int rank, int number, string row)
    {
        Rank = rank;
        Number = number;
        Row = row;
        Available = true;
        takeseat = false;
    }
    public string RowNumber()
    {
        switch (Row)
        {
            case "screen":
                return "\b\b\b\bScreen\n    -----------------------------------------------";
            case "Continue":
                return "\n\n\n\n\r\t\t\t\b\b\b<<Continue>>";
            default:
                if (Rank != 0 && Number != 0)
                {
                    return $"{Row}{Number}";
                }
                else
                {
                    return null;
                }
        }
    }
    public void TakeSeat()
    {
        takeseat = true;
        Available = false;
        Reservation.Total(Rank);
    }
    public void RemoveSeat()
    {
        if (takeseat)
        {
            takeseat = false;
            Available = true;
            Reservation.RemoveTotal(Rank);
        }

    }
    public static string GetRow(int index) => rows[index];
}
