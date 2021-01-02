using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.entities.validators
{
    class PlayerValidator : IValidator<Player>
    {
        Dictionary<string, string> schools = new Dictionary<string, string> {
            {"Scoala Gimnaziala Horea","Houston Rockets" },
            {"Scoala Gimnaziala Octavian Goga","Los Angeles Lakers" },
            {"Liceul Teoretic Lucian Blaga","LA Clippers" },
            {"Scoala Gimnaziala Ioan Bob","Chicago Bulls" },
            {"Scoala Gimnaziala Ion Creanga","Cleveland Cavaliers" },
            {"Colegiul National Pedagogic Gheorghe Lazar" ,"Utah Jazz" },
            { "Scoala Gimnaziala Internationala SPECTRUM","Brooklyn Nets" },
            { "Colegiul National Emil Racovita", "New Orleans Pelicans" },
            { "Colegiul National George Cosbuc", "Indiana Pacers" },
            { "Scoala Gimnaziala Ion Agarbiceanu","Toronto Raptors" },
            { "Liceul Teoretic Avram Iancu","Charlotte Hornets" },
            { "Scoala Gimnaziala Constantin Brancusi","Phoenix Suns" },
            { "Liceul Teoretic Onisifor Ghibu","Portland TrailBlazers" },
            { "Liceul Teoretic Onisifor Ghibu 2","Golden State Warriors" },
            { "Liceul cu Program Sportiv Cluj-Napoca","Washington Wizards" },
            { "Liceul Teoretic Nicolae Balcescu","San Antonio Spurs" },
            { "Liceul Teoretic Gheorghe Sincai", "Orlando Magic" },
            { "Scoala Nicolae Titulescu","Denver Nuggets" },
            {"Scoala Gimnaziala Liviu Rebreanu", "Detroit Pistons" },
            { "Scoala Gimnaziala Iuliu Hatieganu", "Atlanta Hawks" },
            { "Liceul Teoretic Bathory Istvan","Dallas Mavericks" },
            { "Colegiul National George Baritiu","Sacramento Kings" },
            { "Liceul Teoretic Apaczai Csere Janos","Oklahoma City Thunder" },
            { "Seminarul Teologic Ortodox","Boston Celtics" },
            { "Liceul de Informatica Tiberiu Popoviciu","New York Knicks"},
            { "Scoala Gimnaziala Alexandru Vaida – Voevod","Minnesota Timberwolves" },
            { "Liceul Teoretic ELF","Miami Heat" },
            { "Scoala Gimnaziala Gheorghe Sincai Floresti", "Milwaukee Bucks" }
        };
        
        public void validate(Player e)
        {
            if (e.Nume.Length < 3)
                throw new Exception("The name is too short!");
            if (e.Nume.Length >= 100)
                throw new Exception("Name is too long!");
            if (!schools.ContainsKey(e.Scoala))
                throw new Exception("The student isn't from a valid school");
            if (!schools[e.Scoala].Equals(e.Echipa.Name))
                throw new Exception("The player from this school can only play for: " + schools[e.Scoala]);
        }
    }
}
