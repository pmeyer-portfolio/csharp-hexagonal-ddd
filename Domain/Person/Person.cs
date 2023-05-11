namespace Neusta.Workshop.Buchungssystem.Domain.Person;
using Neusta.Workshop.Buchungssystem.Domain.Common;

public class Person
{
    public Person(Guid id, string vorname, string nachname, string namenszusatz, string ldapKennung)
    {
        this.Id = new Id(id);
        this.Vorname = new Name(vorname);
        this.Nachname = new Name(nachname);
        this.Namenszusatz = new Namenszusatz(namenszusatz);
        this.LdapKennung = ldapKennung;
    }

    public Id Id { get; set; }
    public Name Nachname { get; set; }
    public Namenszusatz Namenszusatz { get; set; }
    public Name Vorname { get; set; }
    public string LdapKennung { get; set; }

    public string GetKurzschreibweise()
    {
        return $"{Vorname} {Namenszusatz} {Nachname} ({LdapKennung})";
    }
}