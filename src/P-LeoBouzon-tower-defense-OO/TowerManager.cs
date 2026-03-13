using P_LeoBouzon_tower_defense_OO.Display;
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
using System.Threading;
using System.Threading.Tasks;

namespace P_LeoBouzon_tower_defense_OO
{
    internal class TowerManager
    {
        private HUD _hud;
        public HUD Hud { set { _hud = value; } }
        
        // ========== TOWER DATA ==========
        private int[] _TowerPlace = new int[20];
        public int[] TowerPlace
        {
            get { return _TowerPlace; }
        }
        private int towerPosition;
        private int towerXMovement = 1;
        private int oldTowerPosition;
        private int towerPlaced = 0;
        private int maxTower = 4;
        private int _range = 1;
        public int range
        {
            get { return _range; }
        }
        private int _damages = 10;
        public int damages
        {
            get { return _damages; }
        }
        private int maxMoveX = 19;
        private int minMoveX = 1;

        private Bullet _bullet;
        private PathManager _pathmanager;
        private int GamePath_Length = 20;
        public int PathLength { set { GamePath_Length = value; } }
        public TowerManager(PathManager pathmanager)
        {
            _pathmanager = pathmanager;
            _bullet = new Bullet(this, pathmanager);
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
                        towerPosition = towerPosition < maxMoveX ? towerPosition + towerXMovement : minMoveX;
                        break;
                    case ConsoleKey.LeftArrow:
                        towerPosition = towerPosition > minMoveX ? towerPosition - towerXMovement : maxMoveX;
                        break;
                }

                if ((towerMove.Key == ConsoleKey.Enter || towerMove.Key == ConsoleKey.Spacebar)
                    && towerPlaced < maxTower && TowerPlace[towerPosition] == 0)
                {
                    TowerPlace[towerPosition] = 1;
                    towerPlaced++;
                }

                Console.SetCursorPosition(0, 0);
                Console.Write(new string(' ', maxMoveX + 1));

                for (int i = 0; i <= maxMoveX; i++)
                    if (TowerPlace[i] == 1)
                    {
                        Console.SetCursorPosition(i, 0);
                        Console.Write("T");
                    }

                Console.SetCursorPosition(towerPosition, 0);
                Console.Write("T");
                _hud.GameLegend();
            }
        }
        // ========== TOWER SHOT SYSTEM ==========
        // Chaque tour ne tire que sur un seul ennemi à la fois
        public void HandleTargetting(List<Monster> monsters, int[] positions)
        {
            _bullet.EraseBullet(1);

            for (int i = 0; i < TowerPlace.Length; i++)
            {
                if (TowerPlace[i] != 1) continue;

                // Cette tour cherche le premier ennemi dans sa portée
                for (int j = 0; j < monsters.Count; j++)
                {
                    if (monsters[j].MonsterHP <= 0) continue;
                    if (positions[j] > GamePath_Length) continue;

                    if (positions[j] >= i - range && positions[j] <= i + range)
                    {
                        _bullet.Shot(positions[j]);
                        DamageCalculation(monsters[j]);
                        break; // cette tour a tiré, on passe à la tour suivante
                    }
                }
            }
        }
        // ========== DAMAGE INFLICTED ==========
        private void DamageCalculation(Monster monster)
        {
            monster.MonsterHP -= damages;
            if (monster.MonsterHP < 0) monster.MonsterHP = 0;

            _hud.DamageDisplay(monster);
        }
    }
}
