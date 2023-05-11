namespace Neusta.Workshop.Buchungssystem.RestApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using Neusta.Workshop.Buchungssystem.Application;
using Neusta.Workshop.Buchungssystem.Application.Interfaces;
using Neusta.Workshop.Buchungssystem.Application.Models;
using Neusta.Workshop.Buchungssystem.Domain.Common;
using Neusta.Workshop.Buchungssystem.Domain.Person.Exceptions;
using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.Domain.Raum.Exceptions;
using Neusta.Workshop.Buchungssystem.RestApi.Dtos;
using Neusta.Workshop.Buchungssystem.RestApi.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IPersonHinzufügen personHinzufügen;
    private readonly IRaumAbfragen raumAbfragen;
    private readonly IRaumAnlegen raumAnlegen;
    private readonly IRaumMapper raumMapper;

    public RoomController(IPersonHinzufügen personHinzufügen,
        IRaumAnlegen raumAnlegen,
        IRaumAbfragen raumAbfragen,
        IRaumMapper raumMapper)
    {
        this.personHinzufügen = personHinzufügen;
        this.raumAbfragen = raumAbfragen;
        this.raumAnlegen = raumAnlegen;
        this.raumMapper = raumMapper;
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        try
        {
            RaumDto raum = this.raumAbfragen.Abfragen(new Id(id));
            Room room = this.raumMapper.MapToRoom(raum);
            return this.Ok(room);
        }
        catch (RaumDoesNotExistException ex)
        {
            return this.NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Create(RoomCreateDto room)
    {
        try
        {
            Raum raum = this.raumMapper.Map(room);
            Raum raumErgebnis = this.raumAnlegen.Anlegen(raum);
            Room mappedroom = this.raumMapper.MapToRoom(raumErgebnis);
            return this.Ok(mappedroom);
        }
        catch (RaumNotValidException ex)
        {
            return this.BadRequest(ex.Message);
        }
        catch (RaumExistException ex)
        {
            return this.BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}/person/{ldapKennung}")]
    public IActionResult AddPerson(Guid id, string ldapKennung)
    {
        try
        {
            this.personHinzufügen.Hinzufügen(new Id(id), ldapKennung);
            return this.Ok();
        }

        catch (PersonExistiertNichtException e)
        {
            return this.BadRequest(e.Message);
        }
        catch (RaumDoesNotExistException e)
        {
            return this.BadRequest(e.Message);
        }
        catch (PersonExistiertImRaumException e)
        {
            return this.BadRequest(e.Message);
        }
    }
}