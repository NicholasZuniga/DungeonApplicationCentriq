using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonLibrary
{
    public class BossMonster : Monster
    {
        public int Posion { get; set; }


        public BossMonster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, int monsterExp, int posion) : base(minDamage, maxDamage, description, name, hitChance, block, life, maxLife, monsterExp)
        {
            Posion = posion;
        }
    }
}
