using Neusta.Workshop.Buchungssystem.Application.Interfaces;
using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.Domain.Raum.Exceptions;

namespace Neusta.Workshop.Buchungssystem.Application;

public class RaumAnlegen : IRaumAnlegen
{
    private readonly IRaumRepository raumRepository;

    public RaumAnlegen(IRaumRepository raumRepository)
    {
        this.raumRepository = raumRepository;
    }

    public Raum Anlegen(Raum raum)
    {
        if (this.raumRepository.Existiert(raum.Nummer))
            throw new RaumExistException($"Die Raumnummer {raum.Nummer} existiert schon");

        return this.raumRepository.Anlegen(raum);
    }
}