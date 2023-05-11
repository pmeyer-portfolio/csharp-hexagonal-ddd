using Neusta.Workshop.Buchungssystem.Domain.Common;
using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.Storage.Entities;
using Neusta.Workshop.Buchungssystem.Storage.Interfaces;

namespace Neusta.Workshop.Buchungssystem.Storage.Repositories;

internal class RaumRepository : IRaumRepository
{
    private readonly IRoomEntityMapper roomEntityMapper;

    public RaumRepository(IRoomEntityMapper roomEntityMapper)
    {
        this.roomEntityMapper = roomEntityMapper;
    }

    public ICollection<RoomEntity> Rooms { get; } = new List<RoomEntity>();

    public Raum Anlegen(Raum raum)
    {
        RoomEntity roomEntity = this.roomEntityMapper.Map(raum);
        this.Rooms.Add(roomEntity);
        return this.roomEntityMapper.Map(roomEntity);
    }

    public Raum Abfragen(Id id)
    {
        RoomEntity roomEntity = this.Rooms.First(x => x.Id == id.Value);

        return this.roomEntityMapper.Map(roomEntity);
    }

    public bool Existiert(Nummer nummer)
    {
        return this.Rooms.Any(x => x.Nummer.Equals(nummer.Value));
    }

    public bool Existiert(Id id)
    {
        return this.Rooms.Any(x => x.Id.Equals(id.Value));
    }

    public bool PersonExistiertInEinmRaum(Id personId)
    {
        return this.Rooms.Any(x => x.PersonIds.Contains(personId.Value));
    }

    public void FuegePersonInRaumHinzu(Id raumId, Id personId)
    {
        RoomEntity roomEntity = this.Rooms.First(x => x.Id == raumId.Value);
        roomEntity.PersonIds.Add(personId.Value);
    }

    public void Aktualisieren(Raum raum)
    {
        RoomEntity roomEntity = this.Rooms.First(x => x.Id == raum.Id.Value);
        this.roomEntityMapper.MapToEntity(roomEntity, raum);
    }
}