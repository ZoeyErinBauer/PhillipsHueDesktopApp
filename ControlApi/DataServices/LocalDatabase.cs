using HueControlApi.DataModels.Hue;
using Microsoft.EntityFrameworkCore;

namespace HueControlApi.DataServices;

public class LocalDatabase : DbContext
{
    public DbSet<ClientInformation> ClientInformations;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=database.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientInformation>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
    }
}