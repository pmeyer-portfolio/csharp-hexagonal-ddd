namespace Neusta.Workshop.Buchungssystem.Domain.Raum.Exceptions;

public class RaumNotValidException : Exception
{
    public RaumNotValidException(string message) : base(message)
    {
    }
}