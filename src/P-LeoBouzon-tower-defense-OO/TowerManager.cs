using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P_LeoBouzon_tower_defense_OO.Display;

namespace P_LeoBouzon_tower_defense_OO
{
    internal class TowerManager
    {
        // ========== TOWER DATA ==========
        public static int[] TowerPlace = new int[20];
        public static int towerPosition = TowerPlace[0];
        public static int towerXMovement = 1;
        public static int oldTowerPosition;
        public static int towerPlaced = 0;
        public static int maxTower = 4;
        public static int range = 1;
        public static int damages = 10;
        public static bool enemyHit = true;

        // ========== TOWER PLACEMENT ==========
        public static void TowerPlacement()
        {
            ConsoleKeyInfo towerMove;

            Console.Clear();
            Console.CursorVisible = false;

            while (towerPlaced < maxTower)
            {
                towerMove = Console.ReadKey(true);
                oldTowerPosition = towerPosition;

                switch (towerMove.Key)
                {
                    case ConsoleKey.RightArrow:

                        if (towerPosition < PathManager.maxMoveX)
                        {
                            towerPosition += towerXMovement;
                        }
                        else
                        {
                            towerPosition = PathManager.minMoveX;
                        }
                        break;

                    case ConsoleKey.LeftArrow:

                        if (towerPosition > PathManager.minMoveX)
                        {
                            towerPosition -= towerXMovement;
                        }
                        else
                        {
                            towerPosition = PathManager.maxMoveX;
                        }
                        break;
                }
                if ((towerMove.Key == ConsoleKey.Enter || towerMove.Key == ConsoleKey.Spacebar) && towerPlaced < maxTower && TowerPlace[towerPosition] == 0)
                {
                    TowerPlace[towerPosition] = 1;
                    towerPlaced++;
                }
                Console.SetCursorPosition(0, 0);
                Console.Write(new string(' ', PathManager.maxMoveX + 1));

                for (int i = 0; i <= PathManager.maxMoveX; i++)
                {
                    if (TowerPlace[i] == 1)
                    {
                        Console.SetCursorPosition(i, 0);
                        Console.Write("T");
                    }
                }
                Console.SetCursorPosition(towerPosition, 0);
                Console.Write("T");
            }
        }
        // ========== TOWER SHOT SYSTEM ==========
        public static void HandleTargetting()
        {
            if (EnemyManager.enemyHP <= 0)
            {
                enemyHit = false;
            }


            for (int i = 0; i < TowerPlace.Length; i++)
            {
                if (enemyHit && TowerPlace[i] == 1)
                {
                    if (PathManager.enemyPosition >= i - range && PathManager.enemyPosition <= i + range)
                    {

                        DamageCalculation();
                        if (EnemyManager.enemyHP <= 0)
                        {
                            enemyHit = false;
                        }

                    }
                }
            }
        }
        // ========== DAMAGE INFLICTED ==========
        public static void DamageCalculation()
        {
            EnemyManager.enemyHP -= damages;                                             // le nombre de PV de l'ennemi diminue de 25 quand il est touché

            if (EnemyManager.enemyHP < 0)
            {
                EnemyManager.enemyHP = 0;

            }
            Console.SetCursorPosition(0, 5);
            HUD.RemainingPV();
            Console.SetCursorPosition(0, 6);
            HUD.DamageDisplay();
        }
    }
}
