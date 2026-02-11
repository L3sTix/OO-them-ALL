using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_LeoBouzon_tower_defense_OO
{
    internal class Bullet
    {
        
        public static void Shot()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            EraseBullet(1);
            for (int i = 0; i < TowerManager.TowerPlace.Length; i++)
            {
                

                if (TowerManager.TowerPlace[i] == 1)
                {
                    
                    
                    if (PathManager.enemyPosition == i - TowerManager.range)
                    {
                        Console.SetCursorPosition(i - TowerManager.range, 1);
                        Console.Write("/");
                        
                    }
                    else if (PathManager.enemyPosition == i)
                    {
                        Console.SetCursorPosition(i, 1);
                        Console.Write("|");
                        
                    }
                    else if (PathManager.enemyPosition == i + TowerManager.range)
                    {
                        Console.SetCursorPosition(i + TowerManager.range, 1);
                        Console.Write(@"\");
                        
                    }
                    
                }
                
            }
            Console.ResetColor();
        }
        public static void EraseBullet(int line)
        {
            Console.SetCursorPosition(0, line);
            for (int i = 0; i < TowerManager.TowerPlace.Length; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(0, line);
        }
    }
}
