using PocketMonsters.Core.App;
using PocketMonsters.Core.Enums;
using PocketMonsters.Core.Models;

            
var game = new Game();



// var ash = new Player("Ash");
// var monsterA = new Monster
// (
//     "Swagasaurus Rex",
//     MonsterType.Charizard
// );
// ash.Monsters.Add(monsterA);
// ash.TrySwapMonster(MonsterType.Charizard);

// var minglePooper = new Player("Mingler Pooper");
// var monsterB = new Monster
// (
//     "Grassy Knoll",
//     MonsterType.Venusaur
// );
// minglePooper.Monsters.Add(monsterB);
// minglePooper.TrySwapMonster(MonsterType.Venusaur);

// var battle = new Battle(
//     [ ash ],
//     [ minglePooper ],
//     (state, stats) =>
//     {
//         switch (state)
//         {
//             case BattleState.Won:
//                 Console.WriteLine($"Won! Winners: {string.Join(", ", stats.Winners.Select(x => x.Name))}");
//                 break;
//             case BattleState.Draw:
//                 Console.WriteLine($"Draw! Winners: {string.Join(", ", stats.Winners.Select(x => x.Name))}");
//                 break;
//             case BattleState.Lost:
//                 Console.WriteLine($"Lost! Winners: {string.Join(", ", stats.Winners.Select(x => x.Name))}");
//                 break;
//         }
//     }
// );

// while(true)
// {
//     Character targetCharacter = null;

//     battle.Attack((characters, moveTypes) =>  {
//         targetCharacter = characters.First();
//         Console.WriteLine($"{characters.First().Name} - {targetCharacter.EquippedMonster.Name} was attacked with: {moveTypes.First()}");
//         return new AttackTurn
//         {
//             Target = characters.First(),
//             MoveType = moveTypes.First()
//         };
//     });

//     var equipedMonster = targetCharacter.EquippedMonster;
//     Console.WriteLine($"{equipedMonster.Name} Health: {equipedMonster.Stats.Health}");

//     if(battle.State != BattleState.Active)
//         break;
// }

// ash.Satchel.TryAdd(ItemType.RareCandy, 12);
// minglePooper.Satchel.TryAdd(ItemType.RareCandy, 12);


// Console.WriteLine($"Swags level is: {ash.EquippedMonster.Level}");
// battle.UseItem(ash, (items) => {
//     return items.First();
// });
// Console.WriteLine($"Swags level is: {ash.EquippedMonster.Level}");


// Console.WriteLine(string.Join(", ", ash.EquippedMonster.MoveSet.Select(x => x)));

// ash.Satchel.TryAdd(ItemType.BookTheOldDickTwist, 1);

// ash.Satchel.TryUse(ItemType.BookTheOldDickTwist, ash.EquippedMonster);

// Console.WriteLine(string.Join(", ", ash.EquippedMonster.MoveSet.Select(x => x)));