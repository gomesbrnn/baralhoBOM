using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BaralhoBom.API.Data;
using BaralhoBom.API.DTO;
using BaralhoBom.API.Model;
using Microsoft.EntityFrameworkCore;

namespace BaralhoBom.API.Service
{
    public class GameService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        private PlayerService _playerService;
        public GameService(ApplicationDbContext context, IMapper mapper, PlayerService playerService)
        {
            _context = context;
            _mapper = mapper;
            _playerService = playerService;
        }

        public async Task<ICollection<Game>> ListGames()
        {
            ICollection<Game> games = await _context.Games.Include(game => game.Players).AsNoTracking().ToListAsync();

            return games;
        }

        public async Task<Game> GetGameById(int gameId)
        {
            Game game = await _context.Games.FirstOrDefaultAsync(game => game.Id == gameId);
            return game;
        }

        public async Task<Game> CreateNewGame(CreateGameDTO gameDTO)
        {
            Game game = _mapper.Map<Game>(gameDTO);

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return game;
        }

        public async Task<Game> StartNewGame(int gameId, int playerOneId, int playerTwoId, int playerThreeId, int playerFourId)
        {
            Game game = await GetGameById(gameId);

            var player1 = await _playerService.GetPlayerById(playerOneId);
            var player2 = await _playerService.GetPlayerById(playerTwoId);
            var player3 = await _playerService.GetPlayerById(playerThreeId);
            var player4 = await _playerService.GetPlayerById(playerFourId);

            game.Players.Add(player1);
            game.Players.Add(player2);
            game.Players.Add(player3);
            game.Players.Add(player4);

            var drawVerify = game.Players.GroupBy(player => player.Points).Any(player => player.Count() > 1);

            if (!drawVerify)
            {
                game.Winner = game.Players.OrderByDescending(player => player.Points).First().Name;
            }

            game.Winner = "Draw";

            _context.Games.Update(game);
            await _context.SaveChangesAsync();

            return game;
        }

        //         public async Task<Game> StartNewGame(int gameId, int playerOneId, int playerTwoId, int playerThreeId, int playerFourId)
        // {
        //     Game game = await GetGameById(gameId);

        //     var player1 = await _playerService.GetPlayerById(playerOneId);
        //     var player2 = await _playerService.GetPlayerById(playerTwoId);
        //     var player3 = await _playerService.GetPlayerById(playerThreeId);
        //     var player4 = await _playerService.GetPlayerById(playerFourId);

        //     game.Players.Add(player1);
        //     game.Players.Add(player2);
        //     game.Players.Add(player3);
        //     game.Players.Add(player4);

        //     var drawVerify = game.Players.GroupBy(player => player.Points).Any(player => player.Count() > 1);

        //     if (!drawVerify)
        //     {
        //         game.Winner = game.Players.OrderByDescending(player => player.Points).First().Name;
        //     }

        //     game.Winner = "Draw";

        //     _context.Games.Update(game);
        //     await _context.SaveChangesAsync();

        //     return game;
        // }

    }
}