using Neusta.Workshop.Buchungssystem.Application.Models;
using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.RestApi.Dtos;
using Neusta.Workshop.Buchungssystem.RestApi.Interfaces;

namespace Neusta.Workshop.Buchungssystem.RestApi.Mappers;

public class RaumMapper : IRaumMapper
{
    public Room MapToRoom(RaumDto raumDto)
    {
        return new Room
        {
            Id = raumDto.Id,
            Name = raumDto.Name,
            Nummer = raumDto.Nummer,
            Personen = raumDto.Personen
        };
    }

    public Raum Map(RoomCreateDto roomCreateDto)
    {
        return new Raum(roomCreateDto.Name, roomCreateDto.Nummer);
    }

    public Room MapToRoom(Raum raum)
    {
        return new Room
        {
            Id = raum.Id.Value,
            Name = raum.Name.Value,
            Nummer = raum.Nummer.Value
        };
    }
}