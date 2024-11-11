using System.Text;

namespace Homework1

{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("_________");
            Console.WriteLine("ЗАДАЧА 1");
            Console.OutputEncoding = Encoding.UTF8;
            char letter = 'b';

            int position = char.ToUpper(letter) - 'A' + 1;
            Console.WriteLine($"Позиція в алфавіті: {position}");

            char toggledLetter = char.IsUpper(letter) ? char.ToLower(letter) : char.ToUpper(letter);
            Console.WriteLine($"Змінений регістр: {toggledLetter}");


            SecondTask();

        }

        static void SecondTask()
        {
            Console.WriteLine("_________");
            Console.WriteLine("ЗАДАЧА 2");
            string input = "Лондон, Париж, Рим";
            char delimiter = ',';


            List<string> result = new List<string>();

            string currentWord = "";


            foreach (char ch in input)
            {
                if (ch == delimiter)
                {

                    result.Add(currentWord.Trim());
                    currentWord = "";
                }
                else
                {

                    currentWord += ch;
                }
            }


            if (!string.IsNullOrEmpty(currentWord))
            {
                result.Add(currentWord.Trim());
            }


            string[] finalResult = result.ToArray();


            Console.WriteLine("Розділені рядки:");
            foreach (string word in finalResult)
            {
                Console.WriteLine(word);
            }
            TaskThree();

        }
        static void TaskThree()
        {
            Console.WriteLine("_________");
            Console.WriteLine("ЗАДАЧА 3");
            string mainString = "Це тестовий рядок для пошуку";
            string substring = "рядок";

            int index = FindSubstring(mainString, substring);

            if (index != -1)
            {
                Console.WriteLine($"Підрядок знайдено на позиції: {index}");
            }
            else
            {
                Console.WriteLine("Підрядок не знайдено.");
            }
            TaskFour();
        }

        static int FindSubstring(string mainString, string substring)
        {
            int mainLength = mainString.Length;
            int subLength = substring.Length;


            if (subLength > mainLength)
            {
                return -1;
            }


            for (int i = 0; i <= mainLength - subLength; i++)
            {
                int j;


                for (j = 0; j < subLength; j++)
                {
                    if (mainString[i + j] != substring[j])
                    {
                        break;
                    }
                }


                if (j == subLength)
                {
                    return i;
                }
            }


            return -1;


        }


        static void TaskFour()
        {
            Console.WriteLine("_________");
            Console.WriteLine("ЗАДАЧА 4");
            int number = 138;
            string result = NumberToWords(number);
            Console.WriteLine(result);
            TaskFive();
        }

        static string NumberToWords(int number)
        {
            if (number == 0)
                return "нуль";

            if (number < 0 || number > 999)
                throw new ArgumentOutOfRangeException("Підтримуються тільки числа від 0 до 999.");

            string[] hundreds = { "", "сто", "двісті", "триста", "чотириста", "п'ятсот", "шістсот", "сімсот", "вісімсот", "дев'ятсот" };
            string[] tens = { "", "десять", "двадцять", "тридцять", "сорок", "п'ятдесят", "шістдесят", "сімдесят", "вісімдесят", "дев'яносто" };
            string[] units = { "", "один", "два", "три", "чотири", "п'ять", "шість", "сім", "вісім", "дев'ять" };
            string[] teens = { "десять", "одинадцять", "дванадцять", "тринадцять", "чотирнадцять", "п'ятнадцять", "шістнадцять", "сімнадцять", "вісімнадцять", "дев'ятнадцять" };

            string result = "";

            // Визначаємо сотні
            if (number >= 100)
            {
                int hundredPart = number / 100;
                result += hundreds[hundredPart] + " ";
                number %= 100;
            }


            if (number >= 20)
            {
                int tensPart = number / 10;
                result += tens[tensPart] + " ";
                number %= 10;
            }
            else if (number >= 10 && number < 20)
            {
                result += teens[number - 10];
                return result.Trim();
            }


            if (number > 0)
            {
                result += units[number];
            }

            return result.Trim();


        }

        static void TaskFive()
        {
            Console.WriteLine("_________");
            Console.WriteLine("ЗАДАЧА 5");
            int a = 5;
            int b = 10;

            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine($"a = {a}, b = {b}");
        }

    }
}
