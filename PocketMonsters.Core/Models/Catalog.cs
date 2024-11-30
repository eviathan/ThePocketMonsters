namespace PocketMonsters.Core.Models
{
    public abstract class Catalog<TItem, TItemType> 
        where TItem : class, new()
        where TItemType : Enum
    {
        public TItem this[TItemType type]
        {
            get => Items.ContainsKey(type) ? Items[type] : null;
            set => Items[type] = value;
        }

        protected Dictionary<TItemType, TItem> Items { get; set; } = new();
    }
}