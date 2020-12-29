using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.entities
{
    class Team : Entity<long>
    {
        String Name { get; set; }

        public Team(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is Team echipa &&
                   ID == echipa.ID;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
