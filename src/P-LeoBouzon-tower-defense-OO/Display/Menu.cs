using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P_LeoBouzon_tower_defense_OO.Display;

namespace P_LeoBouzon_tower_defense_OO.Display
{
    internal class Menu
    {
        // ========== GAME MENU ==========
        public static void LaunchMenu()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("-------- Bienenvue dans --------");
            Console.WriteLine("-------- Tower Defense ---------");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("----- créé par Léo Bouzon ------");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("\nCe jeu est un Tower Defense, votre objectif est de tirer sur les ennemis grâce au tour placées sur la carte de jeu");
            Console.WriteLine("Merci d'appuyer sur une touche afin de continuer vers le jeu");

            Console.ReadKey();
            Console.Clear();
        }
    }
}
