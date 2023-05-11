namespace Neusta.Workshop.Buchungssystem.Domain.Raum.Exceptions;

public class RaumDoesNotExistException : Exception
{
    public RaumDoesNotExistException(string message)
        : base(message)
    {
    }
}