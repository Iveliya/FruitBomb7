using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityBombData.Data.Entities
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public int LevelId { get; set; }

        [ForeignKey("LevelId")]
        public PlayerLevel Level { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        public double Balance { get; set; }
    }
}
