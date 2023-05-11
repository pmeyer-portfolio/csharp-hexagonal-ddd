namespace Neusta.Workshop.Buchungssystem.Storage.Entities;

public class PersonEntity
{
    public Guid Id { get; set; }
    public string Nachname { get; set; }
    public string Namenszusatz { get; set; }
    public string Vorname { get; set; }
    public string LdapKennung { get; set; }
}