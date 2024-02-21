﻿// <auto-generated />
using BlazorTicketsApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorTicketsApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240221160320_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shared.Models.ResponseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("response");

                    b.Property<string>("SubmittedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("submitted_by");

                    b.Property<int>("TicketId")
                        .HasColumnType("int")
                        .HasColumnName("ticket_id");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("Shared.Models.TagModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Shared.Models.TicketModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<bool>("IsResolved")
                        .HasColumnType("bit")
                        .HasColumnName("is_resolved");

                    b.Property<string>("SubmittedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("submitted_by");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Shared.Models.TicketTag", b =>
                {
                    b.Property<int>("TicketId")
                        .HasColumnType("int")
                        .HasColumnName("ticket_id");

                    b.Property<int>("TagId")
                        .HasColumnType("int")
                        .HasColumnName("tag_id");

                    b.HasKey("TicketId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("TicketTags");
                });

            modelBuilder.Entity("Shared.Models.ResponseModel", b =>
                {
                    b.HasOne("Shared.Models.TicketModel", "Ticket")
                        .WithMany("Responses")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Shared.Models.TicketTag", b =>
                {
                    b.HasOne("Shared.Models.TagModel", "Tag")
                        .WithMany("TicketTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Models.TicketModel", "Ticket")
                        .WithMany("TicketTags")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Shared.Models.TagModel", b =>
                {
                    b.Navigation("TicketTags");
                });

            modelBuilder.Entity("Shared.Models.TicketModel", b =>
                {
                    b.Navigation("Responses");

                    b.Navigation("TicketTags");
                });
#pragma warning restore 612, 618
        }
    }
}
