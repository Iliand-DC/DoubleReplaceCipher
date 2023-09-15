using System;
namespace DoubleReplace
{
    public class KeyGenerator
    {
        public double[] keyPart;
        public int[] key;
        Random rnd = new Random();
        //Возьмём четыре случайных числа в диапазоне от 0 до 1
        //Через ассоциативный массив каждому присвоим "ранг" - его место по
        // величине относительно других чисел
        //Вместо чисел запишем в массив их ранг и получим "случайный" ключ.
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

