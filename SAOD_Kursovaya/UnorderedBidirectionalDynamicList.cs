using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kursovaya
{
    /// <summary>
    /// Класс, описывающий неупорядоченный двунаправленный динамический список
    /// </summary>
    public class UnorderedBidirectionalDynamicList
    {
        #region Описание свойств класса

        /// <summary>
        /// Заголовок списка
        /// </summary>
        private string _title { get; set; }

        /// <summary>
        /// Головной элемент списка
        /// </summary>
        private ItemOfUnorderedBidirectionalDynamicList _head { get; set; }

        /// <summary>
        /// Хвостовой элемент списка
        /// </summary>
        private ItemOfUnorderedBidirectionalDynamicList _tail { get; set; }

        /// <summary>
        /// Кол-во элементов списка
        /// </summary>
        private int _count { get; set; }

        #endregion

        #region Описание коструктора и деструктора класса

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public UnorderedBidirectionalDynamicList(int numb)
        {
            _count = 0;
            _title = $"Список №{numb}";
            _head = null;
            _tail = null;

            Dialog();
        }

        /// <summary>
        /// Второй конструктор класса, используется при работе с файлами
        /// </summary>
        /// <param name="numb">Номер списка</param>
        /// <param name="index"></param>
        public UnorderedBidirectionalDynamicList(int numb, int index)
        {
            _count = 0;
            _title = $"Список №{numb}";
            _head = null;
            _tail = null;
        }

        /// <summary>
        /// Деструктор класса
        /// </summary>
        public void UnorderedBidirectionalDynamicListDestructor()
        {
            _count = 0;
            _title = null;
            _head = null;
            _tail = null;
        }

        #endregion

        #region Описание методов класса

        /// <summary>
        /// Диалоговя функции общения с пользователем
        /// </summary>
        public void Dialog()
        {
            Console.Write("\nВведите кол-во элементов списка: ");
            var count = Convert.ToInt32(Console.ReadLine()); // Вводится кол-во создаваемых элементов в списке

            for (var  i = 0; i < count; i++)
            {
                Console.Write("\nВведите информационную часть, перед/после которой нужно добавить новый элемент: ");
                var nameOfCompany = Console.ReadLine();

                Console.Write("Выбирите тип добавления : 1 - перед элементом, 2 - после элемента\nВаш выбор: ");
                var inputOption = Console.ReadLine();

                while (inputOption != "1" && inputOption != "2")
                {
                    Console.Write("\nНеизвестная команда, повторите ввод: ");
                    inputOption = Console.ReadLine();
                }

                if (inputOption == "1")
                {
                    AddNewItemBefore(nameOfCompany);
                }
                else if (inputOption == "2")
                {
                    AddNewItemAfter(nameOfCompany);
                }
            }
        }

        /// <summary>
        /// Функция добавления нового элемента перед заданным по информационной части
        /// </summary>
        public void AddNewItemBefore(string nameOfCompany)
        {
            Console.Write($"\nВведите название компании №{_count}: "); // Запрашивает у пользователя название компании
            var nameOfNewCompany = Console.ReadLine();

            var newItem = new ItemOfUnorderedBidirectionalDynamicList(nameOfNewCompany); // Новый, добавляемый, элемент списка

            if (_head == null) // Если список пуст
            {
                _head = newItem;
                _tail = _head;
            }
            else // Если в списке есть хотя бы 1 элемент
            {
                var searchingItem = SearchNext(nameOfCompany);

                if (searchingItem != null) // Элемент найден
                {
                    if (Equals(searchingItem, _head) == true) // Если найденный элемент - головной элемент списка
                    {
                        newItem.SetRightNeighbor(_head);
                        _head.SetLeftNeighbor(newItem);
                        _head = newItem; // Новый элемент становится головным
                    }
                    else
                    {
                        var beforeItem = searchingItem.GetLeftNeighbor(); // Получаем соседа слева у найденного элемента
                        beforeItem.SetRightNeighbor(newItem);
                        searchingItem.SetLeftNeighbor(newItem);
                        newItem.SetRightNeighbor(searchingItem);
                        newItem.SetLeftNeighbor(beforeItem);
                    }
                }
                else // Элемент не найден
                {
                    AddNewItem(newItem, nameOfNewCompany);
                }
            }

            _count++; // Увеличиваем число элементов списка
        }

        /// <summary>
        /// Функция добавления нового элемента после заданного по информационной части
        /// </summary>
        public void AddNewItemAfter(string nameOfCompany)
        {
            Console.Write($"\nВведите название компании №{_count}: "); // Запрашивает у пользователя название компании
            var nameOfNewCompany = Console.ReadLine();

            var newItem = new ItemOfUnorderedBidirectionalDynamicList(nameOfNewCompany); // Новый, добавляемый, элемент списка

            if (_head == null) // Если список пуст
            {
                _head = newItem;
                _tail = _head;
            }
            else // Если в списке есть хотя бы 1 элемент
            {
                var searchingItem = SearchNext(nameOfCompany);

                if (searchingItem != null) // Элемент найден
                {
                    if (Equals(searchingItem, _tail) == true) // Если найденный элемент - хвостовой элемент списка
                    {
                        newItem.SetLeftNeighbor(_tail);
                        _tail.SetRightNeighbor(newItem);
                        _tail = newItem; // Новый элемент становится хвостовым
                    }
                    else
                    {
                        var afterItem = searchingItem.GetRightNeighbor(); // Получаем соседа справа у найденного элемента
                        afterItem.SetLeftNeighbor(newItem);
                        searchingItem.SetRightNeighbor(newItem);
                        newItem.SetLeftNeighbor(searchingItem);
                        newItem.SetRightNeighbor(afterItem);
                    }
                }
                else // Элемент не найден
                {
                    AddNewItem(newItem, nameOfNewCompany);
                }
            }

            _count++; // Увеличиваем число элементов списка
        }

        /// <summary>
        /// Функция добавления нового элемента в конец
        /// </summary>
        /// <param name="newItem">Добавляемый элемент</param>
        /// <param name="nameOfCompany">Название компании</param>
        public void AddNewItem(ItemOfUnorderedBidirectionalDynamicList newItem, string nameOfCompany)
        {
            if (_head == null) // Если список пуст
            {
                _head = newItem;
                _tail = _head;
            }
            else
            {
                _tail.SetRightNeighbor(newItem);
                newItem.SetLeftNeighbor(_tail);
                _tail = newItem; // Новый элемент становится хвостовым
            }

            _count++; // Увеличиваем число элементов списка
        }

        /// <summary>
        /// Функция поиска элемента по информационной части (название компании) в прямом направлении
        /// </summary>
        /// <param name="nameOfCompany">Название компании, которое пользователь хочет найти</param>
        /// <returns>Элемент списка</returns>
        public ItemOfUnorderedBidirectionalDynamicList SearchNext(string nameOfCompany)
        {
            var current = _head;

            if (current == null)
            {
                return null;
            }

            while (current.GetRightNeighbor() != null)
            {
                if (current.GetCompany().GetNameOfCompany() == nameOfCompany)
                {
                    return current;
                }

                current = current.GetRightNeighbor();
            }

            if (current.GetCompany().GetNameOfCompany() == nameOfCompany)
            {
                return current;
            }

            return null; // если компания не найдена
        }

        /// <summary>
        /// Функция поиска элемента по информационной части (название компании) в обратном направлении
        /// </summary>
        /// <param name="nameOfCompany">Название компании, которое пользователь хочет найти</param>
        /// <returns>Элемент списка</returns>
        private ItemOfUnorderedBidirectionalDynamicList SearchPrevious(string nameOfCompany)
        {
            var current = _tail;

            while (current.GetLeftNeighbor() != null)
            {
                if (current.GetCompany().GetNameOfCompany() == nameOfCompany)
                {
                    return current;
                }

                current = current.GetLeftNeighbor();
            }

            if (current.GetCompany().GetNameOfCompany() == nameOfCompany)
            {
                return current;
            }

            return null; // если компания не найдена
        }

        /// <summary>
        /// Функция поиска элемента по информационной части в прямом направлении
        /// </summary>
        public void SearchElementInForwardDirection()
        {
            if (Empty() == true)
            {
                Console.WriteLine($"Список пуст, поиск невозможен");

                return;
            }

            Console.Write("Введите название компании: "); // Запрашивает у пользователя название компании
            var nameOfCompany = Console.ReadLine();

            var current = SearchNext(nameOfCompany);

            if (current == null) // Элемент не найден
            {
                Console.WriteLine($"Элемент {nameOfCompany} не найден при поиске в прямом направлении");
            }
            else
            {
                Console.WriteLine($"Элемент {nameOfCompany} найден при поиске в прямом направлении");
            }
        }

        /// <summary>
        /// Функция поиска элемента по информационной части в обратном направлении
        /// </summary>
        public void SearchElementBackwards()
        {
            if (Empty() == true)
            {
                Console.WriteLine($"Список пуст, поиск невозможен");

                return;
            }

            Console.Write("Введите название компании: "); // Запрашивает у пользователя название компании
            var nameOfCompany = Console.ReadLine();

            var current = SearchPrevious(nameOfCompany);

            if (current == null) // Элемент не найден
            {
                Console.WriteLine($"Элемент {nameOfCompany} не найден при поиске в обратном направлении");
            }
            else
            {
                Console.WriteLine($"Элемент {nameOfCompany} найден при поиске в обратном направлении");
            }
        }

        /// <summary>
        /// Функция вывода списка в прямом направдении
        /// </summary>
        public void ShowForward()
        {
            if (Empty() == true)
            {
                Console.WriteLine($"Список пуст");

                return;
            }

            var current = _head;

            Console.Write($"Элементы {_title} в прямом направлении: ");

            while (current.GetRightNeighbor() != null)
            {
                current.GetCompany().GetNameOfCompany2();

                current = current.GetRightNeighbor();
            }

            current.GetCompany().GetNameOfCompany2();

            Console.WriteLine("\n");
        }

        /// <summary>
        /// Функция вывода списка в обратном направлении
        /// </summary>
        public void ShowBackwards()
        {
            if (Empty() == true)
            {
                Console.WriteLine($"Список пуст");

                return;
            }

            var current = _tail;

            Console.Write($"Элементы {_title} в обратном направлении: ");

            while (current.GetLeftNeighbor() != null)
            {
                current.GetCompany().GetNameOfCompany2();

                current = current.GetLeftNeighbor();
            }

            current.GetCompany().GetNameOfCompany2();

            Console.WriteLine("\n");
        }

        /// <summary>
        /// Функция удаления элемента по заданной информационной части
        /// </summary>
        public void RemoveItem()
        {
            if (Empty() == true)
            {
                Console.WriteLine($"Список пуст, удаление невозможно");

                return;
            }

            Console.Write("Введите название компании: "); // Запрашивает у пользователя название компании
            var nameOfCompany = Console.ReadLine();

            var searchingItem = SearchNext(nameOfCompany);

            if (searchingItem != null) // Элемент найден
            {
                if (_count == 1)
                {
                    _head = null;
                    _tail = null;

                    searchingItem = null; // Удаляем элемент
                }
                else if (Equals(searchingItem, _head) == true) // Если удаляемый элемент - головной элемент
                {
                    var removeItem = _head;

                    _head = _head.GetRightNeighbor(); // Головной элемент - следующий элемент после _head
                    _head.SetLeftNeighbor(null);

                    removeItem = null; // удаляем элемент
                }
                else if (Equals(searchingItem, _tail) == true) // ЕСли удаляемый элемент - хвостовой элемент
                {
                    var removeItem = _tail;

                    _tail = _tail.GetLeftNeighbor(); // Хвостовой элемент - предыдущий элемент перед _tail
                    _tail.SetRightNeighbor(null);

                    removeItem = null; // удаляем элемент
                }
                else
                {
                    var nextItem = searchingItem.GetRightNeighbor();
                    var previousItem = searchingItem.GetLeftNeighbor();

                    nextItem.SetLeftNeighbor(previousItem);
                    previousItem.SetRightNeighbor(nextItem);

                    searchingItem = null; // Удаление элемента
                }

                _count--; // Уменьшаем число элементов списка
            }
            else
            {
                Console.WriteLine($"Элемент {nameOfCompany} в списке не найден, удаление элемента не произошло");
            }
        }

        /// <summary>
        /// Проверка на пустоту списка
        /// </summary>
        /// <returns>true - если список пуст, иначе - false</returns>
        public bool Empty()
        {
            if (_count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Функция возвращает заголовок списка
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            return _title;
        }

        /// <summary>
        /// Функция возвращает головной элемент
        /// </summary>
        /// <returns>Лбъкт класса ItemOfUnorderedBidirectionalDynamicList</returns>
        public ItemOfUnorderedBidirectionalDynamicList GetHeadItem()
        {
            return _head;
        }

        #endregion
    }
}
