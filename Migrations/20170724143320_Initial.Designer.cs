using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using bagAPI.Data;

namespace bagAPI.Migrations
{
    [DbContext(typeof(bagAPIContext))]
    [Migration("20170724143320_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("bagAPI.Models.Child", b =>
                {
                    b.Property<int>("ChildId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Delivered");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ChildId");

                    b.ToTable("Child");
                });

            modelBuilder.Entity("bagAPI.Models.Toy", b =>
                {
                    b.Property<int>("ToyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChildId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ToyId");

                    b.HasIndex("ChildId");

                    b.ToTable("Toy");
                });

            modelBuilder.Entity("bagAPI.Models.Toy", b =>
                {
                    b.HasOne("bagAPI.Models.Child", "Child")
                        .WithMany()
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
