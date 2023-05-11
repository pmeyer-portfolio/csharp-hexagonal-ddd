namespace Neusta.Workshop.Buchungssystem.Application;

using Neusta.Workshop.Buchungssystem.Domain.Person;
using Neusta.Workshop.Buchungssystem.Domain.Person.Exceptions;

public class PersonErstellen : IPersonErstellen
{
    private readonly IPersonRepository personRepository;

    public PersonErstellen(IPersonRepository personRepository)
    {
        this.personRepository = personRepository;
    }

    public Person ErstellePerson(Person person)
    {
        if (this.personRepository.Existiert(person.LdapKennung))
        {
            throw new PersonExistiertNichtException($"ldap {person.LdapKennung} existiert schon");
        }

        return this.personRepository.Anlegen(person);
    }
}

public interface IPersonErstellen
{
    Person ErstellePerson(Person person);
}