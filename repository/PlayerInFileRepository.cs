using NbaLeagueRomania.entities;
using NbaLeagueRomania.entities.validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NbaLeagueRomania.repository
{
    class PlayerInFileRepository:InFileRepository<long,Player>
    {
        public PlayerInFileRepository(IValidator<Player> validator, string filename) : base(validator, filename,null)
        {
            loadFromFile();
        }
        private new void loadFromFile()
        {
            List<Team> teams = DataReader.ReadData<Team>("..\\..\\..\\data\\teams.txt", EntityToFileMapping.CreateTeam); ;
            
            using(StreamReader sr = new StreamReader(filename))
            {
                string line;
                while((line = sr.ReadLine())!=null)
                {
                    string[] fields = line.Split('|');
                    Team neededTeam = teams.Find(x => x.ID.Equals(long.Parse(fields[3])));
                    Player player = new Player(fields[1], fields[2], neededTeam);
                    player.ID = long.Parse(fields[0]);
                    base.entities[player.ID] = player;
                }
            }
        }

        protected override void writeToFile(Player entity)
        {
            string toWrite = entity.ID + "|" + entity.Nume+"|"+entity.Scoala+"|"+entity.Echipa.ID;
            using (StreamWriter w = File.AppendText(this.filename))
            {
                w.WriteLine(toWrite);
            }
        }

        public override Player Save(Player entity)
        {
            Player toSave = base.Save(entity);
            writeToFile(entity);
            return toSave;
           
        }
    }
}
