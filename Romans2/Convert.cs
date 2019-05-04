using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Romans2
{
    public class Convert
    {
        static Dictionary<int, string> Lookup=>BuildLookup();

        private static Dictionary<int, string> BuildLookup()
        {
            var dict = new Dictionary<int, string>();
            dict.Add(1000, "M");
            dict.Add(500, "D");
            dict.Add(100, "C");
            dict.Add(50, "L");
            dict.Add(10, "X");
            dict.Add(5, "V");
            dict.Add(1, "I");
            return dict;
        }

        public static string ToArabic(int value) {
            var arabicRepresentation = new StringBuilder();
            foreach (var key in Lookup.Keys) {

                var numeralCount = value / key;
                if (numeralCount == 1 && value%key==4)
                {
                    //Can we prepend anything?
                    int nextKey;
                    string nextValue;
                    NewMethod(key, out nextKey, out nextValue);
                    arabicRepresentation.Append(nextValue);
                    value -= 4 * nextKey;
                    var previousKey = GetPreviousKey(key);
                    arabicRepresentation.Append(Lookup[previousKey]);
                    value -= 1 * key;
                    numeralCount = 0;
                }
                if (numeralCount == 9)
                {
                    var previousKey = GetPreviousKey(key);
                    arabicRepresentation.Append(Lookup[key]);
                    arabicRepresentation.Append(Lookup[previousKey]);
                    value -= 9;// 4 * key;
                    numeralCount -= 9;

                }
                if (numeralCount == 4)
                {
                    var nextLowerKey = Lookup.Keys.OrderBy(k => k > key).Last();
                    arabicRepresentation.Append(Lookup[key]);
                    arabicRepresentation.Append(Lookup[nextLowerKey]);
                    value -= 4 * key;
                    numeralCount -= 4;
                }
                while (numeralCount>0)
                {
                    arabicRepresentation.Append(Lookup[key]);
                    value -= key;
                    numeralCount--;
                }
                
            }
            return arabicRepresentation.ToString();
        }

        private static void NewMethod(int key, out int nextKey, out string nextValue)
        {
            nextKey = GetNextKey(key);
            nextValue = Lookup[nextKey];
        }

        private static int GetPreviousKey(int key)
        {
            return Lookup.Keys.OrderBy(k => k > key).Last();
        }
        private static int GetNextKey(int key)
        {
            return Lookup.Keys.OrderBy(k => k < key).Where(k => k < key).First();
        }
    }
}
