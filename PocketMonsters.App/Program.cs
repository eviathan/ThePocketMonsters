using PocketMonsters.Core.Enums;
using PocketMonsters.Core.Models;

var ash = new Player("Ash");
var monsterA = new Monster
{
    Name = "Swagasaurus Rex",
    Type = MonsterType.Charizard,
};
ash.Monsters.Add(monsterA);
ash.TrySwapMonster(MonsterType.Charizard);

var minglePooper = new Player("Mingler Pooper");
var monsterB = new Monster
{
    Name = "Grassy Knoll",
    Type = MonsterType.Venusaur,
};
minglePooper.Monsters.Add(monsterB);
minglePooper.TrySwapMonster(MonsterType.Venusaur);

var battle = new Battle();

battle.Allies.Add(ash);
battle.Enemies.Add(minglePooper);

Console.WriteLine($"{minglePooper.Name} Health: {minglePooper.EquippedMonster.Health}");
battle.Attack(ash, minglePooper, MoveType.FagBurn);
Console.WriteLine($"{minglePooper.Name} Health: {minglePooper.EquippedMonster.Health}");

Console.WriteLine($"{ash.Name} Health: {ash.EquippedMonster.Health}");
battle.Attack(minglePooper, ash, MoveType.WoodHammer);
Console.WriteLine($"{ash.Name} Health: {ash.EquippedMonster.Health}");