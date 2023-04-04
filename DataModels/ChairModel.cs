using System.Text.Json.Serialization;


public class ChairModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("roomid")]
    public int Room { get; set; }

    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    [JsonPropertyName("row")]
    public string Row { get; set; }

    [JsonPropertyName("column")]
    public int Column { get; set; }


    public ChairModel(int id, int room, int rank, int column, string row)
    {
        Id = id;
        Room = room;
        Rank = rank;
        Column = column;
        Row = row;
    }

}
