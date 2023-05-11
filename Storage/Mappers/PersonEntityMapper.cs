using Neusta.Workshop.Buchungssystem.Domain.Person;
using Neusta.Workshop.Buchungssystem.Storage.Entities;
using Neusta.Workshop.Buchungssystem.Storage.Interfaces;

namespace Neusta.Workshop.Buchungssystem.Storage.Mappers;

public class PersonEntityMapper : IPersonEntityMapper
{
    public PersonEntity Map(Person person)
    {
        return new PersonEntity
        {
            Id = person.Id.Value,
            Vorname = person.Vorname.Value,
            Nachname = person.Nachname.Value,
            Namenszusatz = person.Namenszusatz.Value,
            LdapKennung = person.LdapKennung,
        };
    }

    public Person Map(PersonEntity personEntity)
    {
        return new Person(personEntity.Id, personEntity.Vorname, personEntity.Nachname, personEntity.Namenszusatz, personEntity.LdapKennung);
    }
}