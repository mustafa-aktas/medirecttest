using LightsOut_Api_Mustafa_Aktas.DataAccess;
using LightsOut_Api_Mustafa_Aktas.DTO;
using LightsOut_Api_Mustafa_Aktas.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LightsOut_Api_Mustafa_Aktas.Service.Concrete
{
    public class GameService : IGameService
    {
        private readonly GameDbContext _context;

        public GameService(GameDbContext context) => _context = context;

        public async Task<BoardDTO> GetBoardData()
        {
            var gameData = await _context.GameSetups.Include(x => x.DefaultTiles).FirstAsync();

            return new BoardDTO
            {
                ColCount = gameData.ColCount,
                RowCount = gameData.RowCount,
                DefaultTiles = gameData.DefaultTiles.Select(x => x.TileId).ToList()
            };
        }
    }
}