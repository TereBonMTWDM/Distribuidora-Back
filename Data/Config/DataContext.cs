using System;
using Microsoft.EntityFrameworkCore;

namespace DistrbuidoraAPI.Data.Config;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var databaseUrl = Environment.GetEnvironmentVariable("DATABASE");
        optionsBuilder.UseSqlServer(
            databaseUrl,
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5, 
                    maxRetryDelay: TimeSpan.FromSeconds(30), 
                    errorNumbersToAdd: null); 
            });
    }

}
