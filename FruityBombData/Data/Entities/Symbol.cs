using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityBombData.Data.Entities
{
    public class Symbol
    {

        [Key]
        public int SymbolId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        public decimal Payout { get; set; }
    }
}
