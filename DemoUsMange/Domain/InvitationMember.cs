 /*using DemoCommandSide.Domain;
using DemoUsersManagementCommandSide.Abstraction;
using DemoUsersManagementCommandSide.Commands.AcceptInvitation;
using DemoUsersManagementCommandSide.Commands.CancelInvitationRequest;
using DemoUsersManagementCommandSide.Commands.CreateInvitationCommand;
using DemoUsersManagementCommandSide.Commands.DeleteCommand;
using DemoUsersManagementCommandSide.Commands.RejectInvitation;
using DemoUsersManagementCommandSide.Commands.SendInvitaionRequest;
using DemoUsersManagementCommandSide.Events;
using DemoUsersManagementCommandSide.Exceptions;
using DemoUsersManagementCommandSide.Extensions;

namespace DemoUsersManagementCommandSide.Domain
{
    public class InvitationMember : Aggregate<InvitationMember>, IAggregate
    {
        private readonly BusinessRules _businessRules;

        public InvitationMember()
        {
            _businessRules = new BusinessRules(this);
        }

        public bool IsDeleted { get; private set; }
        public bool IsSent { get; private set; }
        public bool IsPending { get; private set; }
        public bool IsCanceled { get; private set; }
        public bool IsAccepted { get; private set; }
        public bool IsRejected { get; private set; }
        public string AccountId { get; private set; } = string.Empty;
        public string SubscriptionId { get; private set; } = string.Empty;
        public string MemberId { get; private set; } = string.Empty;
        public string UserId { get; private set; } = string.Empty;
        public List<Permission>? Permissions { get; private set; }


        public static InvitationMember Create(CreateInvitationCommand command)
        {
            var @event = command.ToEvent();

            var invitation = new InvitationMember();

            invitation.ApplyNewChange(@event);

            return invitation;
        }

        public void Mutate(InvitationCreated @event)
        {
            UserId = @event.UserId;
            AccountId = @event.Data.AccountId;
            SubscriptionId = @event.Data.SubscriptionId;
            MemberId = @event.Data.MemberId;
            UserId = @event.Data.UserId;
        }

        internal void Send(SendInvitaionCommand command)
        {
            _businessRules.Validate(command);

            var @event = command.ToEvent(NextSequence);

            ApplyNewChange(@event);

        }

        private void Mutate(InvitationSent _)
        {
            IsSent = true;
            IsPending = true;
        }

        internal void Canseled(CancelInvitationCommand command)
        {
            _businessRules.Validate(command);

            var @event = command.ToEvent(NextSequence);

            ApplyNewChange(@event);
        }

        private void Mutate(InvitationCanceled _)
        {
            IsCanceled = true;
            IsPending = true;
        }

        internal void Accept(AcceptInvitationCommand command)
        {
            _businessRules.Validate(command);

            var @event = command.ToEvent(NextSequence);

            ApplyNewChange(@event);
        }

        private void Mutate(InvitationAccepted _)
        {
            IsSent = true;
            IsAccepted = true;
            IsPending = false;
        }

        internal void Reject(RejectInvitationCommand command)
        {
            _businessRules.Validate(command);

            var @event = command.ToEvent(NextSequence);

            ApplyNewChange(@event);
        }

        private void Mutate(InvitationRejected _)
        {
            IsSent = true;
            IsAccepted = false;
            IsRejected = true;
            IsPending = false;
        }

        internal void Delete(DeleteInvitationCommand command)
        {
            _businessRules.Validate(command);

            var @event = command.ToEvent(NextSequence);

            ApplyNewChange(@event);

        }

        private void Mutate(InvitationDeleted _)
        {
            IsDeleted = true;
        }


        protected override void Mutate(Event @event)
        {
            switch (@event)
            {
                case InvitationCreated taskCreated:
                    Mutate(taskCreated);
                    break;
                case InvitationSent taskSent:
                    Mutate(taskSent);
                    break;
                case InvitationCanceled taskCanceled:
                    Mutate(taskCanceled);
                    break;
                case InvitationAccepted taskAccepted:
                    Mutate(taskAccepted);
                    break;
                case InvitationRejected taskRejected:
                    Mutate(taskRejected);
                    break;
                case InvitationDeleted taskDeleted:
                    Mutate(taskDeleted);
                    break;

                default:
                    break;
            

            }

        }
    }
}
*/