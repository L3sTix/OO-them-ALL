using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace P_LeoBouzon_tower_defense_OO.Display
{
    internal class Menu
    {
        // ========== MENU DATA ==========
        public static int yIncremental = 0;
        public static int yMax = 7;
        // ========== GAME MENU ==========
        public static void LaunchMenu()
        {
            HorizontaleLine('╔', '═', 5, 30, '╗', yIncremental);
            for (int i = yIncremental + 1; i < yMax; i++)
            {
                HorizontaleLine('║', ' ', 5, 30, '║', i);
            }
            HorizontaleLine('╚', '═', 5, 30, '╝', yMax);
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("Bienvenue dans ");
            Console.SetCursorPosition(10, 3);
            Console.WriteLine("Castle Defender");
            Console.SetCursorPosition(10, 5); 
            Console.WriteLine("créé par Bouzon Léo");

            Console.SetCursorPosition(5, 9); 
            Console.Write("Ce jeu est un Tower Defense, votre objectif ? ");
            Console.SetCursorPosition(5, 10);
            Console.Write("Défendre le chateau en plaçant des tours aux abords du chemin par ou arrive les ennemis et leur tirer dessus.");
            Console.SetCursorPosition(5, 11);
            Console.Write("Merci d'appuyer sur une touche afin de continuer vers le jeu.");
            Console.ReadKey();
            Console.Clear();
        }
        public static void HorizontaleLine(char startLine, char line, int startX, int length, char finishLine, int y)
        {
            int x = startX + length;
            Console.SetCursorPosition(startX, y);
            Console.Write(startLine);
            for (int i = startX + 1; i < x; i++)
            {
                Console.SetCursorPosition(i, y);
                Console.Write(line);
            }
            Console.SetCursorPosition(x, y);
            Console.Write(finishLine);
        }
        
    }
}
