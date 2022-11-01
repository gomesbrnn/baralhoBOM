using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaralhoBom.API.DTO;
using BaralhoBom.API.Model;
using BaralhoBom.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace BaralhoBom.API.Controllers
{
    [ApiController]
    [Route("api/v1/games")]
    public class GamesController : ControllerBase
    {
        private GameService _gameService;

        public GamesController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Game>>> ListGames()
        {
            var games = await _gameService.ListGames();

            return StatusCode(200, games);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> CreateNewGame(CreateGameDTO gameDTO)
        {
            var game = await _gameService.CreateNewGame(gameDTO);

            return StatusCode(201, game);
        }

        [HttpPut]
        public async Task<ActionResult<Game>> CreateNewGame(int gameId, int playerOneId, int playerTwoId, int playerThreeId, int playerFourId)
        {
            var game = await _gameService.StartNewGame(gameId, playerOneId, playerTwoId, playerThreeId, playerFourId);

            return StatusCode(201, game);
        }
    }
}