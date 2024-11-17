using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketMonsters.Core
{
    public static class Maths
    {
        private static readonly Random random = new Random();

        public static float RandomRange(float minValue, float maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("minValue should be less than or equal to maxValue");
            }

            return (float)(random.NextDouble() * (maxValue - minValue) + minValue);
        }

        public static int RandomRange(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("minValue should be less than or equal to maxValue");
            }

            return random.Next(minValue, maxValue + 1);
        }
    }
}