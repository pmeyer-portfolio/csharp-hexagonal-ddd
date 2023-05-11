using Neusta.Workshop.Buchungssystem.Domain.Common;

namespace Neusta.Workshop.Buchungssystem.Storage.Entities;

public class RoomEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Nummer { get; set; }

    public IList<Guid> PersonIds { get; } = new List<Guid>();
}