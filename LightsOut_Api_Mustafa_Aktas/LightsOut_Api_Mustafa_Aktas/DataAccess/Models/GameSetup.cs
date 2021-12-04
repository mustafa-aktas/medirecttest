using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LightsOut_Api_Mustafa_Aktas.DataAccess.Models
{
    public class GameSetup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int RowCount { get; set; }
        public int ColCount { get; set; }

        public List<DefaultTile> DefaultTiles { get; set; }
    }
}