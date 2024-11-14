using FruityBombData.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityBombData
{
    public class CazinoDbContext:DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Symbol> Symbols { get; set; }
        public DbSet<PlayerLevel> PlayerLevels { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public CazinoDbContext() { }    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-AEUQ5AJ\\SQLEXPRESS;Initial Catalog=JuiceBomb6;Integrated Security=True;TrustServerCertificate=True");
            }
        }
    }
}
