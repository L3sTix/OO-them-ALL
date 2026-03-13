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
        private string _name;
        protected int _monsterInitialHP = 70;
        public int MonsterInitialHP
        {
            get { return _monsterInitialHP; }
        }

        protected int _monsterHP ;
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

        private int _monsterOldPosition;
        private int _monsterPosition = 0;
        public int MonsterPosition
        {
            get { return _monsterPosition; }
            set { }
        }
        public int MonsterOldPosition
        {
            get { return _monsterOldPosition; }
            set { }
        }
        // Symbole affiché sur le chemin (première lettre du nom du monstre)
        protected char _symbol;
        public char Symbol => _symbol;
        public Monster(char symbol = 'E')
        {
            _monsterHP = MonsterInitialHP;
            _symbol = symbol;
        }

    }
}
