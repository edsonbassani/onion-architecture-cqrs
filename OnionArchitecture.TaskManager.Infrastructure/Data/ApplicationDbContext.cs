using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.TaskManager.Core.Models;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectTaskConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
        {
            public void Configure(EntityTypeBuilder<Project> builder)
            {
                builder.ToTable("Project");
                builder.Property(p => p.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
                builder.Property(p => p.CreatedAt).HasColumnType("datetime").IsRequired();
                builder.Property(p => p.CreatedBy).HasColumnType("int").IsRequired();
                builder.Property(p => p.ModifiedAt).HasColumnType("datetime").IsRequired();
                builder.Property(p => p.ModifiedBy).HasColumnType("int").IsRequired();

                builder.HasKey(p => p.Id);

                builder.Property(p => p.Id)
                   .HasColumnType("int")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

                builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(p => p.CreatedBy)
                   .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(p => p.ModifiedBy)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
        internal class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
        {
            public void Configure(EntityTypeBuilder<ProjectTask> builder)
            {
                builder.ToTable("ProjectTasks");
                builder.Property(pt => pt.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                builder.Property(pt => pt.Name).IsRequired().HasMaxLength(100);
                builder.Property(pt => pt.ParentTaskId).HasColumnType("int").IsRequired();
                builder.Property(pt => pt.ProjectId).HasColumnType("int").IsRequired();
                builder.Property(pt => pt.Assignment).HasColumnType("int").IsRequired();
                builder.Property(pt => pt.StartDate).HasColumnType("datetime").IsRequired();
                builder.Property(pt => pt.DueDate).HasColumnType("datetime").IsRequired();
                builder.Property(pt => pt.CompletionDate).HasColumnType("datetime").IsRequired();
                builder.Property(pt => pt.CreatedAt).HasColumnType("datetime").IsRequired();
                builder.Property(pt => pt.CreatedBy).HasColumnType("int").IsRequired();
                builder.Property(pt => pt.ModifiedAt).HasColumnType("datetime").IsRequired();
                builder.Property(pt => pt.ModifiedBy).HasColumnType("int").IsRequired();

                builder.HasKey(pt => pt.Id);

                builder.Property(p => p.Id)
                   .HasColumnType("int")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

                builder.HasOne<Project>()
                   .WithMany()
                   .HasForeignKey(p => p.ProjectId)
                   .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(p => p.Assignment)
                   .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(p => p.CreatedBy)
                   .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(p => p.ModifiedBy)
                   .OnDelete(DeleteBehavior.Restrict);
            }
        }
        internal class UserConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.ToTable("User");
                builder.Property(u => u.Id).HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
                builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
                builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
                builder.Property(u => u.Login).IsRequired().HasMaxLength(10);
                builder.Property(u => u.Token).IsRequired().HasMaxLength(200);
                builder.Property(u => u.CreatedAt).HasColumnType("datetime").IsRequired();
                builder.Property(u => u.CreatedBy).HasColumnType("int").IsRequired();
                builder.Property(u => u.ModifiedAt).HasColumnType("datetime").IsRequired();
                builder.Property(u => u.ModifiedBy).HasColumnType("int").IsRequired();

                builder.HasKey(u => u.Id);

                builder.Property(p => p.Id)
                   .HasColumnType("int")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

                builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(p => p.CreatedBy)
                   .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(p => p.ModifiedBy)
                   .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}
