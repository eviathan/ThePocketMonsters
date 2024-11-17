using PocketMonsters.Core.Enums;

namespace PocketMonsters.Core.Models
{
    public class BeastiaryItem
    {
        public MonsterStats BaseStats { get; set; }
        public string Description { get; set; }
        public HashSet<ElementType> Elements { get; set; } = [];
        public List<Move> BaseMoveSet { get; set; } = [];
        public Dictionary<byte, MonsterType> Evolutions { get; set; } = [];
    }

    public class Beastiary
    {
        private static readonly Beastiary _instance = new Beastiary();
        public static Beastiary Instance
        {
            get
            {
                return _instance;
            }
        }

        public BeastiaryItem this[MonsterType type]
        {
            get => _items[type];
            set => _items[type] = value;
        }

        static Beastiary() { }
        private Beastiary() { }

        private Dictionary<MonsterType, BeastiaryItem> _items { get; set; } = new Dictionary<MonsterType, BeastiaryItem>
        {
            { MonsterType.Bulbasaur, new BeastiaryItem { } },
            { MonsterType.Ivysaur, new BeastiaryItem { } },
            {
                MonsterType.Venusaur, new BeastiaryItem
                {
                    BaseStats = new ()
                    {
                        Health = 78,
                        Attack = 84,
                        Defense = 78,
                        SpecialAttack = 109,
                        SpecialDefence = 85,
                        Speed = 100
                    },
                    Description = "I love running through fields of wheat!",
                    Elements =
                    [
                        ElementType.Grass
                    ],
                    BaseMoveSet =
                    [
                        Move.Moves[MoveType.WoodHammer]
                    ]
                }
            },
            { MonsterType.Charmander, new BeastiaryItem { } },
            { MonsterType.Charmeleon, new BeastiaryItem { } },
            {
                MonsterType.Charizard, new BeastiaryItem
                {
                    BaseStats = new ()
                    {
                        Health = 80,
                        Attack = 82,
                        Defense = 83,
                        SpecialAttack = 100,
                        SpecialDefence = 100,
                        Speed = 80
                    },
                    Description = "Hes a big burny bastard!",
                    Elements =
                    [
                        ElementType.Fire,
                        ElementType.Flying,
                    ],
                    BaseMoveSet =
                    [
                        Move.Moves[MoveType.FagBurn]
                    ]
                }
            },
            { MonsterType.Squirtle, new BeastiaryItem { } },
            { MonsterType.Wartortle, new BeastiaryItem { } },
            { MonsterType.Blastoise, new BeastiaryItem { } },
            { MonsterType.Caterpie, new BeastiaryItem { } },
            { MonsterType.Metapod, new BeastiaryItem { } },
            { MonsterType.Butterfree, new BeastiaryItem { } },
            { MonsterType.Weedle, new BeastiaryItem { } },
            { MonsterType.Kakuna, new BeastiaryItem { } },
            { MonsterType.Beedrill, new BeastiaryItem { } },
            { MonsterType.Pidgey, new BeastiaryItem { } },
            { MonsterType.Pidgeotto, new BeastiaryItem { } },
            { MonsterType.Pidgeot, new BeastiaryItem { } },
            { MonsterType.Rattata, new BeastiaryItem { } },
            { MonsterType.Raticate, new BeastiaryItem { } },
            { MonsterType.Spearow, new BeastiaryItem { } },
            { MonsterType.Fearow, new BeastiaryItem { } },
            { MonsterType.Ekans, new BeastiaryItem { } },
            { MonsterType.Arbok, new BeastiaryItem { } },
            { MonsterType.Pikachu, new BeastiaryItem { } },
            { MonsterType.Raichu, new BeastiaryItem { } },
            { MonsterType.Sandshrew, new BeastiaryItem { } },
            { MonsterType.Sandslash, new BeastiaryItem { } },
            { MonsterType.NidoranF, new BeastiaryItem { } },
            { MonsterType.Nidorina, new BeastiaryItem { } },
            { MonsterType.Nidoqueen, new BeastiaryItem { } },
            { MonsterType.NidoranM, new BeastiaryItem { } },
            { MonsterType.Nidorino, new BeastiaryItem { } },
            { MonsterType.Nidoking, new BeastiaryItem { } },
            { MonsterType.Clefairy, new BeastiaryItem { } },
            { MonsterType.Clefable, new BeastiaryItem { } },
            { MonsterType.Vulpix, new BeastiaryItem { } },
            { MonsterType.Ninetales, new BeastiaryItem { } },
            { MonsterType.Jigglypuff, new BeastiaryItem { } },
            { MonsterType.Wigglytuff, new BeastiaryItem { } },
            { MonsterType.Zubat, new BeastiaryItem { } },
            { MonsterType.Golbat, new BeastiaryItem { } },
            { MonsterType.Oddish, new BeastiaryItem { } },
            { MonsterType.Gloom, new BeastiaryItem { } },
            { MonsterType.Vileplume, new BeastiaryItem { } },
            { MonsterType.Paras, new BeastiaryItem { } },
            { MonsterType.Parasect, new BeastiaryItem { } },
            { MonsterType.Venonat, new BeastiaryItem { } },
            { MonsterType.Venomoth, new BeastiaryItem { } },
            { MonsterType.Diglett, new BeastiaryItem { } },
            { MonsterType.Dugtrio, new BeastiaryItem { } },
            { MonsterType.Meowth, new BeastiaryItem { } },
            { MonsterType.Persian, new BeastiaryItem { } },
            { MonsterType.Psyduck, new BeastiaryItem { } },
            { MonsterType.Golduck, new BeastiaryItem { } },
            { MonsterType.Mankey, new BeastiaryItem { } },
            { MonsterType.Primeape, new BeastiaryItem { } },
            { MonsterType.Growlithe, new BeastiaryItem { } },
            { MonsterType.Arcanine, new BeastiaryItem { } },
            { MonsterType.Poliwag, new BeastiaryItem { } },
            { MonsterType.Poliwhirl, new BeastiaryItem { } },
            { MonsterType.Poliwrath, new BeastiaryItem { } },
            { MonsterType.Abra, new BeastiaryItem { } },
            { MonsterType.Kadabra, new BeastiaryItem { } },
            { MonsterType.Alakazam, new BeastiaryItem { } },
            { MonsterType.Machop, new BeastiaryItem { } },
            { MonsterType.Machoke, new BeastiaryItem { } },
            { MonsterType.Machamp, new BeastiaryItem { } },
            { MonsterType.Bellsprout, new BeastiaryItem { } },
            { MonsterType.Weepinbell, new BeastiaryItem { } },
            { MonsterType.Victreebel, new BeastiaryItem { } },
            { MonsterType.Tentacool, new BeastiaryItem { } },
            { MonsterType.Tentacruel, new BeastiaryItem { } },
            { MonsterType.Geodude, new BeastiaryItem { } },
            { MonsterType.Graveler, new BeastiaryItem { } },
            { MonsterType.Golem, new BeastiaryItem { } },
            { MonsterType.Ponyta, new BeastiaryItem { } },
            { MonsterType.Rapidash, new BeastiaryItem { } },
            { MonsterType.Slowpoke, new BeastiaryItem { } },
            { MonsterType.Slowbro, new BeastiaryItem { } },
            { MonsterType.Magnemite, new BeastiaryItem { } },
            { MonsterType.Magneton, new BeastiaryItem { } },
            { MonsterType.Farfetchd, new BeastiaryItem { } },
            { MonsterType.Doduo, new BeastiaryItem { } },
            { MonsterType.Dodrio, new BeastiaryItem { } },
            { MonsterType.Seel, new BeastiaryItem { } },
            { MonsterType.Dewgong, new BeastiaryItem { } },
            { MonsterType.Grimer, new BeastiaryItem { } },
            { MonsterType.Muk, new BeastiaryItem { } },
            { MonsterType.Shellder, new BeastiaryItem { } },
            { MonsterType.Cloyster, new BeastiaryItem { } },
            { MonsterType.Gastly, new BeastiaryItem { } },
            { MonsterType.Haunter, new BeastiaryItem { } },
            { MonsterType.Gengar, new BeastiaryItem { } },
            { MonsterType.Onix, new BeastiaryItem { } },
            { MonsterType.Drowzee, new BeastiaryItem { } },
            { MonsterType.Hypno, new BeastiaryItem { } },
            { MonsterType.Krabby, new BeastiaryItem { } },
            { MonsterType.Kingler, new BeastiaryItem { } },
            { MonsterType.Voltorb, new BeastiaryItem { } },
            { MonsterType.Electrode, new BeastiaryItem { } },
            { MonsterType.Exeggcute, new BeastiaryItem { } },
            { MonsterType.Exeggutor, new BeastiaryItem { } },
            { MonsterType.Cubone, new BeastiaryItem { } },
            { MonsterType.Marowak, new BeastiaryItem { } },
            { MonsterType.Hitmonlee, new BeastiaryItem { } },
            { MonsterType.Hitmonchan, new BeastiaryItem { } },
            { MonsterType.Lickitung, new BeastiaryItem { } },
            { MonsterType.Koffing, new BeastiaryItem { } },
            { MonsterType.Weezing, new BeastiaryItem { } },
            { MonsterType.Rhyhorn, new BeastiaryItem { } },
            { MonsterType.Rhydon, new BeastiaryItem { } },
            { MonsterType.Chansey, new BeastiaryItem { } },
            { MonsterType.Tangela, new BeastiaryItem { } },
            { MonsterType.Kangaskhan, new BeastiaryItem { } },
            { MonsterType.Horsea, new BeastiaryItem { } },
            { MonsterType.Seadra, new BeastiaryItem { } },
            { MonsterType.Goldeen, new BeastiaryItem { } },
            { MonsterType.Seaking, new BeastiaryItem { } },
            { MonsterType.Staryu, new BeastiaryItem { } },
            { MonsterType.Starmie, new BeastiaryItem { } },
            { MonsterType.MrMime, new BeastiaryItem { } },
            { MonsterType.Scyther, new BeastiaryItem { } },
            { MonsterType.Jynx, new BeastiaryItem { } },
            { MonsterType.Electabuzz, new BeastiaryItem { } },
            { MonsterType.Magmar, new BeastiaryItem { } },
            { MonsterType.Pinsir, new BeastiaryItem { } },
            { MonsterType.Tauros, new BeastiaryItem { } },
            { MonsterType.Magikarp, new BeastiaryItem { } },
            { MonsterType.Gyarados, new BeastiaryItem { } },
            { MonsterType.Lapras, new BeastiaryItem { } },
            { MonsterType.Ditto, new BeastiaryItem { } },
            { MonsterType.Eevee, new BeastiaryItem { } },
            { MonsterType.Vaporeon, new BeastiaryItem { } },
            { MonsterType.Jolteon, new BeastiaryItem { } },
            { MonsterType.Flareon, new BeastiaryItem { } },
            { MonsterType.Porygon, new BeastiaryItem { } },
            { MonsterType.Omanyte, new BeastiaryItem { } },
            { MonsterType.Omastar, new BeastiaryItem { } },
            { MonsterType.Kabuto, new BeastiaryItem { } },
            { MonsterType.Kabutops, new BeastiaryItem { } },
            { MonsterType.Aerodactyl, new BeastiaryItem { } },
            { MonsterType.Snorlax, new BeastiaryItem { } },
            { MonsterType.Articuno, new BeastiaryItem { } },
            { MonsterType.Zapdos, new BeastiaryItem { } },
            { MonsterType.Moltres, new BeastiaryItem { } },
            { MonsterType.Dratini, new BeastiaryItem { } },
            { MonsterType.Dragonair, new BeastiaryItem { } },
            { MonsterType.Dragonite, new BeastiaryItem { } },
            { MonsterType.Mewtwo, new BeastiaryItem { } },
            { MonsterType.Mew, new BeastiaryItem { } }
        };
    }
}