using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kursovaya
{
    /// <summary>
    /// Класс, описывающий сотрудника какого-либо отдела
    /// </summary>
    public class Employee
    {
        #region Описание свойств класса

        /// <summary>
        /// Поле - фамилия сотрудника отдела
        /// </summary>
        private string _serName { get; set; }

        /// <summary>
        /// Поле - должность сотрудника
        /// </summary>
        private string _position { get; set; }

        #endregion

        #region Описание конструктора и деструктора класса

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="serName">Фамилия сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        public Employee(string serName, string position)
        {
            _serName = serName;
            _position = position;
        }

        /// <summary>
        /// Деструктор класса
        /// </summary>
        public void EmployeeDestructor()
        {
            _serName = null;
            _position = null;
        }

        #endregion

        #region Описание методов класса

        /// <summary>
        /// Функция выполняет вывод сотрудников
        /// </summary>
        public void GetSerNameAndPosition2()
        {
            Console.WriteLine($"Фамилия : {_serName}, должность : {_position}");
        }

        /// <summary>
        /// Функция вызвращает фамилию сотрудника
        /// </summary>
        /// <returns>Фамилия сотрудника</returns>
        public string GetSerName()
        {
            return $"Ф: {_serName}";
        }

        /// <summary>
        /// Функция вызвращает должность сотрудника
        /// </summary>
        /// <returns>Должность сотрудника</returns>
        public string GetPosition()
        {
            return $"Д: {_position}";
        }

        #endregion
    }
}
