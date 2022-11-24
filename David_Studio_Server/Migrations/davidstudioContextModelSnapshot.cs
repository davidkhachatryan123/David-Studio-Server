﻿// <auto-generated />
using System;
using David_Studio_Server.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace David_Studio_Server.Migrations
{
    [DbContext(typeof(davidstudioContext))]
    partial class davidstudioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb3_general_ci")
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb3");

            modelBuilder.Entity("David_Studio_Server.Database.Models.Contact.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("VARCHAR(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR(64)");

                    b.HasKey("Id");

                    b.ToTable("Contacts", (string)null);
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Path.Jumbotron", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PathId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PathId");

                    b.ToTable("Jumbotrons");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Path.Path", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.HasKey("Id");

                    b.ToTable("Paths", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Value = "web"
                        },
                        new
                        {
                            Id = 2,
                            Value = "desktop"
                        },
                        new
                        {
                            Id = 3,
                            Value = "arduino"
                        },
                        new
                        {
                            Id = 4,
                            Value = "hosting"
                        });
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Project.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("ImgUrl")
                        .HasMaxLength(2083)
                        .HasColumnType("VARCHAR(2083)");

                    b.Property<int>("PathId")
                        .HasColumnType("int");

                    b.Property<int>("Popularity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR(64)");

                    b.HasKey("Id");

                    b.HasIndex("PathId");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Project.ProjectImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(2083)
                        .HasColumnType("VARCHAR(2083)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectImages", (string)null);
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Project.ProjectTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TagId");

                    b.ToTable("ProjectsTags");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Project.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("LongName")
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR(64)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("VARCHAR(16)");

                    b.HasKey("Id");

                    b.ToTable("Tags", (string)null);
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Service.Circle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CircleBlockId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CircleBlockId");

                    b.HasIndex("TagId");

                    b.ToTable("Circles");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Service.CircleBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR(64)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("CircleBlocks", (string)null);
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Service.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasMaxLength(2083)
                        .HasColumnType("VARCHAR(2083)");

                    b.Property<int>("PathId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PathId");

                    b.ToTable("Services", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImgUrl = "uploads/images/web_dev.jpg",
                            PathId = 1
                        },
                        new
                        {
                            Id = 2,
                            ImgUrl = "uploads/images/desktop_dev.jpg",
                            PathId = 2
                        },
                        new
                        {
                            Id = 3,
                            ImgUrl = "uploads/images/arduino_dev.jpg",
                            PathId = 3
                        },
                        new
                        {
                            Id = 4,
                            ImgUrl = "uploads/images/server_dev.jpg",
                            PathId = 4
                        });
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Translation.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Culture")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Culture = "hy-AM",
                            Name = "Armenian"
                        },
                        new
                        {
                            Id = 2,
                            Culture = "ru-RU",
                            Name = "Russian"
                        },
                        new
                        {
                            Id = 3,
                            Culture = "en-US",
                            Name = "English (US)"
                        });
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Translation.TemplateTranslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR(256)");

                    b.Property<int?>("JumbotronId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR(64)");

                    b.HasKey("Id");

                    b.HasIndex("JumbotronId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ServiceId");

                    b.ToTable("TemplateTranslations", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Ընկերությունն ինքնին շատ հաջողակ ընկերություն է։ Այս ասելով, թող մեծերը ձեռք բերեն, թող ձգտեն ավելի քիչ կուրացած հետևել, որպեսզի մենք կարողանանք վայելել հաճույքները։ Իրական մարզվելը անպայման տեղի կունենա տեսանելի անհարմարության մեջ:",
                            LanguageId = 1,
                            ServiceId = 1,
                            Title = "<strong>| WEB</strong> Կայքերի պատրաստում"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Сама компания очень успешная. Сказав это, пусть старшие приобретут это, пусть постараются следовать за менее слепыми, чтобы мы могли наслаждаться удовольствиями. Получение фактического обучения неизбежно будет сопровождаться видимым дискомфортом.",
                            LanguageId = 2,
                            ServiceId = 1,
                            Title = "<strong>|</strong> ПОДГОТОВКА <strong>Веб</strong> САЙТОВ"
                        },
                        new
                        {
                            Id = 3,
                            Description = "The company itself is a very successful company. Having said this, let the older ones obtain it, let them seek to follow some less blinded, so that we may be able to enjoy pleasures. Gaining the actual training is bound to occur in the visible discomfort.",
                            LanguageId = 3,
                            ServiceId = 1,
                            Title = "<strong>|</strong> PREPARATION OF <strong>WEBSITES</strong>"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Ընկերությունն ինքնին շատ հաջողակ ընկերություն է։ Այս ասելով, թող մեծերը ձեռք բերեն, թող ձգտեն ավելի քիչ կուրացած հետևել, որպեսզի մենք կարողանանք վայելել հաճույքները։ Իրական մարզվելը անպայման տեղի կունենա տեսանելի անհարմարության մեջ:",
                            LanguageId = 1,
                            ServiceId = 2,
                            Title = "<strong>| Desktop</strong> Ծրագրերի Պատրաստում"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Сама компания очень успешная. Сказав это, пусть старшие приобретут это, пусть постараются следовать за менее слепыми, чтобы мы могли наслаждаться удовольствиями. Получение фактического обучения неизбежно будет сопровождаться видимым дискомфортом.",
                            LanguageId = 2,
                            ServiceId = 2,
                            Title = "<strong>| Desktop</strong> Приложения"
                        },
                        new
                        {
                            Id = 6,
                            Description = "The company itself is a very successful company. Having said this, let the older ones obtain it, let them seek to follow some less blinded, so that we may be able to enjoy pleasures. Gaining the actual training is bound to occur in the visible discomfort.",
                            LanguageId = 3,
                            ServiceId = 2,
                            Title = "<strong>| Desktop</strong> Programs Preparation"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Ընկերությունն ինքնին շատ հաջողակ ընկերություն է։ Այս ասելով, թող մեծերը ձեռք բերեն, թող ձգտեն ավելի քիչ կուրացած հետևել, որպեսզի մենք կարողանանք վայելել հաճույքները։ Իրական մարզվելը անպայման տեղի կունենա տեսանելի անհարմարության մեջ:",
                            LanguageId = 1,
                            ServiceId = 3,
                            Title = "<strong>| ARDUINO</strong> Սալիկների Ծրագրավորում"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Сама компания очень успешная. Сказав это, пусть старшие приобретут это, пусть постараются следовать за менее слепыми, чтобы мы могли наслаждаться удовольствиями. Получение фактического обучения неизбежно будет сопровождаться видимым дискомфортом.",
                            LanguageId = 2,
                            ServiceId = 3,
                            Title = "<strong>| ARDUINO</strong> Программирование"
                        },
                        new
                        {
                            Id = 9,
                            Description = "The company itself is a very successful company. Having said this, let the older ones obtain it, let them seek to follow some less blinded, so that we may be able to enjoy pleasures. Gaining the actual training is bound to occur in the visible discomfort.",
                            LanguageId = 3,
                            ServiceId = 3,
                            Title = "<strong>| ARDUINO</strong> Programming"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Ընկերությունն ինքնին շատ հաջողակ ընկերություն է։ Այս ասելով, թող մեծերը ձեռք բերեն, թող ձգտեն ավելի քիչ կուրացած հետևել, որպեսզի մենք կարողանանք վայելել հաճույքները։ Իրական մարզվելը անպայման տեղի կունենա տեսանելի անհարմարության մեջ:",
                            LanguageId = 1,
                            ServiceId = 4,
                            Title = "<strong>| HOSTING</strong> ԵՎ <strong>SERVER</strong>"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Сама компания очень успешная. Сказав это, пусть старшие приобретут это, пусть постараются следовать за менее слепыми, чтобы мы могли наслаждаться удовольствиями. Получение фактического обучения неизбежно будет сопровождаться видимым дискомфортом.",
                            LanguageId = 2,
                            ServiceId = 4,
                            Title = "<strong>| HOSTING</strong> и <strong>SERVER</strong>"
                        },
                        new
                        {
                            Id = 12,
                            Description = "The company itself is a very successful company. Having said this, let the older ones obtain it, let them seek to follow some less blinded, so that we may be able to enjoy pleasures. Gaining the actual training is bound to occur in the visible discomfort.",
                            LanguageId = 3,
                            ServiceId = 4,
                            Title = "<strong>| HOSTING</strong> and <strong>SERVER</strong>"
                        });
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Path.Jumbotron", b =>
                {
                    b.HasOne("David_Studio_Server.Database.Models.Path.Path", "Path")
                        .WithMany("Jumbotrons")
                        .HasForeignKey("PathId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Path");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Project.Project", b =>
                {
                    b.HasOne("David_Studio_Server.Database.Models.Path.Path", "Path")
                        .WithMany("Projects")
                        .HasForeignKey("PathId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Path");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Project.ProjectImage", b =>
                {
                    b.HasOne("David_Studio_Server.Database.Models.Project.Project", "Project")
                        .WithMany("Images")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Project.ProjectTag", b =>
                {
                    b.HasOne("David_Studio_Server.Database.Models.Project.Project", "Project")
                        .WithMany("Tags")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("David_Studio_Server.Database.Models.Project.Tag", "Tag")
                        .WithMany("Projects")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Service.Circle", b =>
                {
                    b.HasOne("David_Studio_Server.Database.Models.Service.CircleBlock", "CircleBlock")
                        .WithMany("Circles")
                        .HasForeignKey("CircleBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("David_Studio_Server.Database.Models.Project.Tag", null)
                        .WithMany("Circles")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CircleBlock");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Service.CircleBlock", b =>
                {
                    b.HasOne("David_Studio_Server.Database.Models.Service.Service", "Service")
                        .WithMany("CircleBlocks")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Service.Service", b =>
                {
                    b.HasOne("David_Studio_Server.Database.Models.Path.Path", "Path")
                        .WithMany("Services")
                        .HasForeignKey("PathId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Path");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Translation.TemplateTranslation", b =>
                {
                    b.HasOne("David_Studio_Server.Database.Models.Path.Jumbotron", "Jumbotron")
                        .WithMany("Translations")
                        .HasForeignKey("JumbotronId");

                    b.HasOne("David_Studio_Server.Database.Models.Translation.Language", "Language")
                        .WithMany("TemplateTranslations")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("David_Studio_Server.Database.Models.Service.Service", "Service")
                        .WithMany("Translations")
                        .HasForeignKey("ServiceId");

                    b.Navigation("Jumbotron");

                    b.Navigation("Language");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Path.Jumbotron", b =>
                {
                    b.Navigation("Translations");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Path.Path", b =>
                {
                    b.Navigation("Jumbotrons");

                    b.Navigation("Projects");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Project.Project", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Project.Tag", b =>
                {
                    b.Navigation("Circles");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Service.CircleBlock", b =>
                {
                    b.Navigation("Circles");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Service.Service", b =>
                {
                    b.Navigation("CircleBlocks");

                    b.Navigation("Translations");
                });

            modelBuilder.Entity("David_Studio_Server.Database.Models.Translation.Language", b =>
                {
                    b.Navigation("TemplateTranslations");
                });
#pragma warning restore 612, 618
        }
    }
}
