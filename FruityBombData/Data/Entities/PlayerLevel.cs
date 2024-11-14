using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityBombData.Data.Entities
{
    public class PlayerLevel
    {
        [Key]
        public int LevelId { get; set; }

        [Required]
        [MaxLength(50)]
        public string LevelName { get; set; }
    }
}
