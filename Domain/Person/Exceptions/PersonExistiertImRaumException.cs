namespace Neusta.Workshop.Buchungssystem.Domain.Person.Exceptions;

public class PersonExistiertImRaumException : Exception
{
    public PersonExistiertImRaumException(string message)
        : base(message)
    {
    }
}