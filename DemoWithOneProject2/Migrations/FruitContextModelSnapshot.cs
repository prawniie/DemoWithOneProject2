﻿// <auto-generated />
using System;
using DemoWithOneProject2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoWithOneProject2.Migrations
{
    [DbContext(typeof(FruitContext))]
    partial class FruitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DemoWithOneProject2.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("DemoWithOneProject2.Fruit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Name");

                    b.Property<decimal?>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Fruits");
                });

            modelBuilder.Entity("DemoWithOneProject2.FruitCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FruitCategories");
                });

            modelBuilder.Entity("DemoWithOneProject2.FruitInBasket", b =>
                {
                    b.Property<int>("FruitId");

                    b.Property<int>("BasketId");

                    b.HasKey("FruitId", "BasketId");

                    b.HasIndex("BasketId");

                    b.ToTable("FruitInBasket");
                });

            modelBuilder.Entity("DemoWithOneProject2.Fruit", b =>
                {
                    b.HasOne("DemoWithOneProject2.FruitCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("DemoWithOneProject2.FruitInBasket", b =>
                {
                    b.HasOne("DemoWithOneProject2.Basket", "Basket")
                        .WithMany("FruitInBaskets")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DemoWithOneProject2.Fruit", "Fruit")
                        .WithMany("FruitInBasket")
                        .HasForeignKey("FruitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
