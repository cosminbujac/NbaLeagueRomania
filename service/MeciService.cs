using NbaLeagueRomania.entities;
using NbaLeagueRomania.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.service
{
    class MeciService
    {
        private IRepository<long, Game> repository;

        public MeciService(IRepository<long, Game> repository)
        {
            this.repository = repository;
        }

        public Game AddGame(Team team1, Team team2)
        {
            Game newGame =new Game(team1, team2);
            newGame.ID = GetNewId();
            return repository.Save(newGame);
        }

        private long GetNewId()
        {
            long newID = -1;
            foreach (var x in repository.GetAll())
            {
                newID = x.ID;
            }
            return ++newID;
        }

        public Game DeleteGame(long id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<Game> GetAll()
        {
            return repository.GetAll();
        }

        public List<Game> GetGamesBetween(DateTime start, DateTime end)
        {
            List<Game> games = new List<Game>();
            foreach (Game g in repository.GetAll())
                if (g.DateTime.CompareTo(start) > 0 && g.DateTime.CompareTo(end) < 0)
                    games.Add(g);
            return games;

        }
    }
}
