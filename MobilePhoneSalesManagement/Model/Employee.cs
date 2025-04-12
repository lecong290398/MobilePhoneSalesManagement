using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Model
{
    public class Employee
    {
        // Các thuộc tính của nhân viên
        public string Id { get; set; }  // Mã nhân viên
        public string Name { get; set; }  // Tên nhân viên
        public DateTime BirthDate { get; set; }  // Ngày sinh
        public string Position { get; set; }  // Chức vụ
        public double Salary { get; set; }  // Lương
        public string Address { get; set; }  // Địa chỉ
        public string PhoneNumber { get; set; }  // Số điện thoại
        public string Email { get; set; }  // Email
        public string Gender { get; set; }  // Giới tính (ví dụ: Nam, Nữ, Khác)
        public string Education { get; set; }  // Bằng cấp (ví dụ: Cử nhân, Thạc sĩ)

        // Constructor mặc định
        public Employee()
        {
        }

        // Constructor với các tham số
        public Employee(string id, string name, DateTime birthDate, string position, double salary, string address, string phoneNumber, string email, string gender, string education)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Position = position;
            Salary = salary;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
            Education = education;
        }

        // Phương thức để hiển thị thông tin nhân viên
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Birth Date: {BirthDate.ToShortDateString()}, Position: {Position}, Salary: {Salary:N0}, Address: {Address}, Phone: {PhoneNumber}, Email: {Email}, Gender: {Gender}, Education: {Education}";
        }
    }
}
