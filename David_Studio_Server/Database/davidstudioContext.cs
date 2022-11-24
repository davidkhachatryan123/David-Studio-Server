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
            Models.Path.Path path_desktop = new() { Id = 2, Value = "desktop" };
            Models.Path.Path path_arduino = new() { Id = 3, Value = "arduino" };
            Models.Path.Path path_hosting = new() { Id = 4, Value = "hosting" };

            Service service_web = new() { Id = 1, ImgUrl = "uploads/images/web_dev.jpg", PathId = path_web.Id };
            Service service_desktop = new() { Id = 2, ImgUrl = "uploads/images/desktop_dev.jpg", PathId = path_desktop.Id };
            Service service_arduino = new() { Id = 3, ImgUrl = "uploads/images/arduino_dev.jpg", PathId = path_arduino.Id };
            Service service_hosting = new() { Id = 4, ImgUrl = "uploads/images/server_dev.jpg", PathId = path_hosting.Id };

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

            TemplateTranslation t_4 = new()
            {
                Id = 4,
                Title = "<strong>| Desktop</strong> Ծրագրերի Պատրաստում",
                Description = "Ընկերությունն ինքնին շատ հաջողակ ընկերություն է։ Այս ասելով, թող մեծերը ձեռք բերեն, թող ձգտեն ավելի քիչ կուրացած հետևել, որպեսզի մենք կարողանանք վայելել հաճույքները։ Իրական մարզվելը անպայման տեղի կունենա տեսանելի անհարմարության մեջ:",
                ServiceId = service_desktop.Id,
                LanguageId = am.Id
            };
            TemplateTranslation t_5 = new()
            {
                Id = 5,
                Title = "<strong>| Desktop</strong> Приложения",
                Description = "Сама компания очень успешная. Сказав это, пусть старшие приобретут это, пусть постараются следовать за менее слепыми, чтобы мы могли наслаждаться удовольствиями. Получение фактического обучения неизбежно будет сопровождаться видимым дискомфортом.",
                ServiceId = service_desktop.Id,
                LanguageId = ru.Id
            };
            TemplateTranslation t_6 = new()
            {
                Id = 6,
                Title = "<strong>| Desktop</strong> Programs Preparation",
                Description = "The company itself is a very successful company. Having said this, let the older ones obtain it, let them seek to follow some less blinded, so that we may be able to enjoy pleasures. Gaining the actual training is bound to occur in the visible discomfort.",
                ServiceId = service_desktop.Id,
                LanguageId = en.Id
            };

            TemplateTranslation t_7 = new()
            {
                Id = 7,
                Title = "<strong>| ARDUINO</strong> Սալիկների Ծրագրավորում",
                Description = "Ընկերությունն ինքնին շատ հաջողակ ընկերություն է։ Այս ասելով, թող մեծերը ձեռք բերեն, թող ձգտեն ավելի քիչ կուրացած հետևել, որպեսզի մենք կարողանանք վայելել հաճույքները։ Իրական մարզվելը անպայման տեղի կունենա տեսանելի անհարմարության մեջ:",
                ServiceId = service_arduino.Id,
                LanguageId = am.Id
            };
            TemplateTranslation t_8 = new()
            {
                Id = 8,
                Title = "<strong>| ARDUINO</strong> Программирование",
                Description = "Сама компания очень успешная. Сказав это, пусть старшие приобретут это, пусть постараются следовать за менее слепыми, чтобы мы могли наслаждаться удовольствиями. Получение фактического обучения неизбежно будет сопровождаться видимым дискомфортом.",
                ServiceId = service_arduino.Id,
                LanguageId = ru.Id
            };
            TemplateTranslation t_9 = new()
            {
                Id = 9,
                Title = "<strong>| ARDUINO</strong> Programming",
                Description = "The company itself is a very successful company. Having said this, let the older ones obtain it, let them seek to follow some less blinded, so that we may be able to enjoy pleasures. Gaining the actual training is bound to occur in the visible discomfort.",
                ServiceId = service_arduino.Id,
                LanguageId = en.Id
            };

            TemplateTranslation t_10 = new()
            {
                Id = 10,
                Title = "<strong>| HOSTING</strong> ԵՎ <strong>SERVER</strong>",
                Description = "Ընկերությունն ինքնին շատ հաջողակ ընկերություն է։ Այս ասելով, թող մեծերը ձեռք բերեն, թող ձգտեն ավելի քիչ կուրացած հետևել, որպեսզի մենք կարողանանք վայելել հաճույքները։ Իրական մարզվելը անպայման տեղի կունենա տեսանելի անհարմարության մեջ:",
                ServiceId = service_hosting.Id,
                LanguageId = am.Id
            };
            TemplateTranslation t_11 = new()
            {
                Id = 11,
                Title = "<strong>| HOSTING</strong> и <strong>SERVER</strong>",
                Description = "Сама компания очень успешная. Сказав это, пусть старшие приобретут это, пусть постараются следовать за менее слепыми, чтобы мы могли наслаждаться удовольствиями. Получение фактического обучения неизбежно будет сопровождаться видимым дискомфортом.",
                ServiceId = service_hosting.Id,
                LanguageId = ru.Id
            };
            TemplateTranslation t_12 = new()
            {
                Id = 12,
                Title = "<strong>| HOSTING</strong> and <strong>SERVER</strong>",
                Description = "The company itself is a very successful company. Having said this, let the older ones obtain it, let them seek to follow some less blinded, so that we may be able to enjoy pleasures. Gaining the actual training is bound to occur in the visible discomfort.",
                ServiceId = service_hosting.Id,
                LanguageId = en.Id
            };

            modelBuilder.Entity<Models.Path.Path>().HasData(path_web, path_desktop, path_arduino, path_hosting);
            modelBuilder.Entity<Service>().HasData(service_web, service_desktop, service_arduino, service_hosting);
            modelBuilder.Entity<Language>().HasData(am, ru, en);
            modelBuilder.Entity<TemplateTranslation>().HasData(t_1, t_2, t_3, t_4, t_5, t_6, t_7, t_8, t_9, t_10, t_11, t_12);
        }
    }
}
