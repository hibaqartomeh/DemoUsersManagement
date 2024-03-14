using DemoUsMange;
using DemoUsMange.Extensions;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DemoUsMange.Commands;
using DemoUsMange.Events;
using DemoUsMange.Commands.AcceptInvitation;
using DemoUsMange.Commands.CancelInvitation;
using DemoUsMange.Commands.SendInvCommand;
using DemoUsMange.Commands.RejectInvCommand;
using Polly;

namespace DemoUsMange.Services
{
    public class InvitationMemberService(IMediator mediator, ILogger<InvitationMemberService> logger): InvitaionMember.InvitaionMemberBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly AsyncPolicy _policy = ConfigureRetries(logger);


      public override async Task<Response> AcceptInvitation(AcceptInvitationRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var id = await _policy.ExecuteAsync(() => _mediator.Send(command));

            return new Response()
            {
                Id = id.ToString(),
                Message = $"InvitationAccepted "

            };
        }

        public override async Task<Response> CancelInvitation(CancelInvitationRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var id = await _policy.ExecuteAsync(() => _mediator.Send(command));

            return new Response()
            {
                Id = id.ToString(),
                Message = $"InvitationCanceled "

            };
        }

        public override async Task<Response> RejectInvitation(RejectInvitationRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var id = await _policy.ExecuteAsync(() => _mediator.Send(command));

            return new Response()
            {
                Id = id.ToString(),
                Message = $"InvitationRejected "

            };
        }

        public override async Task<Response> SendInvitation(SendInvitationRequest request, ServerCallContext context)
        {
            var command = request.ToSendCommand();

            var id = await _policy.ExecuteAsync(() => _mediator.Send(command));

            return new Response()
            {
                Id = id.ToString(),
                Message = $"InvitationSent "

            };
        }


      

        private static AsyncPolicy ConfigureRetries(ILogger logger) =>

   Policy.Handle<DbUpdateException>()

       .WaitAndRetryAsync(new[]
       {

                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(3),
       }, onRetry: (exception, _, attempt, _) => logger.LogWarning(exception, "Call failed, Retry attempt: {RetryAttempt}", attempt));

    }

}

