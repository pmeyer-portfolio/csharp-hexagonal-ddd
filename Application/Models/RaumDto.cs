namespace Neusta.Workshop.Buchungssystem.Application.Models;

public class RaumDto
{
    public Guid? Id { get; set; }

    public string Name { get; set; }

    public string Nummer { get; set; }

    public IList<string> Personen { get; set; }
}