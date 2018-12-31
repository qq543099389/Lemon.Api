﻿// <auto-generated />
using System;
using Lemon.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lemon.API.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    partial class CoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Lemon.API.Models.BlogModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlogImgUri");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Createtime");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.ToTable("BlogModel");
                });

            modelBuilder.Entity("Lemon.API.Models.ReplyModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Createtime");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.ToTable("ReplyModel");
                });

            modelBuilder.Entity("Lemon.API.Models.RoleModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("roleType");

                    b.HasKey("ID");

                    b.ToTable("RoleModel");
                });

            modelBuilder.Entity("Lemon.API.Models.UserModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Createtime");

                    b.Property<DateTime>("LastLoginTime");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("RoleId");

                    b.Property<string>("UserHeadImageUri");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("RoleId");

                    b.ToTable("userModels");
                });

            modelBuilder.Entity("Lemon.API.Models.UserModel", b =>
                {
                    b.HasOne("Lemon.API.Models.RoleModel", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}