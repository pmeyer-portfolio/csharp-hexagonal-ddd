namespace Neusta.Workshop.Buchungssystem.Domain.Raum.Exceptions;

public class RaumExistException : Exception
{
    public RaumExistException(string message)
        : base(message)
    {
    }
}