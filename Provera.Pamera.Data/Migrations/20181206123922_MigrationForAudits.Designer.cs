﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Provera.Pamera.Data.Concrete;

namespace Provera.Pamera.Data.Migrations
{
    [DbContext(typeof(PameraContext))]
    [Migration("20181206123922_MigrationForAudits")]
    partial class MigrationForAudits
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Provera.Pamera.Model.Concrete.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Memo");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Provera.Pamera.Model.Helpers.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("KeyValues");

                    b.Property<string>("NewValues");

                    b.Property<string>("OldValues");

                    b.Property<string>("TableName");

                    b.HasKey("Id");

                    b.ToTable("Audits");
                });
#pragma warning restore 612, 618
        }
    }
}
