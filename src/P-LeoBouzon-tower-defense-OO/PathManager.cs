///*****************************************************************************
/// ETML
/// Auteur          : Léo Bouzon
/// Date            : 04.02.2026
/// Description     : Classe servant à gérer tout les éléments et les méthodes
///                   utilisées pour le chemin que les ennemis parcourent.
///*****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using P_LeoBouzon_tower_defense_OO.Display;

namespace P_LeoBouzon_tower_defense_OO
{
    internal class PathManager
    {
        private HUD _hud;
        private WinCondition _winCondition = new WinCondition();
        private TowerManager _towerManager;
        

        public HUD Hud {set{ _hud = value; } }
        public TowerManager TowerManager { set { _towerManager = value; } }

        // ========== PATH DATA ==========
        private int[] GamePath = new int[20];
        private int xPath = 0;


        // ========== MONSTERS CREATION ==========
        private List<Monster> _monsters = new List<Monster>
        {
            new Monster('K'),
            new Monster('G'),
            new Boss()
        };



        // ========== MONSTERS PATH MOVEMENT ==========
        public void MoveMonsters()
        {
            Console.CursorVisible = false;

            // Dessin du chemin
            for (int i = 0; i < GamePath.Length + 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(xPath, 2);
                Console.Write("═");
                Console.SetCursorPosition(xPath, 4);
                Console.Write("═");
                xPath += 1;
            }
            Console.ResetColor();
            Console.SetCursorPosition(GamePath.Length + 1, 3);
            Console.Write("C");

            _hud.MonstersCount = _monsters.Count;
            _hud.AllEnemiesHP(_monsters);

            int[] positions = new int[_monsters.Count];
            int[] oldPositions = new int[_monsters.Count];
            for (int i = 0; i < _monsters.Count; i++)
            {
                positions[i] = -i * 3;
                oldPositions[i] = -1;
            }
            while (true)
            {
                bool allDone = true;
                bool anyReached = false;

                for (int i = 0; i < _monsters.Count; i++)
                {
                    Monster monster = _monsters[i];

                    // Ennemi déjà sorti du chemin
                    if (positions[i] > GamePath.Length) continue;

                    allDone = false;

                    if (monster.MonsterHP <= 0)
                    {
                        if (positions[i] >= 0 && positions[i] < GamePath.Length)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.SetCursorPosition(positions[i], 3);
                            Console.Write("X");
                            Console.ResetColor();
                            Thread.Sleep(300);
                            Console.SetCursorPosition(positions[i], 3);
                            Console.Write(" ");
                        }
                        positions[i] = GamePath.Length + 1;
                        continue;
                    }

                    // Effacer l'ancienne position
                    if (oldPositions[i] >= 0 && oldPositions[i] < GamePath.Length)
                    {
                        Console.SetCursorPosition(oldPositions[i], 3);
                        Console.Write(" ");
                    }

                    // Avancer l'ennemi
                    oldPositions[i] = positions[i];
                    positions[i] += monster.MonsterXMovement;

                    // Ennemi arrivé au château
                    if (positions[i] >= GamePath.Length)
                    {
                        anyReached = true;
                        positions[i] = GamePath.Length + 1;
                        continue;
                    }

                    // Afficher le symbole de l'ennemi
                    if (positions[i] >= 0)
                    {
                        Console.SetCursorPosition(positions[i], 3);
                        Console.Write(monster.Symbol);
                    }

                }

                _towerManager.HandleTargetting(_monsters, positions);
                _hud.AllEnemiesHP(_monsters);

                Thread.Sleep(500);

                if (allDone || anyReached)
                {
                    _winCondition.GameLose();
                    return;
                }

                // Tous les ennemis sont-ils morts ?
                bool allKilled = true;
                foreach (Monster m in _monsters)
                    if (m.MonsterHP > 0) { allKilled = false; break; }

                if (allKilled)
                {
                    _winCondition.GameWin();
                    return;
                }
            }
        }
    }
}
