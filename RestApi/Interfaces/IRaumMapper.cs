using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.RestApi.Dtos;

namespace Neusta.Workshop.Buchungssystem.RestApi.Interfaces;

public interface IRaumMapper
{
    Room Map(Raum raum);

    Raum Map(Room room);
}