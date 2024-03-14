using DemoUsMange.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using DemoUsMange.Exceptions;
using DemoUsMange.Domain;

namespace DemoUsMange.Commands.SendInvCommand
{
    public class SendInvCommandHandler(IEventStore eventStore) : IRequestHandler<SendInvCommand, string>
    {
        private readonly IEventStore _eventStore = eventStore;

        public async Task<string> Handle(SendInvCommand command, CancellationToken cancellationToken)
        {
            var events = await _eventStore.GetAllAsync((command.Sub_Id + "-" + command.Member_Id), cancellationToken);
            if (events.Any())

                throw new AlreadyExistsException("this invitation is already exist");

            var invitation = Invitation.LoadFromHistory(events);

            invitation.Send(command);

            await _eventStore.CommitAsync(invitation, cancellationToken);

            return command.Sub_Id + "-" + command.Member_Id;
        }
    }
}

