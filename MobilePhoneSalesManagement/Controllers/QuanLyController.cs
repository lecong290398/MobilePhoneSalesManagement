using MobilePhoneSalesManagement.Services.Implements;
using MobilePhoneSalesManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Controllers
{
    public class QuanLyController
    {
        private IPhoneService _dienThoaiService;
        private IEmployeeService  _employeeService;

        public QuanLyController(IPhoneService dienThoaiService, IEmployeeService employeeService)
        {
            _dienThoaiService = dienThoaiService;
            _employeeService = employeeService;
        }

        public void HienThiMenu()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("===== MENU =====");
                Console.WriteLine("1. Quản lý điện thoại");
                Console.WriteLine("2. Quản lý nhân viên");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        ProcessMenuPhone();
                        break;
                    case "2":
                        ProcessMenuEmployee();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Chọn không hợp lệ.");
                        break;
                }
            }
        }


        #region Menu - Function  - Employee

        public void ProcessMenuEmployee()
        {
            bool isStop = false;

            while (!isStop)
            {
                Console.Clear();
                Console.WriteLine("=== MENU QUẢN LÝ NHÂN VIÊN ===");
                Console.WriteLine("1. Thêm nhân viên");
                Console.WriteLine("2. Sửa thông tin nhân viên");
                Console.WriteLine("3. Xóa nhân viên");
                Console.WriteLine("4. Tìm kiếm nhân viên");
                Console.WriteLine("5. Sắp xếp nhân viên");
                Console.WriteLine("6. Tìm MIN/MAX");
                Console.WriteLine("7. Tính tổng, trung bình, điếm");
                Console.WriteLine("8. Thống kê");
                Console.WriteLine("9. Thêm dữ liệu mẫu 15 item");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _employeeService.AddEmployee();
                        break;
                    case "2":
                        _employeeService.EditEmployee();
                        break;
                    case "3":
                        _employeeService.DeleteEmployeeByModel();
                        break;
                    case "4":
                        SearchEmployee();
                        break;
                    case "5":
                        SortEmployee();
                        break;
                    case "6":
                        TimMinMaxNhanVien();
                        break;
                    case "7":
                        TinhTongTrungBinhDiemNhanVien();
                        break;
                    case "8":
                        ThongKeNhanVien();
                        break;
                    case "9":
                        _employeeService.AddSampleData();
                        break;
                    case "0":
                        isStop = false;
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                        break;
                }

                // Hỏi người dùng có muốn quay lại menu tìm kiếm hoặc quay về menu chính
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục tìm kiếm hoặc '0' để quay lại menu chính...");
                string back = Console.ReadLine();
                if (back == "0")
                {
                    isStop = true;
                    Console.Clear();
                    return; // Quay lại menu chính
                }
            }
        }
        public void SearchEmployee()
        {
            var isStop = false;
            while (!isStop)
            {
                Console.Clear();
                Console.WriteLine("===== MENU TÌM KIẾM NHÂN VIÊN =====");
                Console.WriteLine("Tìm kiếm nhân viên theo:");
                Console.WriteLine("1. ID");
                Console.WriteLine("2. Tên");
                Console.WriteLine("3. Vị trí");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn tiêu chí tìm kiếm: ");
                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        _employeeService.SearchById(); 
                        break;
                    case "2":
                        _employeeService.SearchByName(); 
                        break;
                    case "3":
                        _employeeService.SearchByPosition(); 
                        break;
                    case "0":
                        ProcessMenuEmployee();  
                        return;
                    default:
                        Console.WriteLine("Chọn không hợp lệ.");
                        break;
                }

                // Ask the user if they want to continue searching or return to the main menu
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục tìm kiếm hoặc '0' để quay lại menu chính...");
                string back = Console.ReadLine();
                if (back == "0")
                {
                    isStop = true;
                    Console.Clear();
                    ProcessMenuEmployee();  // Return to the main menu for employees
                }
            }
        }
        /// <summary>
        /// MENU Sắp xếp nhân viên theo các tiêu chí khác nhau
        /// </summary>
        public void SortEmployee()
        {
            var isStop = false;
            while (!isStop)
            {
                Console.Clear(); // Xóa màn hình
                Console.WriteLine("===== MENU SẮP XẾP NHÂN VIÊN =====");
                Console.WriteLine("Sắp xếp nhân viên theo:");
                Console.WriteLine("1. ID");
                Console.WriteLine("2. Tên");
                Console.WriteLine("3. Chức vụ");
                Console.WriteLine("4. Giới tính");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn tiêu chí sắp xếp: ");
                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        _employeeService.SortById(); // Sort by ID
                        break;
                    case "2":
                        _employeeService.SortByName(); // Sort by Name
                        break;
                    case "3":
                        _employeeService.SortByPosition(); // Sort by Position
                        break;
                    case "4":
                        _employeeService.SortByGender(); // Sort by Salary
                        break;
                    case "0":
                        Console.Clear();
                        ProcessMenuEmployee(); // Go back to main employee menu
                        break;
                    default:
                        Console.WriteLine("Chọn không hợp lệ.");
                        break;
                }

                // Ask the user if they want to continue sorting or go back to the main menu
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục sắp xếp hoặc '0' để quay lại...");
                string back = Console.ReadLine();
                if (back == "0")
                {
                    isStop = true;
                    Console.Clear();
                    ProcessMenuEmployee(); // Go back to the main employee menu
                }
            }
        }

        private void TimMinMaxNhanVien()
        {
            var isStop = false;
            while (!isStop)
            {
                Console.Clear(); // Xóa màn hình
                Console.WriteLine("===== MENU Tìm MIN/MAX NHÂN VIÊN =====");
                Console.WriteLine("Tìm min/max nhân viên theo:");
                Console.WriteLine("==Lương==");
                Console.WriteLine("1. Min Lương");
                Console.WriteLine("2. Max Lương");
                Console.WriteLine("==Tuổi==");
                Console.WriteLine("3. Min Tuổi");
                Console.WriteLine("4. Max Tuổi");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn tiêu chí tìm min/max: ");
                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        _employeeService.FindMinSalary(); // Find employee with min salary
                        break;
                    case "2":
                        _employeeService.FindMaxSalary(); // Find employee with max salary
                        break;
                    case "3":
                        _employeeService.FindMinAge(); // Find employee with min age
                        break;
                    case "4":
                        _employeeService.FindMaxAge(); // Find employee with max age
                        break;
                   
                    case "0":
                        Console.Clear();
                        ProcessMenuEmployee(); // Go back to the main employee menu
                        break;
                    default:
                        Console.WriteLine("Chọn không hợp lệ.");
                        break;
                }

                // Ask the user if they want to continue searching or go back to the main menu
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục tìm kiếm hoặc '0' để quay lại...");
                string back = Console.ReadLine();
                if (back == "0")
                {
                    isStop = true;
                    Console.Clear();
                    ProcessMenuEmployee(); // Go back to the main employee menu
                }
            }
        }

        public void TinhTongTrungBinhDiemNhanVien()
        {
            var isStop = false;
            while (!isStop)
            {
                Console.Clear(); // Xóa màn hình
                Console.WriteLine("===== MENU TÍNH TỔNG, TRUNG BÌNH, ĐẾM NHÂN VIÊN =====");
                Console.WriteLine("Tính tổng, trung bình và đếm nhân viên theo:");
                Console.WriteLine("1. Đếm số lượng nhân viên theo vị trí (Chức vụ)");
                Console.WriteLine("2. Tổng lương của nhân viên có bằng cấp");
                Console.WriteLine("3. Tuổi trung bình của nhân viên giới tính");
                Console.WriteLine("4. Đếm số lượng nhân viên theo giới tính");
                Console.WriteLine("5. Đếm số lượng nhân viên theo bằng cấp");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn tiêu chí tính: ");
                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        _employeeService.CountEmployeesByPosition(); 
                        break;
                    case "2":
                        _employeeService.TotalByEducation(); 
                        break;
                    case "3":
                        _employeeService.CalculateAverageAgeByGender();
                        break;
                    case "4":
                        _employeeService.CountEmployeesByGender(); 
                        break;
                    case "5":
                        _employeeService.CountEmployeesByEducation(); 
                        break;
                    case "0":
                        Console.Clear();
                        ProcessMenuEmployee(); // Quay lại menu nhân viên chính
                        break;
                    default:
                        Console.WriteLine("Chọn không hợp lệ.");
                        break;
                }

                // Hỏi người dùng có muốn quay lại menu tìm kiếm hoặc quay về menu chính
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục tính toán hoặc '0' để quay lại...");
                string back = Console.ReadLine();
                if (back == "0")
                {
                    isStop = true;
                    Console.Clear();
                    ProcessMenuEmployee(); // Quay lại menu chính nhân viên
                }
            }
        }

        public void ThongKeNhanVien()
        {
            var isStop = false;
            while (!isStop)
            {
                Console.Clear(); // Xóa màn hình
                Console.WriteLine("===== MENU THỐNG KÊ NHÂN VIÊN =====");
                Console.WriteLine("1. Thống nhân viên theo giới tính");
                Console.WriteLine("2. Thống kê nhân viên sắp hết tuổi lao động Nam 60 và nữ 55 điều kiện khoảng 1-2 năm trước tuổi nghỉ hưu");
                Console.WriteLine("3. Thống kê nhân viên theo bằng cấp");
                Console.WriteLine("4. Thống kê tỷ lệ phần trăm nhân viên theo giới tính");
                Console.WriteLine("5. Thống kê nhân viên theo khoảng lương");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn tiêu chí thống kê: ");
                string chon = Console.ReadLine();
                switch (chon)
                {
                    case "1":
                        _employeeService.GroupStatisticsByGender(); 
                        break;
                    case "2":
                        _employeeService.WarnEmployeesNearRetirement(); 
                        break;
                    case "3":
                        _employeeService.GroupStatisticsByEducation(); 
                        break;
                    case "4":
                        _employeeService.PercentageStatisticsByGender(); 
                        break;
                    case "5":
                        _employeeService.GroupStatisticsBySalary(); 
                        break;
                    case "0":
                        Console.Clear();
                        ProcessMenuEmployee(); 
                        break;
                    default:
                        Console.WriteLine("Chọn không hợp lệ.");
                        break;
                }

                // Ask the user if they want to continue or return to the main menu
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục tìm kiếm hoặc '0' để quay lại...");
                string back = Console.ReadLine();
                if (back == "0")
                {
                    isStop = true;
                    Console.Clear();
                    ProcessMenuEmployee(); // Return to the main employee menu
                }
            }
        }


        #endregion

        #region MENU  - Function - Phone


        public void ProcessMenuPhone()
        {
            var isStop = false;
            while (!isStop)
            {
                Console.Clear(); // Xóa màn hình
                Console.WriteLine("===== MENU QUẢN LÝ ĐIỆN THOẠI =====");
                Console.WriteLine("1. Thêm điện thoại");
                Console.WriteLine("2. In danh sách điện thoại");
                Console.WriteLine("3. Xóa điện thoại theo mã");
                Console.WriteLine("4. Chỉnh sửa điện thoại theo mã");
                Console.WriteLine("5. Tìm kiếm điện thoại");
                Console.WriteLine("6. Sắp xếp điện thoại");
                Console.WriteLine("7. Tìm MIN/MAX điện thoại");
                Console.WriteLine("8. Tính tổng, trung bình, điếm điện thoại");
                Console.WriteLine("9. Thống kê điện thoại");
                Console.WriteLine("10. Tạo các điện thoại mẫu - 40 Item điện thoại");
                Console.WriteLine("0. Quay lại menu chính");
                Console.Write("Chọn chức năng: ");
                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        _dienThoaiService.AddPhone();
                        break;
                    case "2":
                        _dienThoaiService.ReadPhoneFromFile();
                        break;
                    case "3":
                        _dienThoaiService.DeletePhoneByModel();
                        break;
                    case "4":
                        _dienThoaiService.EditPhone();
                        break;
                    case "5":
                        TimKiemDienThoai();
                        break;
                    case "6":
                        SapXepDienThoai();
                        break;
                    case "7":
                        TimMinMax();
                        break;
                    case "8":
                        TinhTongTrungBinhDiemDienThoai();
                        break;
                    case "9":
                        ThongKeDienThoai();
                        break;
                    case "10":
                        _dienThoaiService.AddSampleData();
                        break;
                    case "0":
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }

                // Hỏi người dùng có muốn quay lại menu tìm kiếm hoặc quay về menu chính
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục tìm kiếm hoặc '0' để quay lại menu chính...");
                string back = Console.ReadLine();
                if (back == "0")
                {
                    isStop = true;
                    Console.Clear();
                    return; // Quay lại menu chính
                }
            }
        }

        /// <summary>
        /// MENU Tìm kiếm điện thoại theo các tiêu chí khác nhau
        /// </summary>
        public void TimKiemDienThoai()
        {
            var isStop = false;
            while (!isStop)
            {
                Console.Clear();
                Console.WriteLine("===== MENU TÌM KIẾM ĐIỆN THOẠI =====");
                Console.WriteLine("Tìm kiếm điện thoại theo:");
                Console.WriteLine("1. Mã");
                Console.WriteLine("2. Tên");
                Console.WriteLine("3. Hãng");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn tiêu chí tìm kiếm: ");
                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        _dienThoaiService.SearchByCode();
                        break;
                    case "2":
                        _dienThoaiService.SearchByName();
                        break;
                    case "3":
                        _dienThoaiService.SearchByBrand();
                        break;
                    case "0":
                        ProcessMenuPhone();
                        return; // Quay lại menu chính
                    default:
                        Console.WriteLine("Chọn không hợp lệ.");
                        break;
                }

                // Hỏi người dùng có muốn quay lại menu tìm kiếm hoặc quay về menu chính
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục tìm kiếm hoặc '0' để quay lại menu chính...");
                string back = Console.ReadLine();
                if (back == "0")
                {
                    isStop = true;
                    Console.Clear();
                    ProcessMenuPhone();
                }
            }
        }

        /// <summary>
        /// MENU Sắp xếp điện thoại theo các tiêu chí khác nhau
        /// </summary>
        public void SapXepDienThoai()
        {
            var isStop = false;
            while (!isStop)
            {
                Console.Clear(); // Xóa màn hình
                Console.WriteLine("===== MENU SẮP XẾP ĐIỆN THOẠI =====");
                Console.WriteLine("Sắp xếp điện thoại theo:");
                Console.WriteLine("1. Mã");
                Console.WriteLine("2. Tên");
                Console.WriteLine("3. Hãng");
                Console.WriteLine("4. RAM");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn tiêu chí sắp xếp: ");
                string chon = Console.ReadLine();
                switch (chon)
                {
                    case "1":

                        _dienThoaiService.SortByCode();
                        break;
                    case "2":
                        _dienThoaiService.SortByName();
                        break;
                    case "3":
                        _dienThoaiService.SortByBrand();
                        break;
                    case "4":
                        _dienThoaiService.SortByRAM();
                        break;
                    case "0":
                        Console.Clear();
                        ProcessMenuPhone();
                        break;
                    default:
                        Console.WriteLine("Chọn không hợp lệ.");
                        break;
                }

                // Hỏi người dùng có muốn quay lại menu tìm kiếm hoặc quay về menu chính
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục tìm kiếm hoặc '0' để quay lại...");
                string back = Console.ReadLine();
                if (back == "0")
                {
                    isStop = true;
                    Console.Clear();
                    ProcessMenuPhone();
                }
            }
        }

        /// <summary>
        /// MENU Tìm MIN/MAX  điện thoại theo các tiêu chí khác nhau
        /// </summary>
        private void TimMinMax()
        {
            var isStop = false;
            while (!isStop)
            {
                Console.Clear(); // Xóa màn hình
                Console.WriteLine("===== MENU Tìm MIN/MAX =====");
                Console.WriteLine("Tìm min/max điện thoại theo:");
                Console.WriteLine("==Giá==");
                Console.WriteLine("1.Min Giá");
                Console.WriteLine("2.Max Giá");
                Console.WriteLine("==Số lượng tồn==");
                Console.WriteLine("3. Min số lượng tồn");
                Console.WriteLine("4. Max số lượng tồn");
                Console.WriteLine("==RAM==");
                Console.WriteLine("5. Min RAM");
                Console.WriteLine("6. Max RAM");
                Console.WriteLine("==Dung lượng lưu trữ==");
                Console.WriteLine("7. Min Dung lượng lưu trữ");
                Console.WriteLine("8. Max Dung lượng lưu trữ");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn tiêu chí xóa: ");
                string chon = Console.ReadLine();
                switch (chon)
                {
                    case "1":
                        _dienThoaiService.FindMinPrice();
                        break;
                    case "2":
                        _dienThoaiService.FindMaxPrice();
                        break;
                    case "3":
                        _dienThoaiService.FindMinStockQuantity();
                        break;
                    case "4":
                        _dienThoaiService.FindMaxStockQuantity();
                        break;
                    case "5":
                        _dienThoaiService.FindMinRAM();
                        break;
                    case "6":
                        _dienThoaiService.FindMaxRAM();
                        break;
                    case "7":
                        _dienThoaiService.FindMinStorageCapacity();
                        break;
                    case "8":
                        _dienThoaiService.FindMaxStorageCapacity();
                        break;
                    case "0":
                        Console.Clear();
                        ProcessMenuPhone();
                        break;
                    default:
                        Console.WriteLine("Chọn không hợp lệ.");
                        break;
                }

                // Hỏi người dùng có muốn quay lại menu tìm kiếm hoặc quay về menu chính
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục tìm kiếm hoặc '0' để quay lại...");
                string back = Console.ReadLine();
                if (back == "0")
                {
                    isStop = true;
                    Console.Clear();
                    ProcessMenuPhone();
                }
            }
        }

        /// <summary>
        /// MENU Tính tổng, trung bình, điếm điện thoại theo các tiêu chí khác nhau
        /// </summary>
        public void TinhTongTrungBinhDiemDienThoai()
        {
            var isStop = false;
            while (!isStop)
            {
                Console.Clear(); // Xóa màn hình
                Console.WriteLine("===== MENU TÍNH TỔNG, TRUNG BÌNH, ĐẾM ĐIỆN THOẠI =====");
                Console.WriteLine("Sắp xếp điện thoại theo:");
                Console.WriteLine("1. Điếm số lượng điện thoại theo Hãng");
                Console.WriteLine("2. Trung bình giá theo hãng");
                Console.WriteLine("3. Tính tổng số lượng tồn theo hãng");
                Console.WriteLine("4. Điếm điện thoại theo khoảng giá");
                Console.WriteLine("5. Điếm số lượng điện thoại theo khoảng RAM");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn tiêu chí sắp xếp: ");
                string chon = Console.ReadLine();
                switch (chon)
                {
                    case "1":
                        _dienThoaiService.CountPhonesByBrand();
                        break;
                    case "2":
                        _dienThoaiService.CalculateAveragePriceByBrand();
                        break;
                    case "3":
                        _dienThoaiService.TotalStockQuantityByBrand();
                        break;
                    case "4":
                        _dienThoaiService.CountPhonesByPriceRange();
                        break;
                    case "5":
                        _dienThoaiService.CountPhonesByRAMRange();
                        break;
                    case "0":
                        Console.Clear();
                        ProcessMenuPhone();
                        break;
                    default:
                        Console.WriteLine("Chọn không hợp lệ.");
                        break;
                }

                // Hỏi người dùng có muốn quay lại menu tìm kiếm hoặc quay về menu chính
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục tìm kiếm hoặc '0' để quay lại...");
                string back = Console.ReadLine();
                if (back == "0")
                {
                    isStop = true;
                    Console.Clear();
                    ProcessMenuPhone();
                }
            }
        }

        /// <summary>
        /// MENU Thống kê điện thoại theo các tiêu chí khác nhau
        /// </summary>
        public void ThongKeDienThoai()
        {
            var isStop = false;
            while (!isStop)
            {
                Console.Clear(); // Xóa màn hình
                Console.WriteLine("===== MENU THỐNG KÊ ĐIỆN THOẠI =====");
                Console.WriteLine("1. Thống kê theo model theo hãng");
                Console.WriteLine("2. Thống kê giá trị tồn theo hãng");
                Console.WriteLine("3. Thống kê điện thoại sắp hết hàng SL < 3");
                Console.WriteLine("4. Tính % tổng tồn kho theo từng hãng");
                Console.WriteLine("5. Thống kê điện thoại theo khoảng giá");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn tiêu chí sắp xếp: ");
                string chon = Console.ReadLine();
                switch (chon)
                {
                    case "1":
                        _dienThoaiService.GroupStatisticsByBrand();
                        break;
                    case "2":
                        _dienThoaiService.StockValueStatisticsByBrand();
                        break;
                    case "3":
                        _dienThoaiService.WarnLowStockPhones();
                        break;
                    case "4":
                        _dienThoaiService.StockPercentageStatisticsByBrand();
                        break;
                    case "5":
                        _dienThoaiService.GroupStatisticsByPriceRange();
                        break;
                    case "0":
                        Console.Clear();
                        ProcessMenuPhone();
                        break;
                    default:
                        Console.WriteLine("Chọn không hợp lệ.");
                        break;
                }

                // Hỏi người dùng có muốn quay lại menu tìm kiếm hoặc quay về menu chính
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục tìm kiếm hoặc '0' để quay lại...");
                string back = Console.ReadLine();
                if (back == "0")
                {
                    isStop = true;
                    Console.Clear();
                    ProcessMenuPhone();
                }
            }
        }

        #endregion

    }
}
