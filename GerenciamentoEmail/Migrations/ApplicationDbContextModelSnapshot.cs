﻿// <auto-generated />
using System;
using GerenciamentoEmail.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GerenciamentoEmail.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("business.Body", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Html");

                    b.HasKey("Id");

                    b.ToTable("Body");
                });

            modelBuilder.Entity("business.EmailAdvocacia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assunto");

                    b.Property<DateTime>("Data");

                    b.Property<string>("MensagemId");

                    b.Property<int>("PessoaId");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("EmailAdvocacia");
                });

            modelBuilder.Entity("business.EmailCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assunto");

                    b.Property<int?>("AtendenteId");

                    b.Property<string>("Body");

                    b.Property<string>("Categoria");

                    b.Property<string>("ConteudoTexto");

                    b.Property<DateTime>("Data");

                    b.Property<string>("MensagemId");

                    b.Property<string>("Remetente");

                    b.HasKey("Id");

                    b.HasIndex("AtendenteId");

                    b.ToTable("EmailCliente");
                });

            modelBuilder.Entity("business.Permissao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Permissao");
                });

            modelBuilder.Entity("business.PermissaoFuncionario", b =>
                {
                    b.Property<int>("FuncionarioId");

                    b.Property<int>("PermissaoId");

                    b.HasKey("FuncionarioId", "PermissaoId");

                    b.HasIndex("PermissaoId");

                    b.ToTable("PermissaoFuncionario");
                });

            modelBuilder.Entity("business.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<int?>("PessoaPJId");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("PessoaPJId");

                    b.ToTable("Pessoa");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pessoa");
                });

            modelBuilder.Entity("business.Funcionario", b =>
                {
                    b.HasBaseType("business.Pessoa");

                    b.Property<string>("Senha");

                    b.HasDiscriminator().HasValue("Funcionario");
                });

            modelBuilder.Entity("business.PessoaPF", b =>
                {
                    b.HasBaseType("business.Pessoa");

                    b.Property<string>("Cpf");

                    b.HasDiscriminator().HasValue("PessoaPF");
                });

            modelBuilder.Entity("business.PessoaPJ", b =>
                {
                    b.HasBaseType("business.Pessoa");

                    b.Property<string>("Cnpj");

                    b.HasDiscriminator().HasValue("PessoaPJ");
                });

            modelBuilder.Entity("business.Terceiros", b =>
                {
                    b.HasBaseType("business.Pessoa");

                    b.HasDiscriminator().HasValue("Terceiros");
                });

            modelBuilder.Entity("business.Admin", b =>
                {
                    b.HasBaseType("business.Funcionario");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("business.Atendente", b =>
                {
                    b.HasBaseType("business.Funcionario");

                    b.HasDiscriminator().HasValue("Atendente");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("business.Body", b =>
                {
                    b.HasOne("business.EmailAdvocacia", "EmailAdvocacia")
                        .WithOne("Body")
                        .HasForeignKey("business.Body", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("business.EmailAdvocacia", b =>
                {
                    b.HasOne("business.Pessoa", "Pessoa")
                        .WithMany("EmailAdvocacia")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("business.EmailCliente", b =>
                {
                    b.HasOne("business.Atendente", "Atendente")
                        .WithMany("EmailCliente")
                        .HasForeignKey("AtendenteId");
                });

            modelBuilder.Entity("business.PermissaoFuncionario", b =>
                {
                    b.HasOne("business.Funcionario", "Funcionario")
                        .WithMany("Permissao")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("business.Permissao", "Permissao")
                        .WithMany("Funcionarios")
                        .HasForeignKey("PermissaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("business.Pessoa", b =>
                {
                    b.HasOne("business.PessoaPJ", "PessoaPJ")
                        .WithMany("Clientes")
                        .HasForeignKey("PessoaPJId");
                });
#pragma warning restore 612, 618
        }
    }
}
