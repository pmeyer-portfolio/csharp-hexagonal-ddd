using Neusta.Workshop.Buchungssystem.Application.Interfaces;
using Neusta.Workshop.Buchungssystem.Domain.Common;
using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.Domain.Raum.Exceptions;

namespace Neusta.Workshop.Buchungssystem.Application;

public class RaumAbfragen : IRaumAbfragen
{
    private readonly IRaumRepository raumRepository;

    public RaumAbfragen(IRaumRepository raumRepository)
    {
        this.raumRepository = raumRepository;
    }

    public Raum Abfragen(Id id)
    {
        if (!this.raumRepository.Existiert(id))
        {
            throw new RaumDoesNotExistException($"Raum mit {id} existiert nicht");
        }

        return this.raumRepository.Abfragen(id);
    }
}