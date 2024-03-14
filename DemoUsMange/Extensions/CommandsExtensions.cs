using DemoUsMange.Commands.SendInvCommand;
using DemoUsMange.Commands.RejectInvCommand;
using DemoUsMange.Commands.CancelInvitation;
using DemoUsMange.Commands.AcceptInvitation;
using DemoUsMange.Command;

namespace DemoUsMange.Extensions
{
    public static class CommandsExtensions
    {
        public static SendInvCommand ToSendCommand(this SendInvitationRequest request)
           => new()
           {
               Us_Id = request.UsId,
               Acc_Id = request.AccId,
               Sub_Id = request.SubId,
               Member_Id = request.MemberId,
               Permission = (int)request.Permissions
           };

        public static RejectInvCommand ToCommand(this RejectInvitationRequest request)
           => new()
           {
               Us_Id = request.UsId,
               Acc_Id = request.AccId,
               Sub_Id = request.SubId,
               Member_Id = request.MemberId,
            
           };

        public static CancelInvCommand ToCommand(this CancelInvitationRequest request)
           => new()
           {
               Us_Id = request.UsId,
               Acc_Id = request.AccId,
               Sub_Id = request.SubId,
               Member_Id = request.MemberId,

           };
        public static AcceptInvCommand ToCommand(this AcceptInvitationRequest request)
           => new()
           {
               Us_Id = request.UsId,
               Acc_Id = request.AccId,
               Sub_Id = request.SubId,
               Member_Id = request.MemberId,

           };

    }
}

