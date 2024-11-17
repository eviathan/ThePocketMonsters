using System;
using System.Collections.Generic;
using System.Linq;

namespace PocketMonsters.Core.Extensions
{
    public static class ListExtensions
    {
        public static List<T> InterleaveRandom<T>(this IList<T> list1, IList<T> list2)
        {
            var result = new List<T>();
            var rng = new Random();
            
            var queue1 = new Queue<T>(list1);
            var queue2 = new Queue<T>(list2);

            while (queue1.Count > 0 || queue2.Count > 0)
            {
                if (queue1.Count > 0 && (queue2.Count == 0 || rng.Next(2) == 0))
                    result.Add(queue1.Dequeue());
                else if (queue2.Count > 0)
                    result.Add(queue2.Dequeue());
            }

            return result;
        }
    }
}