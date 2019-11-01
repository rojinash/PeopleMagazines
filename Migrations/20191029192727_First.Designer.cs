﻿// <auto-generated />
using ManyToMany.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManyToMany.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20191029192727_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ManyToMany.Models.Magazine", b =>
                {
                    b.Property<int>("MagazineId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("MagazineId");

                    b.ToTable("Magazines");
                });

            modelBuilder.Entity("ManyToMany.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("PersonId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("ManyToMany.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MagazineId");

                    b.Property<int>("PersonId");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("MagazineId");

                    b.HasIndex("PersonId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("ManyToMany.Models.Subscription", b =>
                {
                    b.HasOne("ManyToMany.Models.Magazine", "Magazine")
                        .WithMany("Readers")
                        .HasForeignKey("MagazineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ManyToMany.Models.Person", "Person")
                        .WithMany("Subscriptions")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
