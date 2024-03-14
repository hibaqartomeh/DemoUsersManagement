using DemoUsMange.Commands.AcceptInvitation;
using DemoUsMange.Commands.CancelInvitation;
using DemoUsMange.Commands.RejectInvCommand;
using DemoUsMange.Commands.SendInvCommand;
using DemoUsMange.Events;

namespace DemoUsMange.Extensions
{
    public static class EventsExtensions
    {

       
        public static InvitationAccepted ToEvent(this AcceptInvCommand command, int sequence) => new(
                AggregateId:command.Sub_Id + "-" + command.Member_Id,
                Sequence: sequence,
                DateTime: DateTime.UtcNow,
                Data: new InvitationAcceptedData(
                    AccountId: command.Acc_Id,
                    SubscriptionId: command.Sub_Id,
                    MemberId: command.Member_Id,
                    UserId:command.Us_Id
                   
                ),
                UserId: command.Us_Id,
                Version: 1
            );
        
        public static InvitationCanceled ToEvent(this CancelInvCommand command, int sequence) => new(
                AggregateId:command.Sub_Id+"-"+command.Member_Id,
                Sequence: sequence,
                DateTime: DateTime.UtcNow,
                Data: new InvitationCanceledData(
                    AccountId: command.Acc_Id,
                    SubscriptionId: command.Sub_Id,
                    MemberId: command.Member_Id,
                    UserId:command.Us_Id
                   
                ),
                UserId: command.Us_Id,
                Version: 1
            ); 
        public static InvitationRejected ToEvent(this RejectInvCommand command, int sequence) => new(
                AggregateId:command.Sub_Id+"-"+command.Member_Id,
                Sequence: sequence,
                DateTime: DateTime.UtcNow,
                Data: new InvitationRejectedData(
                    AccountId: command.Acc_Id,
                    SubscriptionId: command.Sub_Id,
                    MemberId: command.Member_Id,
                    UserId:command.Us_Id
                   
                ),
                UserId: command.Us_Id,
                Version: 1
            ); 
        public static InvitationSent ToEvent(this SendInvCommand command) => new(
                AggregateId:command.Sub_Id + "-" + command.Member_Id,
                Sequence: 1,
                DateTime: DateTime.UtcNow,
                Data: new InvitationSentData(
                    AccountId: command.Acc_Id,
                    SubscriptionId: command.Sub_Id,
                    MemberId: command.Member_Id,
                    UserId:command.Us_Id,
                    Permission: command.Permission
                   
                ),
                UserId: command.Us_Id,
                Version: 1
            );
    
    
    } 
   
    
}
