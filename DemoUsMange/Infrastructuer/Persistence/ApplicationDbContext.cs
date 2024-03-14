using DemoUsMange.Events;
using DemoUsMange.Infrastructuer.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DemoUsMange.Infrastructure.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {


        public DbSet<Event> Events { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        // ملاحظة هاد مو موجود بال نو سيكوال  انو بيشتغل بالجيسون
        // ريفرنس للاينتينتي
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OutboxMessageConfigurations());
            modelBuilder.ApplyConfiguration(new BaseEventConfigurations());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<InvitationAccepted, InvitationAcceptedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<InvitationCanceled, InvitationCanceledData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<InvitationRejected, InvitationRejectedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<InvitationSent, InvitationSentData>());
          //  modelBuilder.ApplyConfiguration(new GenericEventConfiguration<MemberJoined, MemberJoinedData>());

        }
    }
}
