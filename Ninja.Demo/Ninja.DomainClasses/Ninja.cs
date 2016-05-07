using NinjaDomain.Classes.Interfaces;
using System;
using System.Collections.Generic;

namespace NinjaDomain.Classes
{
    public class Ninja : IModificationHistory
    {
        public Clan Clan { get; set; }

        public int ClanId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DayOfBirth { get; set; }

        public List<NinjaEquipment> EquipmentOwned { get; set; } = new List<NinjaEquipment>();

        public int Id { get; set; }

        public bool IsDirty { get; set; }

        public string Name { get; set; }

        public bool ServedInOniwaban { get; set; }
    }
}
