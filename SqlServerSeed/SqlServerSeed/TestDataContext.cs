using Microsoft.EntityFrameworkCore;
using SqlServerSeed.Models;

namespace SqlServerSeed;

public class TestDataContext : DbContext
{
    private readonly string _connectionString;

    public TestDataContext(string connectionString) => _connectionString = connectionString;

    public TestDataContext(DbContextOptions<TestDataContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}