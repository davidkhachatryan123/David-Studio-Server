using David_Studio_Server.Database.Base;
using David_Studio_Server.Database.Enums;
using David_Studio_Server.Database.Models.Contact;
using David_Studio_Server.Database.Models.Path;
using David_Studio_Server.Database.Models.Project;
using David_Studio_Server.Database.Models.Service;
using David_Studio_Server.Database.Models.Translation;
using Microsoft.EntityFrameworkCore;

namespace David_Studio_Server.Database
{
    public partial class davidstudioContext : DbContext
    {
        public davidstudioContext(DbContextOptions<davidstudioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Models.Path.Path> Paths { get; set; } = null!;
        public virtual DbSet<Jumbotron> Jumbotrons { get; set; } = null!;

        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectImage> ProjectImages { get; set; } = null!;
        public virtual DbSet<ProjectTag> ProjectsTags { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;

        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<CircleBlock> CircleBlocks { get; set; } = null!;
        public virtual DbSet<Circle> Circles { get; set; } = null!;

        public virtual DbSet<Contact> Contacts { get; set; } = null!;

        public virtual DbSet<Language> Languages { get; set; } = null!;
        //public virtual DbSet<Translation> Translations { get; set; } = null!;
        public virtual DbSet<TemplateTranslation> TemplateTranslations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityModelConfiguration<Identity>).Assembly);


            FillData(modelBuilder);
        }

        private void FillData(ModelBuilder modelBuilder)
        {
            Models.Path.Path path_web = new() { Id = 1, Value = "web" };

            Service service_web = new() { Id = 1, ImgUrl = "uploads/images/web_dev.jpg", PathId = path_web.Id };

            Language am = new() { Id = 1, Name = "Armenian", Culture = "hy-AM" };
            Language ru = new() { Id = 2, Name = "Russian", Culture = "ru-RU" };
            Language en = new() { Id = 3, Name = "English (US)", Culture = "en-US" };

            TemplateTranslation t_1 = new()
            {
                Id = 1,
                Title = "<strong>| WEB</strong> Կայքերի պատրաստում",
                Description = "Ընկերությունն ինքնին շատ հաջողակ ընկերություն է։ Այս ասելով, թող մեծերը ձեռք բերեն, թող ձգտեն ավելի քիչ կուրացած հետևել, որպեսզի մենք կարողանանք վայելել հաճույքները։ Իրական մարզվելը անպայման տեղի կունենա տեսանելի անհարմարության մեջ:",
                ServiceId = service_web.Id,
                LanguageId = am.Id
            };
            TemplateTranslation t_2 = new()
            {
                Id = 2,
                Title = "<strong>|</strong> ПОДГОТОВКА <strong>Веб</strong> САЙТОВ",
                Description = "Сама компания очень успешная. Сказав это, пусть старшие приобретут это, пусть постараются следовать за менее слепыми, чтобы мы могли наслаждаться удовольствиями. Получение фактического обучения неизбежно будет сопровождаться видимым дискомфортом.",
                ServiceId = service_web.Id,
                LanguageId = ru.Id
            };
            TemplateTranslation t_3 = new()
            {
                Id = 3,
                Title = "<strong>|</strong> PREPARATION OF <strong>WEBSITES</strong>",
                Description = "The company itself is a very successful company. Having said this, let the older ones obtain it, let them seek to follow some less blinded, so that we may be able to enjoy pleasures. Gaining the actual training is bound to occur in the visible discomfort.",
                ServiceId = service_web.Id,
                LanguageId = en.Id
            };

            modelBuilder.Entity<Models.Path.Path>().HasData(path_web);
            modelBuilder.Entity<Service>().HasData(service_web);
            modelBuilder.Entity<Language>().HasData(am, ru, en);
            modelBuilder.Entity<TemplateTranslation>().HasData(t_1, t_2, t_3);
        }
    }
}
