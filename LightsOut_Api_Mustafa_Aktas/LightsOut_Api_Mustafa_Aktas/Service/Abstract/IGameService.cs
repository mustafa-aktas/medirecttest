using LightsOut_Api_Mustafa_Aktas.DTO;
using System.Threading.Tasks;

namespace LightsOut_Api_Mustafa_Aktas.Service.Abstract
{
    public interface IGameService
    {
        Task<BoardDTO> GetBoardData();
    }
}