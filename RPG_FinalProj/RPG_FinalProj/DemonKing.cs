﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial1_Movement_Classes_COMPROGPROJ
{
    internal class DemonKing
    {
        public string[] Skills = { "Hellish Roar", "Abyssal Steel", "Binding Vow", "Armaggeddon" };
        public int[] Attack(int attackNum, int MobStrength, int playerArmor, int playerMR, int playerLuck, int playerEvasion, int[] playerDebuffs, int[] mobBuffs)
        {
            int[] damage = { 0, 0, 0, 0, 0, 0, 0 };
            Random random = new Random();
            int randomAttack = attackNum % 6;
            int Attackpicker = random.Next(1, 101);
            if (randomAttack == 0)
            {
                damage = Damage(4, MobStrength, playerArmor, playerMR, playerLuck, playerEvasion, playerDebuffs, mobBuffs);
            }
            else if (randomAttack == 1)
            {
                if (Attackpicker >= 70)
                {
                    damage = Damage(3, MobStrength, playerArmor, playerMR, playerLuck, playerEvasion, playerDebuffs, mobBuffs);
                }
                else
                {
                    damage = Damage(4, MobStrength, playerArmor, playerMR, playerLuck, playerEvasion, playerDebuffs, mobBuffs);
                }
            }
            else if (randomAttack == 2)
            {
                if (Attackpicker >= 85)
                {
                    damage = Damage(4, MobStrength, playerArmor, playerMR, playerLuck, playerEvasion, playerDebuffs, mobBuffs);
                }
                else
                {
                    damage = Damage(3, MobStrength, playerArmor, playerMR, playerLuck, playerEvasion, playerDebuffs, mobBuffs);
                }
            }
            else if (randomAttack == 3)
            {
                if (Attackpicker >= 85)
                {
                    damage = Damage(3, MobStrength, playerArmor, playerMR, playerLuck, playerEvasion, playerDebuffs, mobBuffs);
                }
                else if (Attackpicker >= 80)
                {
                    damage = Damage(4, MobStrength, playerArmor, playerMR, playerLuck, playerEvasion, playerDebuffs, mobBuffs);
                }
                else
                {
                    damage = Damage(1, MobStrength, playerArmor, playerMR, playerLuck, playerEvasion, playerDebuffs, mobBuffs);
                }
            }
            else if (randomAttack == 4 || randomAttack == 5)
            {
                if (Attackpicker >= 50)
                {
                    damage = Damage(1, MobStrength, playerArmor, playerMR, playerLuck, playerEvasion, playerDebuffs, mobBuffs);
                }
                else
                {
                    damage = Damage(2, MobStrength, playerArmor, playerMR, playerLuck, playerEvasion, playerDebuffs, mobBuffs);
                }
            }
            return damage;
        }
        public int[] Damage(int chosenAttack, int MobStrength, int playerArmor, int playerMR, int playerLuck, int playerEvasion, int[] playerDebuffs, int[] mobBuffs)
        {
            Random random = new Random();
            int[] damage = { 0, 0, 0, 0, 0, 0, 0, 0 };
            damage[0] = chosenAttack;
            if (chosenAttack == 1)
            {

                if (random.Next(1, 101) >= 50 - (playerLuck * .6))
                {
                    damage[1] = (int)(((30 + (MobStrength * (1 + (mobBuffs[0] / 100f))) * 3.5f) * ((100 - (playerArmor * (playerDebuffs[0] / 100f))) / 100f)) * 1.5);
                    damage[2] = 100;
                    damage[3] = 100;
                    damage[7] = 0;
                }
                else
                {
                    damage[1] = (int)(((30 + (MobStrength * (1 + (mobBuffs[0] / 100f))) * 3.5f) * ((100 - (playerArmor * (playerDebuffs[0] / 100f))) / 100f)));
                    damage[2] = 100;
                    damage[3] = 100;
                    damage[7] = 0;
                }

            }
            else if (chosenAttack == 2)
            {
                if (random.Next(1, 101) >= 50 - (playerLuck * .6))
                {
                    damage[1] = 0;
                    damage[2] = 200;
                    damage[3] = 200;
                    damage[7] = 1;
                }
            }
            else if (chosenAttack == 3)
            {
                if (random.Next(1, 76) >= 50 - (playerLuck * .6))
                {
                    damage[1] = (int)(((30 + (MobStrength * (1 + (mobBuffs[0] / 100f))) * 2.8f) * ((100 - (playerArmor * (playerDebuffs[0] / 100f))) / 100f)) * 1.5);
                    damage[2] = 70;
                    damage[3] = 100;
                    damage[7] = 2;
                }
                else
                {
                    damage[1] = (int)(((30 + (MobStrength * (1 + (mobBuffs[0] / 100f))) * 2.8f) * ((100 - (playerArmor * (playerDebuffs[0] / 100f))) / 100f)));
                    damage[2] = 70;
                    damage[3] = 100;
                    damage[7] = 2;
                }
            }
            else if (chosenAttack == 4)
            {
                    damage[7] = 3;
            }
            return damage;
        }
    }
}
