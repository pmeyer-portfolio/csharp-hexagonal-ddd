namespace Neusta.Workshop.Buchungssystem.RestApi.Dtos;

public class Room
{
    public Guid? Id { get; set; }

    public string Name { get; set; }

    public string Nummer { get; set; }

    public IList<string> Personen { get; set; } = new List<string>();
}