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
    [Migration("20220615170850_SizeOfMainbarTypo")]
    partial class SizeOfMainbarTypo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("QSANN.Data.Entities.CarpentryworksInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AreaOfDesignation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SizeOfLumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("CarpentryworksInputs", (string)null);
                });

            modelBuilder.Entity("QSANN.Data.Entities.ConcreteBeamInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClassMixture")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeightOfBeam")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("LengthOfBeam")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumbersOfCount")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("WidthOfBeam")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ConcreteBeamInputs", (string)null);
                });

            modelBuilder.Entity("QSANN.Data.Entities.ConcreteColumnInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClassMixture")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeightOfColumn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("LengthOfColumn")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumbersOfCount")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("WidthOfColumn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ConcreteColumnInputs", (string)null);
                });

            modelBuilder.Entity("QSANN.Data.Entities.ConcreteFootingInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClassMixture")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("LengthOfFooting")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumbersOfCount")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThicknessOfFooting")
                        .HasColumnType("TEXT");

                    b.Property<string>("WidthOfFooting")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ConcreteFootingInputs", (string)null);
                });

            modelBuilder.Entity("QSANN.Data.Entities.ConcreteOtherInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClassMixture")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumbersOfCount")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("TotalVolume")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ConcreteOtherInputs", (string)null);
                });

            modelBuilder.Entity("QSANN.Data.Entities.ConcreteSlabInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClassMixture")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("LengthOfSlab")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumbersOfCount")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThicknessOfSlab")
                        .HasColumnType("TEXT");

                    b.Property<string>("WidthOfSlab")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ConcreteSlabInputs", (string)null);
                });

            modelBuilder.Entity("QSANN.Data.Entities.FormworksBeamInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeightOfBeam")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("LengthOfBeam")
                        .HasColumnType("TEXT");

                    b.Property<string>("LumberSize")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumberOfCounts")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThicknessOfPlywood")
                        .HasColumnType("TEXT");

                    b.Property<string>("WidthOfBeam")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("FormworksBeamInputs", (string)null);
                });

            modelBuilder.Entity("QSANN.Data.Entities.FormworksColumnInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeightOfColumn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("LengthOfColumn")
                        .HasColumnType("TEXT");

                    b.Property<string>("LumberSize")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumberOfCounts")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThicknessOfPlywood")
                        .HasColumnType("TEXT");

                    b.Property<string>("WidthOfColumn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("FormworksColumnInputs", (string)null);
                });

            modelBuilder.Entity("QSANN.Data.Entities.MasonryInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClassMixtureForMortar")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClassMixtureForPlaster")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeightOfWall")
                        .HasColumnType("TEXT");

                    b.Property<string>("HorizontalBarSpacing")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("LengthOfWall")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThicknessInMillimeter")
                        .HasColumnType("TEXT");

                    b.Property<string>("VerticalBarSpacing")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("MasonryInputs", (string)null);
                });

            modelBuilder.Entity("QSANN.Data.Entities.OtherMaterial", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConstructionScope")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Quantity")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("OtherMaterials", (string)null);
                });

            modelBuilder.Entity("QSANN.Data.Entities.PaintworksInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AreaOfApplication")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Finish")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("PaintworksInputs", (string)null);
                });

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

                    b.ToTable("Project");
                });

            modelBuilder.Entity("QSANN.Data.Entities.RebarworksBeamInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeightOfBeam")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("LengthOfBeam")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumbersOfBeam")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SizeOfMainbar")
                        .HasColumnType("TEXT");

                    b.Property<string>("SizeOfStirrups")
                        .HasColumnType("TEXT");

                    b.Property<string>("WidthOfBeam")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("RebarworksBeamInputs", (string)null);
                });

            modelBuilder.Entity("QSANN.Data.Entities.RebarworksColumnInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeightOfColumn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("LengthOfColumn")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumbersOfColumn")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SizeOfLateralties")
                        .HasColumnType("TEXT");

                    b.Property<string>("SizeOfMainbar")
                        .HasColumnType("TEXT");

                    b.Property<string>("WidthOfColumn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("RebarworksColumnInputs", (string)null);
                });

            modelBuilder.Entity("QSANN.Data.Entities.RebarworksFootingInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("LengthOfFooting")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumbersOfFooting")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SizeOfSteelbar")
                        .HasColumnType("TEXT");

                    b.Property<string>("SpacingOfSteelbar")
                        .HasColumnType("TEXT");

                    b.Property<string>("WidthOfFooting")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("RebarworksFootingInputs", (string)null);
                });

            modelBuilder.Entity("QSANN.Data.Entities.RebarworksSlabInput", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("FloorArea")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<int>("OneWayOrTwoWay")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SizeOfSteelbar")
                        .HasColumnType("TEXT");

                    b.Property<string>("SteelbarSpacing")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("RebarworksSlabInputs", (string)null);
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

                    b.ToTable("TileworksInputs", (string)null);
                });

            modelBuilder.Entity("QSANN.Data.Entities.CarpentryworksInput", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("QSANN.Data.Entities.ConcreteBeamInput", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("QSANN.Data.Entities.ConcreteColumnInput", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("QSANN.Data.Entities.ConcreteFootingInput", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("QSANN.Data.Entities.ConcreteOtherInput", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("QSANN.Data.Entities.ConcreteSlabInput", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("QSANN.Data.Entities.FormworksBeamInput", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("QSANN.Data.Entities.FormworksColumnInput", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("QSANN.Data.Entities.MasonryInput", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("QSANN.Data.Entities.OtherMaterial", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("QSANN.Data.Entities.PaintworksInput", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("QSANN.Data.Entities.RebarworksBeamInput", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("QSANN.Data.Entities.RebarworksColumnInput", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("QSANN.Data.Entities.RebarworksFootingInput", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("QSANN.Data.Entities.RebarworksSlabInput", b =>
                {
                    b.HasOne("QSANN.Data.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
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
