using NbaLeagueRomania.entities;
using NbaLeagueRomania.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.service
{
    class EchipaService
    {
        private IRepository<long,Team> repository;

        public EchipaService(IRepository<long, Team> repository)
        {
            this.repository = repository;
        }

        public Team AddTeam(string nume)
        {
            Team newTeam = new Team(nume);
            newTeam.ID = GetNewId();
            return repository.Save(newTeam);
        }

        private long GetNewId()
        {
            long newID = -1;
            foreach(var x in repository.GetAll())
            {
                newID = x.ID;
            }
            return ++newID;
        }

        public Team DeleteTeam(long id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return repository.GetAll();
        }
       
        public Team GetOne(long id)
        {
           return repository.GetOne(id);
        }
    }
}
