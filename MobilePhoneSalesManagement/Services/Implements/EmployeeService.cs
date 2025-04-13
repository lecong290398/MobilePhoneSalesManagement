using MobilePhoneSalesManagement.DataStructures;
using MobilePhoneSalesManagement.Model;
using MobilePhoneSalesManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileEmployeeSalesManagement.Services.Implements
{
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// Danh sách liên kết chứa các đối tượng nhân viên
        /// </summary>
        public SinglyLinkedList<Employee> _employeeList;

        /// <summary>
        /// Dịch vụ xử lý file, cung cấp các phương thức để đọc và ghi dữ liệu từ/đến tệp.
        /// </summary>
        public IFileService _fileService;

        /// <summary>
        /// Dịch vụ xử lý các tình huống hoặc kịch bản liên quan đến nhân viên
        /// </summary>
        public IScenarioService _scenarioService;

        /// <summary>
        /// Đường dẫn đến tệp JSON chứa dữ liệu danh sách nhân viên
        /// </summary>
        public string _filePath;

        /// <summary>
        /// Constructor của lớp EmployeeService. Phương thức này khởi tạo các thành phần cần thiết cho dịch vụ quản lý danh sách nhân viên
        /// </summary>
        /// <param name="fileService">Dịch vụ xử lý file, cung cấp các phương thức để đọc và ghi dữ liệu từ/đến tệp.</param>
        /// <param name="scenarioService">Dịch vụ xử lý các tình huống hoặc kịch bản liên quan đến danh sách liên kết đơn</param>
        public EmployeeService(IFileService fileService, IScenarioService scenarioService)
        {
            // Khởi tạo danh sách nhân viên rỗng
            _employeeList = new SinglyLinkedList<Employee>();

            // Gán giá trị cho dịch vụ xử lý file
            _fileService = fileService;

            // Lấy đường dẫn đến thư mục dự án (ba thư mục cấp trên từ thư mục hiện tại)
            string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

            // Kết hợp đường dẫn dự án với đường dẫn đến tệp JSON chứa dữ liệu danh sách nhân viên
            _filePath = Path.Combine(projectDir, "Data\\employee.json");

            // Gán giá trị cho dịch vụ kịch bản
            _scenarioService = scenarioService;

            // Khởi tạo danh sách nhân viên với dữ liệu từ file
            _employeeList = _fileService.GetAll<Employee>(_filePath);
        }

        #region Function

        // Phương thức để tạo dữ liệu mẫu với 20 nhân viên ở Việt Nam
        public void AddSampleData()
        {
            // Tạo danh sách nhân viên mẫu với thông tin Việt Nam
            Employee[] employeeArray = new Employee[]
                {
                new Employee("E001", "Nguyễn Văn A", new DateTime(1985, 5, 15), "Quản lý", 15000000, "123 Đường Lê Lợi, TP.HCM", "0912345678", "nguyen.a@example.vn", "Nam", "Cử nhân"),
                new Employee("E002", "Trần Thị B", new DateTime(1990, 8, 25), "Kế toán", 12000000, "456 Đường Nguyễn Huệ, Hà Nội", "0987654321", "tran.b@example.vn", "Nữ", "Thạc sĩ"),
                new Employee("E003", "Phan Văn C", new DateTime(1987, 3, 30), "Nhân viên", 10000000, "789 Đường Hoàng Quốc Việt, Đà Nẵng", "0976543210", "phan.c@example.vn", "Nam", "Tiến sĩ"),
                new Employee("E004", "Lê Thị D", new DateTime(1982, 7, 20), "Nhân sự", 13000000, "101 Đường Tôn Đức Thắng, TP.HCM", "0965432109", "le.d@example.vn", "Nữ", "Cử nhân"),
                new Employee("E005", "Vũ Minh E", new DateTime(1995, 11, 10), "Kinh doanh", 11000000, "202 Đường Trần Phú, Hà Nội", "0908765432", "vu.e@example.vn", "Nam", "Cử nhân"),
                new Employee("E006", "Ngô Thị F", new DateTime(1984, 12, 5), "Marketing", 14000000, "305 Đường Phan Đình Phùng, TP.HCM", "0912345679", "ngo.f@example.vn", "Nữ", "Thạc sĩ"),
                new Employee("E007", "Bùi Quang G", new DateTime(1988, 6, 25), "Quản lý", 16000000, "406 Đường Nguyễn Trãi, Hà Nội", "0923456789", "bui.g@example.vn", "Nam", "Cử nhân"),
                new Employee("E008", "Nguyễn Thị H", new DateTime(1993, 9, 18), "Thiết kế", 13000000, "507 Đường Phạm Ngọc Thạch, Đà Nẵng", "0934567890", "nguyen.h@example.vn", "Nữ", "Cử nhân"),
                new Employee("E009", "Đặng Quốc I", new DateTime(1986, 1, 30), "Hỗ trợ IT", 11000000, "608 Đường Lý Thường Kiệt, TP.HCM", "0945678901", "dang.i@example.vn", "Nam", "Cử nhân"),
                new Employee("E010", "Hoàng Lan J", new DateTime(1994, 3, 22), "Nhân sự", 12500000, "709 Đường Lê Quang Đạo, Hà Nội", "0956789012", "hoang.j@example.vn", "Nữ", "Thạc sĩ"),
                new Employee("E011", "Lâm Hữu K", new DateTime(1989, 11, 10), "Kinh doanh", 11500000, "810 Đường Hùng Vương, TP.HCM", "0967890123", "lam.k@example.vn", "Nam", "Tiến sĩ"),
                new Employee("E012", "Lê Thiên L", new DateTime(1992, 7, 12), "Lập trình viên", 14000000, "911 Đường Cầu Giấy, Hà Nội", "0978901234", "le.l@example.vn", "Nữ", "Cử nhân"),
                new Employee("E013", "Nguyễn Ngọc M", new DateTime(1980, 4, 3), "Quản lý", 15000000, "102 Đường Thanh Niên, TP.HCM", "0989012345", "nguyen.m@example.vn", "Nam", "Thạc sĩ"),
                new Employee("E014", "Trương Thị N", new DateTime(1991, 10, 8), "Kế toán", 12500000, "203 Đường Nguyễn Xiển, Đà Nẵng", "0990123456", "truong.n@example.vn", "Nữ", "Cử nhân"),
                new Employee("E015", "Phan Thanh O", new DateTime(1983, 2, 18), "Kinh doanh", 12000000, "304 Đường Quang Trung, TP.HCM", "0901234567", "phan.o@example.vn", "Nam", "Thạc sĩ"),
                new Employee("E016", "Nguyễn Thị P", new DateTime(1996, 5, 17), "Hỗ trợ khách hàng", 10000000, "405 Đường Hà Huy Tập, Hà Nội", "0912345670", "nguyen.p@example.vn", "Nữ", "Cử nhân"),
                new Employee("E017", "Lê Hữu Q", new DateTime(1984, 8, 25), "Lập trình viên", 14500000, "506 Đường Trần Duy Hưng, TP.HCM", "0923456780", "le.q@example.vn", "Nam", "Tiến sĩ"),
                new Employee("E018", "Hoàng Thị R", new DateTime(1997, 1, 15), "Marketing", 13000000, "607 Đường Láng, Hà Nội", "0934567892", "hoang.r@example.vn", "Nữ", "Cử nhân"),
                new Employee("E019", "Đoàn Thị S", new DateTime(1994, 5, 30), "Kinh doanh", 13500000, "708 Đường Hoàng Mai, TP.HCM", "0945678903", "doan.s@example.vn", "Nữ", "Thạc sĩ"),
                new Employee("E020", "Vũ Hữu T", new DateTime(1985, 7, 10), "Quản lý", 15000000, "809 Đường Đông Ngạc, Hà Nội", "0956789014", "vu.t@example.vn", "Nam", "Cử nhân")
            };
            // Thêm các điện thoại mẫu vào danh sách nếu chưa tồn tại
            foreach (var dt in employeeArray)
            {
                _employeeList.Add(dt);
            }

            // Lưu danh sách điện thoại vào file JSON
            foreach (var nv in employeeArray)
            {
                _fileService.Add(nv, _filePath);
            }
            Console.WriteLine($"Điện thoại 40 Item mẫu của đối tượng điện thoại đã được thêm.");

        }

        #region Nhập - In - Xóa - Sửa - Lưu trữ - danh sách nhân viên

        /// <summary>
        /// Thêm nhân viên vào danh sách
        /// </summary>
        public void AddEmployee()
        {
            bool isAdding = true;
            while (isAdding)
            {
                // Nhập thông tin nhân viên từ người dùng
                Console.Write("Id nhân viên: ");
                string id;
                while (true)
                {
                    Console.Write("Mã: ");
                    id = Console.ReadLine();
                    var foundDienThoai = _scenarioService.SearchObjectByAttribute(_employeeList, "Id", id);
                    if (foundDienThoai != null)
                    {
                        Console.WriteLine("! ID nhân viên là tồn duy nhất, không trùng lập, vui lòng nhập lại !");
                    }
                    else
                    {
                        break;
                    }
                }


                Console.Write("Tên nhân viên: ");
                string name = Console.ReadLine();

                Console.Write("Ngày sinh (dd/MM/yyyy): ");
                DateTime birthDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Console.Write("Chức vụ: ");
                string position = Console.ReadLine();

                Console.Write("Lương: ");
                double salary = double.Parse(Console.ReadLine());

                Console.Write("Địa chỉ: ");
                string address = Console.ReadLine();

                Console.Write("Số nhân viên: ");
                string phoneNumber = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                Console.Write("Giới tính (Nam/Nữ): ");
                string gender = Console.ReadLine();

                Console.Write("Bằng cấp: ");
                string education = Console.ReadLine();

                // Tạo đối tượng nhân viên mới
                Employee newEmployee = new Employee(id, name, birthDate, position, salary, address, phoneNumber, email, gender, education);

                _employeeList.Add(newEmployee);
                _fileService.Add(newEmployee, _filePath);
                Console.WriteLine("nhân viên đã được thêm.");
                Console.WriteLine(newEmployee.ToString());
                Console.WriteLine("\nBạn có muốn thêm nhân viên khác không? (y/n): ");
                string response = Console.ReadLine();
                if (response.ToLower() != "y")
                {
                    isAdding = false;
                    Console.Clear();
                    return;
                }
            }
        }

        /// <summary>
        /// Đọc danh sách nhân viên từ file
        /// </summary>
        public void ReadEmployeeFromFile()
        {
            _employeeList = _fileService.GetAll<Employee>(_filePath);
            if (_employeeList.Head == null)
            {
                Console.WriteLine("X Danh sách nhân viên rỗng.");
            }
            else
            {
                Console.WriteLine("Danh sách nhân viên đã được đọc từ file.");
                PrintEmployeeList(_employeeList);
            }
        }

        /// <summary>
        /// In danh sách nhân viên 
        /// </summary>
        /// <param name="dienThoaiList">Danh sách nhân viên cần hiển thị</param>
        public void PrintEmployeeList(SinglyLinkedList<Employee>? employeeList)
        {
            // Kiểm tra danh sách nhân viên rỗng
            if (employeeList == null || employeeList.Head == null)
            {
                Console.WriteLine("X Danh sách nhân viên rỗng.");
                return;
            }

            // Hiển thị tiêu đề
            Console.WriteLine("\n=== DANH SÁCH NHÂN VIÊN ===");
            Console.WriteLine(new string('-', 200));
            Console.WriteLine(
                "Id".PadRight(10) +
                "Tên".PadRight(25) +
                "Ngày Sinh".PadRight(15) +
                "Chức Vụ".PadRight(25) +
                "Lương".PadRight(15) +
                "Địa Chỉ".PadRight(50) +
                "SĐT".PadRight(15) +
                "Email".PadRight(25) +
                "Giới Tính".PadRight(12) +
                "Bằng Cấp".PadRight(15)
            );
            Console.WriteLine(new string('-', 200));

            var node = employeeList.Head;
            while (node != null)
            {
                var employee = node.Data;
                // In thông tin của từng nhân viên
                Console.WriteLine(
                    employee.Id.PadRight(10) +
                    employee.Name.PadRight(25) +
                    employee.BirthDate.ToShortDateString().PadRight(15) +
                    employee.Position.PadRight(25) +
                    $"{employee.Salary:N0}".PadRight(15) +
                    employee.Address.PadRight(50) +
                    employee.PhoneNumber.PadRight(15) +
                    employee.Email.PadRight(25) +
                    employee.Gender.PadRight(12) +
                    employee.Education.PadRight(15)
                );
                node = node.Next;
            }
            Console.WriteLine(new string('-', 200));
        }


        /// <summary>
        /// In thông tin nhân viên 
        /// </summary>
        /// <param name="dt">nhân viên cần hiển thị</param>
        public void PrintEmployee(Employee employee)
        {
            // In dòng phân cách
            Console.WriteLine(new string('-', 110));

            // In tiêu đề
            Console.WriteLine(
                "Id".PadRight(10) +
                "Tên".PadRight(25) +
                "Ngày Sinh".PadRight(15) +
                "Chức Vụ".PadRight(15) +
                "Lương".PadRight(15) +
                "Địa Chỉ".PadRight(20) +
                "Số nhân viên".PadRight(15) +
                "Email".PadRight(25) +
                "Giới Tính".PadRight(12) +
                "Bằng Cấp".PadRight(15)
            );
            Console.WriteLine(new string('-', 110));

            // In thông tin của nhân viên
            Console.WriteLine(
                employee.Id.PadRight(10) +
                employee.Name.PadRight(25) +
                employee.BirthDate.ToShortDateString().PadRight(15) +
                employee.Position.PadRight(15) +
                $"{employee.Salary:N0}".PadRight(15) +
                employee.Address.PadRight(20) +
                employee.PhoneNumber.PadRight(15) +
                employee.Email.PadRight(25) +
                employee.Gender.PadRight(12) +
                employee.Education.PadRight(15)
            );

            // In dòng phân cách
            Console.WriteLine(new string('-', 110));
        }


        /// <summary>
        /// Xóa nhân viên theo id
        /// </summary>
        public Employee? DeleteEmployeeByModel()
        {
            Console.Write("Nhập id nhân viên cần xoá: ");
            string id = Console.ReadLine();
            var dataDienThoai = _scenarioService.DeleteByAttributes(_employeeList, "Id", id);
            _fileService.Delete(dataDienThoai, _filePath, "Id", id);
            return dataDienThoai;
        }

        public Employee? EditEmployee()
        {
            Console.Write("Nhập Id nhân viên bạn muốn chỉnh sửa: ");
            string id = Console.ReadLine();
            var updatedEmployee = EditEmployeeById(_employeeList, id);

            if (updatedEmployee != null)
            {
                Console.WriteLine($" nhân viên đã được chỉnh sửa:");
                PrintEmployee(updatedEmployee);
                _fileService.Update(updatedEmployee, "Id", id, _filePath);
            }
            return updatedEmployee;
        }

        #endregion


        #region Tìm kiếm 
        // Tìm kiếm theo Id
        public Employee? SearchById()
        {
            Console.Write("Nhập Id nhân viên: ");
            string ma = Console.ReadLine();
            // Tìm kiếm đối tượng theo Id
            var foundDienThoai = _scenarioService.SearchObjectByAttribute(_employeeList, "Code", ma);
            if (foundDienThoai != null)
            {
                Console.WriteLine($"Tìm thấy nhân viên với Id : {ma} ");
                PrintEmployee(foundDienThoai);
                return foundDienThoai;
            }
            else
            {
                Console.WriteLine($"X Không tìm thấy nhân viên với Id {ma} này.");
                return null;
            }
        }

        // Tìm kiếm theo tên
        public SinglyLinkedList<Employee> SearchByName()
        {
            Console.Write("Nhập tên nhân viên: ");
            string ten = Console.ReadLine();
            var foundEmployee = _scenarioService.SearchObjectListByAttributes(_employeeList, "Name", ten);
            if (foundEmployee != null)
            {
                Console.WriteLine($"Tìm thấy nhân viên với Tên : {ten} ");
                PrintEmployeeList(foundEmployee);
                return foundEmployee;
            }
            else
            {
                Console.WriteLine($"X Không tìm thấy nhân viên với tên {ten} này.");
                return new SinglyLinkedList<Employee>();
            }
        }

        // Tìm kiếm theo vị trí
        public SinglyLinkedList<Employee> SearchByPosition()
        {
            Console.Write("Nhập hãng nhân viên: ");
            string viTri = Console.ReadLine();
            var foundEmployee = _scenarioService.SearchObjectListByAttributes(_employeeList, "Position", viTri);
            if (foundEmployee != null)
            {
                Console.WriteLine($"Tìm thấy nhân viên với tên vị trí : {viTri} ");
                PrintEmployeeList(foundEmployee);
                return foundEmployee;
            }
            else
            {
                Console.WriteLine($"X Không tìm thấy nhân viên với vị trí {viTri} này.");
                return new SinglyLinkedList<Employee>();
            }
        }

        #endregion

        #region Sắp xếp

        public SinglyLinkedList<Employee> SortById()
        {
            var ascending = ValidateSortOrder();
            var sortedEmployeeList = _scenarioService.SortByAttributes(_employeeList, "Id", ascending);
            if (sortedEmployeeList != null)
            {
                Console.WriteLine("Danh sách đã được sắp xếp theo mã nhân viên.");
                PrintEmployeeList(sortedEmployeeList);
                return sortedEmployeeList;
            }
            return new SinglyLinkedList<Employee>();
        }

        // 4.2 Sắp xếp theo tên nhân viên
        public SinglyLinkedList<Employee> SortByName()
        {
            var ascending = ValidateSortOrder();
            var sortedEmployeeList = _scenarioService.SortByAttributes(_employeeList, "Name", ascending);
            if (sortedEmployeeList != null)
            {
                Console.WriteLine("Danh sách đã được sắp xếp theo tên nhân viên.");
                PrintEmployeeList(sortedEmployeeList);
                return sortedEmployeeList;
            }
            return new SinglyLinkedList<Employee>();
        }

        // Sắp xếp theo chức vụ (Position)
        public SinglyLinkedList<Employee> SortByPosition()
        {
            var ascending = ValidateSortOrder();
            var sortedEmployeeList = _scenarioService.SortByAttributes(_employeeList, "Position", ascending);
            if (sortedEmployeeList != null)
            {
                Console.WriteLine("Danh sách đã được sắp xếp theo chức vụ.");
                PrintEmployeeList(sortedEmployeeList);
            }
            return new SinglyLinkedList<Employee>();

        }

        // Sắp xếp theo giới tính (Gender)
        public SinglyLinkedList<Employee> SortByGender()
        {
            var ascending = ValidateSortOrder();
            var sortedEmployeeList = _scenarioService.SortByAttributes(_employeeList, "Gender", ascending);
            if (sortedEmployeeList != null)
            {
                Console.WriteLine("Danh sách đã được sắp xếp theo giới tính.");
                PrintEmployeeList(sortedEmployeeList);
            }
            return new SinglyLinkedList<Employee>();

        }


        #endregion

        #region Min/Max

        // Tìm phần tử nhân viên có lương cao nhất
        public Employee? FindMaxSalary()
        {
            var maxEmployee = _scenarioService.FindMaxByAttributes(_employeeList, "Salary");
            Console.WriteLine($"Nhân viên có lương cao nhất:");
            PrintEmployee(maxEmployee);
            return maxEmployee;
        }
        // Tìm phần tử nhân viên có lương thấp nhất
        public Employee? FindMinSalary()
        {
            var minEmployee = _scenarioService.FindMinByAttributes(_employeeList, "Salary");
            Console.WriteLine($"Nhân viên có lương thấp nhất:");
            PrintEmployee(minEmployee);
            return minEmployee;
        }

        // Tìm phần tử nhân viên có tuổi cao nhất
        public Employee? FindMaxAge()
        {
            var maxAgeEmployee = _scenarioService.FindMaxByAttributes(_employeeList, "Age");
            Console.WriteLine($"Nhân viên có tuổi cao nhất:");
            PrintEmployee(maxAgeEmployee);
            return maxAgeEmployee;
        }
        // Tìm phần tử nhân viên có tuổi thấp nhất
        public Employee? FindMinAge()
        {
            var minAgeEmployee = _scenarioService.FindMinByAttributes(_employeeList, "Age");
            Console.WriteLine($"Nhân viên có tuổi thấp nhất:");
            PrintEmployee(minAgeEmployee);
            return minAgeEmployee;
        }


        #endregion

        #region  Tính tổng, trung bình, điếm

        public int CountEmployeesByPosition()
        {
            // Nhập vị trí (chức vụ) cần đếm
            Console.Write("Nhập vị trí (chức vụ) nhân viên cần đếm: ");
            string position = Console.ReadLine();

            // Sử dụng phương thức CountByAttributes để đếm số nhân viên theo vị trí
            var count = _scenarioService.CountByAttributes(_employeeList, "Position", position);

            // In ra kết quả đếm
            Console.WriteLine($"\nCó {count} nhân viên ở vị trí {position}");
            return count;
        }

        public int TotalByEducation()
        {
            Console.Write("Nhập bằng cấp cần tính tổng số lượng: ");
            string education = Console.ReadLine();

            // Sử dụng phương thức SumByAttributes để tính tổng số lượng nhân viên theo bằng cấp
            var sum = _scenarioService.SumByAttributes(_employeeList, "Education", education, "Salary");

            Console.WriteLine($"\nTổng lương của nhân viên có bằng cấp {education} là {sum:N0}");
            return sum;
        }

        public double CalculateAverageAgeByGender()
        {
            // Nhập giới tính cần tính trung bình tuổi
            Console.Write("Nhập giới tính cần tính trung bình tuổi: ");
            string gender = Console.ReadLine();

            // Sử dụng phương thức AverageByAttributes để tính trung bình tuổi của nhân viên theo giới tính
            var averageAge = _scenarioService.AverageByAttributes(_employeeList, "Gender", gender, "Age");

            // In kết quả
            Console.WriteLine($"\nTuổi trung bình của nhân viên giới tính \"{gender}\" là: {averageAge:N0} tuổi");
            return averageAge;
        }

        public int CountEmployeesByGender()
        {
            // Nhập giới tính cần đếm
            Console.Write("Nhập giới tính cần đếm (Nam/Nữ/Khác): ");
            string gender = Console.ReadLine();

            // Sử dụng phương thức CountByAttributes để đếm số nhân viên theo giới tính
            var count = _scenarioService.CountByAttributes(_employeeList, "Gender", gender);

            // In kết quả
            Console.WriteLine($"\nCó {count} nhân viên giới tính {gender}");
            return count;
        }

        public int CountEmployeesByEducation()
        {
            // Nhập học vấn cần đếm
            Console.Write("Nhập học vấn cần đếm (Cử nhân/Thạc sĩ/Tiến sĩ): ");
            string education = Console.ReadLine();

            // Sử dụng phương thức CountByAttributes để đếm số nhân viên theo học vấn
            var count = _scenarioService.CountByAttributes(_employeeList, "Education", education);

            // In kết quả
            Console.WriteLine($"\nCó {count} nhân viên có học vấn {education}");
            return count;
        }

        #endregion

        #region  Thống kê 

        public Dictionary<string, int> GroupStatisticsByGender()
        {
            // Sử dụng phương thức CountByGroup để nhóm nhân viên theo giới tính và đếm số lượng trong mỗi nhóm
            var thongKe = _scenarioService.CountByGroup(_employeeList, "Gender");

            if (thongKe == null || thongKe.Count == 0)
            {
                Console.WriteLine("Không có dữ liệu để thống kê.");
                return new Dictionary<string, int>();
            }

            // In ra tiêu đề và các thông tin thống kê
            Console.WriteLine("=== Số lượng nhân viên theo giới tính:");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("{0,-15} | {1,5}", "Giới tính", "Số nhân viên");
            Console.WriteLine("-------------------------------");

            // Lặp qua các nhóm (Giới tính) và in ra số lượng nhân viên trong mỗi nhóm
            foreach (var kv in thongKe)
            {
                Console.WriteLine("{0,-15} | {1,5}", kv.Key, kv.Value);
            }
            return thongKe;
        }

        public SinglyLinkedList<Employee> WarnEmployeesNearRetirement()
        {
            // Đặt tuổi nghỉ hưu cho nam và nữ
            int retirementAgeForMen = 60;
            int retirementAgeForWomen = 55;
            int retirementThreshold = 2;  // Khoảng 1-2 năm trước tuổi nghỉ hưu

            // Kiểm tra danh sách nhân viên
            if (_employeeList.Head == null)
            {
                Console.WriteLine("Không có dữ liệu để thống kê.");
                return new SinglyLinkedList<Employee>();
            }

            // Lọc nhân viên gần đến tuổi nghỉ hưu
            var employeesNearRetirement = new SinglyLinkedList<Employee>();

            var node = _employeeList.Head;
            while (node != null)
            {
                var employee = node.Data;
                int age = DateTime.Now.Year - employee.BirthDate.Year;

                // Kiểm tra nếu nhân viên gần đến tuổi nghỉ hưu
                if ((employee.Gender == "Nam" && age >= retirementAgeForMen - retirementThreshold && age <= retirementAgeForMen) ||
                    (employee.Gender == "Nữ" && age >= retirementAgeForWomen - retirementThreshold && age <= retirementAgeForWomen))
                {
                    employeesNearRetirement.Add(employee);
                }

                node = node.Next;
            }

            // Kiểm tra nếu có nhân viên gần đến tuổi nghỉ hưu
            if (employeesNearRetirement.Head == null)
            {
                Console.WriteLine("Không có nhân viên sắp hết tuổi lao động.");
                return new SinglyLinkedList<Employee>();
            }

            // In thông tin nhân viên gần đến tuổi nghỉ hưu
            Console.WriteLine("=== Nhân viên sắp hết tuổi lao động ===");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("{0,-10} | {1,-25} | {2,-10} | {3,-10}", "Mã", "Tên", "Giới tính", "Tuổi");
            Console.WriteLine("---------------------------------------------------------");

            node = employeesNearRetirement.Head;
            while (node != null)
            {
                var employee = node.Data;
                int age = DateTime.Now.Year - employee.BirthDate.Year;
                Console.WriteLine("{0,-10} | {1,-25} | {2,-10} | {3,-10}", employee.Id, employee.Name, employee.Gender, age);
                node = node.Next;
            }

            Console.WriteLine("---------------------------------------------------------");
            return employeesNearRetirement;
        }

        public Dictionary<string, int> GroupStatisticsByEducation()
        {
            // Sử dụng phương thức CountByGroup để nhóm nhân viên theo bằng cấp và đếm số lượng trong mỗi nhóm
            var thongKe = _scenarioService.CountByGroup(_employeeList, "Education");

            if (thongKe == null || thongKe.Count == 0)
            {
                Console.WriteLine("Không có dữ liệu để thống kê.");
                return new Dictionary<string, int>();
            }

            // In ra tiêu đề và các thông tin thống kê
            Console.WriteLine("=== Số lượng nhân viên theo bằng cấp:");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("{0,-15} | {1,5}", "Bằng cấp", "Số nhân viên");
            Console.WriteLine("-------------------------------");

            // Lặp qua các nhóm (Bằng cấp) và in ra số lượng nhân viên trong mỗi nhóm
            foreach (var kv in thongKe)
            {
                Console.WriteLine("{0,-15} | {1,5}", kv.Key, kv.Value);
            }
            return thongKe;
        }

        public Dictionary<string, double> PercentageStatisticsByGender()
        {
            var thongKe = TinhPhanTramTheoThuocTinh(_employeeList, "Gender");

            if (thongKe == null || thongKe.Count == 0)
            {
                Console.WriteLine("Không có dữ liệu để thống kê.");
                return new Dictionary<string, double>();
            }
            // In kết quả
            Console.WriteLine("Tỷ lệ phần trăm nhân viên theo giới tính:");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("{0,-10} | {1,8}%", "Giới tính", "Tỷ lệ");
            Console.WriteLine("-----------------------------------------");

            foreach (var kvp in thongKe)
            {
                Console.WriteLine("{0,-10} | {1,8:N2}%", kvp.Key, kvp.Value);
            }
            return thongKe;
        }

        public SinglyLinkedList<Employee> GroupStatisticsBySalary()
        {
            double salaryMin;
            while (true)
            {
                Console.Write("Nhập lương tối thiểu (triệu VND): ");
                if (double.TryParse(Console.ReadLine(), out salaryMin))
                    break;
                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
            }

            double salaryMax;
            while (true)
            {
                Console.Write("Nhập lương tối đa (triệu VND): ");
                if (double.TryParse(Console.ReadLine(), out salaryMax))
                    break;
                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
            }

            // Lọc nhân viên theo khoảng lương nhập vào
            var filteredEmployees = _scenarioService.FilterByRange(_employeeList, "Salary", salaryMin, salaryMax);
            if (filteredEmployees != null)
            {
                // In danh sách nhân viên sau khi lọc
                PrintEmployeeList(filteredEmployees);
                return filteredEmployees;
            }
            return new SinglyLinkedList<Employee>();
        }

        #endregion

        #endregion

        #region Private 

        private Dictionary<string, double> TinhPhanTramTheoThuocTinh<T>(SinglyLinkedList<T> list, string propertyName)
        {
            // Tính tổng số lượng theo từng thuộc tính (ví dụ: giới tính, chức vụ, v.v.)
            var totalByProperty = _scenarioService.CountByGroup(list, propertyName);

            // Tính tổng số lượng của tất cả các nhóm
            double totalAll = totalByProperty.Values.Sum();

            // Tạo dictionary để lưu trữ tỷ lệ phần trăm theo thuộc tính
            var percentage = new Dictionary<string, double>();

            // Duyệt qua từng nhóm và tính tỷ lệ phần trăm
            foreach (var kvp in totalByProperty)
            {
                // Tính tỷ lệ phần trăm (nếu tổng số lượng > 0)
                percentage[kvp.Key] = totalAll > 0 ? (kvp.Value / totalAll) * 100 : 0;
            }

            // Trả về dictionary chứa tỷ lệ phần trăm theo thuộc tính
            return percentage;
        }

        private Employee EditEmployeeById(SinglyLinkedList<Employee> list, string id)
        {
            if (list == null || list.Head == null) return null;

            // Tìm kiếm nhân viên theo Id
            var employeeToEdit = _scenarioService.SearchObjectByAttribute(list, "Id", id);

            if (employeeToEdit == null)
            {
                Console.WriteLine("X Không tìm thấy nhân viên với Id: " + id);
                return null;
            }

            Console.WriteLine($"Đang chỉnh sửa nhân viên: {employeeToEdit.Name}");

            // Yêu cầu người dùng chọn thuộc tính muốn chỉnh sửa
            Console.WriteLine("\nChọn thuộc tính bạn muốn chỉnh sửa:");
            Console.WriteLine("1. Tên");
            Console.WriteLine("2. Chức vụ");
            Console.WriteLine("3. Lương");
            Console.WriteLine("4. Địa chỉ");
            Console.WriteLine("5. Số nhân viên");
            Console.WriteLine("6. Email");
            Console.WriteLine("7. Giới tính");
            Console.WriteLine("8. Bằng cấp");

            string choice = Console.ReadLine();

            // Nhập giá trị mới tùy theo thuộc tính
            switch (choice)
            {
                case "1":
                    Console.Write("Nhập tên mới: ");
                    employeeToEdit.Name = Console.ReadLine();
                    break;

                case "2":
                    Console.Write("Nhập chức vụ mới: ");
                    employeeToEdit.Position = Console.ReadLine();
                    break;

                case "3":
                    Console.Write("Nhập lương mới: ");
                    if (double.TryParse(Console.ReadLine(), out double newSalary))
                        employeeToEdit.Salary = newSalary;
                    else
                        Console.WriteLine("Lương không hợp lệ.");
                    break;

                case "4":
                    Console.Write("Nhập địa chỉ mới: ");
                    employeeToEdit.Address = Console.ReadLine();
                    break;

                case "5":
                    Console.Write("Nhập số nhân viên mới: ");
                    employeeToEdit.PhoneNumber = Console.ReadLine();
                    break;

                case "6":
                    Console.Write("Nhập email mới: ");
                    employeeToEdit.Email = Console.ReadLine();
                    break;

                case "7":
                    Console.Write("Nhập giới tính mới (Nam/Nữ): ");
                    employeeToEdit.Gender = Console.ReadLine();
                    break;

                case "8":
                    Console.Write("Nhập bằng cấp mới: ");
                    employeeToEdit.Education = Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("X Lựa chọn không hợp lệ.");
                    return null;
            }

            Console.WriteLine("✅ Đã cập nhật thông tin nhân viên.");
            return employeeToEdit;
        }

        /// <summary>
        /// Phương thức này yêu cầu người dùng nhập lựa chọn để xác định thứ tự sắp xếp (tăng dần hoặc giảm dần).
        /// Người dùng có thể nhập "0" để sắp xếp giảm dần và "1" để sắp xếp tăng dần. Phương thức sẽ tiếp tục yêu cầu nhập lại nếu người dùng nhập sai.
        /// </summary>
        /// <returns>Trả về giá trị boolean: true nếu sắp xếp tăng dần, false nếu sắp xếp giảm dần.</returns>
        private bool ValidateSortOrder()
        {
            string input;  // Biến để lưu giá trị nhập vào từ người dùng
            bool ascending;  // Biến lưu trữ kết quả sắp xếp (tăng dần hoặc giảm dần)

            while (true)
            {
                // Yêu cầu người dùng nhập lựa chọn sắp xếp
                Console.Write("Lựa chọn sắp xếp 0 (Giảm) / 1 (Tăng) : ");
                input = Console.ReadLine();

                // Kiểm tra nếu người dùng nhập "1" để sắp xếp tăng dần
                if (input == "1")
                {
                    ascending = true;
                    break;  // Thoát khỏi vòng lặp khi nhập hợp lệ
                }
                // Kiểm tra nếu người dùng nhập "0" để sắp xếp giảm dần
                else if (input == "0")
                {
                    ascending = false;
                    break;  // Thoát khỏi vòng lặp khi nhập hợp lệ
                }
                else
                {
                    // Thông báo lỗi nếu người dùng nhập không hợp lệ và yêu cầu nhập lại
                    Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng nhập 0 (Giảm) hoặc 1 (Tăng).");
                }
            }
            return ascending;
        }

        #endregion
    }
}
