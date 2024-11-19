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

            TaskFour();

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

        public static string CompressDNA(string dna)
        {
            if (string.IsNullOrEmpty(dna))
                return "";

            StringBuilder compressed = new StringBuilder();
            char currentChar = dna[0];
            int count = 1;

            for (int i = 1; i < dna.Length; i++)
            {
                if (dna[i] == currentChar)
                {
                    count++;
                }
                else
                {
                    compressed.Append(currentChar);
                    compressed.Append(count);
                    currentChar = dna[i];
                    count = 1;
                }
            }


            compressed.Append(currentChar);
            compressed.Append(count);

            return compressed.ToString();
        }


        public static string DecompressDNA(string compressedDna)
        {
            if (string.IsNullOrEmpty(compressedDna))
                return "";

            StringBuilder decompressed = new StringBuilder();
            for (int i = 0; i < compressedDna.Length; i += 2)
            {
                char nucleotide = compressedDna[i];
                int count = int.Parse(compressedDna[i + 1].ToString());

                decompressed.Append(new string(nucleotide, count));
            }

            return decompressed.ToString();
        }


        static void TaskFour()
        {

            Console.WriteLine("____________");
            Console.WriteLine("ЗАДАЧА 5");
            Console.WriteLine("____________");

            while (true)
            {
                Console.WriteLine("\nВиберіть дію:");
                Console.WriteLine("1 - Зжати ДНК");
                Console.WriteLine("2 - Розжати ДНК");
                Console.WriteLine("0 - Вихід");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть цепочку ДНК: ");
                        string dna = Console.ReadLine();
                        string compressed = CompressDNA(dna);
                        Console.WriteLine($"Зжата ДНК: {compressed}");
                        break;

                    case "2":
                        Console.Write("Ведіть зжату ДНК: ");
                        string compressedDna = Console.ReadLine();
                        string decompressed = DecompressDNA(compressedDna);
                        Console.WriteLine($"Розпакована ДНК: {decompressed}");
                        break;

                    case "0":
                        Console.WriteLine("Вийти.");
                        return;

                    default:
                        Console.WriteLine("Помилка вводу.");
                        break;
                }
            }
        }
    }
}
