using System.Text.RegularExpressions;
using System.Text;

namespace Homework2
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("____________");
            Console.WriteLine("ЗАДАЧА 1");
            Console.WriteLine("____________");

            int[] array = { 1, 2, 3, 4, 5 };
            Reverse(array);
            Console.WriteLine(string.Join(", ", array));
            TaskTwo();
        }

        public static void Reverse(int[] array)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;
                left++;
                right--;
            }
        }

        static void TaskTwo()
        {
            Console.WriteLine("____________");
            Console.WriteLine("ЗАДАЧА 2");
            Console.WriteLine("____________");

            string text = "Це текст, який містить заборонені слова: Заборонене слово.";
            string[] forbiddenWords = { "Заборонене", "слово" };
            string filteredText = Filter(text, forbiddenWords);
            Console.WriteLine(filteredText);

            TaskThree();


            static string Filter(string input, string[] forbiddenWords)
            {
                foreach (var word in forbiddenWords)
                {
                    string pattern = $@"\b{Regex.Escape(word)}\b";
                    input = Regex.Replace(input, pattern, "****", RegexOptions.IgnoreCase);
                }
                return input;
            }
        }

        static void TaskThree()
        {
            Console.WriteLine("____________");
            Console.WriteLine("ЗАДАЧА 3");
            Console.WriteLine("____________");

            int length = 10;
            string randomString = Generate(length);
            Console.WriteLine(randomString);


            static string Generate(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                StringBuilder result = new StringBuilder(length);
                Random random = new Random();

                for (int i = 0; i < length; i++)
                {
                    result.Append(chars[random.Next(chars.Length)]);
                }

                return result.ToString();
            }
        }
    }
}



