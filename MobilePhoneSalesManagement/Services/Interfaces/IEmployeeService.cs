using MobilePhoneSalesManagement.DataStructures;
using MobilePhoneSalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Services.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Thêm nhân viên mới vào danh sách
        /// </summary>
        void AddEmployee();
        void ReadEmployeeFromFile();
        /// <summary>
        /// Chỉnh sửa thông tin nhân viên theo ID
        /// </summary>
        Employee? EditEmployee();
        void AddSampleData();
        Employee? DeleteEmployeeByModel();
        Employee? SearchById();
        SinglyLinkedList<Employee> SearchByName();
        SinglyLinkedList<Employee> SearchByPosition();
        SinglyLinkedList<Employee> SortById();
        SinglyLinkedList<Employee> SortByName();
        SinglyLinkedList<Employee> SortByPosition();
        SinglyLinkedList<Employee> SortByGender();
        Employee? FindMinSalary();
        Employee? FindMaxSalary();
        Employee? FindMinAge();
        Employee? FindMaxAge();
        int CountEmployeesByPosition();
        int TotalByEducation();
        double CalculateAverageAgeByGender();
        int CountEmployeesByGender();
        int CountEmployeesByEducation();
        Dictionary<string, int> GroupStatisticsByGender();
        SinglyLinkedList<Employee> WarnEmployeesNearRetirement();
        Dictionary<string, int> GroupStatisticsByEducation();
        Dictionary<string, double> PercentageStatisticsByGender();
        SinglyLinkedList<Employee> GroupStatisticsBySalary();
    }
}
