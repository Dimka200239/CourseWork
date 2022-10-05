using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kursovaya
{
    /// <summary>
    /// Гланый класс программы
    /// </summary>
    class Program
    {
       /// <summary>
       /// Главная функции программы
       /// </summary>
       /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var newQueue = new StaticQueueOfUnorderedBidirectionalDynamicLists();

            var run = true;

            while (run)
            {
                Console.WriteLine("\nВыберите дейстие:\n\n" +
                                  "1 - Вывести очередь\n" +
                                  "2 - Проверить очередь на пустоту\n" +
                                  "3 - Проверить очередь на заполненность\n" +
                                  "4 - Добавить новый элемент в очередь\n" +
                                  "5 - Удалить улемент из очереди\n" +
                                  "6 - Выбрать какой-то конкретный список\n" +
                                  "7 - Сохранить результат в файл\n" +
                                  "8 - Достать информацию из файла\n" +
                                  "0 - Закончить программу\n\n");

                Console.Write("Выбор: ");
                var x = Console.ReadLine();

                if (x == "0")
                {
                    run = false;
                }
                else if (x == "1")
                {
                    newQueue.ShowQueue();
                }
                else if (x == "2")
                {
                    Console.WriteLine($"Очередь пуста? - {newQueue.Empty()}");
                }
                else if (x == "3")
                {
                    Console.WriteLine($"Очередь заполнена? - {newQueue.Occupancy()}");
                }
                else if (x == "4")
                {
                    newQueue.Add();
                }
                else if (x == "5")
                {
                    newQueue.Remove();
                }
                else if (x == "6")
                {
                    newQueue.SelectList();
                }
                else if (x == "7")
                {
                    newQueue.InputToFile();
                }
                else if (x == "8")
                {
                    newQueue.OutputFromFile();
                }
                else
                {
                    Console.WriteLine("Неизвестная команда..");
                }
            }
        }
    }
}
