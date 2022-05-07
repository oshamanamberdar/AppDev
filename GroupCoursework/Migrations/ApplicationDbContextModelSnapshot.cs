﻿// <auto-generated />
using System;
using GroupCoursework.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GroupCoursework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.3.22175.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GroupCoursework.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ActorFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActorSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("GroupCoursework.Models.CastMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("DvdId")
                        .HasColumnType("int");

                    b.HasKey("Id", "ActorId", "DvdId");

                    b.HasIndex("ActorId");

                    b.HasIndex("DvdId");

                    b.ToTable("CastMembers");
                });

            modelBuilder.Entity("GroupCoursework.Models.DvdCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AgeRestricted")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DvdCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DvdCategories");
                });

            modelBuilder.Entity("GroupCoursework.Models.DvdCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DatePurchased")
                        .HasColumnType("datetime2");

                    b.Property<int>("DvdNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DvdNumber");

                    b.ToTable("DvdCopies");
                });

            modelBuilder.Entity("GroupCoursework.Models.DvdTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateReleased")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PenaltyCharge")
                        .HasColumnType("money");

                    b.Property<int>("ProducerNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("StandardCharge")
                        .HasColumnType("money");

                    b.Property<int>("StudioNumber")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryNumber");

                    b.HasIndex("ProducerNumber");

                    b.HasIndex("StudioNumber");

                    b.ToTable("DvdTitles");
                });

            modelBuilder.Entity("GroupCoursework.Models.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CopyNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDue")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateReturned")
                        .HasColumnType("datetime2");

                    b.Property<int>("LoanTypeNumber")
                        .HasColumnType("int");

                    b.Property<int>("MemberNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CopyNumber");

                    b.HasIndex("LoanTypeNumber");

                    b.HasIndex("MemberNumber");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("GroupCoursework.Models.LoanType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LoanDurantion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoanTypes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoanTypes");
                });

            modelBuilder.Entity("GroupCoursework.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MemberAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MemberDob")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MembershipCategoryNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MembershipCategoryNumber");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("GroupCoursework.Models.MembershipCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MembershipCategoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MembershipCategoryTotalLoans")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MembershipCategories");
                });

            modelBuilder.Entity("GroupCoursework.Models.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ProducerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("GroupCoursework.Models.Studio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("StudioName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("GroupCoursework.Models.CastMember", b =>
                {
                    b.HasOne("GroupCoursework.Models.Actor", "Actor")
                        .WithMany("CastMembers")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupCoursework.Models.DvdTitle", "DvdTitle")
                        .WithMany("CastMembers")
                        .HasForeignKey("DvdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("DvdTitle");
                });

            modelBuilder.Entity("GroupCoursework.Models.DvdCopy", b =>
                {
                    b.HasOne("GroupCoursework.Models.DvdTitle", "DvdTitle")
                        .WithMany()
                        .HasForeignKey("DvdNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DvdTitle");
                });

            modelBuilder.Entity("GroupCoursework.Models.DvdTitle", b =>
                {
                    b.HasOne("GroupCoursework.Models.DvdCategory", "DvdCategory")
                        .WithMany("DvdTitles")
                        .HasForeignKey("CategoryNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupCoursework.Models.Producer", "Producer")
                        .WithMany("DvdTitles")
                        .HasForeignKey("ProducerNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupCoursework.Models.Studio", "Studio")
                        .WithMany("DvdTitles")
                        .HasForeignKey("StudioNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DvdCategory");

                    b.Navigation("Producer");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("GroupCoursework.Models.Loan", b =>
                {
                    b.HasOne("GroupCoursework.Models.DvdCopy", "DvdCopy")
                        .WithMany("Loans")
                        .HasForeignKey("CopyNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupCoursework.Models.LoanType", "LoanType")
                        .WithMany("Loans")
                        .HasForeignKey("LoanTypeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupCoursework.Models.Member", "Member")
                        .WithMany("Loans")
                        .HasForeignKey("MemberNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DvdCopy");

                    b.Navigation("LoanType");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("GroupCoursework.Models.Member", b =>
                {
                    b.HasOne("GroupCoursework.Models.MembershipCategory", "MembershipCategory")
                        .WithMany("Members")
                        .HasForeignKey("MembershipCategoryNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipCategory");
                });

            modelBuilder.Entity("GroupCoursework.Models.Actor", b =>
                {
                    b.Navigation("CastMembers");
                });

            modelBuilder.Entity("GroupCoursework.Models.DvdCategory", b =>
                {
                    b.Navigation("DvdTitles");
                });

            modelBuilder.Entity("GroupCoursework.Models.DvdCopy", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("GroupCoursework.Models.DvdTitle", b =>
                {
                    b.Navigation("CastMembers");
                });

            modelBuilder.Entity("GroupCoursework.Models.LoanType", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("GroupCoursework.Models.Member", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("GroupCoursework.Models.MembershipCategory", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("GroupCoursework.Models.Producer", b =>
                {
                    b.Navigation("DvdTitles");
                });

            modelBuilder.Entity("GroupCoursework.Models.Studio", b =>
                {
                    b.Navigation("DvdTitles");
                });
#pragma warning restore 612, 618
        }
    }
}
