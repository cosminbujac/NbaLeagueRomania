using NbaLeagueRomania.controller;
using NbaLeagueRomania.entities;
using NbaLeagueRomania.entities.validators;
using NbaLeagueRomania.repository;
using NbaLeagueRomania.service;
using NbaLeagueRomania.ui;
using System;

namespace NbaLeagueRomania
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<long, Team> teamRepo = new InMemoryRepository<long, Team>(new BasicValidator<Team>());
            IRepository<long, Player> playerRepo = new InMemoryRepository<long, Player>(new BasicValidator<Player>());
            IRepository<long, Game> gameRepo = new InMemoryRepository<long, Game>(new BasicValidator<Game>());
            IRepository<Tuple<long,long>, ActivePlayer> activePlayerRepo = new InMemoryRepository<Tuple<long,long>, ActivePlayer>(new BasicValidator<ActivePlayer>());

            TeamService teamService = new TeamService(teamRepo);
            PlayerService playerService = new PlayerService(playerRepo);
            GameService gameService = new GameService(gameRepo);
            ActivePlayersService activePlayersService = new ActivePlayersService(activePlayerRepo);

            Controller controller = new Controller(activePlayersService, teamService, playerService, gameService);
            consoleUI ui = new consoleUI(controller);
            ui.run();
        }
    }
}
