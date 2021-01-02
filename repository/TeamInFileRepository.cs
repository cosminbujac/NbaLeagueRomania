using NbaLeagueRomania.entities;
using NbaLeagueRomania.entities.validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NbaLeagueRomania.repository
{
    class TeamInFileRepository : InFileRepository<long, Team>
    {
        public TeamInFileRepository(IValidator<Team> validator, string filename) : base(validator, filename, EntityToFileMapping.CreateTeam)
        {

        }

        protected override void writeToFile(Team entity)
        {
            string toWrite = entity.ID + "|" + entity.Name;
            using (StreamWriter w = File.AppendText(this.filename))
            {
                w.WriteLine(toWrite);
            }
        }

        public override Team Save(Team entity)
        {
            Team toSave = base.Save(entity);
            writeToFile(entity);
            return toSave;
        }
    }
}
