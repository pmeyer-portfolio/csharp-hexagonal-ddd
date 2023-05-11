using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.RestApi.Dtos;
using Neusta.Workshop.Buchungssystem.RestApi.Interfaces;

namespace Neusta.Workshop.Buchungssystem.RestApi.Mappers;

public class RaumMapper : IRaumMapper
{
    public Room Map(Raum raum)
    {
        return new Room
        {
            Id = raum.Id.Value,
            Name = raum.Name.Value,
            Nummer = raum.Nummer.Value,
            PersonIds = raum.PersonIds.Select(x=> x.Value).ToList()
        };
    }

    public Raum Map(Room room)
    {
        return new Raum(room.Id.GetValueOrDefault(Guid.Empty), room.Name, room.Nummer);
    }
}