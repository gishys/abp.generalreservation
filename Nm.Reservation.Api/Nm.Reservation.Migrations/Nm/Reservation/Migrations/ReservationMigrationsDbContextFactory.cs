using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nm.Reservation.Migrations
{
    public class ReservationMigrationsDbContextFactory : IDesignTimeDbContextFactory<ReservationMigrationsDbContext>
    {
        public ReservationMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ReservationMigrationsDbContext>()
                .UseOracle(configuration.GetConnectionString("NmReservation"));

            return new ReservationMigrationsDbContext(builder.Options);
        }
        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
