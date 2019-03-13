using EFDemoLiveCoding.Core.Entities;
using EFDemoLiveCoding.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFDemoLiveCoding.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Database.EnsureDeleted();
                //ctx.Database.EnsureCreated();
                ctx.Database.Migrate();

                Team ferrari = new Team()
                {
                    Name = "Ferrari"
                };

                Team mercedes = new Team()
                {
                    Name = "Mercedes"
                };

                Driver schuhmacher = new Driver()
                {
                    Name = "Michael Schuhmacher",
                    Team = ferrari
                };

                Driver nikiLauda = new Driver()
                {
                    Name = "Niki Lauda",
                    Team = ferrari
                };

                Driver rossberg = new Driver()
                {
                    Name = "Niko Rossberg",
                    Team = mercedes
                };




                ctx.Drivers.Add(schuhmacher);
                ctx.Drivers.Add(nikiLauda);
                ctx.Drivers.Add(rossberg);

                Console.WriteLine($"Drivers in DB = {ctx.Drivers.Count()}");


                try
                {
                    int cntOfOperations = ctx.SaveChanges();
                    Console.WriteLine($"Number of Operations = {cntOfOperations}");
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine($"DB-Error: {ex.Message}");
                }
            }
        }


    }
}
