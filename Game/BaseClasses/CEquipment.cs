using System.Reflection;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Game.BaseClasses
{
    public class CEquipmentDescription:CItemDescription
    {
        public override CCultivator.CStats Bonus { get; set; } = new CCultivator.CStats();
        
        public CEquipmentDescription(int id, string name, string description, string picture) : base(id, name, description, picture)
        {         
            
        }

        public CEquipmentDescription Use(CCultivator.CStats in_)
        {
            Bonus = in_.Copy();
            return this;
        }
    }
    public class CEquipmentInventory:CItemInventory
    {
        public CCultivator.CStats Bonus { get; set; } = new CCultivator.CStats();

        public CEquipmentInventory(){}

        public CEquipmentInventory(int id, CCultivator.CStats bonus)
        {
            Id = id;
            Bonus = bonus.Copy();
        }
        
        public CEquipmentInventory Copy()
        {
            CEquipmentInventory out_ = new CEquipmentInventory();
            out_.Bonus = Bonus.Copy();
            out_.Id = Id;
            return out_;
        }

        public CCultivator.CStats PutOn(CCultivator.CStats in_)
        {
            CCultivator.CStats out_ = in_;
            out_.MainStats.Agility += Bonus.MainStats.Agility;
            out_.MainStats.Endurance += Bonus.MainStats.Endurance;
            out_.MainStats.Intelligence += Bonus.MainStats.Intelligence;
            out_.MainStats.Strength += Bonus.MainStats.Strength;
            out_.SubStats.Charisma += Bonus.SubStats.Charisma;
            out_.SubStats.Luck += Bonus.SubStats.Luck;
            out_.SubStats.Perception += Bonus.SubStats.Perception;
            out_.Scales.Agility *= Bonus.Scales.Agility;
            out_.Scales.Endurance *= Bonus.Scales.Endurance;
            out_.Scales.Intelligence *= Bonus.Scales.Intelligence;
            out_.Scales.Strength *= Bonus.Scales.Strength;
            return out_;
            
        }
        
        public override CItemDescription Description()
        {
            return ((CEquipmentDescription)GItemsList.Get(Id)).Use(Bonus);
        }
    }
}