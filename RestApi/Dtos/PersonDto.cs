
namespace Neusta.Workshop.Buchungssystem.RestApi.Dtos;

public class PersonDto
{
    public Guid Id { get; set; }
    public string Nachname { get; set; }
    public string? Namenszusatz { get; set; }
    public string Vorname { get; set; }
    public string LdapKennung { get; set; }
}