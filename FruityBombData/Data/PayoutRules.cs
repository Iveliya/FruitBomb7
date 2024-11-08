using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityBombData.Data
{
    public class PayoutRules
    {
        [Key]
        public int RuleId { get; set; }
        [Required]
        public string Combination { get; set; }
        public decimal PayoutAmount { get; set; }
    }
}
