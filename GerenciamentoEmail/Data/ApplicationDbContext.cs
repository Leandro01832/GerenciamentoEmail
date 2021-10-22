using System;
using System.Collections.Generic;
using System.Text;
using business;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEmail.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Atendente> Atendente { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<PessoaPF> PessoaPF { get; set; }
        public DbSet<PessoaPJ> PessoaPJ { get; set; }
        public DbSet<Terceiros> Terceiros { get; set; }
        public DbSet<EmailAdvocacia> EmailAdvocacia { get; set; }
        public DbSet<EmailCliente> EmailCliente { get; set; }
        public DbSet<Permissao> Permissao { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PermissaoFuncionario>()
                .HasKey(p => new { p.FuncionarioId, p.PermissaoId });

            builder.Entity<Pessoa>()
           .HasIndex(u => u.Email)
           .IsUnique();
        }
    }
}
