using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEleven
{
    class Program
    {
        static int ReadInt()// Ввод целого числа
        { 
            int num = 0;
            bool OK = false;
            do
            {
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                    OK = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка ввода. Ожидалось целое число.");
                    OK = false;
                }
            } while (!OK);
            return num;
        }

        static char[] Cryptographer(string message, int shift)
        {
            char[] alphabet = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            char[] arr = new char[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                int index = -1;
                arr[i] = message[i];
                    for (int j = 0; j < alphabet.Length; j++)
                    if (arr[i] == alphabet[j])
                    {
                        index = j;
                    }

                if (index > -1)
                {
                    if (index + shift < 0) index = alphabet.Length + ((index + shift) % alphabet.Length);
                    else index = (index + shift) % alphabet.Length;
                    arr[i] = alphabet[index];
                }
            }          
            return arr;
        }

        static void Main(string[] args)
        {
            int reverse = 0;
            int choiсe;
            bool OK = true;
            string menu = "Что вы хотите сделать?\n1.Зашифровать текст.\n2.Расшифровать текст.";
            Console.WriteLine(menu);
            do
            {
                choiсe = ReadInt();
                if (choiсe == 1) reverse = 1;
                else if (choiсe == 2) reverse = -1;
                else
                {
                    Console.WriteLine("Ошибка ввода! Выберите один из пунктов меню.");
                    OK = false;
                }
            } while (!OK);
            Console.WriteLine("Введите текст на русском языке строчными буквами:");
            string message = Console.ReadLine();
            Console.WriteLine("Введите ключ к шифру:");
            int shift = ReadInt();
            char[] arr = Cryptographer(message, shift * reverse);
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i]);
            Console.ReadLine();
        }
    }
}
