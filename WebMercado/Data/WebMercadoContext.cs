using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMercado.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace WebMercado.Data
{
    public class WebMercadoContext : IdentityDbContext<Usuario>
    {
        public WebMercadoContext(DbContextOptions<WebMercadoContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.Entity<Usuario>().ToTable("Usuario");
            builder.Entity<Usuario>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            builder.Entity<Usuario>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(85));
            builder.Entity<Usuario>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(85));

            builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(85));

            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(85));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));

            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));

            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(85));

            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));

            // IDS DOS PERFIS
            string ROLE_ADMIN_ID = Guid.NewGuid().ToString();
            string ROLE_CLIENTE_ID = Guid.NewGuid().ToString();

            // IDS DOS USUARIOS
            string ADMIN_ID = Guid.NewGuid().ToString();
            string CLIENTE_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLE_ADMIN_ID,
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR"
                },
                new IdentityRole
                {
                    Id = ROLE_CLIENTE_ID,
                    Name = "Cliente",
                    NormalizedName = "CLIENTE"
                }
            );

            var hash1 = new PasswordHasher<Usuario>();
            var hash2 = new PasswordHasher<Usuario>();
            builder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = ADMIN_ID,
                    Nome = "Admin",
                    Apelido = "Admin",
                    DataNascimento = DateTime.Now,
                    UserName = "admin@webmercado.com.br",
                    NormalizedUserName = "ADMIN@WEBMERCADO.COM.BR",
                    Email = "admin@webmercado.com.br",
                    NormalizedEmail = "ADMIN@WEBMERCADO.COM.BR",
                    EmailConfirmed = true,
                    PasswordHash = hash1.HashPassword(null, "123456"),
                    SecurityStamp = hash1.GetHashCode().ToString()
                },
                new Usuario
                {
                    Id = CLIENTE_ID,
                    Nome = "Nathan Davison Lima",
                    Apelido = "Nathan",
                    DataNascimento = Convert.ToDateTime("08/11/2002"),
                    UserName = "nadavison@live.com",
                    NormalizedUserName = "NADAVISON@LIVE.COM",
                    Email = "nadavison@live.com",
                    NormalizedEmail = "NADAVISON@LIVE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hash2.HashPassword(null, "123456"),
                    SecurityStamp = hash2.GetHashCode().ToString()
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_ADMIN_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_CLIENTE_ID,
                    UserId = CLIENTE_ID
                }
            );

        }


    }
}
