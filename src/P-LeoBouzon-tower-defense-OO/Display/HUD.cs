///*****************************************************************************
/// ETML
/// Auteur          : Léo Bouzon
/// Date            : 09.02.2026
/// Description     : Classe servant à gérer tout les éléments et les méthodes
///                   utilisées pour afficher les HUD (Heads-Up Display) du jeu.
///*****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace P_LeoBouzon_tower_defense_OO.Display
{
    internal class HUD
    {
        private TowerManager _towerManager;
        public HUD(TowerManager towerManager)
        {
            _towerManager = towerManager;
            _towerManager.Hud = this;
        }

        public void AllEnemiesHP(List<Monster> monsters)
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                Console.SetCursorPosition(0, 5 + i);
                if (monsters[i].MonsterHP <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"Ennemi {monsters[i].Symbol} : MORT          ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"Ennemi {monsters[i].Symbol} : {monsters[i].MonsterHP} PV     ");
                }
            }
        }
        public void DamageDisplay(Monster monster)
        {
            Console.SetCursorPosition(0, 5 + _monsters_count + 1);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"{monster.Symbol} est touché (-{_towerManager.damages} PV) ");
            Console.ResetColor();
        }
        private int _monsters_count = 0;
        public int MonstersCount { set { _monsters_count = value; } }

        public void GameLegend()
        {
            Console.SetCursorPosition(50, 4);
            Console.Write("Tour = T");
            Console.SetCursorPosition(50, 5);
            Console.Write("Ennemi = E");
            Console.SetCursorPosition(50, 6);
            Console.Write("Chemin = ═");
            Console.SetCursorPosition(50, 7);
            Console.Write(@"Projectile = '/', '|', '\'");
            Console.SetCursorPosition(50, 8);
            Console.Write("Chateau = C");
        }
    }
}
