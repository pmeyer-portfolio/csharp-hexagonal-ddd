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
        Raum raum = new Raum(roomEntity.Id, roomEntity.Name, roomEntity.Nummer);
        raum.PersonIds = roomEntity.PersonIds.Select(x=> new Id(x)).ToList();
        return raum;
    }
}