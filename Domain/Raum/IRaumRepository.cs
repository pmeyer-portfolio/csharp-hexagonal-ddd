using Neusta.Workshop.Buchungssystem.Domain.Common;

namespace Neusta.Workshop.Buchungssystem.Domain.Raum;

public interface IRaumRepository
{
    Raum Anlegen(Raum raum);

    Raum Abfragen(Id id);

    bool Existiert(Nummer nummer);
    
    bool Existiert(Id id);

    bool PersonExistiertInEinmRaum(Id personId);

    void FuegePersonInRaumHinzu(Id raumId, Id personId);
    void Aktualisieren(Raum raum);
}