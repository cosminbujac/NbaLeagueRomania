using NbaLeagueRomania.entities;
using NbaLeagueRomania.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.service
{
    class ServiceJucatori
    {
        private IRepository<long, Player> repository;

        public ServiceJucatori(IRepository<long, Player> repository)
        {
            this.repository = repository;
        }

        public Player AddPlayer(string nume,string scoala, Team echipa)
        {
            Player newPlayer = new Player(nume,scoala,echipa);
            newPlayer.ID = GetNewId();
            return repository.Save(newPlayer);
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

        public Player DeletePlayer(long id)
        {
            return repository.Delete(id);
        }

        public List<Player> GetPlayersOfTeam(Team echipa)
        {
            List < Player > players = new List<Player>();
            foreach (Player x in repository.GetAll())
                if (x.Echipa.Equals(echipa))
                    players.Add(x);
            return players;
        }

    }
}
