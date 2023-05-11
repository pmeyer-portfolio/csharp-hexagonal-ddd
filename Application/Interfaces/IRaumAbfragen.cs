using Neusta.Workshop.Buchungssystem.Domain.Common;
using Neusta.Workshop.Buchungssystem.Application.Models;

namespace Neusta.Workshop.Buchungssystem.Application.Interfaces;

public interface IRaumAbfragen
{
    RaumDto Abfragen(Id id);
}