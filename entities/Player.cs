using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.entities
{
    class Player:Student
    {
        public Team Echipa { get; set; }

        public Player(string nume, string scoala,Team echipa): base (nume,scoala)
        {
            Echipa = echipa;
        }

        public override string ToString()
        {
            return this.Nume + " plays for " + this.Echipa;
        }
    }
}
