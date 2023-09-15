using System;
//using Javax.Crypto;

namespace DoubleReplace
{
    public class Coder
    {
        int[] keyString;
        int[] keyColumn;
        private string text;
        int size;
        private char[,] matrixOfSymbols;
        public char[,] GetMatrixOfSymbols()
        {
            return matrixOfSymbols;
        }
        public int GetSize()
        {
            return size;
        }
        //Получить ключ строк
        public string GetKeyString()
        {
            string output = "";
            for (int i = 0; i < size; i++)
                output += keyString[i];
            return output;
        }
        //получить ключ стоблцов
        public string GetKeyColumn()
        {
            string output = "";
            for (int i = 0; i < size; i++)
                output += keyColumn[i];
            return output;
        }
        //Конструктор, инициализация всех полей и создание ключей
        public Coder(string text)
        {
            TextToMatrix translator = new TextToMatrix(text);
            matrixOfSymbols = translator.GetMatrix();
            size = translator.GetSize();

            KeyGenerator keygen = new KeyGenerator(size);
            keyString = keygen.GetKey();
            keygen = new KeyGenerator(size);
            keyColumn = keygen.GetKey();
            Console.Write("Ключ строк ");
            for (int i = 0; i < size; i++)
                Console.Write(keyString[i] + " ");
            Console.WriteLine();
            Console.Write("Ключ столбцов ");
            for (int i = 0; i < size; i++)
                Console.Write(keyColumn[i] + " ");
            Console.WriteLine();
        }
        //щифрование перестановкой строк, а потом колонок
        public char[,] Cipher()
        {
            char[,] matrix = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = matrixOfSymbols[keyString[i], j];
                }
            }
            Console.WriteLine("Шифровка");
            Print(matrix);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrixOfSymbols[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = matrixOfSymbols[i, keyColumn[j]];
                }
            }
            Console.WriteLine("Вторая перестановка");
            Print(matrix);
            return matrix;
        }
        //Печать матрицы
        public void Print(char[,] matrix)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}

