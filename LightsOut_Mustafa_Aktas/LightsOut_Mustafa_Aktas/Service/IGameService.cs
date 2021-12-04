using LightsOut_Mustafa_Aktas.DTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOut_Mustafa_Aktas.Service
{
    public interface IGameService
    {
        [Get("/api/Game/board")]
        Task<BoardDTO> GetBoardSize();
    }
}
