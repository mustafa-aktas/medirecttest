using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LightsOut_Api_Mustafa_Aktas.DataAccess.Models
{
    public class DefaultTile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TileId { get; set; }
        public long GameSetupId { get; set; }
        public GameSetup GameSetup { get; set; }
    }
}