using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiteSpeakAndSing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSpeakAndSing.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }
        public DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            // создаем РОЛЬ администратора
            modelbuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "3911E849-2F60-4D40-BE18-87037B47E2B2",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            // создаем админа
            modelbuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "AE8A9060-71CF-4A49-9860-96BE65D9464C",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            //привязываем роль администратора к админу 
            modelbuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "3911E849-2F60-4D40-BE18-87037B47E2B2",
                UserId = "AE8A9060-71CF-4A49-9860-96BE65D9464C"
            });

            //создаем три объекта в БД (текстовые поля)
            modelbuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("569E4890-F884-4E68-86DB-7E61CD607EE6"),
                CodeWord = "PageIndex",
                Title = "Главная",
                DateAdded = DateTime.UtcNow
            });

            modelbuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("CB9F69AE-ECD5-40B0-B180-ABF6F806E136"),
                CodeWord = "PageService",
                Title = "Наши услуги",
                DateAdded = DateTime.UtcNow
            });

            modelbuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("ED1CEE78-DFDF-42FA-80D7-ABDA43A9AF56"),
                CodeWord = "PageContacts",
                Title = "Контакты",
                DateAdded = DateTime.UtcNow
            });

            modelbuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("D4A57309-2DD0-4E35-A511-98D8C5D86A16"),
                CodeWord = "PageTeachers",
                Title = "Педагоги",
                DateAdded = DateTime.UtcNow
            });

            modelbuilder.Entity<Teacher>().HasData(new Teacher
            {
                Id = new Guid("4950245F-4E06-4A57-85DB-7C5AE8376B88"),
                CodeWord = "Teacher",
                Title = "Педагог",
                DateAdded = DateTime.UtcNow
            }) ;
        }
    }
}
