using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.Storage.Entities;

namespace Neusta.Workshop.Buchungssystem.Storage.Interfaces;

public interface IRoomEntityMapper
{
    RoomEntity Map(Raum raum);
    Raum Map(RoomEntity roomEntity);
    void MapToEntity(RoomEntity roomEntity, Raum raum);
}