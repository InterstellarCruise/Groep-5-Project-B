using System.Text.Json.Serialization;

public class ChairModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("roomid")]
    public int Roomid { get; set; }

    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    [JsonPropertyName("column")]
    public int Column { get; set; }

    [JsonPropertyName("row")]
    public string Row { get; set; }

    public ChairModel(int id, int roomid, int rank, int column, string row)
    {
        Id = id;
        Roomid = roomid;
        Rank = rank;
        Column = column;
        Row = row;
    }

}