﻿using System;
using System.Collections.Generic;

namespace QueueStore1
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            int clientNumber = 1;
            int numberBuyers = GetBuyersAmount();

            Queue<int> clients = GetQueue(numberBuyers);

            while (clients.Count > 0)
            {
                int purchaseAmount = clients.Dequeue();
                score += purchaseAmount;

                Console.WriteLine($"клиен [{clientNumber++}] купил [{GetProduct()}] на сумму [{purchaseAmount}] руб.");
                Console.WriteLine($"\nна счёте - [{score}] рублей.");

                if (clients.Count == 0)
                {
                    Console.WriteLine("Товар продан!!!");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private static string GetProduct()
        {
            string[] products = new string[] { "телефон", "фотоаппарат", "ноутбук" };

            Random random = new Random();

            int minValue = 0;
            int maxValue = 3;
            int result;

            result = random.Next(minValue, maxValue);

            return products[result];
        }

        private static int GetBuyersAmount()
        {
            int number = 0;

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Введите количество покупателей в очереди: ");

                string userInput = Console.ReadLine();
                int.TryParse(userInput, out number);

                if (number <= 0)
                {
                    Console.WriteLine("Ошибка!!!");
                }
                else
                {
                    isWork = false;
                    Console.Clear();
                }  
            }

            return number;
        }

        private static Queue<int> GetQueue(int numberBuyers)
        {
            Queue<int> clients = new Queue<int>();
            Random random = new Random();

            int minValue = 100;
            int maxValue = 1000;

            for (int i = 0; i < numberBuyers; i++)
            {
                clients.Enqueue(random.Next(minValue, maxValue));
            }

            return clients;
        }
    }
}
