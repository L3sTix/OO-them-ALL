///***************************************************************************
/// ETML
/// Auteur          : Léo Bouzon
/// Date            : 09.02.2026
/// Description     : Classe servant à gérer tout les éléments et les méthodes
///                   utilisées pour afficher les écrans de victoire et de 
///                   défaite.
///***************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_LeoBouzon_tower_defense_OO.Display
{
    internal class WinCondition
    {
        // ========== WIN CONDITION DATA ==========
        public static bool win = false;
        // ========== WIN DISPLAY ==========
        public static void GameWin()
        {
            Console.SetCursorPosition(0, 7);
            Console.Write($"Ennemi Mort ");
            Thread.Sleep(1000);
            Console.Clear();
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(30, 11);
            Console.WriteLine("║                                                             ║");
            Console.SetCursorPosition(30, 12);
            Console.WriteLine("║   ██╗   ██╗  ██████╗ ██╗   ██╗  ██╗    ██╗ ██╗ ███╗   ██╗   ║");
            Console.SetCursorPosition(30, 13);
            Console.WriteLine("║   ╚██╗ ██╔╝ ██╔═══██╗██║   ██║  ██║    ██║ ██║ ████╗  ██║   ║");
            Console.SetCursorPosition(30, 14);
            Console.WriteLine("║    ╚████╔╝  ██║   ██║██║   ██║  ██║ █╗ ██║ ██║ ██╔██╗ ██║   ║");
            Console.SetCursorPosition(30, 15);
            Console.WriteLine("║      ██╔╝   ██║   ██║██║   ██║  ██║███╗██║ ██║ ██║╚██╗██║   ║");
            Console.SetCursorPosition(30, 16);
            Console.WriteLine("║      ██║    ╚██████╔╝╚██████╔╝  ╚███╔███╔╝ ██║ ██║ ╚████║   ║");
            Console.SetCursorPosition(30, 17);
            Console.WriteLine("║      ╚═╝     ╚═════╝  ╚═════╝    ╚══╝╚══╝  ╚═╝ ╚═╝  ╚═══╝   ║");
            Console.SetCursorPosition(30, 18);
            Console.WriteLine("║                                                             ║");
            Console.SetCursorPosition(30, 19);
            Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        // ========== LOSE DISPLAY ==========
        public static void GameLose()
        {
            Console.SetCursorPosition(0, 7);
            Console.Write($"You're dead ");
            Thread.Sleep(1000);
            Console.Clear();
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗");
            Console.SetCursorPosition(30, 11);
            Console.WriteLine("║                                                                      ║");
            Console.SetCursorPosition(30, 12);
            Console.WriteLine("║   ██╗   ██╗  ██████╗ ██╗   ██╗   ██╗      ██████╗ ███████╗███████╗   ║");
            Console.SetCursorPosition(30, 13);
            Console.WriteLine("║   ╚██╗ ██╔╝ ██╔═══██╗██║   ██║   ██║     ██╔═══██╗██╔════╝██╔════╝   ║");
            Console.SetCursorPosition(30, 14);
            Console.WriteLine("║    ╚████╔╝  ██║   ██║██║   ██║   ██║     ██║   ██║███████╗███████╗   ║");
            Console.SetCursorPosition(30, 15);
            Console.WriteLine("║      ██╔╝   ██║   ██║██║   ██║   ██║     ██║   ██║╚════██║██╔════╝   ║");
            Console.SetCursorPosition(30, 16);
            Console.WriteLine("║      ██║    ╚██████╔╝╚██████╔╝   ███████╗╚██████╔╝███████║███████╗   ║");
            Console.SetCursorPosition(30, 17);
            Console.WriteLine("║      ╚═╝     ╚═════╝  ╚═════╝    ╚══════╝ ╚═════╝ ╚══════╝╚══════╝   ║");
            Console.SetCursorPosition(30, 18);
            Console.WriteLine("║                                                                      ║");
            Console.SetCursorPosition(30, 19);
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝");

            Console.ResetColor();
        }
    }
}
