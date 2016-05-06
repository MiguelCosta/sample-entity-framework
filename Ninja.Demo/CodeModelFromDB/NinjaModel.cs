namespace CodeModelFromDB
{
    using System.Data.Entity;

    public partial class NinjaModel : DbContext
    {
        public NinjaModel()
            : base("name=NinjaModel")
        {
        }

        public virtual DbSet<Clan> Clan { get; set; }

        public virtual DbSet<Ninja> Ninja { get; set; }

        public virtual DbSet<NinjaEquipment> NinjaEquipment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
