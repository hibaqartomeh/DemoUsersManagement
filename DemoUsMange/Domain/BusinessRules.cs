using DemoUsMange.Commands.RejectInvCommand;
using DemoUsMange.Commands.SendInvCommand;
using DemoUsMange.Domain;
using DemoUsMange.Abstraction;



namespace DemoUsMange.Domain
{
    public class BusinessRules
    {
        private readonly BusinessRequirements _requirements;

        public BusinessRules(Invitation invitation)
        {
            _requirements = new BusinessRequirements(invitation);
        }
        public void Validate(SendInvCommand command)
        {
             _requirements.RequireSameUser(command);
        }
        public void Validate(CancelInvitationRequest command)
        {


            _requirements.RequireSent();
        }

        public void Validate(AcceptInvitationRequest command)
        {


            _requirements.RequireSent();
        }

        public void Validate(RejectInvCommand command)
        {

            _requirements.RequireSent();
        }


    }

}
