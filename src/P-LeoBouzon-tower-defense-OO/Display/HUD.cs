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
        public void InitialPV()
        {
            Console.Write($"PV restants : {Enemy.enemyInitialHP} ");
        }
        public void RemainingPV()
        {
            Console.Write($"PV restants : {Enemy.enemyHP} ");

        }
        public void DamageDisplay()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"L'ennemi est touché (-" + TowerManager.damages + " PV) ");
            Console.ResetColor();
        }
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
