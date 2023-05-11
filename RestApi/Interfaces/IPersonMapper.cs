using Neusta.Workshop.Buchungssystem.Domain.Person;
using Neusta.Workshop.Buchungssystem.RestApi.Dtos;

namespace Neusta.Workshop.Buchungssystem.RestApi.Interfaces;

public interface IPersonMapper
{
    PersonDto Map(Person person);

    Person Map(PersonDto person);
}