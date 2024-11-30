using PocketMonsters.Core.Enums;

namespace PocketMonsters.Core.Models
{
    public class ItemCatalog : Catalog<Item, ItemType> 
    {
        public static ItemCatalog Instance = new();
        static ItemCatalog () { }
        private ItemCatalog () 
        { 
            Items = new()
            {
                [ItemType.Potion] = new Item
                {
                    Type = ItemType.Potion,
                    UseItem = (source, target) =>
                    {
                        target.EquippedMonster.Stats.Health += 20;
                    }
                },
                [ItemType.RareCandy] = new Item
                {
                    Type = ItemType.RareCandy,
                    UseItem = (source, target) =>
                    {
                        target.EquippedMonster.Level++;
                    }
                },
                [ItemType.BookTheOldDickTwist] = new Item
                {
                    Type = ItemType.BookTheOldDickTwist,
                    UseItem = (source, target) =>
                    {
                        target.EquippedMonster.MoveSet.Add(MoveType.TheOldDickTwist);
                    }
                },
                [ItemType.MegaBeastOrb] = new Item
                {
                    Type = ItemType.MegaBeastOrb,
                    UseItem = (source, target) =>
                    {
                        var successful = true;
                        if(successful)
                        {
                            source.Monsters.Add(target.EquippedMonster);                        
                            target.Monsters.Remove(target.EquippedMonster);

                            target.EquippedMonster = target.Monsters.Any()
                                ? target.Monsters.First()
                                : null;
                        }
                    }
                }
            };
        }
    }
}