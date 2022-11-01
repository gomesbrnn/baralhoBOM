using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BaralhoBom.API.DTO;
using BaralhoBom.API.Model;
using BaralhoBom.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace BaralhoBom.API.Controllers
{
    [ApiController]
    [Route("api/v1/players")]
    public class PlayersController : ControllerBase
    {
        private PlayerService _playerService;
        public PlayersController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Player>>> GetPlayer()
        {
            var player = await _playerService.GetPlayers();
            return StatusCode(200, player);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _playerService.GetPlayerById(id);
            return StatusCode(200, player);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> CreatePlayer(CreatePlayerDTO playerDTO)
        {
            var player = await _playerService.CreatePlayer(playerDTO);

            return StatusCode(201, player);
        }
    }
}