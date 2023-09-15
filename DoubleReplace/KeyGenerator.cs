using System;
namespace DoubleReplace
{
    public class KeyGenerator
    {
        public double[] keyPart;
        public int[] key;
        Random rnd = new Random();
        public KeyGenerator(int size)
        {
            keyPart = new double[size];
            key = new int[size];
            for (int i = 0; i < size; i++)
                keyPart[i] = rnd.NextDouble();
            SortedDictionary<double, int> mapForKey = new SortedDictionary<double, int>();
            for (int i = 0; i < size; i++)
                mapForKey.Add(keyPart[i], i);
            int rank = 0;
            foreach (var val in mapForKey.Values)
            {
                key[val] = rank;
                rank++;
            }
        }
        public int[] GetKey()
        {
            return key;
        }
    }
}

