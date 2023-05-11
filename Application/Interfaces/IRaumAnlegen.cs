using Neusta.Workshop.Buchungssystem.Domain.Raum;

namespace Neusta.Workshop.Buchungssystem.Application.Interfaces;

public interface IRaumAnlegen
{
    Raum Anlegen(Raum raum);
}