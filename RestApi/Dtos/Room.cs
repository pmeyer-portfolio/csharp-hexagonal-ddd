namespace Neusta.Workshop.Buchungssystem.RestApi.Dtos;

public class Room
{
    public Guid? Id { get; set; }

    public string Name { get; set; }

    public string Nummer { get; set; }

    public IList<Guid> PersonIds { get; set; }
}