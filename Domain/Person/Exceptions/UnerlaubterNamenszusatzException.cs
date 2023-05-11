namespace Neusta.Workshop.Buchungssystem.Domain.Person.Exceptions;
public class UnerlaubterNamenszusatzException : Exception
{
    public UnerlaubterNamenszusatzException(string message) : base(message) { }
}