using System;
using System.Collections.Generic;

namespace InschrijvingPietieterken.Shared
{
    public static class LeeftijdenGroepen
    {
        public static string Kleuters = "Kleuters";
        public static string Jongsten = "Jongsten";
        public static string Middden = "Midden";
        public static string Oudsten = "Oudsten";

        private static readonly Dictionary<string, Tuple<int, int>> Leeftijden = new Dictionary<string, Tuple<int, int>>()
        {
            { Kleuters, new Tuple<int, int>(4,6) },
            { Jongsten, new Tuple<int, int>(7,9) },
            { Middden, new Tuple<int, int>(10,12) },
            { Oudsten, new Tuple<int, int>(13,15) }
        };

        public static Tuple<DateTime, DateTime> GetGeboorteJarenGroepen(string key)
        {
            var currentYear = DateTime.Now.Year;
            var ondergrens = currentYear - 4;
            var bovengrens = currentYear - 15;

            if (Leeftijden.TryGetValue(key, out var grenzen))
            {
                ondergrens = grenzen.Item1;
                bovengrens = grenzen.Item2;
            }

            var minDatum = new DateTime(currentYear - bovengrens, 1, 1);
            var maxDatum = new DateTime(currentYear - ondergrens, 12, 31);

            return new Tuple<DateTime, DateTime>(minDatum, maxDatum);
        }
    }
}
