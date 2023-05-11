using Microsoft.AspNetCore.Mvc;
using Neusta.Workshop.Buchungssystem.Application;
using Neusta.Workshop.Buchungssystem.Application.Interfaces;
using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.Domain.Raum.Exceptions;
using Neusta.Workshop.Buchungssystem.Domain.Common;
using Neusta.Workshop.Buchungssystem.Domain.Person;
using Neusta.Workshop.Buchungssystem.RestApi.Dtos;
using Neusta.Workshop.Buchungssystem.RestApi.Interfaces;
using Neusta.Workshop.Buchungssystem.Domain.Person.Exceptions;

namespace Neusta.Workshop.Buchungssystem.RestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IPersonHinzufügen personHinzufügen;
    private readonly IPersonMapper personMapper;
    private readonly IRaumMapper raumMapper;
    private readonly IRaumAbfragen raumAbfragen;
    private readonly IRaumAnlegen raumAnlegen;

    public RoomController(IPersonHinzufügen personHinzufügen,
        IPersonMapper personMapper,
        IRaumAnlegen raumAnlegen, 
        IRaumAbfragen raumAbfragen, 
        IRaumMapper raumMapper)
    {
        this.personHinzufügen = personHinzufügen;
        this.personMapper = personMapper;
        this.raumAnlegen = raumAnlegen;
        this.raumAbfragen = raumAbfragen;
        this.raumMapper = raumMapper;
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        try
        {
            Raum raum = this.raumAbfragen.Abfragen(new Id(id));
            Room room = this.raumMapper.Map(raum);
            return this.Ok(room);
        }
        catch (RaumDoesNotExistException ex)
        {
            return this.NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Create(Room room)
    {
        try
        {
            Raum raum = this.raumMapper.Map(room);
            Raum raumErgebnis = this.raumAnlegen.Anlegen(raum);
            Room mappedroom = this.raumMapper.Map(raumErgebnis);
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

    [HttpPut("{id}/person")]
    public IActionResult AddPerson(Guid id, PersonDto personDto)
    {
        try
        {
            Person person = this.personMapper.Map(personDto);
            Person createdPerson = this.personHinzufügen.Hinzufügen(new Id(id), person);
            return this.Ok(this.personMapper.Map(createdPerson));
        }
        catch (UnerlaubterNamenszusatzException e)
        {
            return this.BadRequest(e.Message);
        }

        catch (PersonExistiertException e)
        {
            return this.BadRequest(e.Message);
        }

        catch (PersonExistiertImRaumException e)
        {
            return this.BadRequest(e.Message);
        }
    }
}