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
        private HUD _hud;
        public HUD Hud { set { _hud = value; } }
        
        private Monster _monster;
        public Monster Monster { set { _monster = value; } }
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
        private bool enemyHit = true;
        private int maxMoveX = 19;
        private int minMoveX = 1;

        private Bullet _bullet;

        private PathManager _pathmanager;
        public TowerManager(PathManager pathmanager)
        {
            this._pathmanager = pathmanager;
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
                _hud.GameLegend();
            }
        }
        // ========== TOWER SHOT SYSTEM ==========
        public void HandleTargetting()
        {
            if (_monster.MonsterHP <= 0)
            {
                enemyHit = false;
            }

            _bullet.EraseBullet(1);
            for (int i = 0; i < TowerPlace.Length; i++)
            {
                
                if (enemyHit && TowerPlace[i] == 1)
                {
                    if (_pathmanager.enemyPosition >= i - range && _pathmanager.enemyPosition <= i + range)
                    {
                        _bullet.Shot();
                        DamageCalculation();
                        if (_monster.MonsterHP <= 0)
                        {
                            enemyHit = false;
                        }

                    }
                }
            }
        }
        // ========== DAMAGE INFLICTED ==========
        private void DamageCalculation()
        {
            _monster.MonsterHP -= damages;                                             // le nombre de PV de l'ennemi diminue de 25 quand il est touché

            if (_monster.MonsterHP < 0)
            {
                _monster.MonsterHP = 0;

            }
            Console.SetCursorPosition(0, 5);
            _hud.RemainingPV();
            Console.SetCursorPosition(0, 6);
            _hud.DamageDisplay();
        }
    }
}
