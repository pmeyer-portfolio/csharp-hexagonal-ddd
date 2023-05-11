using Neusta.Workshop.Buchungssystem.Application.Interfaces;
using Neusta.Workshop.Buchungssystem.Application.Models;
using Neusta.Workshop.Buchungssystem.Domain.Common;
using Neusta.Workshop.Buchungssystem.Domain.Person;
using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.Domain.Raum.Exceptions;

namespace Neusta.Workshop.Buchungssystem.Application;

public class RaumAbfragen : IRaumAbfragen
{
    private readonly IPersonRepository personRepository;
    private readonly IRaumRepository raumRepository;

    public RaumAbfragen(IPersonRepository personRepository, 
        IRaumRepository raumRepository)
    {
        this.personRepository = personRepository;
        this.raumRepository = raumRepository;
    }

    public RaumDto Abfragen(Id id)
    {
        if (!this.raumRepository.Existiert(id))
        {
            throw new RaumDoesNotExistException($"Raum mit {id} existiert nicht");
        }

        Raum raum = this.raumRepository.Abfragen(id);
        List<string> kurzschreibweisen = raum.PersonIds.Select(x => this.personRepository.Abfragen(x).GetKurzschreibweise()).ToList();

        //TODO add mapper
        RaumDto raumDto = new RaumDto()
        {
            Id = raum.Id.Value,
            Name = raum.Name.Value,
            Nummer = raum.Nummer.Value,
            Personen = kurzschreibweisen
        };
        return raumDto;
    }
}