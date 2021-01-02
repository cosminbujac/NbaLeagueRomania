using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.entities.validators
{
    class TeamValidator : IValidator<Team>
    {
        List<String> teamNames = new List<string> { "Houston Rockets","Los Angeles Lakers","LA Clippers","Chicago Bulls","Cleaveland Cavaliers"
        , "Utah Jazz", "Brooklyn Jazz", "New Orleans Pelicans", "Indiana Pacers", "Toronto Raptors", "Charlotte Hornets", "Pheonix Suns","Portland TrailBlazers",
        "Golden State Warriors","Washington Warriors","San Antonio Spurs","Orlando Magic","Denver Nuggets","Detroit Pistons","Atlanta Hawks","Dallas Mavericks","Sacremento Kings"
        , "Oklahoma City Thunder","Boston Celtics","New York Knicks","Minnesota Timberwolves","Miami Heat","Milwaukee Bucks"};
        List<String> registeredTeams = new List <String>();
        public void validate(Team e)
        {
            if (!teamNames.Contains(e.Name))
                throw new Exception("Invalid team name!");
            if (registeredTeams.Contains(e.Name))
                throw new Exception("Team already registered!");
            registeredTeams.Add(e.Name);
        }
    }
}
