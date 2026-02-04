using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace P_LeoBouzon_tower_defense_OO.Display
{
    internal class HUD
    {
        public static void InitialPV()
        {
            Console.Write($"PV restants : {EnemyManager.enemyInitialHP} ");
        }
        public static void RemainingPV()
        {
            Console.Write($"PV restants : {EnemyManager.enemyHP} ");

        }
        public static void DamageDisplay()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"L'ennemi est touché (-" + TowerManager.damages + " PV) ");
            Console.ResetColor();
        }
    }
}
