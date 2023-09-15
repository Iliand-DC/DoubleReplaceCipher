using System;
namespace DoubleReplace
{
	public class Decoder
	{
        int[] keyStr;
        int[] keyCol;
        private string text;
        int size;
        private char[,] matrixOfSymbols;
        //Расшифровка сообщения по ключу
        public char[,] Decipher()
        {
            Console.WriteLine("Расшифровка");
            char[,] matrix = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, keyCol[j]] = matrixOfSymbols[i, j];
                }
            }
            Print(matrix);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrixOfSymbols[i, j] = matrix[i, j];
                }
            }
            //Print(wrongMatrix);
            Console.WriteLine("Вторая перестановка");
            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < size; i++)
                {
                    matrix[keyStr[i], j] = matrixOfSymbols[i, j];
                }
            }
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
        public Decoder(int[] _keyCol, int[] _keyStr, char[,] matrix, int _size)
		{
            keyCol = _keyCol;
            keyStr = _keyStr;
            matrixOfSymbols = matrix;
            size = _size;
		}
    }
}

