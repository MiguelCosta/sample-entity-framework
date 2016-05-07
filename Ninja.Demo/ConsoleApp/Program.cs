using NinjaDomain.Classes;
using NinjaDomain.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Database.SetInitializer(new NullDatabaseInitializer<NinjaContext>());
                //ResetDb();
                ClearInfo();
                InsertClan();
                ClearInfo();
                InsertMultipleNinjas();
                ClearInfo();
                InsertNinja();
                ClearInfo();
                SimpleNinjaQuiries();
                ClearInfo();
                QueryAndUpdateNinja();
                ClearInfo();
                QueryAndUpdateNinjaDisconnected();
                ClearInfo();
                RetrieveDataWithFind();
                ClearInfo();
                RetrieveDataWithStoredProc();
                ClearInfo();
                DeleteNinja();
                ClearInfo();
                DeleteNinjaWithFind();
                ClearInfo();
                InsertNinjaWithEquipment();
                ClearInfo();
                SimpleNinjaGraphQuery();
                ClearInfo();
                ProjectionQuery();
                ClearInfo();
                ReseedDatabase();
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static void ClearInfo()
        {
            Console.WriteLine("#################################################################");
            Console.WriteLine("#################################################################");
            Console.WriteLine("#################################################################");
        }

        private static void DeleteNinja()
        {
            using(var ctx = new NinjaContext())
            {
                ctx.Database.Log = Console.WriteLine;
                var ninja = ctx.Ninjas.FirstOrDefault();
                ctx.Ninjas.Remove(ninja);
                // OR 
                //ctx.Entry(ninja).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        private static void DeleteNinjaWithFind()
        {
            var keyval = 3;
            using(var ctx = new NinjaContext())
            {
                ctx.Database.Log = Console.WriteLine;
                ctx.Database.ExecuteSqlCommand("exec DeleteNinja {0}", keyval);
            }
        }

        private static void InsertClan()
        {
            using(var ctx = new NinjaContext())
            {
                var clan1 = new Clan
                {
                    Id = 1,
                    ClanName = "Clan PT"
                };
                var clan2 = new Clan
                {
                    Id = 2,
                    ClanName = "Clan BR"
                };

                ctx.Database.Log = Console.WriteLine;
                ctx.Clans.AddRange(new List<Clan> { clan1, clan2 });
                ctx.SaveChanges();
            }
        }

        private static void InsertMultipleNinjas()
        {
            var ninja1 = new Ninja
            {
                Name = "Leonardo",
                ServedInOniwaban = false,
                DayOfBirth = new DateTime(1984, 1, 1),
                ClanId = 1
            };
            var ninja2 = new Ninja
            {
                Name = "Raphael",
                ServedInOniwaban = false,
                DayOfBirth = new DateTime(1985, 1, 1),
                ClanId = 1
            };
            var ninja3 = new Ninja
            {
                Name = "Obama",
                ServedInOniwaban = false,
                DayOfBirth = new DateTime(1995, 3, 20),
                ClanId = 1
            };
            using(var ctx = new NinjaContext())
            {
                ctx.Database.Log = Console.WriteLine;
                ctx.Ninjas.AddRange(new List<Ninja> { ninja1, ninja2, ninja3 });
                ctx.SaveChanges();
            }
        }

        private static void InsertNinja()
        {
            var ninja = new Ninja
            {
                Name = "SampsonSan",
                ServedInOniwaban = false,
                DayOfBirth = new DateTime(2008, 1, 28),
                ClanId = 1
            };
            using(var ctx = new NinjaContext())
            {
                ctx.Database.Log = Console.WriteLine;
                ctx.Ninjas.Add(ninja);
                ctx.SaveChanges();
            }
        }

        private static void InsertNinjaWithEquipment()
        {
            using(var ctx = new NinjaContext())
            {
                ctx.Database.Log = Console.WriteLine;

                var ninja = new Ninja
                {
                    Name = "Kacy Catanzaro",
                    ServedInOniwaban = false,
                    DayOfBirth = new DateTime(1990, 1, 14),
                    ClanId = 1
                };
                var muscles = new NinjaEquipment
                {
                    Name = "Muscles",
                    Type = EquipmentType.Tool,
                };
                var spunk = new NinjaEquipment
                {
                    Name = "Spunk",
                    Type = EquipmentType.Weapon
                };

                ninja.EquipmentOwned.Add(muscles);
                ninja.EquipmentOwned.Add(spunk);
                ctx.Ninjas.Add(ninja);
                ctx.SaveChanges();
            }
        }

        private static void ProjectionQuery()
        {
            using(var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                // Projection Queries
                var ninjas = context.Ninjas
                    .Select(n => new { n.Name, n.DayOfBirth, n.EquipmentOwned })
                    .ToList();
            }
        }

        private static void QueryAndUpdateNinja()
        {
            using(var ctx = new NinjaContext())
            {
                ctx.Database.Log = Console.WriteLine;
                var ninja = ctx.Ninjas.FirstOrDefault();
                ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);
                ctx.SaveChanges();
            }
        }

        private static void QueryAndUpdateNinjaDisconnected()
        {
            Ninja ninja;
            using(var ctx = new NinjaContext())
            {
                ctx.Database.Log = Console.WriteLine;
                ninja = ctx.Ninjas.FirstOrDefault();
            }

            ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);

            using(var ctx = new NinjaContext())
            {
                ctx.Database.Log = Console.WriteLine;
                ctx.Entry(ninja).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        private static void ReseedDatabase()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<NinjaContext>());
            using(var context = new NinjaContext())
            {
                context.Clans.Add(new Clan { ClanName = "Vermont Clan" });
                var j = new Ninja
                {
                    Name = "JulieSan",
                    ServedInOniwaban = false,
                    DayOfBirth = new DateTime(1980, 1, 1),
                    ClanId = 1
                };
                var s = new Ninja
                {
                    Name = "SampsonSan",
                    ServedInOniwaban = false,
                    DayOfBirth = new DateTime(2008, 1, 28),
                    ClanId = 1
                };
                var l = new Ninja
                {
                    Name = "Leonardo",
                    ServedInOniwaban = false,
                    DayOfBirth = new DateTime(1984, 1, 1),
                    ClanId = 1
                };
                var r = new Ninja
                {
                    Name = "Raphael",
                    ServedInOniwaban = false,
                    DayOfBirth = new DateTime(1985, 1, 1),
                    ClanId = 1
                };
                context.Ninjas.AddRange(new List<Ninja> { j, s, l, r });
                context.SaveChanges();
                context.Database.ExecuteSqlCommand(
                  @"CREATE PROCEDURE GetOldNinjas
                    AS  SELECT * FROM Ninjas WHERE DayOfBirth<='1/1/1980'");

                context.Database.ExecuteSqlCommand(
                   @"CREATE PROCEDURE DeleteNinjaViaId
                     @Id int
                     AS
                     DELETE from Ninjas Where Id = @id
                     RETURN @@rowcount");
            }
        }

        private static void ResetDb()
        {
            using(var ctx = new NinjaContext())
            {
                ctx.Database.Log = Console.WriteLine;
                ctx.Ninjas.RemoveRange(ctx.Ninjas);
                ctx.Clans.RemoveRange(ctx.Clans);
                ctx.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Clans', RESEED, 0)");
                ctx.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Ninjas', RESEED, 0)");
                ctx.SaveChanges();
            }
        }

        private static void RetrieveDataWithFind()
        {
            var keyval = 4;
            using(var ctx = new NinjaContext())
            {
                ctx.Database.Log = Console.WriteLine;
                var ninja = ctx.Ninjas.Find(keyval);
                Console.WriteLine($"FIND#1: {ninja.Name}");

                // nao chega a fazer query à base de dados
                var ninja2 = ctx.Ninjas.Find(keyval);
                Console.WriteLine($"FIND#2: {ninja2.Name}");
            }
        }

        private static void RetrieveDataWithStoredProc()
        {
            using(var ctx = new NinjaContext())
            {
                ctx.Database.Log = Console.WriteLine;
                var ninjas = ctx.Ninjas.SqlQuery("exec GetOldNinjas").ToList();
                foreach(var n in ninjas)
                {
                    Console.WriteLine(n.Name);
                }
            }
        }

        private static void SimpleNinjaGraphQuery()
        {
            using(var ctx = new NinjaContext())
            {
                ctx.Database.Log = Console.WriteLine;

                //Eager Loading
                //var ninjas = context.Ninjas.Include(n => n.EquipmentOwned)
                //    .FirstOrDefault(n => n.Name.StartsWith("Kacy"));

                // Explicit Loading
                var ninja = ctx.Ninjas
                           .FirstOrDefault(n => n.Name.StartsWith("Kacy"));
                Console.WriteLine("Ninja Retrieved:" + ninja.Name);
                ctx.Entry(ninja).Collection(n => n.EquipmentOwned).Load();
            }
        }

        private static void SimpleNinjaQuiries()
        {
            using(var ctx = new NinjaContext())
            {
                ctx.Database.Log = Console.WriteLine;
                // all ninjas
                var ninjas = ctx.Ninjas.ToList();
                Console.WriteLine("ALL NINJAS");
                Console.WriteLine(string.Join(", ", ninjas.Select(n => n.Name)));

                // some ninjas
                var query = ctx.Ninjas;
                var someNinjas = query.Where(n => n.Id > 1);
                Console.WriteLine("SOME NINJAS");
                Console.WriteLine(string.Join(", ", someNinjas.Select(n => n.Name)));

                // first ninja
                var firstNinja = ctx.Ninjas.FirstOrDefault(n => n.DayOfBirth > new DateTime(1990, 01, 01));
                Console.WriteLine("FIRST NINJA");
                Console.WriteLine(firstNinja.Name);

                // bad idea - connection fica aberta durante executacao
                var queryNo = ctx.Ninjas;
                Console.WriteLine("BAD IDEA");
                foreach(var n in queryNo)
                {
                    Console.WriteLine(n.Name);
                }

                // pagination
                int pageNumber = 2;
                int itensPerPage = 3;
                var page = ctx.Ninjas
                    .OrderBy(n => n.Name)
                    .Skip((pageNumber - 1) * itensPerPage)
                    .Take(itensPerPage)
                    .ToList();
            }
        }
    }
}
