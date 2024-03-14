﻿// <auto-generated />
using System;
using DemoUsMange.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoUsMange.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DemoUsMange.Events.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AggregateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AggregateId", "Sequence")
                        .IsUnique();

                    b.ToTable("Events");

                    b.HasDiscriminator<string>("EventType").HasValue("Event");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DemoUsMange.Infrastructure.Persistence.OutboxMessage", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OutboxMessages");
                });

            modelBuilder.Entity("DemoUsMange.Events.InvitationAccepted", b =>
                {
                    b.HasBaseType("DemoUsMange.Events.Event");

                    b.Property<string>("Data")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Data");

                    b.HasDiscriminator().HasValue("InvitationAccepted");
                });

            modelBuilder.Entity("DemoUsMange.Events.InvitationCanceled", b =>
                {
                    b.HasBaseType("DemoUsMange.Events.Event");

                    b.Property<string>("Data")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Data");

                    b.HasDiscriminator().HasValue("InvitationCanceled");
                });

            modelBuilder.Entity("DemoUsMange.Events.InvitationRejected", b =>
                {
                    b.HasBaseType("DemoUsMange.Events.Event");

                    b.Property<string>("Data")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Data");

                    b.HasDiscriminator().HasValue("InvitationRejected");
                });

            modelBuilder.Entity("DemoUsMange.Events.InvitationSent", b =>
                {
                    b.HasBaseType("DemoUsMange.Events.Event");

                    b.Property<string>("Data")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Data");

                    b.HasDiscriminator().HasValue("InvitationSent");
                });

            modelBuilder.Entity("DemoUsMange.Infrastructure.Persistence.OutboxMessage", b =>
                {
                    b.HasOne("DemoUsMange.Events.Event", "Event")
                        .WithOne()
                        .HasForeignKey("DemoUsMange.Infrastructure.Persistence.OutboxMessage", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });
#pragma warning restore 612, 618
        }
    }
}
