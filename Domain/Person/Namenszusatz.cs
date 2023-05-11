using Neusta.Workshop.Buchungssystem.Domain.Person.Exceptions;

namespace Neusta.Workshop.Buchungssystem.Domain.Person;

public class Namenszusatz
{
    private static readonly string?[] erlaubteNamenszusätze = { "von", "van", "de", string.Empty, null };

    public Namenszusatz(string value)
    {
        if (!this.IstErlaubterNamenszusatz(value))
            throw new UnerlaubterNamenszusatzException($"Der Namenszusatz {value} ist nicht erlaubt");
        this.Value = value;
    }

    public string Value { get; }

    private bool IstErlaubterNamenszusatz(string value)
    {
        return erlaubteNamenszusätze.Contains(value);
    }
}