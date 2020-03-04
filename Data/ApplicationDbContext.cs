using System;
using System.Collections.Generic;
using System.Text;
using GerenciamentoEvento.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEvento.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) { }
        public DbSet<GerenciamentoEvento.Models.Local> Local { get; set; }
        public DbSet<GerenciamentoEvento.Models.Evento> Evento { get; set; }
        public DbSet<GerenciamentoEvento.Models.Venda> Venda { get; set; }
        public DbSet<GerenciamentoEvento.Models.Usuario> Usuario { get; set; }
    }
}