using FruityBombData.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityBombData
{
    public class FruityBombDbContext:DbContext
    {
        public DbSet<GameResult> GameResultss { get; set; }
        public DbSet<PayoutRules> PayoutRuless { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Symbol> Symbols { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameResult>()
                .HasOne(gr => gr.Symbol1)
                .WithMany(s => s.GameResults1)
                .HasForeignKey(gr => gr.SymbolId1)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GameResult>()
                .HasOne(gr => gr.Symbol2)
                .WithMany(s => s.GameResults2)
                .HasForeignKey(gr => gr.SymbolId2)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GameResult>()
                .HasOne(gr => gr.Symbol3)
                .WithMany(s => s.GameResults3)
                .HasForeignKey(gr => gr.SymbolId3)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GameResult>()
                .HasOne(gr => gr.Symbol4)
                .WithMany(s => s.GameResults4)
                .HasForeignKey(gr => gr.SymbolId4)
                .OnDelete(DeleteBehavior.Restrict);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-AEUQ5AJ\\SQLEXPRESS;Initial Catalog=JuiceBomb;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
