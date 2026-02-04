using P_LeoBouzon_tower_defense_OO.Display;
using System;
using System.Data.Common;
using System.Threading;

namespace P_LeoBouzon_tower_defense_OO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ========== MAIN CODE ========== 
            Menu.LaunchMenu();
            TowerManager.TowerPlacement();
            PathManager.MoveEnemies();
            Console.ReadLine();
        }
    }
}