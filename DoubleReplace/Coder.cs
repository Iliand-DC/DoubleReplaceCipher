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
        //Вставить в ключ разделитель ','
        public string GetKeyWithSplitter(string strKey)
        {
            string new_string = "";
            for(int i=0; i<size;i++)
            {
                new_string += strKey[i];
                if(i!=size-1)
                    new_string += ',';
            }
            return new_string;
        }

        //перевод текста в матрицу
        public Coder(string text)
        {
            this.text = text;
            size = FindMatrixSize();
            matrixOfSymbols = new char[size, size];
            int index = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (index != text.Length)
                    {
                        matrixOfSymbols[j, i] = text[index];
                        index += 1;
                    }
                    else matrixOfSymbols[j, i] = ' ';
                }
            }
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

        //Расшифровка сообщения по ключу
        public char[,] Decipher(int[] keyCol, int[] keyStr)
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
        //подбор размера квадратной матрицы в зависимости от длины строки
        private int FindMatrixSize()
        {
            int size = text.Length;
            int i = 1;
            while (i * i < size)
                i++;
            return i;
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

