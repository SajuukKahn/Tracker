namespace Tracker.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using Tracker.Models;

    public class TrackerContext(DbContextOptions<TrackerContext> options) : DbContext(options)
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Issue> Issues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Project self-reference
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Reference)
                .WithMany()
                .HasForeignKey(p => p.ReferenceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Machine self-reference
            modelBuilder.Entity<Machine>()
                .HasOne(m => m.Reference)
                .WithMany()
                .HasForeignKey(m => m.ReferenceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Project -> Machines relationship
            modelBuilder.Entity<Machine>()
                .HasOne<Project>()
                .WithMany(p => p.Machines)
                .HasForeignKey(m => m.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Issue relationships
            modelBuilder.Entity<Issue>()
                .HasOne(i => i.Project)
                .WithMany(p => p.Issues)
                .HasForeignKey(i => i.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.Machine)
                .WithMany()
                .HasForeignKey(i => i.MachineId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.ReportedBy)
                .WithMany()
                .HasForeignKey(i => i.ReportedById)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Issue>()
                .HasOne(i => i.AssignedTo)
                .WithMany()
                .HasForeignKey(i => i.AssignedToId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configure many-to-many relationship for Project and People
            modelBuilder.Entity<Project>()
                .HasMany(p => p.People)
                .WithMany()
                .UsingEntity(j => j.ToTable("ProjectPeople"));

            // Configure many-to-many relationships for Machine and Person lists
            modelBuilder.Entity<Machine>()
                .HasMany(m => m.Project)
                .WithMany()
                .UsingEntity(j => j.ToTable("MachineProjectPersons"));

            modelBuilder.Entity<Machine>()
                .HasMany(m => m.Controls)
                .WithMany()
                .UsingEntity(j => j.ToTable("MachineControlsPersons"));

            modelBuilder.Entity<Machine>()
                .HasMany(m => m.Fluid)
                .WithMany()
                .UsingEntity(j => j.ToTable("MachineFluidPersons"));

            modelBuilder.Entity<Machine>()
                .HasMany(m => m.Software)
                .WithMany()
                .UsingEntity(j => j.ToTable("MachineSoftwarePersons"));

            modelBuilder.Entity<Machine>()
                .HasMany(m => m.Computer)
                .WithMany()
                .UsingEntity(j => j.ToTable("MachineComputerPersons"));

            modelBuilder.Entity<Machine>()
                .HasMany(m => m.Vision)
                .WithMany()
                .UsingEntity(j => j.ToTable("MachineVisionPersons"));

            modelBuilder.Entity<Machine>()
                .HasMany(m => m.Programming)
                .WithMany()
                .UsingEntity(j => j.ToTable("MachineProgrammingPersons"));

            modelBuilder.Entity<Machine>()
                .HasMany(m => m.Quality)
                .WithMany()
                .UsingEntity(j => j.ToTable("MachineQualityPersons"));

            modelBuilder.Entity<Machine>()
                .HasMany(m => m.Service)
                .WithMany()
                .UsingEntity(j => j.ToTable("MachineServicePersons"));
        }
    }
}