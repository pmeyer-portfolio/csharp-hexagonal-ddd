using Neusta.Workshop.Buchungssystem.Domain.Person;
using Neusta.Workshop.Buchungssystem.Domain.Common;
using Neusta.Workshop.Buchungssystem.Storage.Entities;
using Neusta.Workshop.Buchungssystem.Storage.Interfaces;

namespace Neusta.Workshop.Buchungssystem.Storage.Repositories;

internal class PersonRepository : IPersonRepository
{
    private readonly IPersonEntityMapper personEntityMapper;

    public PersonRepository(IPersonEntityMapper personEntityMapper)
    {
        this.personEntityMapper = personEntityMapper;
    }

    public ICollection<PersonEntity> Persons { get; } = new List<PersonEntity>();

    public Person Anlegen(Person person)
    {
        PersonEntity personEntity = this.personEntityMapper.Map(person);
        personEntity.Id = Guid.NewGuid();
        this.Persons.Add(personEntity);
        return this.personEntityMapper.Map(personEntity);
    }

    public Id Abfragen(string ldapKennung)
    {
        PersonEntity personEntity = this.Persons.First(x => x.LdapKennung == ldapKennung);

        return new Id(personEntity.Id);
    }

    public Person Abfragen(Id id)
    {
        PersonEntity personEntity = this.Persons.First(x => x.Id == id.Value);
        return this.personEntityMapper.Map(personEntity);
    }

    public bool Existiert(string ldapKennung)
    {
        return this.Persons.Any(x => x.LdapKennung.Equals(ldapKennung));
    }
}