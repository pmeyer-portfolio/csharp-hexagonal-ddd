using Neusta.Workshop.Buchungssystem.Domain.Common;
using Neusta.Workshop.Buchungssystem.Domain.Person;
using Neusta.Workshop.Buchungssystem.Domain.Person.Exceptions;
using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.Domain.Raum.Exceptions;

namespace Neusta.Workshop.Buchungssystem.Application;

public class PersonHinzufügen : IPersonHinzufügen
{
    private readonly IPersonRepository personRepository;
    private readonly IRaumRepository raumRepository;

    public PersonHinzufügen(IRaumRepository raumRepository, IPersonRepository personRepository)
    {
        this.raumRepository = raumRepository;
        this.personRepository = personRepository;
    }

    public Person Hinzufügen(Id raumId, Person person)
    {
        if (this.personRepository.Existiert(person.LdapKennung))
        {
            throw new PersonExistiertException($"ldap {person.LdapKennung} existiert schon");
        }

        if (!this.raumRepository.Existiert(raumId))
        {
            throw new RaumDoesNotExistException($"Raum exisitiert noch nicht raumId: {raumId}");
        }

        Person angelegtePerson = this.personRepository.Anlegen(person);
        if (!this.raumRepository.PersonExistiertInEinmRaum(person.Id))
        {
            this.raumRepository.FuegePersonInRaumHinzu(raumId, angelegtePerson.Id);
            return angelegtePerson;
        }

        throw new PersonExistiertImRaumException($"Person existiert schon im Raum mit id {raumId} und personId {person.Id}");
    }
}

public interface IPersonHinzufügen
{
    Person Hinzufügen(Id raumId, Person person);
}