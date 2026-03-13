///***************************************************************************
/// ETML
/// Auteur          : Léo Bouzon
/// Date            : 13.03.2026
/// Description     : Classe représentant un boss, hérite de Enemy.
///                   Plus de HP qu'un ennemi normal.
///***************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_LeoBouzon_tower_defense_OO
{
    internal class Boss : Monster
    {
        public Boss() : base('B')
        {
            _monsterInitialHP = 120;
            _monsterHP = 120;
        }
    }
}
