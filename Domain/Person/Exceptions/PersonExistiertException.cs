namespace Neusta.Workshop.Buchungssystem.Domain.Person.Exceptions;

public class PersonExistiertException : Exception
{
    public PersonExistiertException(string message)
        : base(message)
    {
    }
}