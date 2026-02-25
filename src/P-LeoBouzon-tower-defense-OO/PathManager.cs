///*****************************************************************************
/// ETML
/// Auteur          : Léo Bouzon
/// Date            : 04.02.2026
/// Description     : Classe servant à gérer tout les éléments et les méthodes
///                   utilisées pour le chemin que les ennemis parcourent.
///*****************************************************************************
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
        private int[] GamePath = new int[20];
        private int enemyOldPosition;
        private int enemyPosition = 0;
        private int xPath = 0;
        

        private Enemy[] _enemies = new Enemy[1];

        

        //private Enemy _enemy1=new Enemy();

        public Enemy[] Enemies { get { return _enemies; } }

        // ========== constructeur qui créé 10 objets et les stock dans le tableau _enemies au dessus ==========
        public PathManager()
        {
            //enemy = new Enemy();

            for (int i = 0; i < _enemies.Length; i++)
            {
                _enemies[i] = new Enemy();
            }
        }

        // ========== ENEMIES PATH MOVEMENT ==========
        public void MoveEnemies()
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
            Console.SetCursorPosition(GamePath.Length + 1 , 3);
            Console.Write("C");
            Console.SetCursorPosition(enemyPosition, 3);
            Console.Write("E");
            Console.SetCursorPosition(0, 5);
            HUD.InitialPV();

            for (int i = 0; i < 1; i++)
            {
                Enemy enemy = _enemies[i];
                
                do
                {
                    if (enemy.enemyHP <= 0)
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
                            enemyPosition += enemy.enemyXMovement;
                        }
                        else
                        {
                            enemyPosition = enemy.enemyXMovement;
                        }

                        Console.SetCursorPosition(enemyOldPosition, 3);
                        Console.Write(" ");

                        Console.SetCursorPosition(enemyPosition, 3);
                        Console.Write("E");

                        TowerManager.HandleTargetting();
                        if (enemy.enemyHP <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.SetCursorPosition(enemyPosition, 3);
                            Console.Write("X");
                        }
                        Thread.Sleep(2000);
                    }

                } while (enemyPosition != GamePath.Length);
            }


            
            if (WinCondition.win == false)
            {
                WinCondition.GameLose();
            }
        }
    }
}
