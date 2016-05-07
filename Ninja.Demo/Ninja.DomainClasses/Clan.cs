using NinjaDomain.Classes.Interfaces;
using System;
using System.Collections.Generic;

namespace NinjaDomain.Classes
{
    public class Clan : IModificationHistory
    {
        public string ClanName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public int Id { get; set; }

        public bool IsDirty { get; set; }

        public List<Ninja> Ninjas { get; set; } = new List<Ninja>();
    }
}
