using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocketMonsters.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Money = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypeEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypeEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonsterTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Elements = table.Column<string>(type: "TEXT", nullable: false),
                    EvolutionLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    EvolutionTypeId = table.Column<int>(type: "INTEGER", nullable: true),
                    EvolutionTypeId1 = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterTypes_MonsterTypes_EvolutionTypeId1",
                        column: x => x.EvolutionTypeId1,
                        principalTable: "MonsterTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    Power = table.Column<byte>(type: "INTEGER", nullable: false),
                    Accuracy = table.Column<byte>(type: "INTEGER", nullable: false),
                    Probability = table.Column<byte>(type: "INTEGER", nullable: false),
                    PowerPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    Element = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CharacterId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemEntity_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemEntity_ItemTypeEntity_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemTypeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    Attack = table.Column<int>(type: "INTEGER", nullable: false),
                    Defense = table.Column<int>(type: "INTEGER", nullable: false),
                    SpecialAttack = table.Column<int>(type: "INTEGER", nullable: false),
                    SpecialDefence = table.Column<int>(type: "INTEGER", nullable: false),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false),
                    MonsterTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    MonsterTypeId1 = table.Column<Guid>(type: "TEXT", nullable: false),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterId1 = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monsters_Characters_CharacterId1",
                        column: x => x.CharacterId1,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Monsters_MonsterTypes_MonsterTypeId1",
                        column: x => x.MonsterTypeId1,
                        principalTable: "MonsterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonsterMoves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MonsterId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MoveId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterMoves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterMoves_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonsterMoves_Moves_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemEntity_CharacterId",
                table: "ItemEntity",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemEntity_ItemId",
                table: "ItemEntity",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterMoves_MonsterId",
                table: "MonsterMoves",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterMoves_MoveId",
                table: "MonsterMoves",
                column: "MoveId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_CharacterId1",
                table: "Monsters",
                column: "CharacterId1");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_MonsterTypeId1",
                table: "Monsters",
                column: "MonsterTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterTypes_EvolutionTypeId1",
                table: "MonsterTypes",
                column: "EvolutionTypeId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemEntity");

            migrationBuilder.DropTable(
                name: "MonsterMoves");

            migrationBuilder.DropTable(
                name: "ItemTypeEntity");

            migrationBuilder.DropTable(
                name: "Monsters");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "MonsterTypes");
        }
    }
}
