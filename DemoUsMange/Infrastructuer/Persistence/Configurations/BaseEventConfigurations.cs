using DemoUsMange.Events;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace DemoUsMange.Infrastructuer.Persistence.Configurations
{
    public class BaseEventConfigurations :IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasIndex(e => new { e.AggregateId, e.Sequence }).IsUnique();  // هدول عليهم انديكس يونيك
        builder.Property<string>("EventType").HasMaxLength(128);// منضيف حقل الايفينت
        builder.HasDiscriminator<string>("EventType");//بيخزن اس الكلاس بالايفنت تايب لتميز نوع الايفينت في الاينتتي
        }
}
}

  