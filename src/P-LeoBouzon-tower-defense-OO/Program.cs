///***************************************************************************
/// ETML
/// Auteur          : Léo Bouzon
/// Date            : 21.01.2026
/// Description     : Ce projet est une reproduction simplifiée d'un
///                   TOWER DEFENSE en mode console. L'objectif ? tirer sur 
///                   les différents ennemis parcourant le chemin à l'aide 
///                   des différentes tours mises à disposition afin de les
///                   empêcher d'atteindre le château.
///***************************************************************************
using P_LeoBouzon_tower_defense_OO.Display;
using System;
using System.Data.Common;
using System.Threading;

namespace P_LeoBouzon_tower_defense_OO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PathManager path = new PathManager();
            TowerManager tower = new TowerManager(path);
            Enemy enemy = new Enemy();

            // ========== MAIN CODE ========== 
            Menu menu = new Menu();
            menu.LaunchMenu();
            HUD hud = new HUD(enemy, tower);
            hud.GameLegend();

            //post configuration
            path.TowerManager = tower;
            path.Hud = hud;
            path.Enemy = enemy;
            tower.Enemy = enemy;
            


            tower.TowerPlacement();

            path.MoveEnemies();
            Console.ReadLine();
        }
    }
}