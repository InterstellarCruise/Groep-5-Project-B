using System.Text.Json.Serialization;


public class ShowModel : IModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("filmId")]
    public int FilmId { get; set; }

    [JsonPropertyName("roomId")]
    public int RoomId { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; }


    public ShowModel(int id, int filmId, int roomId, string date, string time)
    {
        Id = id;
        FilmId = filmId;
        RoomId = roomId;
        Date = date;
        Time = time;
    }

}
