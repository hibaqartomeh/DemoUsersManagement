using MediatR;
using DemoUsMange.Abstraction;
using DemoUsMange.Domain;
using DemoUsMange.Exceptions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace DemoUsMange.Commands.CancelInvitation
{
    public class CancelInvCommandHandler(IEventStore eventStore) : IRequestHandler<CancelInvCommand, string>
    {

        private readonly IEventStore _eventStore = eventStore;

        public async Task<string> Handle(CancelInvCommand command, CancellationToken cancellationToken)
        {
            var events = await _eventStore.GetAllAsync(command.Sub_Id + "-" + command.Member_Id, cancellationToken);

            if (events.Count == 0)
                throw new NotFoundException("Invitations not found");


            var invitation = Invitation.LoadFromHistory(events);
            invitation.Canseled(command);
            await _eventStore.CommitAsync(invitation, cancellationToken);

            return command.Sub_Id + "-" + command.Member_Id;
        }
    }
}
