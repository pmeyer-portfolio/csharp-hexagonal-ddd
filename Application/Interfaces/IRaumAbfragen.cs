using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.Domain.Common;

namespace Neusta.Workshop.Buchungssystem.Application.Interfaces;

public interface IRaumAbfragen
{
    Raum Abfragen(Id id);
}