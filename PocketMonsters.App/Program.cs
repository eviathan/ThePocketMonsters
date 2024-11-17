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

while(true)
{
    Character targetCharacter = null;

    battle.Attack((characters, moveTypes) =>  {
        targetCharacter = characters.First();
        Console.WriteLine($"{characters.First().Name} - {targetCharacter.EquippedMonster.Name} was attacked with: {moveTypes.First()}");
        return new AttackTurn
        {
            Target = characters.First(),
            MoveType = moveTypes.First()
        };
    });

    var equipedMonster = targetCharacter.EquippedMonster;
    Console.WriteLine($"{equipedMonster.Name} Health: {equipedMonster.Stats.Health}");

    if(battle.State != BattleState.Active)
    {
        switch (battle.State)
        {
            case BattleState.Won:
                Console.WriteLine("Won!");
                break;
            case BattleState.Draw:
                Console.WriteLine("Draw!");
                break;
            case BattleState.Lost:
                Console.WriteLine("Lost!");
                break;
        }

        break;
    }
}