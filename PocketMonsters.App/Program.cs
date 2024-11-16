using PocketMonsters.Core.Enums;
using PocketMonsters.Core.Models;


var ash = new Player("Ash");

ash.Monsters.AddRange([
    new Monster
    {
        Name = "Swagasaurus Rex",
        Type = MonsterType.Charizard,
    }
]);

var minglePooper = new Player("Mingler Pooper");

minglePooper.Monsters.AddRange([
    new Monster
    {
        Name = "Grassy Knoll",
        Type = MonsterType.Venusaur,
    }
]);


