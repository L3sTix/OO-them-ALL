///*****************************************************************************
/// ETML
/// Auteur          : Léo Bouzon
/// Date            : 11.02.2026
/// Description     : Classe servant à gérer tout les éléments et les méthodes
///                   utilisées pour l'affichage des projectiles lancés par 
///                   les tours.
///*****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_LeoBouzon_tower_defense_OO
{
    internal class Bullet
    {
        private TowerManager _towerManager;
        private PathManager _pathManager;
        public Bullet(TowerManager towerManager, PathManager pathManager)
        {
            _towerManager = towerManager;
            _pathManager = pathManager;
        }
        
        public void Shot()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            EraseBullet(1);
            
            
            for (int i = 0; i < _towerManager.TowerPlace.Length; i++)
            {
                

                if (_towerManager.TowerPlace[i] == 1)
                {
                    
                    
                    if (_pathManager.enemyPosition == i - _towerManager.range)
                    {
                        Console.SetCursorPosition(i - _towerManager.range, 1);
                        Console.Write("/");
                        
                    }
                    else if (_pathManager.enemyPosition == i)
                    {
                        Console.SetCursorPosition(i, 1);
                        Console.Write("|");
                        
                    }
                    else if (_pathManager.enemyPosition == i + _towerManager.range)
                    {
                        Console.SetCursorPosition(i + _towerManager.range, 1);
                        Console.Write(@"\");
                        
                    }
                    else if(_pathManager.enemyPosition == i - _towerManager.range || _pathManager.enemyPosition == i)
                    {
                        Console.SetCursorPosition(i, 1);
                        Console.Write(@"V");
                    }
                    
                }
                
            }
            Console.ResetColor();
        }
        public void EraseBullet(int line)
        {
            Console.SetCursorPosition(0, line);
            for (int i = 0; i < _towerManager.TowerPlace.Length; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(0, line);
        }
    }
}
