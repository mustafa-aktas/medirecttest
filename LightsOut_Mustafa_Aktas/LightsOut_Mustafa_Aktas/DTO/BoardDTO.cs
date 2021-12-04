using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOut_Mustafa_Aktas.DTO
{
    public class BoardDTO
    {
        public int RowCount { get; set; }
        public int ColCount { get; set; }
        public IList<int> DefaultTiles { get; set; }
    }
}
