using Neusta.Workshop.Buchungssystem.Domain.Common;

namespace Neusta.Workshop.Buchungssystem.Domain.Raum;

public class Raum
{
    public Raum(Guid id, string name, string nummer)
    {
        this.Id = new Id(id);
        this.Nummer = new Nummer(nummer);
        this.Name = new Name(name);
    }

    public Id Id { get; set; }

    public Nummer Nummer { get; }

    public Name Name { get; }

    public IList<Id> PersonIds { get; set; } = new List<Id>();
}