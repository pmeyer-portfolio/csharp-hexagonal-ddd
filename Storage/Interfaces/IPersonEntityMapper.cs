using Neusta.Workshop.Buchungssystem.Domain.Person;
using Neusta.Workshop.Buchungssystem.Storage.Entities;

namespace Neusta.Workshop.Buchungssystem.Storage.Interfaces;

public interface IPersonEntityMapper
{
    PersonEntity Map(Person raum);
    Person Map(PersonEntity roomEntity);
}