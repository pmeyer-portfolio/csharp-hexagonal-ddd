using Neusta.Workshop.Buchungssystem.Domain.Person;
using Neusta.Workshop.Buchungssystem.RestApi.Dtos;
using Neusta.Workshop.Buchungssystem.RestApi.Interfaces;

namespace Neusta.Workshop.Buchungssystem.RestApi.Mappers;

public class PersonMapper : IPersonMapper
{
    public PersonDto Map(Person person)
    {
        return new PersonDto
        {
            Id = person.Id.Value,
            Vorname = person.Vorname.Value,
            Nachname = person.Nachname.Value,
            Namenszusatz = person.Namenszusatz.Value,
            LdapKennung = person.LdapKennung,
        };
    }

    public Person Map(PersonDto person)
    {
        return new Person(person.Id, person.Vorname, person.Nachname, person.Namenszusatz, person.LdapKennung);
    }
}