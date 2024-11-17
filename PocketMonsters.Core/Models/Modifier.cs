namespace PocketMonsters.Core.Models
{
    public class Modifier<T>
    {
        public int Lifetime { get; set; }

        public void Modify(T item, Action<T> predicate)
        {
            if (TryModify(item, predicate))
            {
                return;
            }

            throw new InvalidOperationException($"Insufficient {nameof(Lifetime)}");
        }

        public bool TryModify(T item, Action<T> predicate)
        {
            if (Lifetime > 0)
            {
                predicate(item);
                Lifetime--;
                return true;
            }

            return false;
        }
    }
}