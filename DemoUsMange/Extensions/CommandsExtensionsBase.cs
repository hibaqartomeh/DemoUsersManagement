using DemoUsMange.Commands.SendInvCommand;

namespace DemoUsMange.Extensions
{
    public static class  CommandsExtensionsBase
    {
        public static SendInvCommand ToCommand(this SendInvitationRequest request) => new()
        {
            Us_Id = request.UsId,
            Acc_Id = request.AccId,
            Sub_Id = request.SubId,
            Member_Id = request.MemberId,
            Permission = (int)request.Permissions,
        };
    }
}