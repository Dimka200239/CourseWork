using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kursovaya
{
    /// <summary>
    ///  Класс, описывающий какую-либо компанию
    /// </summary>
    public class Company
    {
        #region Описание свойств класса

        /// <summary>
        /// Название компании
        /// </summary>
        private string _nameOfCompany { get; set; }

        /// <summary>
        /// Список всех отделов компании
        /// </summary>
        private List<Department> _companyDepartments { get; set; }

        /// <summary>
        /// Кол-во отделов компании
        /// </summary>
        private int _countOfCompanyDepartments { get; set; }

        #endregion

        #region Описание конструктора и деструктора класса

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Company(string nameOfCompany)
        {
            _nameOfCompany = nameOfCompany;
            _companyDepartments = new List<Department>();
            _countOfCompanyDepartments = 0;

            Console.Write("\nВведите кол-во отделов: ");
            var count = Convert.ToInt32(Console.ReadLine());

            for ( var i = 0; i < count; i++)
            {
                Console.Write($"\nВведите название отдела №{i}: ");
                var name = Console.ReadLine();

                AddNewDepartment(name);
            }
        }

        /// <summary>
        /// Второй конструктор класса, используется для работы с файлом
        /// </summary>
        /// <param name="nameOfCompany">Название компании</param>
        /// <param name="nameOfDepartment">Название отдела</param>
        /// <param name="serName">Фамилия сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        public Company(string nameOfCompany, string nameOfDepartment, string serName, string position)
        {
            _nameOfCompany = nameOfCompany;
            _companyDepartments = new List<Department>();
            _countOfCompanyDepartments = 0;

            if (nameOfDepartment != "")
            {
                AddNewDepartment(nameOfDepartment, serName, position);
            }
        }

        /// <summary>
        /// Деструктор класса
        /// </summary>
        public void CompanyDestructor()
        {
            _nameOfCompany = null;
            _companyDepartments = null;
            _countOfCompanyDepartments = 0;
        }

        #endregion

        #region Описание методов класса

        /// <summary>
        /// Функция добавления нового отдела
        /// </summary>
        /// <param name="nameOfDepartment">Название отдела</param>
        public void AddNewDepartment(string nameOfDepartment)
        {
            var newDepartment = new Department(nameOfDepartment); // Композиция отделов

            _companyDepartments.Add(newDepartment);
            _countOfCompanyDepartments++;
        }

        /// <summary>
        /// Функция добавления нового отдела, используется для работы с файлом
        /// </summary>
        /// <param name="nameOfDepartment">Название отдела</param>
        /// <param name="serName">Фамилия сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        public void AddNewDepartment(string nameOfDepartment, string serName, string position)
        {
            var newDepartment = new Department(nameOfDepartment, serName, position); // Композиция отделов

            _companyDepartments.Add(newDepartment);
            _countOfCompanyDepartments++;
        }

        /// <summary>
        /// Функция выводит название компании и выполняет вывод отделов
        /// </summary>
        public void GetNameOfCompany2()
        {
            Console.WriteLine($"\n\nНазвание компании: {_nameOfCompany}");

            foreach (var el in _companyDepartments)
            {
               el.GetNameOfDepartment2();
            }
        }

        /// <summary>
        /// Функция возвращает название компании
        /// </summary>
        /// <returns>Строка - название компании</returns>
        public string GetNameOfCompany()
        {
            return _nameOfCompany;
        }

        /// <summary>
        /// Функция возвращает список с отделами
        /// </summary>
        /// <returns>Список отделов</returns>
        public List<Department> GetAllDepartment()
        {
            return _companyDepartments;
        }

        /// <summary>
        /// Функция поиска какого-то конкретного отдела
        /// </summary>
        /// <param name="nameOfDepartment">Название отдела</param>
        /// <returns>Объект класса Department</returns>
        public Department SearchDepartment(string nameOfDepartment)
        {
            if (_companyDepartments != null)
            {
                foreach (var el in _companyDepartments)
                {
                    if (el.GetNameOfDepartment() == nameOfDepartment)
                    {
                        return el;
                    }
                }

                return null;
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
