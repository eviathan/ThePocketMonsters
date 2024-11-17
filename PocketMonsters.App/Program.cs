using PocketMonsters.Core.Enums;
using PocketMonsters.Core.Models;

var ash = new Player("Ash");
var monsterA = new Monster
(
    "Swagasaurus Rex",
    MonsterType.Charizard
);
ash.Monsters.Add(monsterA);
ash.TrySwapMonster(MonsterType.Charizard);

var minglePooper = new Player("Mingler Pooper");
var monsterB = new Monster
(
    "Grassy Knoll",
    MonsterType.Venusaur
);
minglePooper.Monsters.Add(monsterB);
minglePooper.TrySwapMonster(MonsterType.Venusaur);

var battle = new Battle([ash], [minglePooper]);

Console.WriteLine($"{monsterB.Name} Health: {minglePooper.EquippedMonster.Stats.Health}");
battle.Attack((characters, moveTypes) =>  {
    return new AttackTurn
    {
        Target = characters.First(),
        MoveType = moveTypes.First()
    };
});
Console.WriteLine($"{monsterB.Name} Health: {minglePooper.EquippedMonster.Stats.Health}");

Console.WriteLine($"{monsterA.Name} Health: {ash.EquippedMonster.Stats.Health}");
battle.Attack((characters, moveTypes) =>  {
    return new AttackTurn
    {
        Target = characters.First(),
        MoveType = moveTypes.First()
    };
});
Console.WriteLine($"{monsterA.Name} Health: {ash.EquippedMonster.Stats.Health}");

battle.RunAway(
    (character) => 
    {
        Console.WriteLine($"{character.Name} ran Away!");
    },
    (character) => 
    {
        Console.WriteLine($"{character.Name} failed to run Away!");
    }
);