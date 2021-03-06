using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
   public class BD : DbContext
    {
        public DbSet<PermissaoFuncionario> PermissaoFuncionario { get; set; }
        public DbSet<Atendente> Atendente { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<PessoaPF> PessoaPF { get; set; }
        public DbSet<PessoaPJ> PessoaPJ { get; set; }
        public DbSet<Terceiros> Terceiros { get; set; }
        public DbSet<EmailAdvocacia> EmailAdvocacia { get; set; }
        public DbSet<EmailCliente> EmailCliente { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

           // optionsBuilder.UseSqlServer(@"Data Source=database-advocacia.mssql.somee.com;packet size=4096;user id=leandro01835_SQLLogin_1;pwd=cuiom27is7;data source=database-advocacia.mssql.somee.com;persist security info=False;initial catalog=database-advocacia");
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-5HMQJL9;Initial Catalog=Database-Email;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PermissaoFuncionario>()
                .HasKey(p => new { p.FuncionarioId, p.PermissaoId });

            modelBuilder.Entity<Pessoa>()
           .HasIndex(u => u.Email)
           .IsUnique();
        }

    }
}
