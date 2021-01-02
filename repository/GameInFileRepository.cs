using NbaLeagueRomania.entities;
using NbaLeagueRomania.entities.validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NbaLeagueRomania.repository
{
    class GameInFileRepository:InFileRepository<long,Game>
    {
        public GameInFileRepository(IValidator<Game> validator, string filename) : base(validator, filename, null)
        {
            loadFromFile();
        }

      

        protected override void loadFromFile()
        {
            List<Team> teams = DataReader.ReadData<Team>("..\\..\\..\\data\\teams.txt", EntityToFileMapping.CreateTeam); ;

            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields = line.Split('|');
                    Team team1 = teams.Find(x => x.ID.Equals(long.Parse(fields[1])));
                    Team team2 = teams.Find(x => x.ID.Equals(long.Parse(fields[2])));
                    DateTime datetime = DateTime.Parse(fields[3]);
                    Game game = new Game(team1,team2,datetime);
                    game.ID = long.Parse(fields[0]);
                    base.entities[game.ID] = game;
                }
            }
        }

        protected override void writeToFile(Game entity)
        {
            string toWrite = entity.ID + "|" + entity.FirstTeam.ID + "|" + entity.SecondTeam.ID + "|" + entity.DateTime;
            using (StreamWriter w = File.AppendText(this.filename))
            {
                w.WriteLine(toWrite);
            }
        }
        public override Game Save(Game entity)
        {
            Game toSave =base.Save(entity);
            writeToFile(entity);
            return toSave;
            
        }
    }
}
