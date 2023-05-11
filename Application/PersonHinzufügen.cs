namespace Neusta.Workshop.Buchungssystem.Application;

using Neusta.Workshop.Buchungssystem.Domain.Common;
using Neusta.Workshop.Buchungssystem.Domain.Person;
using Neusta.Workshop.Buchungssystem.Domain.Person.Exceptions;
using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.Domain.Raum.Exceptions;

public class PersonHinzufügen : IPersonHinzufügen
{
    private readonly IPersonRepository personRepository;
    private readonly IRaumRepository raumRepository;

    public PersonHinzufügen(IRaumRepository raumRepository, IPersonRepository personRepository)
    {
        this.raumRepository = raumRepository;
        this.personRepository = personRepository;
    }

    public void Hinzufügen(Id raumId, string ldapKennung)
    {
        if (!this.personRepository.Existiert(ldapKennung))
        {
            throw new PersonExistiertNichtException($"ldap {ldapKennung} existiert noch nicht");
        }

        if (!this.raumRepository.Existiert(raumId))
        {
            throw new RaumDoesNotExistException($"Raum exisitiert noch nicht raumId: {raumId}");
        }

        Id personId = this.personRepository.Abfragen(ldapKennung);

        Raum raum = this.raumRepository.Abfragen(raumId);
        raum.AddPerson(personId);
        this.raumRepository.Aktualisieren(raum);
    }
}

public interface IPersonHinzufügen
{
    void Hinzufügen(Id raumId, string ldapKennung);
}