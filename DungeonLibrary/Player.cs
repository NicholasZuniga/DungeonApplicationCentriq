using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public int Experience { get; set; }
        public int MaxExp { get; set; }
        public int Level { get; set; }


        public Player(string name, int hitChance, int block, int life, int maxlife, Race characterRace, Weapon equippedWeapon)
        {
            MaxLife = maxlife;
            Name = name;
            HitChance = hitChance > 100 ? 100 : hitChance;
            Life = life;
            Block = block;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
            Experience = 0;
            MaxExp = 10;
            Level = 1;

            switch (CharacterRace)
            {
                case Race.Shade:
                    HitChance += 5;
                    break;
                case Race.Golem:
                    HitChance -= 5;
                    Block += 10;
                    break;
                case Race.Zombie:
                    HitChance -= 2;
                    Life += 5;
                    break;
                case Race.Mimic:
                    HitChance += 5;
                    break;
                default:
                    break;
            }
        }
        public override string ToString()
        {
            string description = "";

            switch (CharacterRace)
            {
                case Race.Shade:
                    description = "As a shade you are made of shadow and darker things";
                    break;
                case Race.Golem:
                    description = "You are made of dark magic and durable stone";
                    break;
                case Race.Zombie:
                    description = "Rotting flesh and a hate for the living is what makes a Zombie";
                    break;
                case Race.Mimic:
                    description = "Your body constantly shifts and bends to blend in your surroundings";
                    break;
            }

            return string.Format("***{0}***\nLife: {1} of {2}\nLevel :{8}\nExperience: {7}/{9}\nHit Chance: {3}%\nWeapon:\n{4}\nBlock: {5}\nDescription {6}",
                Name,
                Life,
                MaxLife,
                CalcHitChance(),
                EquippedWeapon,
                Block,
                description,
                Experience,
                Level,
                MaxExp);
        }

        public override int CalcDamage()
        {
            Random rand = new Random();

            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);

            return damage;
        }
        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }
        public void GainExperience(int MonsterLevel)
        {
            Experience += MonsterLevel;
            if (Experience >= MaxExp)
            {
                MaxExp = MaxExp + (Level ^ 2 / Level);
                Level++;
                Experience = 0;
                HitChance++;
                MaxLife = MaxLife + (Level ^ 2 / Level);
                Life = MaxLife;
                Block++;
            }
        }
    }
}
