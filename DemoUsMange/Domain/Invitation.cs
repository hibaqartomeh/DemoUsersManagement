using DemoUsMange.Abstraction;
using DemoUsMange.Commands.AcceptInvitation;
using DemoUsMange.Commands.CancelInvitation;
using DemoUsMange.Commands.SendInvCommand;
using DemoUsMange.Commands.RejectInvCommand;
using DemoUsMange.Domain;
using DemoUsMange.Events;
using DemoUsMange.Extensions;
using System.Security;
using DemoUsMange.Command.Abstraction;
using DemoUsMange.Exceptions;
using System.Numerics;

namespace DemoUsMange.Domain
{
    public class Invitation : Aggregate<Invitation>, IAggregate
    {
        private readonly BusinessRules _businessRules;

        public Invitation()
        {
            _businessRules = new BusinessRules(this);
        }


        public bool IsSent { get; private set; }

        public bool IsCanceled { get; private set; }
        public bool IsAccepted { get; private set; }
        public bool IsRejected { get; private set; }
        public bool IsPending { get; private set; }
        public string UserId { get; private set; } = string.Empty;
        public string MemberId { get; private set; } = string.Empty;
        //  public bool IsDeleted { get; private set; }


        internal void Send(SendInvCommand command)
        {
            _businessRules.Validate(command);


            var @event = command.ToEvent();

            ApplyNewChange(@event);
        }



        public void Mutate(InvitationSent _)
        {
           
            IsSent =true;
            IsCanceled = false;
            IsAccepted = false;
            IsRejected = false;


            // IsPending = false;
        }


        internal void Canseled(CancelInvCommand command)
        {
            _businessRules.Validate(command);

            var @event = command.ToEvent(NextSequence);

            ApplyNewChange(@event);
        }
      
        public void Mutate(InvitationCanceled _)
        {
            IsCanceled = true;
            

        }

        internal void Accept(AcceptInvCommand command)
        {
            _businessRules.Validate(command);

            var @event = command.ToEvent(NextSequence);

            ApplyNewChange(@event);
        }




      
        public void Mutate(InvitationAccepted _)
        {
            IsAccepted = true; 
            IsCanceled=false;

        }




        internal void Reject(RejectInvCommand command)
        {
            _businessRules.Validate(command);

            var @event = command.ToEvent(NextSequence);

            ApplyNewChange(@event);
        }

        public void Mutate(InvitationRejected _)
        {
            IsRejected = true;
            IsAccepted = false;

        }


        protected override void Mutate(Event @event)
        {
            switch (@event)
            {
                case InvitationAccepted e:
                    Mutate(e);
                    break;
                case InvitationCanceled e:
                    Mutate(e);
                    break;
                case InvitationRejected e:
                    Mutate(e);
                    break;
                case InvitationSent e:
                    Mutate(e);
                    break;
                default:
                    break;
            }
        }

    
    }



}
