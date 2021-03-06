﻿// <auto-generated />
using GateKeeper.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace GateKeeper.Data.Migrations
{
    [DbContext(typeof(GateKeeperDbContext))]
    partial class GateKeeperDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("GateKeeper.Domain.Entities.Resident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apartment");

                    b.Property<string>("Block");

                    b.Property<string>("Cpf");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Residents");
                });
#pragma warning restore 612, 618
        }
    }
}
