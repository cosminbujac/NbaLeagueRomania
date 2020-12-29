using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.entities
{
    class Game:Entity<long>
    {
        protected Team FirstTeam { get; set; }
        protected Team SecondTeam { get; set; }
        public DateTime DateTime { get; set; }

        public Game(Team echipa_1, Team echipa_2)
        {
            FirstTeam = echipa_1;
            SecondTeam = echipa_2;
            DateTime = DateTime.Now;
        }

        public override string ToString()
        {
            return FirstTeam + " played " + SecondTeam + "at : " + this.DateTime.ToString();
        }
    }
}
