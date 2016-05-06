namespace CodeModelFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NinjaEquipment")]
    public partial class NinjaEquipment
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int NinjaId { get; set; }

        public int Type { get; set; }

        public virtual Ninja Ninja { get; set; }
    }
}