using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrabalhoDAAW.Models;

namespace TrabalhoDAAW.Data
{
    public class TrabalhoDAAWContext : DbContext
    {
        public TrabalhoDAAWContext (DbContextOptions<TrabalhoDAAWContext> options)
            : base(options)
        {
        }

        public DbSet<TrabalhoDAAW.Models.CadastroUsuario> CadastroUsuario { get; set; } = default!;
        public DbSet<TrabalhoDAAW.Models.Produto> Produto { get; set; } = default!;
        public DbSet<TrabalhoDAAW.Models.Marca> Marca { get; set; } = default!;
        public DbSet<TrabalhoDAAW.Models.Suporte> Suporte { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .Property(f => f.Preco)
                .HasColumnType("decimal(18,2)");

        }
    }

}
