﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pub.Core.Model;

namespace Pub.Core.Provider;

public partial class DBProvider : DbContext
{
    public DBProvider()
    {
    }

    public DBProvider(DbContextOptions<DBProvider> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventLikedQuestion> EventLikedQuestions { get; set; }

    public virtual DbSet<EventStatus> EventStatuses { get; set; }

    public virtual DbSet<PicutreEventLink> PicutreEventLinks { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<TableReservation> TableReservations { get; set; }

    public virtual DbSet<TeamAssignment> TeamAssignments { get; set; }

    public virtual DbSet<TeamAssignmentStatus> TeamAssignmentStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Hungarian_100_CI_AI_SC_UTF8");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.AccountName).HasMaxLength(100);
            entity.Property(e => e.EmailAddress).HasMaxLength(255);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.EventAssignedDate).HasColumnType("date");
            entity.Property(e => e.EventPinnedDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<EventStatus>(entity =>
        {
            entity.HasKey(e => e.EventStatusId).HasName("PK__EventSta__2EB666ACDD2A7AD4");

            entity.Property(e => e.EventStatusId).ValueGeneratedNever();
            entity.Property(e => e.EventStatusName).HasMaxLength(20);
        });

        modelBuilder.Entity<PicutreEventLink>(entity =>
        {
            entity.HasKey(e => e.PictureEventLinkId);
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.Property(e => e.TeamName).HasMaxLength(255);
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.Property(e => e.TableName).HasMaxLength(20);
        });

        modelBuilder.Entity<TableReservation>(entity =>
        {
            entity.Property(e => e.TeamName).HasMaxLength(255);
        });

        modelBuilder.Entity<TeamAssignment>(entity =>
        {
            entity.Property(e => e.SourceEmailAddress).HasMaxLength(255);
            entity.Property(e => e.TeamName).HasMaxLength(255);
        });

        modelBuilder.Entity<TeamAssignmentStatus>(entity =>
        {
            entity.Property(e => e.TeamAssignmentStatusId).ValueGeneratedNever();
            entity.Property(e => e.TeamAssignmentStatusName).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
