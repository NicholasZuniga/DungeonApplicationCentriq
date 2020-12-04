using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;


namespace DungeonMonster
{
    public class NormalMonster : Monster
    {
        public NormalMonster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, int monsterExp) : base(minDamage, maxDamage, description, name, hitChance, block, life, maxLife, monsterExp) { }

        public NormalMonster()
        {
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Forest Rat";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "A large rat, looks like easy target for practing your capablities";
            MonsterExp = 1;
        }
    }
}
