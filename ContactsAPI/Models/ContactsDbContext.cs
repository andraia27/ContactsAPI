using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using ContactsAPI.Models;
using NuGet.Protocol.Plugins;

namespace ContactsAPI.Models
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(new Contact { Id = 1, LastName = "Hillion", Firstname = "Sabelle", Email = "sabh@test.fr", DateCreated = new DateTime(2023, 08, 1), Address = "17 rue des bois, 75000 PARIS, FRANCE", FullName = "Sabelle HILLION", MobilePhoneNumber = "(+33)631256321", UserId = 1 });
            modelBuilder.Entity<Contact>().HasData(new Contact { Id = 2, LastName = "Dubois", Firstname = "Thierry", Email = "tdubois@test.ch", DateCreated = new DateTime(2023, 09, 23), Address = "12 rue du 31-Decembre 32, Genève 1207, SUISSE", FullName = "Thierry DUBOIS", MobilePhoneNumber = "091 670 11 93", UserId = 2 });
            modelBuilder.Entity<Contact>().HasData(new Contact { Id = 3, LastName = "Leblanco", Firstname = "Sonia", Email = "sleblanc@test.it", DateCreated = new DateTime(2023, 10, 1), Address = "Via Giotto 135, 37060 Pizzoletta, ITALIA", FullName = "Sonia LEBLANCO", MobilePhoneNumber = "0337 8412749" });

            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 1, Name = "Programming" });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 2, Name = "Accounting" });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 3, Name = "Management" });

            modelBuilder.Entity<ContactSkillLevel>().HasData(new ContactSkillLevel { Id = 1, ContactId = 1, SkillId = 1, Level = LevelEnum.Confirmed });
            modelBuilder.Entity<ContactSkillLevel>().HasData(new ContactSkillLevel { Id = 2, ContactId = 2, SkillId = 1, Level = LevelEnum.Intermediate });
            modelBuilder.Entity<ContactSkillLevel>().HasData(new ContactSkillLevel { Id = 3, ContactId = 2, SkillId = 2, Level = LevelEnum.Expert });
            modelBuilder.Entity<ContactSkillLevel>().HasData(new ContactSkillLevel { Id = 4, ContactId = 2, SkillId = 3, Level = LevelEnum.Confirmed });
            modelBuilder.Entity<ContactSkillLevel>().HasData(new ContactSkillLevel { Id = 5, ContactId = 3, SkillId = 2, Level = LevelEnum.Discovery });
            modelBuilder.Entity<ContactSkillLevel>().HasData(new ContactSkillLevel { Id = 6, ContactId = 3, SkillId = 3, Level = LevelEnum.Intermediate });

            modelBuilder.Entity<UserInfo>().HasData(new UserInfo { Id = 1, DisplayName = "Sabelle", CreatedDate = DateTime.Now, Email = "sab@test.fr", Password = "123P@$$!!", UserName = "sabelleh"});
            modelBuilder.Entity<UserInfo>().HasData(new UserInfo { Id = 2, DisplayName = "Thierry", CreatedDate = DateTime.Now, Email = "titi@test.ch", Password = "456$$AA??", UserName = "thierryd"});

        }

        public DbSet<Contact> Contacts { get; set; } = null!;

        public DbSet<Skill> Skills { get; set; } = null!;

        public DbSet<ContactSkillLevel> ContactSkillLevels { get; set; } = null!;
        public DbSet<UserInfo> UserInfos { get; set; } = null!;

    }
}
