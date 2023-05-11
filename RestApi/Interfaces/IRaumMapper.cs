using Neusta.Workshop.Buchungssystem.Application.Models;
using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.RestApi.Dtos;

namespace Neusta.Workshop.Buchungssystem.RestApi.Interfaces;

public interface IRaumMapper
{
    Raum Map(RoomCreateDto roomCreateDto);

    Room MapToRoom(Raum raum);
    
    Room MapToRoom(RaumDto raumDto);
}