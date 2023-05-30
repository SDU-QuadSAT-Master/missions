using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DbSet<Mission> Missions { get; set; }
	public DbSet<AntennaConfig> AntennaConfigs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("Host=postgres; Database=missions; Username=usr_missions; Password=missions");
}

