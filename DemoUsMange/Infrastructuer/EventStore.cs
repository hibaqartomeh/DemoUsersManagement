using DemoUsMange.Abstraction;
using DemoUsMange.Events;
using DemoUsMange.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Polly;
using DemoUsMange.Domain;
namespace DemoUsMange.Infrastructuer
{
    public class EventStore(ApplicationDbContext context) : IEventStore
    {

        private readonly ApplicationDbContext _context = context;

        public Task<List<Event>> GetAllAsync(string aggregateId, CancellationToken cancellationToken) =>
             _context.Events
        .Where(x => x.AggregateId == aggregateId)
                 .OrderBy(x => x.Id)// تريب الاحداث 
                 .ToListAsync(cancellationToken);

        public async Task CommitAsync(Invitation invitation, CancellationToken cancellationToken)
         {


             var events = invitation.GetUncommittedEvents();

             var messages = events.Select(x => new OutboxMessage(x));
             await _context.Events.AddRangeAsync(events, cancellationToken);
             await _context.OutboxMessages.AddRangeAsync(messages, cancellationToken);

             await _context.SaveChangesAsync(cancellationToken);

         } 

    }
}


