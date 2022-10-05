using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kursovaya
{
    /// <summary>
    /// Класс, описывающий статическую очередь неупорядоченных двунаправленных динамических списков
    /// </summary>
    public class StaticQueueOfUnorderedBidirectionalDynamicLists
    {
        #region Описание свойств класса

        /// <summary>
        /// Массив с неупорядоченными двунаправленными динамическими списками
        /// </summary>
        private UnorderedBidirectionalDynamicList[] _array { get; set; }

        /// <summary>
        /// Начало очереди
        /// </summary>
        private int _first { get; set; }

        /// <summary>
        /// Конец очереди
        /// </summary>
        private int _last { get; set; }

        /// <summary>
        /// Кол-во элементов в очереди
        /// </summary>
        private int _count { get; set;}

        /// <summary>
        /// Размер очереди
        /// </summary>
        private int _size { get; set; }

        #endregion

        #region Описание конструктора и деструктора класса

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="size">Размер очереди</param>
        public StaticQueueOfUnorderedBidirectionalDynamicLists()
        {
            Console.Write("Введите кол-во элементов очереди: ");
            var size = Convert.ToInt32(Console.ReadLine());

            _size = size;
            _count = 0;
            _first = 0;
            _last = 0;
            _array = new UnorderedBidirectionalDynamicList[size];
        }

        /// <summary>
        /// Деструктор класса
        /// </summary>
        public void StaticQueueOfUnorderedBidirectionalDynamicListsDestructor()
        {
            _size = 0;
            _count = 0;
            _first = 0;
            _last = 0;

            for (var i = 0; i < _size; i++)
            {
                if (_array[i] != null)
                {
                    _array[i].UnorderedBidirectionalDynamicListDestructor();
                }
            }

            _array = null;
        }

        #endregion

        #region Описание методов класса

        /// <summary>
        /// Функция проверки на заполненность очереди
        /// </summary>
        /// <returns>true - если заполнена, иначе - false</returns>
        public bool Occupancy()
        {
            if (_size == _count) // Очередь заполнена
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Функция проверки на пустоту очереди
        /// </summary>
        /// <returns>true - если пуста, иначе - false</returns>
        public bool Empty()
        {
            if (_count == 0) // Очередь пуста
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Функция вывода очереди
        /// </summary>
        public void ShowQueue()
        {
            if (Empty() == true)
            {
                Console.WriteLine("Очередь пуста");

                return;
            }

            if (_last > _first)
            {
                Console.WriteLine("Состояние очереди:");

                for (var i = _first; i < _last; i++)
                {
                    Console.WriteLine($"{_array[i].GetTitle()}");
                }
            }
            else
            {
                Console.WriteLine("Состояние очереди:");

                for (var i = _first; i < _size; i++)
                {
                    Console.WriteLine($"{_array[i].GetTitle()}");
                }

                for (var i = 0; i < _last; i++)
                {
                    Console.WriteLine($"{_array[i].GetTitle()}");
                }
            }
        }

        /// <summary>
        /// Функция добавления элемента очереди
        /// </summary>
        public void Add()
        {
            if (Occupancy() == true)
            {
                Console.WriteLine("В очереди нет места, добавление невозможно");

                return;
            }

            _array[_last] = new UnorderedBidirectionalDynamicList(_last); // Добавление элемента
            _last++;

            if (_last >= _size)
            {
                _last = 0;
            }

            _count++;
        }

        /// <summary>
        /// Функция добавления элемента очереди, используется при работе с файлами
        /// </summary>
        /// <param name="indexOfList"></param>
        public void Add(int indexOfList)
        {
            if (Occupancy() == true)
            {
                Console.WriteLine("В очереди нет места, добавление невозможно");

                return;
            }

            _array[_last] = new UnorderedBidirectionalDynamicList(_last, indexOfList); // Добавление элемента
            _last++;

            if (_last >= _size)
            {
                _last = 0;
            }

            _count++;
        }

        /// <summary>
        /// Функция удаления элемента очереди
        /// </summary>
        public void Remove()
        {
            if (Empty() == true)
            {
                Console.WriteLine("Очередь пуста, удаление невозможно");

                return;
            }

            _array[_first].UnorderedBidirectionalDynamicListDestructor(); // Вызов деструктора списка
            _array[_first] = null; // Удаление элемента
            _first++;

            if (_first >= _size)
            {
                _first = 0;
            }

            _count--;
        }

        /// <summary>
        /// Функция выбора списка для дальнейшей работы с ним
        /// </summary>
        public void SelectList()
        {
            ShowQueue();

            if (Empty() == false)
            {
                Console.Write("Выберите список: ");
                var choose = Convert.ToInt32(Console.ReadLine());

                Menu(_array[choose]);
            }
        }

        /// <summary>
        /// Функция записи в файл
        /// </summary>
        public void InputToFile()
        {
            if (Empty() == true)
            {
                Console.WriteLine("Очередь пуста, нет смысла записывать её в файл");

                return;
            }

            var str = "";

            foreach (var el in _array)
            {
                if (el != null)
                {
                    var nameOfList = el.GetTitle(); // Название списка

                    var head = el.GetHeadItem();
                    var k = 0;

                    while (head != null)
                    {
                        k++;
                        var company = head.GetCompany();
                        var nameOfCompany = company.GetNameOfCompany(); // Название компании
                        var j = 0;

                        foreach (var item in company.GetAllDepartment()) // Получение списка отделов
                        {
                            j++;
                            var nameOfDepartmen = item.GetNameOfDepartment(); // Название отдела
                            var i = 0;

                            foreach (var element in item.GetAllEmployee())
                            {
                                i++;
                                var nameOfEmployee = element.GetSerName(); // Фамилия сотрудника
                                var positionOfEmployee = element.GetPosition(); // Должность сотрудника

                                var newStr = $"{nameOfList}\nК: {nameOfCompany}\nО: {nameOfDepartmen}\n{nameOfEmployee}\n{positionOfEmployee}\n\n";

                                str += newStr;
                            }

                            if (i == 0)
                            {
                                var newStr = $"{nameOfList}\nК: {nameOfCompany}\nО: {nameOfDepartmen}\n\n";
                                str += newStr;
                            }
                        }

                        if (j == 0)
                        {
                            var newStr = $"{nameOfList}\nК: {nameOfCompany}\n\n";
                            str += newStr;
                        }

                        head = head.GetRightNeighbor();
                    }

                    if (k == 0)
                    {
                        var newStr = $"{nameOfList}\n\n";
                        str += newStr;
                    }
                }
            }
            
            File.WriteAllText(@"D:\SAOD_Kursovaya\SAOD_Kursovaya\output.txt", str); // Сохранение в файл информации
        }

        /// <summary>
        /// Функция берет информацию из файла
        /// </summary>
        public void OutputFromFile()
        {
            string[] lines = File.ReadAllLines(@"D:\SAOD_Kursovaya\SAOD_Kursovaya\input.txt"); // Считываем с файла информацию

            int indexOfList = 0; // Индекс списка
            string nameOfCompany = ""; // Название компании
            string nameOfDepartment = ""; // Название отдела
            string serName = ""; // Фамилия сотрудника
            string position = ""; // Должность сотрудника

            foreach (string el in lines)
            {
                if (el != "") // Проверяем на разбивку (пустую строку)
                {
                    if (el[0] == 'С') // Получаем(считываем) индекс списка
                    {
                        var str = "";

                        for (var i = 8; i < el.Length; i++)
                        {
                            str += el[i];
                        }

                        indexOfList = Convert.ToInt32(str);
                    }
                    else if (el[0] == 'К') // Получаем(считываем) название компании
                    {
                        for (var i = 3; i < el.Length; i++)
                        {
                            nameOfCompany += el[i];
                        }
                    }
                    else if (el[0] == 'О') // Получаем(считываем) название отдела
                    {
                        for (var i = 3; i < el.Length; i++)
                        {
                            nameOfDepartment += el[i];
                        }
                    }
                    else if (el[0] == 'Ф') // Получаем(считываем) фамилию сотрудника
                    {
                        for (var i = 3; i < el.Length; i++)
                        {
                            serName += el[i];
                        }
                    }
                    else if (el[0] == 'Д') // Получаем(считываем) должность сотрудника
                    {
                        for (var i = 3; i < el.Length; i++)
                        {
                            position += el[i];
                        }
                    }
                }
                else
                {
                    if (_array[indexOfList] == null) // Если списка нет, то добавляем новый список
                    {
                        Add(indexOfList);
                    }

                    if (_array[indexOfList].SearchNext(nameOfCompany) == null && nameOfCompany != "") // Если компании нет, то добавляем новую компанию
                    {
                            
                        ItemOfUnorderedBidirectionalDynamicList newItem = new ItemOfUnorderedBidirectionalDynamicList(nameOfCompany, nameOfDepartment, serName, position);
                            
                        _array[indexOfList].AddNewItem(newItem, nameOfCompany);
                    }
                    else // Если компания есть, то проверяем дальше
                    {
                        if (_array[indexOfList].SearchNext(nameOfCompany).GetCompany().SearchDepartment(nameOfDepartment) == null && nameOfDepartment != "") // Если отдела нет, то добавляем новый отдел
                        {
                            _array[indexOfList].SearchNext(nameOfCompany).GetCompany().AddNewDepartment(nameOfDepartment, serName, position);
                        }
                        else // Если отдел есть, то дабовляем в него человека
                        {
                            _array[indexOfList].SearchNext(nameOfCompany).GetCompany().SearchDepartment(nameOfDepartment).AddNewEmployee(serName, position);
                        }
                    }

                    indexOfList = 0;
                    nameOfCompany = "";
                    nameOfDepartment = "";
                    serName = "";
                    position = "";
                }
            }
        }

        #endregion

        #region Меню роботы со списком

        /// <summary>
        /// Функция работы со списком
        /// </summary>
        /// <param name="element">Список</param>
        public void Menu(UnorderedBidirectionalDynamicList element)
        {
            var run = true;

            while (run)
            {
                Console.WriteLine("\nВыберите дейстие:\n\n" +
                                  "1 - Вывести список в прямом направлении\n" +
                                  "2 - Вывести список в обратном направлении\n" +
                                  "3 - Проверить список на пустоту\n" +
                                  "4 - Поиск эл-та в прямом направлении\n" +
                                  "5 - Поиск эл-та в обратном направлении\n" +
                                  "6 - Добавление элемента\n" +
                                  "7 - Удаление элемента\n" +
                                  "0 - Закончить работу со списком\n\n");

                Console.Write("Выбор: ");
                var x = Console.ReadLine();

                if (x == "0")
                {
                    run = false;
                }
                else if (x == "1")
                {
                    element.ShowForward();
                }
                else if (x == "2")
                {
                    element.ShowBackwards();
                }
                else if (x == "3")
                {
                    Console.WriteLine($"Список пуст? - {element.Empty()}");
                }
                else if (x == "4")
                {
                    element.SearchElementInForwardDirection();
                }
                else if (x == "5")
                {
                    element.SearchElementBackwards();
                }
                else if (x == "6")
                {
                    Console.Write("\nВведите информационную часть, перед/после которой нужно добавить новый элемент: ");
                    var nameOfCompany = Console.ReadLine();

                    Console.Write("1 - после, 2 - перед, выбор : ");
                    var y = Console.ReadLine();

                    if (y == "1")
                    {
                        element.AddNewItemAfter(nameOfCompany);
                    }
                    else if (y == "2")
                    {
                        element.AddNewItemBefore(nameOfCompany);
                    }
                }
                else if (x == "7")
                {
                    element.RemoveItem();
                }
                else
                {
                    Console.WriteLine("Неизвестная команда..");
                }
            }
        }

        #endregion
    }
}
