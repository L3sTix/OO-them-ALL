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
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using P_LeoBouzon_tower_defense_OO.Display;

namespace P_LeoBouzon_tower_defense_OO
{
    internal class PathManager
    {
        private HUD _hud;
        private WinCondition _winCondition = new WinCondition();
        private TowerManager _towerManager;
        private Enemy _enemy;

        public HUD Hud {set{ _hud = value; } }
        //public WinCondition WinCondition { set { _winCondition = value; } }
        public TowerManager TowerManager { set { _towerManager = value; } }
        public Enemy Enemy { set { _enemy = value; } }




        // ========== PATH DATA ==========
        private int[] GamePath = new int[20];
        private int enemyOldPosition;
        private int _enemyPosition = 0;
        public int enemyPosition
        {
            get { return _enemyPosition; }
        }
        private int xPath = 0;
        

        

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
            _hud.InitialPV();

            
                
            do
            {
                if (_enemy.enemyHP <= 0)
                {

                    _enemyPosition = GamePath.Length;
                    _winCondition.GameWin();
                    _winCondition.Win = true;

                }

                else
                {
                    enemyOldPosition = enemyPosition;

                    if (enemyPosition < GamePath.Length)
                    {
                        _enemyPosition += _enemy.enemyXMovement;
                    }
                    else
                    {
                        _enemyPosition = _enemy.enemyXMovement;
                    }

                    Console.SetCursorPosition(enemyOldPosition, 3);
                    Console.Write(" ");

                    Console.SetCursorPosition(enemyPosition, 3);
                    Console.Write("E");

                    _towerManager.HandleTargetting();
                    if (_enemy.enemyHP <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(enemyPosition, 3);
                        Console.Write("X");
                    }
                    Thread.Sleep(2000);
                }

            } while (enemyPosition != GamePath.Length);
            


            
            if (_winCondition.Win == false)
            {
                _winCondition.GameLose();
            }
        }
    }
}
