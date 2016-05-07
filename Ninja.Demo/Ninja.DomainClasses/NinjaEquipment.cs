using NinjaDomain.Classes.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace NinjaDomain.Classes
{
    public class NinjaEquipment : IModificationHistory
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public int Id { get; set; }

        public bool IsDirty { get; set; }

        public string Name { get; set; }

        [Required]
        public Ninja Ninja { get; set; }

        public EquipmentType Type { get; set; }
    }
}
