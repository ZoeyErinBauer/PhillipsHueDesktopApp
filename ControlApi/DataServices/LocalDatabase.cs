using ControlApi.DataModels.Hue;
using Microsoft.EntityFrameworkCore;

namespace ControlApi.DataServices;

public class LocalDatabase : DbContext
{
    public DbSet<ClientInformation> ClientInformations;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=database.db");
    }
    
}