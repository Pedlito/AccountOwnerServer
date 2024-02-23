﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AccountOwnerServer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240223001149_Users")]
    partial class Users
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Account", b =>
                {
                    b.Property<short>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("code");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Code"));

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("account_type");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp(0)")
                        .HasColumnName("create_date");

                    b.Property<short>("CreateUser")
                        .HasColumnType("smallint")
                        .HasColumnName("create_user");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("timestamp(0)")
                        .HasColumnName("delete_date");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bool")
                        .HasColumnName("is_enable");

                    b.Property<short>("OwnerCode")
                        .HasColumnType("smallint")
                        .HasColumnName("owner_code");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp(0)")
                        .HasColumnName("update_date");

                    b.Property<short?>("UpdateUser")
                        .HasColumnType("smallint")
                        .HasColumnName("update_user");

                    b.HasKey("Code");

                    b.HasIndex("OwnerCode");

                    b.ToTable("acount", "owner_acount");
                });

            modelBuilder.Entity("Entities.Models.Owner", b =>
                {
                    b.Property<short>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("code");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Code"));

                    b.Property<string>("Address")
                        .HasColumnType("varchar(150)")
                        .HasColumnName("address");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp(0)")
                        .HasColumnName("create_date");

                    b.Property<short>("CreateUser")
                        .HasColumnType("smallint")
                        .HasColumnName("create_user");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("timestamp(0)")
                        .HasColumnName("delete_date");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bool")
                        .HasColumnName("is_enable");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp(0)")
                        .HasColumnName("update_date");

                    b.Property<short?>("UpdateUser")
                        .HasColumnType("smallint")
                        .HasColumnName("update_user");

                    b.HasKey("Code");

                    b.ToTable("owner", "owner_acount");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<short>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("code");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Code"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp(0)")
                        .HasColumnName("create_date");

                    b.Property<short>("CreateUser")
                        .HasColumnType("smallint")
                        .HasColumnName("create_user");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("timestamp(0)")
                        .HasColumnName("delete_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bool")
                        .HasColumnName("is_enable");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp(0)")
                        .HasColumnName("update_date");

                    b.Property<short?>("UpdateUser")
                        .HasColumnType("smallint")
                        .HasColumnName("update_user");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Code");

                    b.ToTable("user", "authentication");
                });

            modelBuilder.Entity("Entities.Models.Account", b =>
                {
                    b.HasOne("Entities.Models.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Entities.Models.Owner", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}