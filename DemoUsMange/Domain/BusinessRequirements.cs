using DemoUsMange.Abstraction;
using DemoUsMange.Exceptions;
using DemoUsMange.Domain;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoUsMange.Domain
{
    public class BusinessRequirements(Invitation invitation)
    {
        private readonly Invitation _invitation = invitation;
        public void RequireSent()
        {
            if (!_invitation.IsSent)
                throw new RuleViolationException("the invitation is uncsent.");
        }
        public void RequireCanceled()
        {
            if (_invitation.IsSent)
                throw new RuleViolationException("The invitation cannot be canceled is already sent.");
        }
        public void RequireRejected()
        {
            if (!_invitation.IsSent)
                throw new RuleViolationException("Invitation not sent, cannot be rejected.");
            if (_invitation.IsCanceled)
                throw new RuleViolationException("Invitation Is Canceled, cannot be rejected.");
        }

        public void RequireAccepted()
        {
            if (!_invitation.IsSent)
                throw new RuleViolationException("Invitation not sent, cannot be Accepted.");
            if (_invitation.IsCanceled)
                throw new RuleViolationException("Invitation Is Canceled, cannot be Accepted.");
        }

        public void RequireSameUser(IInvitation command)
        {
     
            if (_invitation.UserId != command.UserId  )
     
                    throw new RuleViolationException("cannot send an invitation to yourself");
        }

    }
}
