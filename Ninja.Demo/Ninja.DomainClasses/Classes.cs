using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NinjaDomain.Classes
{
    public class Clan
    {
        public string ClanName { get; set; }

        public int Id { get; set; }

        public List<Ninja> Ninjas { get; set; } = new List<Ninja>();
    }

    public class Ninja
    {
        public Clan Clan { get; set; }

        public int ClanId { get; set; }

        public DateTime DayOfBirth { get; set; }

        public List<NinjaEquipment> EquipmentOwned { get; set; } = new List<NinjaEquipment>();

        public int Id { get; set; }

        public string Name { get; set; }

        public bool ServedInOniwaban { get; set; }
    }

    public class NinjaEquipment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public Ninja Ninja { get; set; }

        public EquipmentType Type { get; set; }
    }
}
