﻿// <auto-generated />
using System;
using DiplomCovid19.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiplomCovid19.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    partial class EmployeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DiplomCovid19.Models.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FIO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<int?>("RankId")
                        .HasColumnType("int");

                    b.Property<int?>("SubdivisionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("RankId");

                    b.HasIndex("SubdivisionId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            FIO = "Гурко Павел Михайлович",
                            PositionId = 8,
                            RankId = 9,
                            SubdivisionId = 2
                        },
                        new
                        {
                            Id = 2L,
                            FIO = "Левенко Евгений Юрьевич",
                            PositionId = 10,
                            RankId = 10,
                            SubdivisionId = 2
                        },
                        new
                        {
                            Id = 3L,
                            FIO = "Гуркский Вадим Михайлович",
                            PositionId = 10,
                            RankId = 10,
                            SubdivisionId = 2
                        },
                        new
                        {
                            Id = 4L,
                            FIO = "Гейц Людмила Николаевна",
                            PositionId = 11,
                            RankId = 8,
                            SubdivisionId = 1
                        },
                        new
                        {
                            Id = 5L,
                            FIO = "Костян Елена Григорьевна",
                            PositionId = 11,
                            RankId = 8,
                            SubdivisionId = 1
                        },
                        new
                        {
                            Id = 6L,
                            FIO = "Бедункевич Марина Александровна",
                            PositionId = 12,
                            RankId = 10,
                            SubdivisionId = 1
                        },
                        new
                        {
                            Id = 7L,
                            FIO = "Райкова Екатерина Александровна",
                            PositionId = 10,
                            RankId = 10,
                            SubdivisionId = 3
                        });
                });

            modelBuilder.Entity("DiplomCovid19.Models.EmployeeVaccineJunction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateFirstComponent")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateSecondComponent")
                        .HasColumnType("datetime2");

                    b.Property<long?>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<int?>("VaccineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VaccineId");

                    b.ToTable("EmployeeVaccineJunctions");
                });

            modelBuilder.Entity("DiplomCovid19.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PositionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PositionName = "начальник академии"
                        },
                        new
                        {
                            Id = 2,
                            PositionName = "заместитель начальника академии"
                        },
                        new
                        {
                            Id = 3,
                            PositionName = "начальник курса"
                        },
                        new
                        {
                            Id = 4,
                            PositionName = "заместитель начальника курса"
                        },
                        new
                        {
                            Id = 5,
                            PositionName = "начальник кафедры"
                        },
                        new
                        {
                            Id = 6,
                            PositionName = "заместитель начальника кафедры"
                        },
                        new
                        {
                            Id = 7,
                            PositionName = "преподаватель"
                        },
                        new
                        {
                            Id = 8,
                            PositionName = "преподаватель-методист"
                        },
                        new
                        {
                            Id = 9,
                            PositionName = "старший преподаватель"
                        },
                        new
                        {
                            Id = 10,
                            PositionName = "старший преподаватель-методист"
                        },
                        new
                        {
                            Id = 11,
                            PositionName = "старший инспектор"
                        },
                        new
                        {
                            Id = 12,
                            PositionName = "старший инспектор по особым поручениям"
                        },
                        new
                        {
                            Id = 13,
                            PositionName = "доцент"
                        },
                        new
                        {
                            Id = 14,
                            PositionName = "профессор"
                        },
                        new
                        {
                            Id = 15,
                            PositionName = "курсант"
                        });
                });

            modelBuilder.Entity("DiplomCovid19.Models.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RankName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ranks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RankName = "рядовой милиции"
                        },
                        new
                        {
                            Id = 2,
                            RankName = "младший сержант милиции"
                        },
                        new
                        {
                            Id = 3,
                            RankName = "сержант милиции"
                        },
                        new
                        {
                            Id = 4,
                            RankName = "старший сержант милиции"
                        },
                        new
                        {
                            Id = 5,
                            RankName = "старшина милиции"
                        },
                        new
                        {
                            Id = 6,
                            RankName = "лейтенант милиции"
                        },
                        new
                        {
                            Id = 7,
                            RankName = "старший лейтенант милиции"
                        },
                        new
                        {
                            Id = 8,
                            RankName = "капитан милиции"
                        },
                        new
                        {
                            Id = 9,
                            RankName = "майор милиции"
                        },
                        new
                        {
                            Id = 10,
                            RankName = "подполковник милиции"
                        },
                        new
                        {
                            Id = 11,
                            RankName = "полковник милиции"
                        });
                });

            modelBuilder.Entity("DiplomCovid19.Models.Subdivision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubdivisionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subdivisions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SubdivisionName = "отдел кадров"
                        },
                        new
                        {
                            Id = 2,
                            SubdivisionName = "отдел образовательных информационных технологий"
                        },
                        new
                        {
                            Id = 3,
                            SubdivisionName = "учебно-методическое управление"
                        });
                });

            modelBuilder.Entity("DiplomCovid19.Models.Vaccine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VaccineName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vaccine");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            VaccineName = "Спутник V - Росия"
                        },
                        new
                        {
                            Id = 2,
                            VaccineName = "SARS-CoV-2 - Китай"
                        },
                        new
                        {
                            Id = 3,
                            VaccineName = "Спутник Лайт - Росия"
                        });
                });

            modelBuilder.Entity("DiplomCovid19.Models.Employee", b =>
                {
                    b.HasOne("DiplomCovid19.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.HasOne("DiplomCovid19.Models.Rank", "Rank")
                        .WithMany()
                        .HasForeignKey("RankId");

                    b.HasOne("DiplomCovid19.Models.Subdivision", "Subdivision")
                        .WithMany("Employees")
                        .HasForeignKey("SubdivisionId");

                    b.Navigation("Position");

                    b.Navigation("Rank");

                    b.Navigation("Subdivision");
                });

            modelBuilder.Entity("DiplomCovid19.Models.EmployeeVaccineJunction", b =>
                {
                    b.HasOne("DiplomCovid19.Models.Employee", "Employee")
                        .WithMany("EmployeeVaccines")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomCovid19.Models.Vaccine", "Vaccine")
                        .WithMany("EmployeeVaccines")
                        .HasForeignKey("VaccineId");

                    b.Navigation("Employee");

                    b.Navigation("Vaccine");
                });

            modelBuilder.Entity("DiplomCovid19.Models.Employee", b =>
                {
                    b.Navigation("EmployeeVaccines");
                });

            modelBuilder.Entity("DiplomCovid19.Models.Subdivision", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("DiplomCovid19.Models.Vaccine", b =>
                {
                    b.Navigation("EmployeeVaccines");
                });
#pragma warning restore 612, 618
        }
    }
}
