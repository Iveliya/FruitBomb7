using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FruityBombData.Data
{
    public class GameResult
    {
        public int Id { get; set; }

        public int SymbolId1 { get; set; }
        [ForeignKey("SymbolId1")]
        [InverseProperty("GameResults1")]
        public Symbol Symbol1 { get; set; }

        public int SymbolId2 { get; set; }
        [ForeignKey("SymbolId2")]
        [InverseProperty("GameResults2")]
        public Symbol Symbol2 { get; set; }

        public int SymbolId3 { get; set; }
        [ForeignKey("SymbolId3")]
        [InverseProperty("GameResults3")]
        public Symbol Symbol3 { get; set; }

        public int SymbolId4 { get; set; }
        [ForeignKey("SymbolId4")]
        [InverseProperty("GameResults4")]
        public Symbol Symbol4 { get; set; }

        public decimal BetAmount { get; set; }
        public decimal WinAmount { get; set; }
    }
}
