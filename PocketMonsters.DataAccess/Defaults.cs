using PocketMonsters.Core.Enums;
using PocketMonsters.DataAccess.Entities;

namespace PocketMonsters.DataAccess
{
    public class Defaults
    {
        public readonly static MonsterTypeEntity[] MonsterTypes =
        [
            new ()
            {
                Name = "Puffachu",
                Description = "This chill Pokémon emits a sweet-smelling, calming vapor from the leafy bud on its tail. Its electricity is less shocking and more soothing, often used to light up dark caves or spark joy in gatherings. Despite its laid-back demeanor, Puffachu packs a zappy punch when needed, especially if you mess with its stash of berries!",
                Elements =
                [
                    ElementType.Electric,
                    ElementType.Grass
                ],
                EvolutionLevel = 30,
                EvolutionTypeId = 2
            },
            new ()
            {
                Name = "Budachu",
                Description = "When Puffachu evolves into Budachu, its leafy tail blooms into a radiant flower, emitting even more potent calming aromas. Budachu is highly social, often forming groups that create electrified fields of energy and tranquility. Its laid-back vibe is contagious, making it a favorite among mellow trainers.",
            Elements =
                [
                    ElementType.Electric,
                    ElementType.Grass
                ],
                EvolutionLevel = 80,
                EvolutionTypeId = 3
            },
            new ()
            {
                Name = "Chillumander",
                Description = "The final evolution, Chillumander, is the pinnacle of relaxation and raw power. Its tail transforms into a blazing, ember-tipped flower, glowing softly as it radiates heat and energy. Chillumander’s demeanor is as cool as they come, but when provoked, it unleashes devastating, electrified firestorms that leave opponents in awe.",
                Elements =
                [
                    ElementType.Electric,
                    ElementType.Grass
                ],
            },
        ];

        public readonly static MoveEntity[] Moves =
        [
            new ()
            {
                Type = MoveType.FagBurn,
                Description = "A blast of static electricity infused with leaves, causing paralysis and damage.",
                Power = 70,
                Accuracy = 95,
                Probability = 20,
                PowerPoints = 15,
                Category = CategoryType.Special,
                Element = ElementType.Fire
            },
            new ()
            {
                Type = MoveType.TheOldDickTwist,
                Description = "Electrified vines coil around the target, trapping them and dealing damage over time.",
                Power = 60,
                Accuracy = 90,
                Probability = 100,
                PowerPoints = 20,
                Category = CategoryType.Physical,
                Element = ElementType.Psychic
            },
            new ()
            {
                Type = MoveType.WoodHammer,
                Description = "Electrified vines coil around the target, trapping them and dealing damage over time.",
                Power = 60,
                Accuracy = 90,
                Probability = 100,
                PowerPoints = 20,
                Category = CategoryType.Physical,
                Element = ElementType.Normal
            }
        ];
    }
}