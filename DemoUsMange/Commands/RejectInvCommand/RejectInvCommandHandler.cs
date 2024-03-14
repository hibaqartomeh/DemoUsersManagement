using MediatR;
using DemoUsMange.Abstraction;
using DemoUsMange.Domain;
using DemoUsMange.Exceptions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace DemoUsMange.Commands.RejectInvCommand
{
    public class RejectInvCommandHandler(IEventStore eventStore) : IRequestHandler<RejectInvCommand, string>
    {
        private readonly IEventStore _eventStore = eventStore;

        public async Task<string> Handle(RejectInvCommand command, CancellationToken cancellationToken)
        {
            var events = await _eventStore.GetAllAsync(command.Sub_Id + "-" + command.Member_Id, cancellationToken);

            if (events.Count == 0)
                throw new NotFoundException("Invitations not found");


            var invitation = Invitation.LoadFromHistory(events);
            invitation.Reject(command);
            await _eventStore.CommitAsync(invitation, cancellationToken);

            return command.Sub_Id + "-" + command.Member_Id;
        }
    }
}

