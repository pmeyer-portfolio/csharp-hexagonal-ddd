namespace Neusta.Workshop.Buchungssystem.RestApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using Neusta.Workshop.Buchungssystem.Application;
using Neusta.Workshop.Buchungssystem.Domain.Person;
using Neusta.Workshop.Buchungssystem.Domain.Person.Exceptions;
using Neusta.Workshop.Buchungssystem.RestApi.Dtos;
using Neusta.Workshop.Buchungssystem.RestApi.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonErstellen personHinzufügen;
    private readonly IPersonMapper personMapper;

    public PersonController(IPersonErstellen personHinzufügen,
        IPersonMapper personMapper)
    {
        this.personHinzufügen = personHinzufügen;
        this.personMapper = personMapper;
    }

    [HttpPost]
    public IActionResult Create(PersonDto givenPersonDto)
    {
        try
        {
            Person person = this.personMapper.Map(givenPersonDto);
            Person createdPerson = this.personHinzufügen.ErstellePerson(person);
            PersonDto mappedPersonDto = this.personMapper.Map(createdPerson);
            return this.Ok(mappedPersonDto);
        }
        catch (PersonExistiertNichtException ex)
        {
            return this.BadRequest(ex.Message);
        }
        catch (UnerlaubterNamenszusatzException ex)
        {
            return this.BadRequest(ex.Message);
        }
    }
}