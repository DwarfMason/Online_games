using System;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Game.BaseClasses
{
    public class CMob
    {
        public CMob(int id, int difficulty, string name, string description, string picture)
        {
            if (GMobsList.MobsList.ContainsKey(id))
            {
                throw new Exception("Mob already exist");
            }
            Id = id;
            Difficulty = difficulty;
            Name = name;
            Description = description;
            Picture = picture;
            GMobsList.Add(this);
        }
            

        public void CalcStats(CCultivator character)
        {
            Random rnd = new Random();
            Strength = Math.Max(character.Stats.MainStats.Strength + rnd.Next(-5,5)*Difficulty + 
                       rnd.Next(-10, 10) * character.Tier + rnd.Next(-20, 0), 1);
            Agility = Math.Max(character.Stats.MainStats.Agility + rnd.Next(-5,5)*Difficulty + 
                               rnd.Next(-10, 10) * character.Tier + rnd.Next(-20, 0), 1);
            Intelligence = Math.Max(character.Stats.MainStats.Intelligence + rnd.Next(-5, 5) * Difficulty +
                                    rnd.Next(-10, 10) * character.Tier + rnd.Next(-20, 0), 1);
            Endurance = Math.Max(character.Stats.MainStats.Endurance + rnd.Next(-5, 5) * Difficulty +
                                    rnd.Next(-10, 10) * character.Tier, 1);
            Gold = 75 * Difficulty * 2 + character.Tier * 10;
        }
        
        
        public int Id { get; set; }
        public int Difficulty { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int Gold;
        public double Strength { get; set; }
        public double Agility { get; set; }
        public double Intelligence { get; set; }
        public double Endurance { get; set; }
    }
}