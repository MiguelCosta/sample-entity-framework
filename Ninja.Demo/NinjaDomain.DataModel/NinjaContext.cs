using NinjaDomain.Classes;
using NinjaDomain.Classes.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace NinjaDomain.DataModel
{
    public class NinjaContext : DbContext
    {
        public DbSet<Clan> Clans { get; set; }

        public DbSet<NinjaEquipment> Equipment { get; set; }

        public DbSet<Ninja> Ninjas { get; set; }

        public override int SaveChanges()
        {
            foreach(var history in ChangeTracker.Entries()
              .Where(e => e.Entity is IModificationHistory && (e.State == EntityState.Added ||
                      e.State == EntityState.Modified))
               .Select(e => e.Entity as IModificationHistory)
              )
            {
                history.DateModified = DateTime.Now;
                if(history.DateCreated == DateTime.MinValue)
                {
                    history.DateCreated = DateTime.Now;
                }
            }

            int result = base.SaveChanges();

            foreach(var history in ChangeTracker.Entries()
                                          .Where(e => e.Entity is IModificationHistory)
                                          .Select(e => e.Entity as IModificationHistory)
              )
            {
                history.IsDirty = false;
            }
            return result;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Types().
                Configure(c => c.Ignore("IsDirty"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
