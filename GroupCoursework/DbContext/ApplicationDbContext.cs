﻿
using GroupCoursework.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GroupCoursework.DbContext;



public class ApplicationDbContext: IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CastMember>().HasKey(cm => new
        {
            cm.Id,  
            cm.ActorId,
            cm.DvdId
        });
        modelBuilder.Entity<CastMember>().HasOne(a => a.Actor).WithMany(am => am.CastMembers)
            .HasForeignKey(a => a.ActorId);
        
        modelBuilder.Entity<CastMember>().HasOne(a => a.DvdTitle).WithMany(am => am.CastMembers)
            .HasForeignKey(a => a.DvdId);
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<MembershipCategory> MembershipCategories { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<LoanType> LoanTypes { get; set; }
    public DbSet<DvdCopy> DvdCopies { get; set; }
    public DbSet<DvdTitle> DvdTitles { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<Studio> Studios { get; set; }
    public DbSet<DvdCategory> DvdCategories { get; set; }
    public DbSet<CastMember> CastMembers { get; set; }
    public DbSet<Actor> Actors { get; set; }
    
}