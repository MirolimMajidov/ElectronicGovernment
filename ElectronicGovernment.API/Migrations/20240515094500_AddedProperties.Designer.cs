﻿// <auto-generated />
using System;
using BankManagementSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElectronicGovernment.API.Migrations
{
    [DbContext(typeof(EGContext))]
    [Migration("20240515094500_AddedProperties")]
    partial class AddedProperties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ElectronicGovernment.API.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOnlyForWorkFlow")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LeaderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("OperatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LeaderId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.HasIndex("OperatorId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("47d1d38f-bd46-4f28-9ef2-4e1e3ce957fd"),
                            IsOnlyForWorkFlow = false,
                            LeaderId = new Guid("842bcc55-d686-43c5-a7c6-6371e6a8bdbe"),
                            Name = "Department 1",
                            OperatorId = new Guid("1cb7f75b-1cd7-481f-99cf-0a17b5ba7b44"),
                            OrganizationId = new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c")
                        },
                        new
                        {
                            Id = new Guid("72091839-9349-4b98-a466-5b0fcd3ee286"),
                            IsOnlyForWorkFlow = false,
                            LeaderId = new Guid("446e2d90-95c8-4767-93a8-a0621de33437"),
                            Name = "Department 2",
                            OperatorId = new Guid("94bdfabe-e24f-4930-8d19-4c2c2c1cdfbb"),
                            OrganizationId = new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c")
                        });
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Attachments")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Attachments");

                    b.Property<string>("AttachmentsJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("TemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.DocumentTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("DocumentTemplates");
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CEOId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OperatorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CEOId");

                    b.HasIndex("OperatorId");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c"),
                            Description = "To automate all departments of the Government",
                            Name = "Electronic Government"
                        });
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoleType")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "RoleType")
                        .IsUnique();

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fdfc185c-baf7-4a85-a575-e0affe03a371"),
                            RoleType = 1,
                            UserId = new Guid("0d0c461a-6364-4fd6-ad98-97a8135f4d88")
                        },
                        new
                        {
                            Id = new Guid("22b5a2f2-3a87-44b9-a265-d08a8f3bea4f"),
                            RoleType = 2,
                            UserId = new Guid("d0609810-1a2b-4630-8f53-282f690de8d5")
                        },
                        new
                        {
                            Id = new Guid("6767a841-1677-4946-ac50-98badab9e1d0"),
                            RoleType = 3,
                            UserId = new Guid("d0609810-1a2b-4630-8f53-282f690de8d5")
                        },
                        new
                        {
                            Id = new Guid("dec1ce28-d169-4095-903c-3dd5b5e68f62"),
                            RoleType = 4,
                            UserId = new Guid("27e1062d-397c-4030-8de3-b3f4d6464c4f")
                        },
                        new
                        {
                            Id = new Guid("380a0bad-960d-40c8-818c-1963734dc0c6"),
                            RoleType = 3,
                            UserId = new Guid("842bcc55-d686-43c5-a7c6-6371e6a8bdbe")
                        },
                        new
                        {
                            Id = new Guid("3f5a1278-44d5-42ea-8287-9b0987137f6a"),
                            RoleType = 3,
                            UserId = new Guid("446e2d90-95c8-4767-93a8-a0621de33437")
                        },
                        new
                        {
                            Id = new Guid("7baec578-67ba-4dc5-9c78-ba5941ddb1d7"),
                            RoleType = 5,
                            UserId = new Guid("1cb7f75b-1cd7-481f-99cf-0a17b5ba7b44")
                        },
                        new
                        {
                            Id = new Guid("f9e63a94-4679-484f-92b5-a6e0cbd53ef3"),
                            RoleType = 5,
                            UserId = new Guid("94bdfabe-e24f-4930-8d19-4c2c2c1cdfbb")
                        });
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.Citizen", b =>
                {
                    b.HasBaseType("ElectronicGovernment.API.Models.User");

                    b.HasDiscriminator().HasValue("Citizen");
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.Employee", b =>
                {
                    b.HasBaseType("ElectronicGovernment.API.Models.User");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("OrganizationId");

                    b.HasDiscriminator().HasValue("Employee");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0d0c461a-6364-4fd6-ad98-97a8135f4d88"),
                            FirstName = "Admin",
                            Password = "Admin",
                            Username = "Admin",
                            OrganizationId = new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c")
                        },
                        new
                        {
                            Id = new Guid("d0609810-1a2b-4630-8f53-282f690de8d5"),
                            FirstName = "CEO",
                            LastName = "Organization",
                            Password = "Organization",
                            Username = "CEO",
                            OrganizationId = new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c")
                        },
                        new
                        {
                            Id = new Guid("27e1062d-397c-4030-8de3-b3f4d6464c4f"),
                            FirstName = "Global",
                            LastName = "Operator",
                            Password = "Operator",
                            Username = "GlobalOperator",
                            OrganizationId = new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c")
                        },
                        new
                        {
                            Id = new Guid("842bcc55-d686-43c5-a7c6-6371e6a8bdbe"),
                            FirstName = "Leader",
                            LastName = "Department1",
                            Password = "Dep1",
                            Username = "LeadDep1",
                            OrganizationId = new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c")
                        },
                        new
                        {
                            Id = new Guid("446e2d90-95c8-4767-93a8-a0621de33437"),
                            FirstName = "Leader",
                            LastName = "Department2",
                            Password = "Dep2",
                            Username = "LeadDep2",
                            OrganizationId = new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c")
                        },
                        new
                        {
                            Id = new Guid("1cb7f75b-1cd7-481f-99cf-0a17b5ba7b44"),
                            FirstName = "Operator",
                            LastName = "Department1",
                            Password = "Dep1",
                            Username = "OpeDep1",
                            OrganizationId = new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c")
                        },
                        new
                        {
                            Id = new Guid("94bdfabe-e24f-4930-8d19-4c2c2c1cdfbb"),
                            FirstName = "Leader",
                            LastName = "Department2",
                            Password = "Dep2",
                            Username = "OpeDep2",
                            OrganizationId = new Guid("2a720891-3e68-4538-bf8f-51b6b5c2067c")
                        });
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.Department", b =>
                {
                    b.HasOne("ElectronicGovernment.API.Models.Employee", "Leader")
                        .WithMany()
                        .HasForeignKey("LeaderId");

                    b.HasOne("ElectronicGovernment.API.Models.Employee", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorId");

                    b.HasOne("ElectronicGovernment.API.Models.Organization", "Organization")
                        .WithMany("Departments")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Leader");

                    b.Navigation("Operator");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.Document", b =>
                {
                    b.HasOne("ElectronicGovernment.API.Models.DocumentTemplate", "Template")
                        .WithMany("Documents")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.DocumentTemplate", b =>
                {
                    b.HasOne("ElectronicGovernment.API.Models.Department", "Department")
                        .WithMany("DocumentTemplates")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.Organization", b =>
                {
                    b.HasOne("ElectronicGovernment.API.Models.Employee", "CEO")
                        .WithMany()
                        .HasForeignKey("CEOId");

                    b.HasOne("ElectronicGovernment.API.Models.Employee", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorId");

                    b.Navigation("CEO");

                    b.Navigation("Operator");
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.UserRole", b =>
                {
                    b.HasOne("ElectronicGovernment.API.Models.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.Employee", b =>
                {
                    b.HasOne("ElectronicGovernment.API.Models.Organization", "Organization")
                        .WithMany("Employees")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.Department", b =>
                {
                    b.Navigation("DocumentTemplates");
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.DocumentTemplate", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.Organization", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.User", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}