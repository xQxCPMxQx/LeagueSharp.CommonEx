﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LeagueSharp.CommonEx.Core.Utils
{
    /// <summary>
    ///     Weighted Random, contains useful extensions for randomizer.
    /// </summary>
    public static class WeightedRandom
    {
        /// <summary>
        ///     Global Random that is being used by WeightedRandom.
        /// </summary>
        public static Random Random = new Random(Environment.TickCount);

        /// <summary>
        ///     Returns a random integer
        /// </summary>
        /// <param name="min">Minimum range</param>
        /// <param name="max">Maximum range</param>
        /// <returns>Random Integer</returns>
        public static int Next(int min, int max)
        {
            var list = new List<int>();
            list.AddRange(Enumerable.Range(min, max));

            var mean = list.Average();
            var stdDev = list.StandardDeviation();

            var v1 = Random.NextDouble();
            var v2 = Random.NextDouble();

            var randStdNormal = System.Math.Sqrt(-2.0 * System.Math.Log(v1)) *
                                System.Math.Sin(2.0 * System.Math.PI * v2);
            return (int) (mean + stdDev * randStdNormal);
        }

        /// <summary>
        ///     Standard Devitation of the values list.
        /// </summary>
        /// <param name="values">Values list</param>
        /// <returns>Standard Devitation</returns>
        public static double StandardDeviation(this IEnumerable<int> values)
        {
            var enumerable = values as int[] ?? values.ToArray();
            var avg = enumerable.Average();
            return System.Math.Sqrt(enumerable.Average(v => System.Math.Pow(v - avg, 2)));
        }
    }
}