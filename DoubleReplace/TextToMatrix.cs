using System;
using static System.Net.Mime.MediaTypeNames;

namespace DoubleReplace
{
	public class TextToMatrix
	{
        int size;
        char[,] matrixOfSymbols;
        public int GetSize() { return size; }
		public TextToMatrix(string text)
		{
            int size = FindMatrixSize(text);
            matrixOfSymbols = new char[size, size];
            int index = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (index != text.Length)
                    {
                        matrixOfSymbols[i, j] = text[index];
                        index += 1;
                    }
                    else matrixOfSymbols[i, j] = ' ';
                }
            }
        }
        public char[,] GetMatrix() { return matrixOfSymbols; }
        //подбор размера квадратной матрицы в зависимости от длины строки
        private int FindMatrixSize(string text)
        {
            int size = text.Length;
            int i = 1;
            while (i * i < size)
                i++;
            this.size = i;
            return i;
        }
        //перевод матрицы в текст
        public string MatrixToText(char[,] matrix)
        {
            string new_text = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    new_text += matrix[j, i];
                }
            }
            return new_text;
        }

        //Вставить в ключ разделитель ','
        public string GetKeyWithSplitter(string strKey)
        {
            string new_string = "";
            for (int i = 0; i < size; i++)
            {
                new_string += strKey[i];
                if (i != size - 1)
                    new_string += ',';
            }
            return new_string;
        }
    }
}

