using System;
using System.Collections.Generic;

namespace NinjaDomain.Classes
{
    public class Clan
    {
        public string ClanName { get; set; }

        public int Id { get; set; }

        public List<Ninja> Ninjas { get; set; }
    }

    public class Ninja
    {
        public Clan Clan { get; set; }

        public int ClanId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<NinjaEquipment> EquipmentOwned { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool ServedInOniwaban { get; set; }
    }

    public class NinjaEquipment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Ninja Ninja { get; set; }

        public int NinjaId { get; set; }

        public EquipmentType Type { get; set; }
    }
}
