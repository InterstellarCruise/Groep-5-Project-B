using System.Text.Json.Serialization;


public class RoomModel : IModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("rows")]
    public int Rows { get; set; }

    [JsonPropertyName("columns")]
    public int Columns { get; set; }
    //chairs = list met chair id's

    [JsonPropertyName("chairs")]
    public int Chairs { get; set; }

    public RoomModel(int id, int columns, int rows, int chairs)
    {
        Id = id;
        Rows = rows;
        Columns = columns;
        Chairs = chairs;
    }

}
