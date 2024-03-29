﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QSANN.Data;

#nullable disable

namespace QSANN.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220609151511_Test")]
    partial class Test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("QSANN.Data.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("QSANN.Data.Entities.TileworksInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AreaOfWorkDesignation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SelectedMultiplier")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tileworks");
                });

            modelBuilder.Entity("QSANN.Data.Entities.TileworksInput", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });
#pragma warning restore 612, 618
        }
    }
}
