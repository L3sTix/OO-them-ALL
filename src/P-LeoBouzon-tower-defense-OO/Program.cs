using System.Data.Common;

namespace P_LeoBouzon_tower_defense_OO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            airDeJeu();
            
            
            static void MenuDeLancement()
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("-------- Bienenvue dans --------");
                Console.WriteLine("-------- Tower Defense ---------");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("----- créé par Léo Bouzon ------");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("\nCe jeu est un Tower Defense, votre objectif est de tirer sur les ennemis grâce au tour placées sur la carte de jeu");
                Console.WriteLine("Merci d'appuyer sur SPACE ou ENTER afin de continuer vers le jeu");

            
            }
            static void airDeJeu()
            {
                int xBoard = 0;
                int yBoard = 0;

                for (byte i = 0; i < 10 ; i++)
                {
                        Console.SetCursorPosition(xBoard, yBoard);
                        Console.Write("║   ║");
                        yBoard += 1;
                }
                
            }
            static void PlacerTour()
            {
                int[] tourPlace = new int[20];
                int towerPosition = tourPlace[0];
                int maxMoveX = 19;
                int mouvementX = 1;
                int minMoveX = 0;
                ConsoleKeyInfo towerMove;
                do 
                { 
                    towerMove = Console.ReadKey(true);
                    switch (towerMove.Key)
                    {
                        case ConsoleKey.RightArrow:
                            
                            Console.Write(" ");
                            if (towerPosition < maxMoveX)
                            {  
                                towerPosition += mouvementX;
                            }
                            else
                            {
                                towerPosition = minMoveX;
                            }
                            Console.Write("T");
                            break;

                        case ConsoleKey.LeftArrow:
                            
                            Console.Write(" ");
                            if (towerPosition > minMoveX)
                            {
                                towerPosition -= mouvementX;
                            }                               
                            else
                            {
                                towerPosition = maxMoveX;
                            }
                            Console.Write("T");
                            break;
                    }
                    Console.SetCursorPosition(towerPosition, 0);
                    
                } while (true) ;

            }
            static void DeplacerEnnemis()
            {
                string[] cheminDeJeu = new string[20];
                int positionEnnemi = 0;
                ConsoleKeyInfo keyInput;
                // initialise tout le chemin de jeu avec des tirets
                for (int i = 0; i < cheminDeJeu.Length; i++)
                {
                    cheminDeJeu[i] = "-";
                    Console.Write("-");
                }

                //Position de l'ennemi sur le chemin de jeu
                cheminDeJeu[positionEnnemi] = "E";
                Console.Write("E");
                
                
                //faire se déplacer l'ennemi
                
                
                    //réécrire à chaque fois la console
                    Console.Clear();

                    for (int i = 0; i < cheminDeJeu.Length; i++)
                    {
                        Console.Write(cheminDeJeu[i] = " ");
                        Console.Write("-");
                    }

                    //temps de déplacement
                    Thread.Sleep(500000);

                    //réécris le chemin
                    

                    //incrémente la position de l'ennemi
                    positionEnnemi++;

                    if (positionEnnemi >= cheminDeJeu.Length)
                    {
                        Environment.Exit(0);
                    }
                    cheminDeJeu[positionEnnemi] = "E";
                    Console.Write("E");
            }
            static void TirerTour()
            {
                
            }
            static void CalculerDegats()
            {

            }
        }
    }
}
