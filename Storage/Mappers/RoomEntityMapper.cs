using Neusta.Workshop.Buchungssystem.Domain.Common;
using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.Storage.Entities;
using Neusta.Workshop.Buchungssystem.Storage.Interfaces;

namespace Neusta.Workshop.Buchungssystem.Storage.Mappers;

public class RoomEntityMapper : IRoomEntityMapper
{
    public RoomEntity Map(Raum raum)
    {
        return new RoomEntity
        {
            Id = raum.Id.Value,
            Nummer = raum.Nummer.Value,
            Name = raum.Name.Value
        };
    }

    public Raum Map(RoomEntity roomEntity)
    {
        return new(roomEntity.Name, roomEntity.Nummer)
        {
            Id = new Id(roomEntity.Id),
            PersonIds = roomEntity.PersonIds.Select(x => new Id(x)).ToList()
        };
    }

    public void MapToEntity(RoomEntity roomEntity, Raum raum)
    {
        roomEntity.Name = raum.Name.Value;
        roomEntity.Nummer = raum.Nummer.Value;
        roomEntity.PersonIds = raum.PersonIds.Select(x => x.Value).ToList();
    }
}