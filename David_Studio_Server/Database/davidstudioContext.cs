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
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
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
        public virtual DbSet<Translation> Translations{ get; set; } = null!;

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("projects");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ImgLink)
                    .HasMaxLength(256)
                    .HasColumnName("img_link");

                entity.Property(e => e.Popularity).HasColumnName("popularity");

                entity.Property(e => e.Title)
                    .HasMaxLength(256)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<ProjectImage>(entity =>
            {
                entity.ToTable("project_images");

                entity.HasIndex(e => e.ProjectId, "project_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Url)
                    .HasMaxLength(256)
                    .HasColumnName("url");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("project_images_ibfk_1");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tags");

                entity.HasIndex(e => e.LongName, "long_name")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LongName)
                    .HasMaxLength(256)
                    .HasColumnName("long_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ProjectTag>(entity =>
            {
                entity.ToTable("projects_tags");

                entity.HasIndex(e => e.ProjectId, "project_id");

                entity.HasIndex(e => e.TagId, "tag_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("projects_tags_ibfk_1");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("projects_tags_ibfk_2");
            });


            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("services");

                entity.HasIndex(e => e.Title, "title")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasMaxLength(256)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<ServiceTag>(entity =>
            {
                entity.ToTable("services_tags");

                entity.HasIndex(e => e.ServiceId, "service_id");

                entity.HasIndex(e => e.TagId, "tag_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("services_tags_ibfk_1");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("services_tags_ibfk_2");
            });



            /*Project smarthome = new Project() { Id = 1, Title = "Smart Home", Popularity = Popularity.Nine };
            Project davidstudio = new Project() { Id = 2, Title = "David Studio", Popularity = Popularity.Ten };
            Project stedicube = new Project() { Id = 3, Title = "Steadicube", Popularity = Popularity.Five };
            Project ta = new Project() { Id = 4, Title = "Text Analyzer UBA", Popularity = Popularity.Two };

            Tag cs = new Tag() { Id = 1, Name = "C#" };
            Tag asp = new Tag() { Id = 2, Name = "ASP.NET", LongName = "ASP.NET Core" };
            Tag arduino = new Tag() { Id = 3, Name = "Arduino" };
            Tag wpf = new Tag() { Id = 4, Name = "WPF", LongName = "Windows Presentation Foundation" };
            Tag iot = new Tag() { Id = 5, Name = "IoT", LongName = "Internet of Things" };
            Tag pcb = new Tag() { Id = 6, Name = "PCB" };
            Tag mysql = new Tag() { Id = 7, Name = "MySQL" };
            Tag mssql = new Tag() { Id = 8, Name = "MSSQL" };
            Tag cpp = new Tag() { Id = 9, Name = "C++" };
            Tag bash = new Tag() { Id = 10, Name = "Bash", LongName = "Bash Script" };
            Tag js = new Tag() { Id = 11, Name = "JS", LongName = "JavaScript" };
            Tag ts = new Tag() { Id = 12, Name = "TS", LongName = "TypeScript" };
            Tag angular = new Tag() { Id = 12, Name = "Angular" };
            Tag jquery = new Tag() { Id = 13, Name = "JQuery" };
            Tag html = new Tag() { Id = 14, Name = "HTML" };
            Tag css = new Tag() { Id = 15, Name = "CSS" };
            Tag bootstrap = new Tag() { Id = 16, Name = "Bootstrap" };
            Tag ef = new Tag() { Id = 17, Name = "EF Core", LongName = "Entity Framework Core" };
            Tag winforms = new Tag() { Id = 18, Name = "Win Forms", LongName = "Windows Forms" };
            Tag dedicated = new Tag() { Id = 19, Name = "Dedicated", LongName = "Dedicated Hosting" };
            Tag cloud = new Tag() { Id = 20, Name = "Cloud", LongName = "Cloud Hosting" };

            ProjectTag pt_1 = new ProjectTag() { Id = 1, ProjectId = smarthome.Id, TagId = cs.Id };
            ProjectTag pt_2 = new ProjectTag() { Id = 2, ProjectId = smarthome.Id, TagId = arduino.Id };
            ProjectTag pt_3 = new ProjectTag() { Id = 3, ProjectId = smarthome.Id, TagId = wpf.Id };
            ProjectTag pt_4 = new ProjectTag() { Id = 4, ProjectId = smarthome.Id, TagId = iot.Id };
            ProjectTag pt_5 = new ProjectTag() { Id = 5, ProjectId = smarthome.Id, TagId = pcb.Id };
            ProjectTag pt_6 = new ProjectTag() { Id = 6, ProjectId = smarthome.Id, TagId = mysql.Id };

            Service front_end = new Service() { Id = 1, Title = "Front-End" };
            Service back_end = new Service() { Id = 2, Title = "Back-End" };

            ServiceTag st_1 = new ServiceTag() { Id = 1, ServiceId = front_end.Id, TagId = html.Id };
            ServiceTag st_2 = new ServiceTag() { Id = 2, ServiceId = front_end.Id, TagId = css.Id };
            ServiceTag st_3 = new ServiceTag() { Id = 3, ServiceId = front_end.Id, TagId = js.Id };
            ServiceTag st_4 = new ServiceTag() { Id = 4, ServiceId = front_end.Id, TagId = ts.Id };
            ServiceTag st_5 = new ServiceTag() { Id = 5, ServiceId = front_end.Id, TagId = angular.Id };
            ServiceTag st_6 = new ServiceTag() { Id = 6, ServiceId = front_end.Id, TagId = bootstrap.Id };

            ServiceTag st_7 = new ServiceTag() { Id = 7, ServiceId = back_end.Id, TagId = asp.Id };
            ServiceTag st_8 = new ServiceTag() { Id = 8, ServiceId = back_end.Id, TagId = ef.Id };
            ServiceTag st_9 = new ServiceTag() { Id = 9, ServiceId = back_end.Id, TagId = mssql.Id };
            ServiceTag st_10 = new ServiceTag() { Id = 10, ServiceId = back_end.Id, TagId = mysql.Id };


            modelBuilder.Entity<Project>().HasData(smarthome, davidstudio, stedicube, ta);
            modelBuilder.Entity<Tag>().HasData(cs, asp, arduino, wpf, iot, pcb, mysql, mssql, cpp, bash, js, ts, jquery,
                html, css, bootstrap, ef, winforms, dedicated, cloud);
            modelBuilder.Entity<ProjectTag>().HasData(pt_1, pt_2, pt_3, pt_4, pt_5, pt_6);

            modelBuilder.Entity<Service>().HasData(front_end, back_end);
            modelBuilder.Entity<ServiceTag>().HasData(st_1, st_2, st_3, st_4, st_5, st_6, st_7, st_8, st_9, st_10);


            OnModelCreatingPartial(modelBuilder);
        }*/

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
