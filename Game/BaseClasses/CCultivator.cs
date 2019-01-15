using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using WebApplication1.Game.BaseClasses.Equipment;

namespace WebApplication1.Game.BaseClasses
{
    public class CCultivator
    {
        public class CStats
        {
            public CStats(){}

            public CStats(int S, int A, int I, int E, int L, int C, int P,
                double S_S, double S_A, double S_I, double S_E)
            {
                MainStats.Endurance = E;
                MainStats.Strength = S;
                MainStats.Intelligence = I;
                MainStats.Agility = A;
                SubStats.Luck = L;
                SubStats.Charisma = C;
                SubStats.Perception = P;
                Scales.Endurance = S_E;
                Scales.Agility = S_A;
                Scales.Intelligence = S_I;
                Scales.Strength = S_S;
            }
            public CMainStats MainStats { get; set; } = new CMainStats();
            public CSubStats SubStats { get; set; } = new CSubStats();
            public CScales Scales { get; set; } = new CScales();

            public class CMainStats
            {
                public double Strength { get; set; } = 5;
                public double Agility { get; set; } = 5;
                public double Intelligence { get; set; } = 5;
                public double Endurance { get; set; } = 5;
            }

            public class CSubStats
            {
                public double Luck { get; set; } = 5;
                public double Charisma { get; set; } = 5;
                public double Perception { get; set; } = 5;
            }

            public class CScales
            {
                public double Strength { get; set; } = 1;
                public double Agility { get; set; } = 1;
                public double Intelligence { get; set; } = 1;
                public double Endurance { get; set; } = 1;
            }

            public CStats Copy()
            {
                CStats out_=new CStats();
                out_.MainStats.Agility = MainStats.Agility;
                out_.MainStats.Endurance = MainStats.Endurance;
                out_.MainStats.Intelligence = MainStats.Intelligence;
                out_.MainStats.Strength = MainStats.Strength;
                out_.SubStats.Charisma = SubStats.Charisma;
                out_.SubStats.Luck = SubStats.Luck;
                out_.SubStats.Perception = SubStats.Perception;
                out_.Scales.Agility = Scales.Agility;
                out_.Scales.Endurance = Scales.Endurance;
                out_.Scales.Intelligence = Scales.Intelligence;
                out_.Scales.Strength = Scales.Strength;
                return out_;
            }
        }

        public static int GetStatPrice(double stat)
        {
            var a = (int) Math.Pow(10, stat.ToString().Length) + (int) stat * 4;
            var b = 0;
            for (int i = 1; i < stat; i++)
            {
                b += i.ToString().Length * 10;
            }

            return (a + b);
        }

        public class CInventory
        {
            public List<CItemInventory> Items = new List<CItemInventory>();

            public void AddItem(CItemInventory itemInventory)
            {
                bool f = true;
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].Id == itemInventory.Id)
                    {
                        Items[itemInventory.Id].Count += itemInventory.Count;
                        f = false;
                        break;
                    }
                }

                if (f)
                {
                    Items.Add(itemInventory.Copy());
                }
            }

            public bool CanAddItem(CItemInventory itemInventory)
            {
                return true;
            }

            public bool ExistItem(CItemInventory itemInventory)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].Id == itemInventory.Id)
                    {
                        if (Items[i].Count >= itemInventory.Count)
                        return true;
                        else
                        return false;
                    }
                }
                return false;
            }

            public void DeleteItem(CItemInventory itemInventory)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].Id == itemInventory.Id)
                    {
                        Items[i].Count -= itemInventory.Count;
                        if (Items[i].Count == 0)
                        {
                            for (int j = i; j < Items.Count-1; j++)
                            {
                                Items[j] = Items[j + 1];
                            }
                            Items.RemoveAt(Items.Count-1);
                        }
                        break;                     
                    }
                }
                throw new Exception("Item don't exist");
            }
        }

        public class CEquipments
        {
            public int? CurentHelmet = null;
            public List<CHelmet> Helmets = new List<CHelmet>{};
            
            public int? CurentPlate= null;
            public List<CPlate> Plates = new List<CPlate>{};
            
            public int? CurentLeggins= null;
            public List<CLeggins> Leggins = new List<CLeggins>{};
            
            public int? CurentBoots= null;
            public List<CBoots> Boots = new List<CBoots>{};
            
            public int? CurentAmulet= null;
            public List<CAmulet> Amulets = new List<CAmulet>{};

            public void AddEquip(CEquipmentInventory in_)
            {
                if (in_ is CHelmet)
                {
                    Helmets.Add((CHelmet)in_);
                } 
                if (in_ is CAmulet)
                {
                    Amulets.Add((CAmulet)in_);
                }
                if (in_ is CPlate)
                {
                    Plates.Add((CPlate)in_);
                } 
                if (in_ is CBoots)
                {
                    Boots.Add((CBoots)in_);
                }
                if (in_ is CLeggins)
                {
                    Leggins.Add((CLeggins)in_);
                }
            }
            
        }
        
        public CStats RealStats()
        {
            CStats out_ = Stats.Copy();
            if (Equipments.CurentAmulet != null)
            {
                Equipments.Amulets[Equipments.CurentAmulet.Value].PutOn(out_);
            }
            if (Equipments.CurentBoots != null)
            {
                Equipments.Boots[Equipments.CurentBoots.Value].PutOn(out_);
            }
            if (Equipments.CurentHelmet != null)
            {
                Equipments.Helmets[Equipments.CurentHelmet.Value].PutOn(out_);
            }
            if (Equipments.CurentPlate != null)
            {
                Equipments.Plates[Equipments.CurentPlate.Value].PutOn(out_);
            }
            if (Equipments.CurentLeggins != null)
            {
                Equipments.Leggins[Equipments.CurentLeggins.Value].PutOn(out_);
            }
            return out_;
        }
        public string Id { get; set; }

        [BsonId] public string PlayerId { get; set; }
        public string Name { get; set; }

        public int Points { get; set; } = 0;
        public int Tier { get; set; } = 0;

        public CStats Stats { get; set; } = new CStats();
        public string HeroType { get; set; }

        public int Gold { get; set; } = 10;
        public int LocationId { get; set; } = 0;
        public CInventory Inventory { get; set; } = new CInventory();
        public CEquipments Equipments { get; set; } = new CEquipments();
    }
}