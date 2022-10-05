using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kursovaya
{
    /// <summary>
    /// Класс, описывающий отдел какой-либо компании
    /// </summary>
    public class Department
    {
        #region Описание свойств класса

        /// <summary>
        /// Название отдела
        /// </summary>
        private string _nameOfDepartment { get; set; }

        /// <summary>
        /// Список всех сотрудников отдела
        /// </summary>
        private List<Employee> _departmentStaff { get; set; }

        /// <summary>
        /// Кол-во сотрудников отдела
        /// </summary>
        private int _countOfDepartmentStaff { get; set; }

        #endregion

        #region Описание конструктора и деструктора класса

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Department(string nameOfDepartment)
        {
            _nameOfDepartment = nameOfDepartment;
            _departmentStaff = new List<Employee>();
            _countOfDepartmentStaff = 0;

            Console.Write("\nВведите кол-во сотрудников: ");
            var count = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < count; i++)
            {
                Console.Write($"Введите фамилию сотрудника №{i}: ");
                var serName = Console.ReadLine();

                Console.Write($"Введите должность сотрудника №{i}: ");
                var position = Console.ReadLine();

                AddNewEmployee(serName, position);
            }
        }

        /// <summary>
        /// Второй конструктор класса, используется для работы с файлом
        /// </summary>
        /// <param name="nameOfDepartment">Название отдела</param>
        /// <param name="serName">Фамилия сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        public Department(string nameOfDepartment, string serName, string position)
        {
            _nameOfDepartment = nameOfDepartment;
            _departmentStaff = new List<Employee>();
            _countOfDepartmentStaff = 0;

            if (serName != "" && position != "")
            {
                AddNewEmployee(serName, position);
            }
        }

        /// <summary>
        /// Деструктор класса
        /// </summary>
        public void DepartmentDestructor()
        {
            _nameOfDepartment = null;
            _departmentStaff = null;
            _countOfDepartmentStaff = 0;
        }

        #endregion

        #region Описание методов класса

        /// <summary>
        /// Функция добавления нового сотрудника
        /// </summary>
        /// <param name="serName">Фамилия сотрудника</param>
        /// <param name="position">Должность сотрудника</param>
        public void AddNewEmployee(string serName, string position)
        {
            var newEmployee = new Employee(serName, position); // Композиция сотрудников

            _departmentStaff.Add(newEmployee);
            _countOfDepartmentStaff++;
        }

        /// <summary>
        /// Функция выводит название отделов и выполняет вывод сотрудников
        /// </summary>
        public void GetNameOfDepartment2()
        {
            Console.WriteLine($"Название отдела: {_nameOfDepartment}");

            foreach (var el in _departmentStaff)
            {
                el.GetSerNameAndPosition2();
            }
        }

        /// <summary>
        /// Функция возвращает название отдела
        /// </summary>
        /// <returns>Название отдела</returns>
        public string GetNameOfDepartment()
        {
            return _nameOfDepartment;
        }

        /// <summary>
        /// Функция возвращает список с сотрудниками отдела
        /// </summary>
        /// <returns>Список с сотрудниками отдела</returns>
        public List<Employee> GetAllEmployee()
        {
            return _departmentStaff;
        }

        #endregion
    }
}
