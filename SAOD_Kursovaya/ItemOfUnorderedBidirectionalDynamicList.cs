using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kursovaya
{
    /// <summary>
    /// Класс, описывающий элемент неупорядоченного двунапрявленного динамического списка
    /// </summary>
    public class ItemOfUnorderedBidirectionalDynamicList
    {
        #region Описание свойств класса

        /// <summary>
        /// Информационная часть элемента
        /// </summary>
        private Company _data { get; set; }

        /// <summary>
        /// Левый сосед
        /// </summary>
        private ItemOfUnorderedBidirectionalDynamicList _left { get; set; }

        /// <summary>
        /// Правый сосед
        /// </summary>
        private ItemOfUnorderedBidirectionalDynamicList _right { get; set; }

        #endregion

        #region Описание конструктора и деструктора класса

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="nameOfCompany">Название компании</param>
        /// <param name="numbOfCompany">Номер компании</param>
        public ItemOfUnorderedBidirectionalDynamicList(string nameOfCompany)
        {
            _data = new Company(nameOfCompany);
            _left = null; // Пока что обнуляем левого соседа
            _right = null; // Пока что обнуляем правого соседа
        }

        /// <summary>
        /// Второй конструктор класса, используется при работе с файлами
        /// </summary>
        /// <param name="nameOfCompany">Название компании</param>
        /// <param name="nameOfDepartment">Название отдела</param>
        /// <param name="serName">Фамилия сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        public ItemOfUnorderedBidirectionalDynamicList(string nameOfCompany, string nameOfDepartment, string serName, string position)
        {
            _data = new Company(nameOfCompany, nameOfDepartment, serName, position);
            _left = null; // Пока что обнуляем левого соседа
            _right = null; // Пока что обнуляем правого соседа
        }

        /// <summary>
        /// Деструктор класса
        /// </summary>
        public void ItemOfUnorderedBidirectionalDynamicListDestructor()
        {
            _data = null;
            _left = null;
            _right = null;
        }

        #endregion

        #region Описание методов класса

        /// <summary>
        /// Фцнкция возвращает объект класса Company
        /// </summary>
        /// <returns>Объект класса Company</returns>
        public Company GetCompany()
        {
            return _data;
        }

        /// <summary>
        /// Функция возвращает левого соседа
        /// </summary>
        /// <returns>Объект класса ItemOfUnorderedBidirectionalDynamicList</returns>
        public ItemOfUnorderedBidirectionalDynamicList GetLeftNeighbor()
        {
            return _left;
        }

        /// <summary>
        /// Функция возвращает правого соседа
        /// </summary>
        /// <returns>Объект класса ItemOfUnorderedBidirectionalDynamicList</returns>
        public ItemOfUnorderedBidirectionalDynamicList GetRightNeighbor()
        {
            return _right;
        }

        /// <summary>
        /// Функция устанавливает левого соседа для элемента
        /// </summary>
        /// <param name="leftNeighbor">Левый сосед - объект класса Company</param>
        public void SetLeftNeighbor(ItemOfUnorderedBidirectionalDynamicList leftNeighbor)
        {
            _left = leftNeighbor;
        }

        /// <summary>
        /// Функция устанавливает правого соседа для элемента
        /// </summary>
        /// <param name="rightNeighbor">Правый сосед - объект класса Company</param>
        public void SetRightNeighbor(ItemOfUnorderedBidirectionalDynamicList rightNeighbor)
        {
            _right = rightNeighbor;
        }

        #endregion
    }
}
