﻿using NinjaDomain.Classes;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace NinjaDomain.DataModel
{
    public class ConnectedRepository
    {
        private readonly NinjaContext _context = new NinjaContext();

        /// <summary>
        /// Quick way to initialize and seed the database on first use.
        /// </summary>
        public ConnectedRepository()
        {
            //DataHelpers.NewDbWithSeed();
        }

        public void DeleteCurrentNinja(Ninja ninja)
        {
            _context.Ninjas.Remove(ninja);
            Save();
        }

        public void DeleteEquipment(ICollection equipmentList)
        {
            foreach(NinjaEquipment equip in equipmentList)
            {
                _context.Equipment.Remove(equip);
            }
        }

        public IEnumerable GetClanList()
        {
            return _context.Clans.OrderBy(c => c.ClanName).Select(c => new { c.Id, c.ClanName }).ToList();
        }

        public Ninja GetNinjaById(int id)
        {
            return _context.Ninjas.Find(id);
        }

        public List<Ninja> GetNinjas()
        {
            return _context.Ninjas.ToList();
        }

        public Ninja GetNinjaWithEquipment(int id)
        {
            return _context.Ninjas.Include(n => n.EquipmentOwned)
              .FirstOrDefault(n => n.Id == id);
        }

        public Ninja NewNinja()
        {
            var ninja = new Ninja();
            _context.Ninjas.Add(ninja);
            return ninja;
        }

        public ObservableCollection<Ninja> NinjasInMemory()
        {
            if(_context.Ninjas.Local.Count == 0)
            {
                GetNinjas();
            }
            return _context.Ninjas.Local;
        }

        public void Save()
        {
            RemoveEmptyNewNinjas();
            _context.SaveChanges();
        }

        private void RemoveEmptyNewNinjas()
        {
            //you can't remove from or add to a collection in a foreach loop
            for(var i = _context.Ninjas.Local.Count ; i > 0 ; i--)
            {
                var ninja = _context.Ninjas.Local[i - 1];
                if(_context.Entry(ninja).State == EntityState.Added
                    && !ninja.IsDirty)
                {
                    _context.Ninjas.Remove(ninja);
                }
            }
        }
    }
}