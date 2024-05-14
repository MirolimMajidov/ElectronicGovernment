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
    [Migration("20240514123157_DBCreated")]
    partial class DBCreated
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

                    b.Property<Guid>("LeaderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("OperatorId")
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
                            Id = new Guid("6e3e79b6-bb5c-4b7d-a2ce-80e351142022"),
                            LeaderId = new Guid("8550b9c5-7e5a-4231-912c-fcf476250c4c"),
                            Name = "Department 1",
                            OperatorId = new Guid("56a949e0-0ab1-42be-9b57-683251029674"),
                            OrganizationId = new Guid("c5bdf0ae-7048-4c5b-aca4-6decb3376569")
                        },
                        new
                        {
                            Id = new Guid("29135890-b943-4d74-bc02-57eb7bb2eb94"),
                            LeaderId = new Guid("bd609e39-781a-457b-a435-3e7418d29a00"),
                            Name = "Department 2",
                            OperatorId = new Guid("b06e4468-5f47-48a2-8784-fb290addf90f"),
                            OrganizationId = new Guid("c5bdf0ae-7048-4c5b-aca4-6decb3376569")
                        });
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                            Id = new Guid("c5bdf0ae-7048-4c5b-aca4-6decb3376569"),
                            Description = "To automate all departments of the Government",
                            Name = "Electronic Government"
                        });
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a5225c4b-c1e8-4587-b50a-af2eecb311b8"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("57475bdd-a271-48d7-b321-cfc7e8df7de1"),
                            Name = "CEO"
                        },
                        new
                        {
                            Id = new Guid("7ab8c60d-06f9-46c7-ac36-ae471b0a8fae"),
                            Name = "Lead"
                        },
                        new
                        {
                            Id = new Guid("a352e5ce-0d34-447b-8b3b-cfe5e00b5a2d"),
                            Name = "Global Operator"
                        },
                        new
                        {
                            Id = new Guid("6eb85f88-a22c-4fec-a3e6-782909ae8e7d"),
                            Name = "Operator"
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

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId", "RoleId")
                        .IsUnique();

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("55f656c5-623d-4ecf-948a-27481898b8b8"),
                            RoleId = new Guid("a5225c4b-c1e8-4587-b50a-af2eecb311b8"),
                            UserId = new Guid("bee61038-a334-498b-9764-454fc897d3e2")
                        },
                        new
                        {
                            Id = new Guid("3b78c21b-c2e2-482f-a007-316be434d534"),
                            RoleId = new Guid("57475bdd-a271-48d7-b321-cfc7e8df7de1"),
                            UserId = new Guid("c25675bc-c4c9-4035-8b79-8afa3827a09f")
                        },
                        new
                        {
                            Id = new Guid("01c95a6e-3521-4fb1-a142-c7a4041aade3"),
                            RoleId = new Guid("a352e5ce-0d34-447b-8b3b-cfe5e00b5a2d"),
                            UserId = new Guid("82b0162c-fc08-4deb-acca-1d4bcc54e8f5")
                        },
                        new
                        {
                            Id = new Guid("5da1071d-0e65-46d8-908e-fd5f04740193"),
                            RoleId = new Guid("7ab8c60d-06f9-46c7-ac36-ae471b0a8fae"),
                            UserId = new Guid("8550b9c5-7e5a-4231-912c-fcf476250c4c")
                        },
                        new
                        {
                            Id = new Guid("5ee17867-ad8d-4828-b333-1246f6df7d01"),
                            RoleId = new Guid("7ab8c60d-06f9-46c7-ac36-ae471b0a8fae"),
                            UserId = new Guid("bd609e39-781a-457b-a435-3e7418d29a00")
                        },
                        new
                        {
                            Id = new Guid("5b27979d-b27d-4484-8542-5a3e0208c216"),
                            RoleId = new Guid("6eb85f88-a22c-4fec-a3e6-782909ae8e7d"),
                            UserId = new Guid("56a949e0-0ab1-42be-9b57-683251029674")
                        },
                        new
                        {
                            Id = new Guid("678be932-6823-4ed6-8c6e-b28f2c6b90ec"),
                            RoleId = new Guid("6eb85f88-a22c-4fec-a3e6-782909ae8e7d"),
                            UserId = new Guid("b06e4468-5f47-48a2-8784-fb290addf90f")
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

                    b.HasDiscriminator().HasValue("Employee");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bee61038-a334-498b-9764-454fc897d3e2"),
                            FirstName = "Admin",
                            Password = "Admin",
                            Username = "Admin"
                        },
                        new
                        {
                            Id = new Guid("c25675bc-c4c9-4035-8b79-8afa3827a09f"),
                            FirstName = "CEO",
                            LastName = "Organization",
                            Password = "Organization",
                            Username = "CEO"
                        },
                        new
                        {
                            Id = new Guid("82b0162c-fc08-4deb-acca-1d4bcc54e8f5"),
                            FirstName = "Global",
                            LastName = "Operator",
                            Password = "Operator",
                            Username = "GlobalOperator"
                        },
                        new
                        {
                            Id = new Guid("8550b9c5-7e5a-4231-912c-fcf476250c4c"),
                            FirstName = "Leader",
                            LastName = "Department1",
                            Password = "Dep1",
                            Username = "LeadDep1"
                        },
                        new
                        {
                            Id = new Guid("bd609e39-781a-457b-a435-3e7418d29a00"),
                            FirstName = "Leader",
                            LastName = "Department2",
                            Password = "Dep2",
                            Username = "LeadDep2"
                        },
                        new
                        {
                            Id = new Guid("56a949e0-0ab1-42be-9b57-683251029674"),
                            FirstName = "Operator",
                            LastName = "Department1",
                            Password = "Dep1",
                            Username = "OpeDep1"
                        },
                        new
                        {
                            Id = new Guid("b06e4468-5f47-48a2-8784-fb290addf90f"),
                            FirstName = "Leader",
                            LastName = "Department2",
                            Password = "Dep2",
                            Username = "OpeDep2"
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
                    b.HasOne("ElectronicGovernment.API.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicGovernment.API.Models.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
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
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ElectronicGovernment.API.Models.User", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
