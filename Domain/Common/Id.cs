namespace Neusta.Workshop.Buchungssystem.Domain.Common;

public class Id
{
    public Id(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }
}