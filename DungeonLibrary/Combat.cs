using DungeonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        public static Random coin = new Random();

        public static void DoBossAttack(Character attacker, Character defender)
        {
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(30);

            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                int damageDealt = attacker.CalcDamage();

                defender.Life -= damageDealt;

                if (coin.Next(0, 1) == 1)
                {
                    var Boss = attacker as BossMonster;
                    var Posion = Boss.Posion;
                    defender.Life -= Posion;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();

            }
            else
            {
                Console.WriteLine("{0} missed!", attacker.Name);
            }
        }
        public static void DoAttack(Character attacker, Character defender)
        {
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(30);

            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                int damageDealt = attacker.CalcDamage();

                defender.Life -= damageDealt;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();

            }
            else
            {
                Console.WriteLine("{0} missed!", attacker.Name);
            }
        }
        public static void DoBattle(Player player, Monster monster)
        {
            if (monster.GetType() == typeof(BossMonster))
            {
                DoAttack(player, monster);
                if (monster.Life > 0)
                {
                    DoBossAttack(monster, player);
                }
                else
                {
                    player.GainExperience(monster.MonsterExp);
                }
            }
            else
            {


                DoAttack(player, monster);
                if (monster.Life > 0)
                {
                    DoAttack(monster, player);
                }
                else
                {
                    player.GainExperience(monster.MonsterExp);
                }
            }
        }
    }
}
