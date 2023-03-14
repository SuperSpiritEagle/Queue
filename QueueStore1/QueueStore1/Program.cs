using System;
using System.Collections.Generic;

namespace QueueStore1
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            int clientNumber = 1;
            int numberBuyers = NumberBuyers();

            Queue<int> clients = QueueStore(numberBuyers);

            while (clients.Count > 0)
            {
                int purchaseAmount = clients.Dequeue();
                score += purchaseAmount;

                if (clients.Count == 0)
                {
                    Console.WriteLine("Товар продан!!!");
                }
                else
                {
                    Console.WriteLine($"клиен [{clientNumber++}] купил [{Products()}] на сумму [{purchaseAmount}] руб.");
                    Console.WriteLine($"\nна счёте - [{score}] рублей.");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private static string Products()
        {
            string[] products = new string[] { "телефон", "фотоаппарат", "ноутбук" };

            Random random = new Random();

            int minValue = 0;
            int maxValue = 3;
            int result;

            result = random.Next(minValue, maxValue);

            return products[result];
        }

        private static int NumberBuyers()
        {
            Console.WriteLine("Введите количество покупателей в очереди: ");
            string userInput = Console.ReadLine();

            int.TryParse(userInput, out int number);

            return number;
        }

        private static Queue<int> QueueStore(int numberBuyers)
        {
            Queue<int> client = new Queue<int>();
            Random random = new Random();

            int minValue = 100;
            int maxValue = 1000;

            for (int i = 0; i < numberBuyers; i++)
            {
                client.Enqueue(random.Next(minValue, maxValue));
            }

            return client;
        }
    }
}
