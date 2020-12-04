﻿// <auto-generated />
using System;
using Day4InClass.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Day4InClass.Data.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Day4InClass.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2020, 12, 3, 12, 56, 9, 811, DateTimeKind.Local).AddTicks(4443),
                            Description = "Project 1",
                            IsComplete = false,
                            Priority = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2020, 12, 3, 12, 56, 9, 820, DateTimeKind.Local).AddTicks(3966),
                            Description = "Project 2",
                            IsComplete = false,
                            Priority = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(2020, 12, 3, 12, 56, 9, 820, DateTimeKind.Local).AddTicks(4052),
                            Description = "Project 3",
                            IsComplete = false,
                            Priority = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
