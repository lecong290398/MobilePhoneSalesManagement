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

        public QuanLyController(IPhoneService dienThoaiService)
        {
            _dienThoaiService = dienThoaiService;
        }

        public void HienThiMenu()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("===== MENU =====");
                Console.WriteLine("1. Quản lý điện thoại");
                Console.WriteLine("2. Quản lý hóa đơn");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        ProcessMenuDienThoai();
                        break;
                    case "2":
                        //_hoaDonService.NhapDanhSachHoaDon();
                        //_hoaDonService.InDanhSachHoaDon();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Chọn không hợp lệ.");
                        break;
                }
            }
        }

        #region MENU  - Function - Phone


        public void ProcessMenuDienThoai()
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
                        ProcessMenuDienThoai();
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
                    ProcessMenuDienThoai();
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
                        ProcessMenuDienThoai();
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
                    ProcessMenuDienThoai();
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
                        ProcessMenuDienThoai();
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
                    ProcessMenuDienThoai();
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
                        ProcessMenuDienThoai();
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
                    ProcessMenuDienThoai();
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
                        ProcessMenuDienThoai();
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
                    ProcessMenuDienThoai();
                }
            }
        }

        #endregion

    }
}
