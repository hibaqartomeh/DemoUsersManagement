using DemoUsMange.Events;

namespace DemoUsMange.Command.Abstraction
{
    public interface IAggregate
    {
        string? Id { get; }
        int Sequence { get; }
        IReadOnlyList<Event> GetUncommittedEvents();
        void MarkChangesAsCommitted();

    }
}
