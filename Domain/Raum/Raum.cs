using Neusta.Workshop.Buchungssystem.Domain.Common;
using Neusta.Workshop.Buchungssystem.Domain.Person.Exceptions;

namespace Neusta.Workshop.Buchungssystem.Domain.Raum;

public class Raum
{
    public Raum(string name, string nummer)
    {
        this.Id = new Id(Guid.NewGuid());
        this.Nummer = new Nummer(nummer);
        this.Name = new Name(name);
    }

    public Id Id { get; set; }

    public Name Name { get; }

    public Nummer Nummer { get; }

    public IList<Id> PersonIds { get; set; } = new List<Id>();

    public void AddPerson(Id personId)
    {
        if (!this.ContainsPerson(personId))
        {
            this.PersonIds.Add(personId);
        }
        else
        {
            throw new PersonExistiertImRaumException(
                $"Person existiert schon in diesem Raum mit id {this.Id.Value} und personId {personId}");
        }
    }

    private bool ContainsPerson(Id personId)
    {
        return this.PersonIds.Contains(personId);
    }
}