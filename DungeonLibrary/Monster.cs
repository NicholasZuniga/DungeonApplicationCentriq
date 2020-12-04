using System;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        private int _minDamage;

        public int MonsterExp { get; set; }
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }

        public Monster() { }

        public Monster(int minDamage, int maxDamage, string description, string name, int hitChance, int block, int life, int maxLife, int monsterExp)
        {
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            MonsterExp = monsterExp;
        }

        public override string ToString()
        {
            return string.Format("\n***Monster***\n{0}\nLife: {1} of {2}\nDamage: {3} to {4}\nBlock: {5}\nDescription:\n{6}\n",
                Name,
                Life,
                MaxLife,
                MinDamage,
                MaxDamage,
                Block,
                Description);
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
        }
    }
}
