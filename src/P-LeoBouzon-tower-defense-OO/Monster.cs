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
    internal class Monster
    {
        // ========== MONSTERS DATA ==========
        private int _monsterInitialHP = 100;
        public int MonsterInitialHP
        {
            get { return _monsterInitialHP; }
        }

        private int _monsterHP ;
        public int MonsterHP
        {
            get { return _monsterHP; }
            set
            { _monsterHP = value; }
        }

        private int _monsterXMovement = 1;
        public int MonsterXMovement
        {
            get { return _monsterXMovement; }
        }

        public Monster()
        {
            _monsterHP = MonsterInitialHP;
        }

    }
}
