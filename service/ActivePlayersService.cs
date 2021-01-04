using NbaLeagueRomania.entities;
using NbaLeagueRomania.repository;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActivePlayer AddActivePlayer(ActivePlayer newActivePlayer)
        {
            newActivePlayer.ID = new Tuple<long, long>(newActivePlayer.idJucator, newActivePlayer.idMeci);
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

        public IEnumerable<ActivePlayer> GetActivePlayersOfGame(long gameID)
        {
            IEnumerable<ActivePlayer> players = from activePlayer in repository.GetAll()
                                         where activePlayer.idMeci.Equals(gameID)
                                         select activePlayer;

            return players;
        }


    }

   

}

