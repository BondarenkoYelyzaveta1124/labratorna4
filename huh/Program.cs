using System;
using System.Text;

namespace lab4
{
    internal class Program
    {
        /* 5.Знайти середнє арифметичне елементів масиву, які розміщені між першим додатним та
        останнім від’ємним числом.*/
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int choice;
            do
            {
                Console.WriteLine("Якщо ви бажаєте заповнити масив випадковим чином, тоді введіть 1");
                Console.WriteLine("Якщо ви бажаєте заповнити масив власноруч, тоді введіть 2");
                Console.WriteLine("Для виходу з програми введіть 0");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Виконую блок 1");
                        Random();
                        break;
                    case 2:
                        PidProgram();
                        break;
                    case 0:
                        Console.WriteLine("Зараз завершимо, тільки натисніть будь ласка ще раз Enter");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Команда ``{0}'' не розпізнана. Зробіь, будь ласка, вибір із 1, 2, 0.", choice);
                        break;
                }
            } while (choice != 0);
        }

        static void PidProgram()
        {
            Console.WriteLine("Якщо ви бажаєте вводити кожен елемент у окремому рядку, тоді введіть 1");
            Console.WriteLine("Якщо ви бажаєте вводити всі елементи разом одним рядком через пробіли та/або табуляції, тоді введіть 2");
            int subChoice = int.Parse(Console.ReadLine());
            switch (subChoice)
            {
                case 1:
                    Console.WriteLine("Виконую блок 1");
                    UserWriteOneString();
                    break;
                case 2:
                    Console.WriteLine("Виконую блок 2");
                    UserWriteNewString();
                    break;
                default:
                    Console.WriteLine("Команда ``{0}'' не розпізнана. Зробіь, будь ласка, вибір із 1, 2.", subChoice);
                    break;
            }
        }

        static void Random()
        {
            Console.WriteLine("Введіть кількість елементів масиву: ");
            int sizeRandom;
            while (!int.TryParse(Console.ReadLine(), out sizeRandom) || sizeRandom <= 0)
            {
                Console.WriteLine("Введіть дадатнє число");
            }

            Console.WriteLine("Введіть мінімальне (від'ємне) значення діапазону: ");
            int minValue;
            while (!int.TryParse(Console.ReadLine(), out minValue))
            {
                Console.WriteLine("Введіть ціле число");
            }

            Console.WriteLine("Введіть максимальне (додатне) значення діапазону: ");
            int maxValue;
            while (!int.TryParse(Console.ReadLine(), out maxValue) || maxValue <= minValue)
            {
                Console.WriteLine("Bведіть ціле число більше за мінімальне значення");
            }

            int[] numbsRand = new int[sizeRandom];
            Random rand = new Random();
            for (int i = 0; i < numbsRand.Length; i++)
            {
                numbsRand[i] = rand.Next(minValue, maxValue + 1);
            }

            Console.WriteLine($"Елементи які були згенеровані рандомно: {string.Join(" ", numbsRand)}");

            Formula(numbsRand);
        }

        static void UserWriteOneString()
        {
            Console.WriteLine("Введіть кількість елементів масиву: ");

            int size;
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Введіть дадатнє число");
            }

            int[] numbs = new int[size];
            Console.WriteLine("Введіть елементи масиву: ");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Елемент {i + 1}: ");
                if (!int.TryParse(Console.ReadLine(), out numbs[i]))
                {
                    Console.WriteLine("Невірний формат. Програма завершується.");
                    return;
                }
            }
            Formula(numbs);
        }

        static void UserWriteNewString()
        {
            Console.WriteLine("Введіть елементи масиву через пробіли та/або табуляції: ");

            string input = Console.ReadLine();
            string[] stringNumbs = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            int[] strNumb = new int[stringNumbs.Length];

            for (int i = 0; i < stringNumbs.Length; i++)
            {
                if (!int.TryParse(stringNumbs[i], out strNumb[i]))
                {
                    Console.WriteLine($"'{stringNumbs[i]}' не є дійсним цілим числом. Програма завершена.");
                    return;
                }
            }
            Console.WriteLine($"Кількість введених елементів: {stringNumbs.Length}");
            Formula(strNumb);
        }

        static void Formula(int[] array)
        {
            int firstPlus = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    firstPlus = i;
                    break;
                }
            }

            int lastMinus = -1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] < 0)
                {
                    lastMinus = i;
                    break;
                }
            }

            if (firstPlus == -1 || lastMinus == -1 || firstPlus >= lastMinus)
            {
                Console.WriteLine("Неможливо знайти елементи між першим додатним і останнім від’ємним числом.");
            }
            else
            {
                int sum = 0;
                int count = 0;

                for (int i = firstPlus + 1; i < lastMinus; i++)
                {
                    sum += array[i];
                    count++;
                }

                if (count > 0)
                {
                    double result = (double)sum / count;
                    Console.WriteLine($"Середнє арифметичне елементів між першим додатним і останнім від’ємним: {result}");
                }
                else
                {
                    Console.WriteLine("Між першим додатним і останнім від’ємним числами немає елементів.");
                }
            }
        }
    }
}