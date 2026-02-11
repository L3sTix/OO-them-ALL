using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P_LeoBouzon_tower_defense_OO.Display;

namespace P_LeoBouzon_tower_defense_OO
{
    internal class PathManager
    {
        // ========== PATH DATA ==========
        public static int[] GamePath = new int[20];
        public static int enemyOldPosition;
        public static int enemyPosition = 0;
        public static int enemyXMovement = 1;
        public static int xPath = 0;
        public static int maxMoveX = 19;
        public static int minMoveX = 1;
        // ========== ENEMIES PATH MOVEMENT ==========
        public static void MoveEnemies()
        {
            Console.CursorVisible = false;

            for (int i = 0; i < GamePath.Length + 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(xPath, 2);
                Console.Write("═");
                Console.SetCursorPosition(xPath, 4);
                Console.Write("═");
                xPath += 1;
            }
            Console.ResetColor();
            Console.SetCursorPosition(20, 3);
            Console.Write("C");
            Console.SetCursorPosition(enemyPosition, 3);
            Console.Write("E");
            Console.SetCursorPosition(0, 5);
            HUD.InitialPV();


            do
            {
                if (EnemyManager.enemyHP <= 0)
                {

                    enemyPosition = GamePath.Length;
                    WinCondition.GameWin();
                    WinCondition.win = true;

                }
                
                else
                {
                    enemyOldPosition = enemyPosition;

                    if (enemyPosition < GamePath.Length)
                    {
                        enemyPosition += enemyXMovement;
                    }
                    else
                    {
                        enemyPosition = enemyXMovement;
                    }

                    Console.SetCursorPosition(enemyOldPosition, 3);
                    Console.Write(" ");

                    Console.SetCursorPosition(enemyPosition, 3);
                    Console.Write("E");

                    TowerManager.HandleTargetting();
                    if (EnemyManager.enemyHP <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(enemyPosition, 3);
                        Console.Write("X");
                    }
                    Thread.Sleep(2000);
                }

            } while (enemyPosition != GamePath.Length);
            if (WinCondition.win == false)
            {
                WinCondition.GameLose();
            }
        }
    }
}
