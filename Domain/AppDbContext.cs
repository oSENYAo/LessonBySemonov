using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<TextField> TextField{ get; set; }
        public DbSet<ServiceItem> ServiceItems  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "8ADD6S41-B43A-E9E-CA8A-812247ADE392",
                Name = "admin",
                NormalizedName ="ADMIN"
            });
            
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "8AFD6841-B23A-A9D3-CA97-C12BEA352992",
                
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "kuv99@mail.ru",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,"superpassword"),
                SecurityStamp = String.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "8ADD6S41-B43A-E9E-CA8A-812247ADE392",
                UserId = "8AFD6841-B23A-A9D3-CA97-C12BEA352992"

            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("8A43EFF1-b23A-E9C3-CCE7-D12FEF3ABAD2"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("8A42EAF1-b23A-E98D-CCE7-D12FEA2BBAD2"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("8B43EAA1-A23B-E9C3-CCE7-A22FE43A28D2"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });

        }
    }
}
