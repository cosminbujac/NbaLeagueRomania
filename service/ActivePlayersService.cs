using NbaLeagueRomania.entities;
using NbaLeagueRomania.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.service
{
    class ActivePlayersService
    {
        private IRepository<Tuple<long, long>, ActivePlayer> repository;

        public ActivePlayersService(IRepository<Tuple<long, long>, ActivePlayer> repository)
        {
            this.repository = repository;
        }

        public ActivePlayer AddActivePlayer(long idJucator, long idMeci, int nrPuncte, Tip tip)
        {
            ActivePlayer newActivePlayer = new ActivePlayer(idJucator, idMeci, nrPuncte, tip);
            newActivePlayer.ID = new Tuple<long, long>(idJucator, idMeci);
            return repository.Save(newActivePlayer);
        }

        public ActivePlayer DeleteActivePlayer(Tuple<long,long> id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<ActivePlayer> GetAllActivePlayers()
        {
            return repository.GetAll();
        }

        public List<ActivePlayer> GetActivePLayersOfGame(long gameID)
        {
            List<ActivePlayer> players = new List<ActivePlayer>();
            foreach (var x in repository.GetAll())
                if (x.idMeci.Equals(gameID))
                    players.Add(x);
            return players;

        }


    }

   

}

