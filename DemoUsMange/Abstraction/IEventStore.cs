using DemoUsMange.Events;
using Microsoft.EntityFrameworkCore.Metadata;
using DemoUsMange.Infrastructuer;
using DemoUsMange.Domain;

namespace DemoUsMange.Abstraction
{
    public interface IEventStore
    {
        Task<List<Event>> GetAllAsync(string aggregateId, CancellationToken cancellationToken);// all event
           Task CommitAsync(Invitation invitation, CancellationToken cancellationToken);// domin
    }
}
//builder.Services.AddScoped<IEventStore, EventStore>();