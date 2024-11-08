using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityBombData.Data
{
    public class Symbol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Payout { get; set; }

        [InverseProperty("Symbol1")]
        public ICollection<GameResult> GameResults1 { get; set; }

        [InverseProperty("Symbol2")]
        public ICollection<GameResult> GameResults2 { get; set; }

        [InverseProperty("Symbol3")]
        public ICollection<GameResult> GameResults3 { get; set; }

        [InverseProperty("Symbol4")]
        public ICollection<GameResult> GameResults4 { get; set; }
    }
}
