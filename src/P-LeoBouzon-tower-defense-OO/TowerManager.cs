///***************************************************************************
/// ETML
/// Auteur          : Léo Bouzon
/// Date            : 04.02.2026
/// Description     : Classe servant à gérer tout les éléments et les méthodes
///                   utilisées pour le choix de placement des tours.
///***************************************************************************
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
        private int[] TowerPlace = new int[20];
        private int towerPosition;
        private int towerXMovement = 1;
        private int oldTowerPosition;
        private int towerPlaced = 0;
        private int maxTower = 4;
        private int range = 1;
        private int damages = 10;
        private bool enemyHit = true;
        private int maxMoveX = 19;
        private int minMoveX = 1;

        private PathManager pm;
        public TowerManager(PathManager pm)
        {
            this.pm = pm;
        }

        // ========== TOWER PLACEMENT ==========
        public void TowerPlacement()
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

                        if (towerPosition < maxMoveX)
                        {
                            towerPosition += towerXMovement;
                        }
                        else
                        {
                            towerPosition = minMoveX;
                        }
                        break;

                    case ConsoleKey.LeftArrow:

                        if (towerPosition > minMoveX)
                        {
                            towerPosition -= towerXMovement;
                        }
                        else
                        {
                            towerPosition = maxMoveX;
                        }
                        break;
                }
                if ((towerMove.Key == ConsoleKey.Enter || towerMove.Key == ConsoleKey.Spacebar) && towerPlaced < maxTower && TowerPlace[towerPosition] == 0)
                {
                    TowerPlace[towerPosition] = 1;
                    towerPlaced++;
                }
                Console.SetCursorPosition(0, 0);
                Console.Write(new string(' ', maxMoveX + 1));

                for (int i = 0; i <= maxMoveX; i++)
                {
                    if (TowerPlace[i] == 1)
                    {
                        Console.SetCursorPosition(i, 0);
                        Console.Write("T");
                    }
                }
                Console.SetCursorPosition(towerPosition, 0);
                Console.Write("T");
                HUD.GameLegend();
            }
        }
        // ========== TOWER SHOT SYSTEM ==========
        public void HandleTargetting()
        {
            if (pm.Enemies[i]enemyHP <= 0)
            {
                enemyHit = false;
            }

            Bullet.EraseBullet(1);
            for (int i = 0; i < TowerPlace.Length; i++)
            {
                
                if (enemyHit && TowerPlace[i] == 1)
                {
                    if (pm.enemyPosition >= i - range && PathManager.enemyPosition <= i + range)
                    {
                        Bullet.Shot();
                        DamageCalculation();
                        if (Enemy.enemyHP <= 0)
                        {
                            enemyHit = false;
                        }

                    }
                }
            }
        }
        // ========== DAMAGE INFLICTED ==========
        public void DamageCalculation()
        {
            Enemy.enemyHP -= damages;                                             // le nombre de PV de l'ennemi diminue de 25 quand il est touché

            if (Enemy.enemyHP < 0)
            {
                Enemy.enemyHP = 0;

            }
            Console.SetCursorPosition(0, 5);
            HUD.RemainingPV();
            Console.SetCursorPosition(0, 6);
            HUD.DamageDisplay();
        }
    }
}
