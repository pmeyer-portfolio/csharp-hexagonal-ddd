namespace Neusta.Workshop.Buchungssystem.Domain.Person;
using Neusta.Workshop.Buchungssystem.Domain.Common;

public interface IPersonRepository
{
    Person Anlegen(Person person);

    Person Abfragen(Id id);

    bool Existiert(string ldapKennung);
}