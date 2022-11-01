using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BaralhoBom.API.Data;
using BaralhoBom.API.DTO;
using BaralhoBom.API.Model;
using Microsoft.EntityFrameworkCore;

namespace BaralhoBom.API.Service
{
    public class PlayerService
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        public PlayerService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Player>> GetPlayers()
        {
            List<Player> player = await _context.Players.AsNoTracking().ToListAsync();
            return player;
        }

        public async Task<Player> GetPlayerById(int playerId)
        {
            Player player = await _context.Players.FirstOrDefaultAsync(player => player.Id == playerId);
            return player;
        }

        public async Task<Player> CreatePlayer(CreatePlayerDTO playerDTO)
        {
            Player player = _mapper.Map<Player>(playerDTO);

            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return player;
        }
    }
}