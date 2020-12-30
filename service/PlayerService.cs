using NbaLeagueRomania.entities;
using NbaLeagueRomania.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.service
{
    class PlayerService
    {
        private IRepository<long, Player> repository;

        public PlayerService(IRepository<long, Player> repository)
        {
            this.repository = repository;
        }

        public Player AddPlayer(Player newPlayer)
        {
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

        public IEnumerable<Player> GetAllPlayers()
        {
            return repository.GetAll();
        }

        public Player GetOne(long id)
        {
            return repository.GetOne(id);
        }

    }
}
