using NinjaDomain.Classes;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NinjaDomain.DataModel
{
    public class NinjaContext : DbContext
    {
        public DbSet<Clan> Clans { get; set; }

        public DbSet<NinjaEquipment> Equipment { get; set; }

        public DbSet<Ninja> Ninjas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
