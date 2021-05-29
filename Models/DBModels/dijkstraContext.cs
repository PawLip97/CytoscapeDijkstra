using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CytoscapeDijkstra2.Models.DBModels
{
    public partial class dijkstraContext : DbContext
    {
        public dijkstraContext()
        {
        }

        public dijkstraContext(DbContextOptions<dijkstraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Graphsdatum> Graphsdata { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=dijkstra", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.18-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Graphsdatum>(entity =>
            {
                entity.ToTable("graphsdata");

                entity.HasIndex(e => e.UserId, "FK_UserId_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.EdgesCount).HasColumnType("int(11)");

                entity.Property(e => e.IsDeleted).HasColumnType("bit(1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NodesCount).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Graphsdata)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Login, "Login_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DateLastLogin).HasColumnType("datetime");

                entity.Property(e => e.DateRegistration).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnType("bit(1)");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(256)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsFixedLength(true);

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(128)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
