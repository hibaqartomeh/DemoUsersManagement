using System.Security;
namespace DemoUsMange.Events
{


    public record InvitationCanceled(
       string AggregateId,
       int Sequence,
       DateTime DateTime,
       InvitationCanceledData Data,
       string UserId,
       int Version
   ) : Event<InvitationCanceledData>(AggregateId, Sequence, DateTime, Data, UserId, Version);

    public record InvitationCanceledData(
         string AccountId,
         string SubscriptionId,
         string MemberId,
         string UserId

    );
}
