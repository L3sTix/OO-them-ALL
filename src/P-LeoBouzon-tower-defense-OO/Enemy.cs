///***************************************************************************
/// ETML
/// Auteur          : Léo Bouzon
/// Date            : 04.02.2026
/// Description     : Classe servant à gérer tout les éléments et les méthodes
///                   utilisées pour gérer les ennemis et les informations les
///                   concernant.
///***************************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P_LeoBouzon_tower_defense_OO.Display;

namespace P_LeoBouzon_tower_defense_OO
{
    internal class Enemy
    {
        // ========== ENNEMIES DATA ==========
        private int _enemyInitialHP = 100;
        public int enemyInitialHP
        {
            get { return _enemyInitialHP; }
        }

        private int _enemyHP ;
        public int enemyHP
        {
            get { return _enemyHP; }
            set
            { _enemyHP = value; }
        }

        private int _enemyXMovement = 1;
        public int enemyXMovement
        {
            get { return _enemyXMovement; }
        }

        public Enemy()
        {
            _enemyHP = enemyInitialHP;
        }

    }
}
