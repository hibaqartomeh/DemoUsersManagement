using MediatR;

namespace DemoUsMange.Commands.AcceptInvitation
{
    public class AcceptInvCommand:IRequest<string>
    {

        public required string Us_Id { get; init; }
        public required string Acc_Id { get; init; }
        public required string Sub_Id { get; init; }
        public required string Member_Id { get; init; }
    }
}
