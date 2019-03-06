using EFDemoLiveCoding.Core.Entities;
using EFDemoLiveCoding.Persistence;
using System;

namespace EFDemoLiveCoding.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Database.EnsureDeleted();

                Driver newDriver = new Driver()
                {
                    Name = "Sebastian Vettel",
                    Team = "Ferrari"
                };

                ctx.Drivers.Add(newDriver);
                try
                {
                    int cntOfOperations = ctx.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine($"DB-Error: {ex.Message}");
                }
            }
        }
    }
}
