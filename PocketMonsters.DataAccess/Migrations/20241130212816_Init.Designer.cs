﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PocketMonsters.DataAccess;

#nullable disable

namespace PocketMonsters.DataAccess.Migrations
{
    [DbContext(typeof(PocketMonstersDbContext))]
    [Migration("20241130212816_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("PocketMonsters.DataAccess.Entities.CharacterEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Money")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("PocketMonsters.DataAccess.Entities.ItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemEntity");
                });

            modelBuilder.Entity("PocketMonsters.DataAccess.Entities.ItemTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ItemTypeEntity");
                });

            modelBuilder.Entity("PocketMonsters.DataAccess.Entities.MonsterEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Attack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("CharacterId1")
                        .HasColumnType("TEXT");

                    b.Property<int>("Defense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Health")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MonsterTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("MonsterTypeId1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SpecialAttack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpecialDefence")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Speed")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId1");

                    b.HasIndex("MonsterTypeId1");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("PocketMonsters.DataAccess.Entities.MonsterMoveEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MonsterId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MoveId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MonsterId");

                    b.HasIndex("MoveId");

                    b.ToTable("MonsterMoves");
                });

            modelBuilder.Entity("PocketMonsters.DataAccess.Entities.MonsterTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Elements")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EvolutionLevel")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EvolutionTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("EvolutionTypeId1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EvolutionTypeId1");

                    b.ToTable("MonsterTypes");
                });

            modelBuilder.Entity("PocketMonsters.DataAccess.Entities.MoveEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<byte>("Accuracy")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Element")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Power")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PowerPoints")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Probability")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("PocketMonsters.DataAccess.Entities.ItemEntity", b =>
                {
                    b.HasOne("PocketMonsters.DataAccess.Entities.CharacterEntity", "Character")
                        .WithMany("Items")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketMonsters.DataAccess.Entities.ItemTypeEntity", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("PocketMonsters.DataAccess.Entities.MonsterEntity", b =>
                {
                    b.HasOne("PocketMonsters.DataAccess.Entities.CharacterEntity", "Character")
                        .WithMany("Monsters")
                        .HasForeignKey("CharacterId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketMonsters.DataAccess.Entities.MonsterTypeEntity", "MonsterType")
                        .WithMany()
                        .HasForeignKey("MonsterTypeId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("MonsterType");
                });

            modelBuilder.Entity("PocketMonsters.DataAccess.Entities.MonsterMoveEntity", b =>
                {
                    b.HasOne("PocketMonsters.DataAccess.Entities.MonsterEntity", "Monster")
                        .WithMany("MonsterMoves")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PocketMonsters.DataAccess.Entities.MoveEntity", "Move")
                        .WithMany()
                        .HasForeignKey("MoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monster");

                    b.Navigation("Move");
                });

            modelBuilder.Entity("PocketMonsters.DataAccess.Entities.MonsterTypeEntity", b =>
                {
                    b.HasOne("PocketMonsters.DataAccess.Entities.MonsterTypeEntity", "EvolutionType")
                        .WithMany()
                        .HasForeignKey("EvolutionTypeId1");

                    b.Navigation("EvolutionType");
                });

            modelBuilder.Entity("PocketMonsters.DataAccess.Entities.CharacterEntity", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Monsters");
                });

            modelBuilder.Entity("PocketMonsters.DataAccess.Entities.MonsterEntity", b =>
                {
                    b.Navigation("MonsterMoves");
                });
#pragma warning restore 612, 618
        }
    }
}