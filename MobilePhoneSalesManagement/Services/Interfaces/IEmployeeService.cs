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

        /// <summary>
        /// Chỉnh sửa thông tin nhân viên theo ID
        /// </summary>
        void EditEmployee();
        void AddSampleData();
        void DeleteEmployeeByModel(); 
        void SearchById();
        void SearchByName();
        void SearchByPosition();
        void SortById();
        void SortByName();
        void SortByPosition();
        void SortByGender();
        void FindMinSalary();
        void FindMaxSalary();
        void FindMinAge();
        void FindMaxAge();
        void CountEmployeesByPosition();
        void TotalByEducation();
        void CalculateAverageAgeByGender();
        void CountEmployeesByGender();
        void CountEmployeesByEducation();
        void GroupStatisticsByGender();
        void WarnEmployeesNearRetirement();
        void GroupStatisticsByEducation();
        void PercentageStatisticsByGender();
        void GroupStatisticsBySalary();
    }
}
