using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityBombData.Data.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public Player Player { get; set; }

        [Required]
        [Range(0.01, Double.MaxValue)]
        public decimal Amount { get; set; }
    }
}
