using System;
using System.Data.Common;
using System.Threading;
namespace P_LeoBouzon_tower_defense_OO
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // ----- VARIABLES -----

            int[] tourPlace = new int[20];                                          // Tableau contenant les tours
            int towerPosition = tourPlace[0];                                       // Initialisation du curseur ou placer des tours
            int[] cheminDeJeu = new int[20];                                        // tableau du 
            int maxMoveX = 19;                                                      // Limite droit du tableau
            int towerMouvementX = 1;                                                // Mouvement horizontal d'une tour
            int minMoveX = 1;                                                       // Limite gauche du tableau
            int oldTowerPosition;                                                   // Ancienne position de tour
            int toursPlacees = 0;                                                   // Nombre de tours placées
            int maxTours = 4;                                                       // Maximum de tours pouvant être placée
            int degats = 25;                                                        // Nombre de dégats infligés à l'ennemi par tire
            int ennemiPvInitial = 100;                                              // PV max de l'ennemi lorsqu'il apparaît
            int ennemiPV = ennemiPvInitial;                                         // PV de l'ennemi au fil du jeu 
            int ennemiPosition = 0;                                                 // Position d'un ennemi
            int oldEnnemiPosition;                                                  // Ancienne position d'un ennemi
            int ennemiMouvementX = 1;                                               // Mouvement horizontal d'un ennemi
            int chemin = 0;                                                         // Initialisation du chemin en "═"
            MenuDeLancement();
            PlacerTour();
            DeplacerEnnemis();
            Console.ReadLine();
            // ----- MENU DE JEU ET MENU POSSIBLE INTERACTIF -----
            static void MenuDeLancement()
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
            // ----- PLACEMENT DES TOURS PAR L'UTILISATEUR -----
            void PlacerTour()
            {
                ConsoleKeyInfo towerMove;

                Console.Clear();
                Console.CursorVisible = false;

                while(toursPlacees < maxTours)
                {
                    towerMove = Console.ReadKey(true);
                    oldTowerPosition = towerPosition;

                    switch (towerMove.Key)
                    {
                        case ConsoleKey.RightArrow:
                            
                                if (towerPosition < maxMoveX)
                                {
                                    towerPosition += towerMouvementX;
                                }
                                else
                                {
                                    towerPosition = minMoveX;
                                }   
                            break;

                        case ConsoleKey.LeftArrow:
                            
                                if (towerPosition > minMoveX)
                                {
                                    towerPosition -= towerMouvementX;
                                }
                                else
                                {
                                    towerPosition = maxMoveX;
                                }
                            break;
                    }
                    if ((towerMove.Key == ConsoleKey.Enter || towerMove.Key == ConsoleKey.Spacebar) && toursPlacees < maxTours && tourPlace[towerPosition] == 0)
                    {
                        tourPlace[towerPosition] = 1;
                        toursPlacees ++;
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.Write(new string(' ', maxMoveX + 1));
 
                    for (int i = 0; i <= maxMoveX; i++)
                    {
                        if (tourPlace[i] == 1)
                        {
                            Console.SetCursorPosition(i, 0);
                            Console.Write("T");
                        }
                    }
                    Console.SetCursorPosition(towerPosition, 0);
                    Console.Write("T");     
                }
            }
            // ----- DEPLACEMENT DES ENNEMIS SUR LE LONG DU CHEMIN -----
            void DeplacerEnnemis()
            {
                Console.CursorVisible = false;
                
                for (int i = 0; i < cheminDeJeu.Length + 1; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(chemin, 2);
                    Console.Write("═");
                    Console.SetCursorPosition(chemin, 4);
                    Console.Write("═");
                    chemin += 1;
                    Console.ResetColor();

                }
                Console.SetCursorPosition(20, 3);
                Console.Write("C");
                Console.SetCursorPosition(ennemiPosition, 3);
                Console.Write("E");
                Console.SetCursorPosition(0, 5);
                Console.Write($"PV restants : {ennemiPvInitial} ");
                do
                {
                    if (ennemiPV <= 0)
                    {
                        
                        ennemiPosition = cheminDeJeu.Length;
                        Console.SetCursorPosition(0, 6);
                        Console.Write($"Ennemi mort ");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.CursorVisible = false;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.SetCursorPosition(30, 10);
                        Console.WriteLine("###############################################################");
                        Console.SetCursorPosition(30, 11);
                        Console.WriteLine("#                                                             #");
                        Console.SetCursorPosition(30, 12);
                        Console.WriteLine("#   ██╗   ██╗  ██████╗ ██╗   ██╗  ██╗    ██╗ ██╗ ███╗   ██╗   #");
                        Console.SetCursorPosition(30, 13);
                        Console.WriteLine("#   ╚██╗ ██╔╝ ██╔═══██╗██║   ██║  ██║    ██║ ██║ ████╗  ██║   #");
                        Console.SetCursorPosition(30, 14);
                        Console.WriteLine("#    ╚████╔╝  ██║   ██║██║   ██║  ██║ █╗ ██║ ██║ ██╔██╗ ██║   #");
                        Console.SetCursorPosition(30, 15);
                        Console.WriteLine("#      ██╔╝   ██║   ██║██║   ██║  ██║███╗██║ ██║ ██║╚██╗██║   #");
                        Console.SetCursorPosition(30, 16);
                        Console.WriteLine("#      ██║    ╚██████╔╝╚██████╔╝  ╚███╔███╔╝ ██║ ██║ ╚████║   #");
                        Console.SetCursorPosition(30, 17);
                        Console.WriteLine("#      ╚═╝     ╚═════╝  ╚═════╝    ╚══╝╚══╝  ╚═╝ ╚═╝  ╚═══╝   #");
                        Console.SetCursorPosition(30, 18);
                        Console.WriteLine("#                                                             #");
                        Console.SetCursorPosition(30, 19);
                        Console.WriteLine("###############################################################");
                        Console.ResetColor();

                    }
                    else
                    {
                        oldEnnemiPosition = ennemiPosition;

                        if (ennemiPosition < cheminDeJeu.Length)
                        {
                            ennemiPosition += ennemiMouvementX;
                        }
                        else
                        {
                            ennemiPosition = ennemiMouvementX;
                        }

                        Console.SetCursorPosition(oldEnnemiPosition, 3);
                        Console.Write(" ");

                        Console.SetCursorPosition(ennemiPosition, 3);
                        Console.Write("E");

                        TirerTour();
                        if (ennemiPV <= 0)
                        {
                            Console.SetCursorPosition(ennemiPosition, 3);
                            Console.Write("X");
                        }
                        Thread.Sleep(1000);
                    }
                    
                } while (ennemiPosition != cheminDeJeu.Length );
                
            }
            // ----- TIRE DES TOURS SUR LES ENNEMIS -----
            void TirerTour()
            {
                bool ennemiTouche = false;
                if (ennemiPV <= 0)
                {
                    ennemiTouche = false;
                }
                    

                for (int i = 0; i < tourPlace.Length; i++)
                {
                    if (!ennemiTouche && tourPlace[i] == 1)
                    {
                        if ((i - 1 >= 0 && ennemiPosition >= i - 1) || (ennemiPosition == i) || (i + 1 < tourPlace.Length && ennemiPosition == i + 1 ))
                        {
                            
                            CalculerDegats();
                            ennemiTouche = true;
                            
                        }
                    }
                }
            }
            // ----- CALCULE DES DEGATS INFLIGES  -----
            void CalculerDegats()
            {
                                                                                
                ennemiPV -= degats;                                             // le nombre de PV de l'ennemi diminue de 25 quand il est touché

                if (ennemiPV < 0)
                {
                    ennemiPV = 0;
                    
                }
                Console.SetCursorPosition(0, 5);
                Console.Write($"PV restants : {ennemiPV} ");
                Console.SetCursorPosition(0, 6);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"L'ennemi est touché (-" + degats + " PV) ");
                Console.ResetColor();
                
            }
        }
    }
}