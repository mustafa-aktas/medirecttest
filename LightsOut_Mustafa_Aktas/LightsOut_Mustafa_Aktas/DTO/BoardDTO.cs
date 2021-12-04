using System.Collections.Generic;

namespace LightsOut_Mustafa_Aktas.DTO
{
    public class BoardDTO
    {
        public int RowCount { get; set; }
        public int ColCount { get; set; }
        public IList<int> DefaultTiles { get; set; }
    }
}