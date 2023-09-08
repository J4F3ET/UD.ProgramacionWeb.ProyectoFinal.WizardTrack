using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.Database.Conn;

public partial class WizardtrackContext : DbContext
{
    public WizardtrackContext()
    {
    }

    public WizardtrackContext(DbContextOptions<WizardtrackContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Debt> Debts { get; set; }

    public virtual DbSet<Income> Incomes { get; set; }

    public virtual DbSet<SaveCount> SaveCounts { get; set; }

    public virtual DbSet<Spent> Spents { get; set; }

    public virtual DbSet<UserWizardtrack> UserWizardtracks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-BEMQCO7\\SQLEXPRESS;Database=wizardtrack;User=sa;Password=123456;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Debt>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdUser }).HasName("PK__debt__5F3EFC5C436C9D5C");

            entity.ToTable("debt");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.Installments).HasColumnName("installments");
            entity.Property(e => e.Interest)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("interest");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.StarDate)
                .HasColumnType("date")
                .HasColumnName("star_date");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Debts)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__debt__id_user__4BAC3F29");
        });

        modelBuilder.Entity<Income>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdUser }).HasName("PK__income__5F3EFC5C4BAC8985");

            entity.ToTable("income");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Frecuency).HasColumnName("frecuency");
            entity.Property(e => e.IncomeDate)
                .HasColumnType("date")
                .HasColumnName("income_date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Incomes)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__income__id_user__5441852A");
        });

        modelBuilder.Entity<SaveCount>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdUser }).HasName("PK__save_cou__5F3EFC5C4B7B0C9D");

            entity.ToTable("save_count");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.StarDate)
                .HasColumnType("date")
                .HasColumnName("star_date");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.SaveCounts)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__save_coun__id_us__4E88ABD4");
        });

        modelBuilder.Entity<Spent>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.IdUser }).HasName("PK__spent__5F3EFC5C2EB23BEF");

            entity.ToTable("spent");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.SpentDate)
                .HasColumnType("date")
                .HasColumnName("spent_date");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Spents)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__spent__id_user__5165187F");
        });

        modelBuilder.Entity<UserWizardtrack>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_wiz__3213E83F3FE9F115");

            entity.ToTable("user_wizardtrack");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Salt)
                .HasMaxLength(16)
                .HasColumnName("salt");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
