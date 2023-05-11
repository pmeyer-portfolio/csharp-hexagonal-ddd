using Neusta.Workshop.Buchungssystem.Domain.Raum.Exceptions;

namespace Neusta.Workshop.Buchungssystem.Domain.Raum;

public class Nummer
{
    public Nummer(string value)
    {
        IstZahl(value);
        IstVierstellig(value);

        this.Value = value;
    }

    public string Value { get; }

    private static void IstZahl(string nummer)
    {
        bool isZahl = int.TryParse(nummer, out _);

        if (!isZahl)
            throw new RaumNotValidException("Raumnummer ist keine Zahl.");
    }

    private static void IstVierstellig(string nummer)
    {
        int length = nummer.Length;

        if (length != 4)
            throw new RaumNotValidException("Länge ist nicht vierstellig");
    }
}