using Microsoft.VisualStudio.TestTools.UnitTesting;
using EfDemo.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfDemo.Core.Entities;

namespace EfDemo.Persistence.Tests
{
    [TestClass()]
    public class ApplicationDbContextTests
    {

        [TestInitialize]
        public void InitTest()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                dbContext.Database.Delete();
            }
        }


        [TestMethod()]
        public void ApplicationDbContext_AddSchoolClass_ShouldPersistSchoolClass()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                SchoolClass schoolClass = new SchoolClass {Name = "6ABIF_6AKIF"};
                Assert.AreEqual(0,schoolClass.Id);
                dbContext.SchoolClasses.Add(schoolClass);
                dbContext.SaveChanges();
                Assert.AreNotEqual(0, schoolClass.Id);
            }
            using (ApplicationDbContext verifyContext = new ApplicationDbContext())
            {
                StringBuilder logText = new StringBuilder();
                verifyContext.Database.Log = text => logText.AppendLine(text);
                Assert.AreEqual(1, verifyContext.SchoolClasses.Count());
                SchoolClass schoolClass = verifyContext.SchoolClasses.First();
                Assert.IsNotNull(schoolClass);
                Assert.AreEqual("6ABIF_6AKIF", schoolClass.Name);

            }
        }

        [TestMethod]
        public void ApplicationDbContext_AddSchoolClassWithPupils_QueryPupils_ShouldReturnPupils()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                SchoolClass schoolClass = new SchoolClass { Name = "6ABIF_6AKIF" };
                schoolClass.Pupils = new List<Pupil>
                {
                    new Pupil {FirstName = "Max", LastName = "Mustermann", BirthDate = DateTime.Parse("1.1.1990")},
                    new Pupil {FirstName = "Eva", LastName = "Musterfrau", BirthDate = DateTime.Parse("1.1.1991")},
                    new Pupil {FirstName = "Fritz", LastName = "Musterkind", BirthDate = DateTime.Parse("1.1.1980")},
                    new Pupil {FirstName = "Franz", LastName = "Huber", BirthDate = DateTime.Parse("10.7.1999")}
                };
                dbContext.SchoolClasses.Add(schoolClass);
                dbContext.SaveChanges();
                Assert.AreEqual(1, schoolClass.Id);
            }
            using (ApplicationDbContext queryContext = new ApplicationDbContext())
            {
                StringBuilder logText = new StringBuilder();
                queryContext.Database.Log = text => logText.AppendLine(text);
                Assert.AreEqual(1, queryContext.SchoolClasses.Count());
                Assert.AreEqual(4, queryContext.Pupils.Count());
                // Ältester Schüler
                var eldest = queryContext.Pupils.OrderBy(pupil => pupil.BirthDate).First();
                Assert.AreEqual("Musterkind", eldest.LastName);
            }
        }


        [TestMethod()]
        public void ApplicationDbContext_UpdateSchoolClass_ShouldReturnChangedSchoolClass()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                SchoolClass schoolClass = new SchoolClass { Name = "5ABIF_5AKIF" };
                Assert.AreEqual(0, schoolClass.Id);
                dbContext.SchoolClasses.Add(schoolClass);
                dbContext.SaveChanges();
                Assert.AreNotEqual(0, schoolClass.Id);
            }
            using (ApplicationDbContext updateContext = new ApplicationDbContext())
            {
                StringBuilder logText = new StringBuilder();
                updateContext.Database.Log = text => logText.AppendLine(text);
                SchoolClass schoolClass = updateContext.SchoolClasses.First();
                schoolClass.Name = "6ABIF_6AKIF";
                updateContext.SaveChanges();
            }
            using (ApplicationDbContext verifyContext = new ApplicationDbContext())
            {
                SchoolClass schoolClass = verifyContext.SchoolClasses.First();
                Assert.AreEqual("6ABIF_6AKIF", schoolClass.Name);
            }
        }

        [TestMethod()]
        public void ApplicationDbContext_DeleteSchoolClass_ShouldReturnZeroSchoolClasses()
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                SchoolClass schoolClass = new SchoolClass { Name = "6ABIF_6AKIF" };
                Assert.AreEqual(0, schoolClass.Id);
                dbContext.SchoolClasses.Add(schoolClass);
                dbContext.SchoolClasses.Add(new SchoolClass {Name = "5ABIF_5AKIF"});
                dbContext.SaveChanges();
                Assert.AreNotEqual(0, schoolClass.Id);
            }
            using (ApplicationDbContext deleteContext = new ApplicationDbContext())
            {
                SchoolClass schoolClass = deleteContext.SchoolClasses.Single(sc=>sc.Name=="5ABIF_5AKIF");
                deleteContext.SchoolClasses.Remove(schoolClass);
                deleteContext.SaveChanges();
            }
            using (ApplicationDbContext verifyContext = new ApplicationDbContext())
            {
                Assert.AreEqual(1, verifyContext.SchoolClasses.Count());
                var schoolClass = verifyContext.SchoolClasses.First();
                Assert.AreEqual("6ABIF_6AKIF", schoolClass.Name);
            }
        }


    }
}