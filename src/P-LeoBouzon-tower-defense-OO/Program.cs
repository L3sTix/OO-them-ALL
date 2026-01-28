using System.Data.Common;
using System.Threading;
namespace P_LeoBouzon_tower_defense_OO
{
    internal class Program
    {


        static void Main(string[] args)
        {
            int[] tourPlace = new int[20];
            int towerPosition = tourPlace[0];
            int[] cheminDeJeu = new int[20];
            int maxMoveX = 19;
            int towerMouvementX = 1;
            int minMoveX = 0;
            int oldTowerPosition;
            int toursPlacees = 0;
            int maxTours = 4;
            int ennemiPV = 100;
            int ennemiPosition = 0;
            int oldEnnemiPosition;
            int ennemiMouvementX = 1;
            MenuDeLancement();
            PlacerTour();
            DeplacerEnnemis();
            Console.ReadLine();
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
            void DeplacerEnnemis()
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(ennemiPosition, 2);
                Console.Write("E");
                do
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

                    Console.SetCursorPosition(oldEnnemiPosition, 2);
                    Console.Write(" ");

                    Console.SetCursorPosition(ennemiPosition, 2);
                    Console.Write("E");

                    TirerTour();

                    Thread.Sleep(1000);
                } while (ennemiPosition != cheminDeJeu.Length);
                if (ennemiPV <= 0)
                {
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("YOU WIN !");
                }
            }
            
            void TirerTour()
            {
                if (ennemiPV <= 0);
                bool ennemiTouche = false;

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
            void CalculerDegats()
            {
                int degats = 25;
                ennemiPV -= degats;

                if (ennemiPV < 0) ennemiPV = 0;

                Console.SetCursorPosition(0, 4);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"L'ennemi est touché (-" + degats + " PV) ");
                Console.ResetColor();
                Console.Write($"PV restants : {ennemiPV} ");
            }
        }
    }
}