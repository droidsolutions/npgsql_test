using Microsoft.EntityFrameworkCore;

namespace npgsql_test
{
  public class DataContext : DbContext
  {
    private readonly string _connectionString;

    public DataContext(string connectionString)
    {
      _connectionString = connectionString;
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Project { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseNpgsql(_connectionString);
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasPostgresExtension("uuid-ossp");

      modelBuilder.Entity<Project>(entity =>
      {
        entity.ToTable("project");

        entity.Property(e => e.Id)
                  .HasColumnName("id")
                  .HasDefaultValueSql("uuid_generate_v4()");

        entity.Property(e => e.OrganisationId)
                  .IsRequired()
                  .HasColumnName("organisationId")
                  .HasColumnType("character varying");
      });
    }
  }
}
