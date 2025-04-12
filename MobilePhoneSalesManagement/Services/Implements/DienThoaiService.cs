using MobilePhoneSalesManagement.DataStructures;
using MobilePhoneSalesManagement.Model;
using MobilePhoneSalesManagement.Services.Interfaces;
using MobilePhoneSalesManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

namespace MobilePhoneSalesManagement.Services.Implements
{
    public class DienThoaiService : IDienThoaiService
    {
        public SinglyLinkedList<DienThoai> _dienThoaiList;
        public IFileService _fileService;
        public IScenarioService _scenarioService;
        public string _filePath;
        public DienThoaiService(IFileService fileService, IScenarioService scenarioService)
        {
            _dienThoaiList = new SinglyLinkedList<DienThoai>();
            _fileService = fileService;
            string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            _filePath = Path.Combine(projectDir, "Data\\dienthoai.json");
            _scenarioService = scenarioService;
            // Khởi tại dữ liệu danh sách đơn điện thoại với dữ liệu trong file
            _dienThoaiList = _fileService.GetAll<DienThoai>(_filePath);
        }

        #region Function

        //tạo các điện thoại mẫu
        public void ThemDuLieuMau()
        {
            var dienThoaiMoi = new List<DienThoai>
            {
                new DienThoai("DT01", "iPhone 14", "Apple", 25000000, 15, 6, 128),
                new DienThoai("DT02", "Galaxy S23", "Samsung", 22000000, 10, 8, 256),
                new DienThoai("DT03", "Xperia 1 V", "Sony", 21000000, 8, 12, 256),
                new DienThoai("DT04", "Mi 13 Pro", "Xiaomi", 18000000, 12, 8, 128),
                new DienThoai("DT05", "OnePlus 11", "OnePlus", 19000000, 7, 16, 512),
                new DienThoai("DT06", "Pixel 8", "Google", 20000000, 5, 8, 256),
                new DienThoai("DT07", "Nokia X30", "Nokia", 9000000, 20, 6, 128),
                new DienThoai("DT08", "Oppo Find X5", "Oppo", 17000000, 9, 12, 256),
                new DienThoai("DT09", "Vivo X90", "Vivo", 16500000, 11, 8, 128),
                new DienThoai("DT10", "Realme GT Neo", "Realme", 13000000, 14, 12, 256),
                new DienThoai("DT11", "Huawei P50", "Huawei", 23000000, 6, 8, 128),
                new DienThoai("DT12", "LG Velvet", "LG", 15000000, 10, 8, 256),
                new DienThoai("DT13", "Asus Zenfone 8", "Asus", 21000000, 9, 16, 512),
                new DienThoai("DT14", "Motorola Edge 30", "Motorola", 17000000, 7, 8, 128),
                new DienThoai("DT15", "Xiaomi Mi 11", "Xiaomi", 20000000, 13, 12, 256),
                new DienThoai("DT16", "iPhone 13", "Apple", 23000000, 18, 6, 128),
                new DienThoai("DT17", "Galaxy Z Flip 3", "Samsung", 30000000, 6, 8, 256),
                new DienThoai("DT18", "Realme GT", "Realme", 16000000, 8, 12, 256),
                new DienThoai("DT19", "Oppo Reno6", "Oppo", 18000000, 9, 8, 128),
                new DienThoai("DT20", "Vivo V21", "Vivo", 17000000, 7, 8, 128),
                new DienThoai("DT21", "Nokia 8.3", "Nokia", 19000000, 12, 8, 128),
                new DienThoai("DT22", "Sony Xperia 10 III", "Sony", 21000000, 8, 8, 128),
                new DienThoai("DT23", "Infinix Zero X", "Infinix", 16000000, 10, 8, 128),
                new DienThoai("DT24", "Tecno Camon 17", "Tecno", 14000000, 15, 6, 64),
                new DienThoai("DT25", "Sharp Aquos R6", "Sharp", 25000000, 6, 12, 128),
                new DienThoai("DT26", "Google Pixel 6 Pro", "Google", 28000000, 9, 12, 256),
                new DienThoai("DT27", "Xiaomi Redmi Note 10", "Xiaomi", 13000000, 20, 6, 64),
                new DienThoai("DT28", "Honor Magic 4", "Honor", 27000000, 5, 8, 128),
                new DienThoai("DT29", "Samsung Galaxy A52", "Samsung", 18000000, 13, 8, 128),
                new DienThoai("DT30", "LG G8 ThinQ", "LG", 16000000, 11, 6, 64),
                new DienThoai("DT31", "Apple iPhone 12", "Apple", 20000000, 14, 6, 128),
                new DienThoai("DT32", "Huawei Mate 40", "Huawei", 27000000, 8, 12, 512),
                new DienThoai("DT33", "Asus ROG Phone 5", "Asus", 27000000, 7, 16, 512),
                new DienThoai("DT34", "Realme 8 Pro", "Realme", 17000000, 10, 8, 128),
                new DienThoai("DT35", "Xiaomi Poco X3 Pro", "Xiaomi", 15000000, 14, 8, 256),
                new DienThoai("DT36", "Vivo V23", "Vivo", 19000000, 9, 8, 128),
                new DienThoai("DT37", "Oppo F19 Pro", "Oppo", 16000000, 8, 8, 128),
                new DienThoai("DT38", "Nokia 7.2", "Nokia", 15000000, 10, 6, 128),
                new DienThoai("DT39", "Motorola Moto G100", "Motorola", 20000000, 6, 12, 256),
                new DienThoai("DT40", "Samsung Galaxy Note 20", "Samsung", 30000000, 5, 8, 512)
            };
            // Thêm các điện thoại mẫu vào danh sách nếu chưa tồn tại
            foreach (var dt in dienThoaiMoi)
            {
                _dienThoaiList.Add(dt);
            }
            // Lưu danh sách điện thoại vào file JSON
            foreach (var dt in dienThoaiMoi)
            {
                _fileService.Add(dt, _filePath);
            }
            Console.WriteLine($"Điện thoại 40 Item mẫu của đối tượng điện thoại đã được thêm.");
        }

        #region Nhập - In - Xóa - Sửa - Lưu trữ - danh sách điện thoại

        /// <summary>
        /// Thêm điện thoại vào danh sách
        /// </summary>
        public void ThemDienThoai()
        {
            bool isAdding = true;
            while (isAdding)
            {
                Console.WriteLine("Nhập thông tin điện thoại:");
                string ma;
                while (true)
                {
                    Console.Write("Mã: ");
                    ma = Console.ReadLine();
                    var foundDienThoai = _scenarioService.SearchObjectByAttribute(_dienThoaiList, "Ma", ma);
                    if (foundDienThoai != null)
                    {
                        Console.WriteLine("! Mã điện thoại là tồn duy nhất, không trùng lập, vui lòng nhập lại !");
                    }
                    else
                    {
                        break;
                    }
                }
                Console.Write("Tên: ");
                string ten = Console.ReadLine();
                Console.Write("Hãng: ");
                string hang = Console.ReadLine();

                int ram;
                while (true)
                {
                    Console.Write("RAM: ");
                    if (int.TryParse(Console.ReadLine(), out ram))
                        break;
                    Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                }

                int dungLuongLuuTru;
                while (true)
                {
                    Console.Write("Dung lượng lưu trữ GB: ");
                    if (int.TryParse(Console.ReadLine(), out dungLuongLuuTru))
                        break;
                    Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                }

                double gia;
                while (true)
                {
                    Console.Write("Giá: ");
                    if (double.TryParse(Console.ReadLine(), out gia))
                        break;
                    Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                }

                int soLuongTon;
                while (true)
                {
                    Console.Write("Số lượng tồn: ");
                    if (int.TryParse(Console.ReadLine(), out soLuongTon))
                        break;
                    Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
                }

                DienThoai dt = new DienThoai(ma, ten, hang, gia, soLuongTon, ram, dungLuongLuuTru);
                _dienThoaiList.Add(dt);
                _fileService.Add(dt, _filePath);
                Console.WriteLine("Điện thoại đã được thêm.");
                Console.WriteLine(dt.ToString());
                Console.WriteLine("\nBạn có muốn thêm điện thoại khác không? (y/n): ");
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
        /// Đọc danh sách điện thoại từ file
        /// </summary>
        public void DocDienThoaiTuFile()
        {
            _dienThoaiList = _fileService.GetAll<DienThoai>(_filePath);
            if (_dienThoaiList.Head == null)
            {
                Console.WriteLine("X Danh sách điện thoại rỗng.");
            }
            else
            {
                Console.WriteLine("Danh sách điện thoại đã được đọc từ file.");
                InBangDienThoaiList(_dienThoaiList);
            }
        }

        /// <summary>
        /// In danh sách điện thoại 
        /// </summary>
        /// <param name="dienThoaiList">Danh sách điện thoại cần hiển thị</param>
        public void InBangDienThoaiList(SinglyLinkedList<DienThoai>? dienThoaiList)
        {
            if (_dienThoaiList.Head == null)
            {
                Console.WriteLine("X Danh sách điện thoại rỗng.");
                return;
            }
            Console.WriteLine("\n=== DANH SÁCH ĐIỆN THOẠI ===");
            Console.WriteLine(new string('-', 110));
            Console.WriteLine(
                "Mã".PadRight(10) +
                "Tên".PadRight(25) +
                "Hãng".PadRight(15) +
                "Giá".PadRight(15) +
                "Số lượng".PadRight(12) +
                "RAM".PadRight(8) +
                "Lưu trữ".PadRight(10)
            );
            Console.WriteLine(new string('-', 110));
            var node = dienThoaiList.Head;
            while (node != null)
            {
                var dt = node.Data;
                Console.WriteLine(
                    dt.Ma.PadRight(10) +
                    dt.Ten.PadRight(25) +
                    dt.Hang.PadRight(15) +
                    $"{dt.Gia:N0}".PadRight(15) +
                    dt.SoLuongTon.ToString().PadRight(12) +
                    (dt.RAM + " GB").PadRight(8) +
                    (dt.DungLuongLuuTru + " GB").PadRight(10)
                );
                node = node.Next;
            }
            Console.WriteLine(new string('-', 110));
        }

        /// <summary>
        /// In thông tin điện thoại 
        /// </summary>
        /// <param name="dt">Điện thoại cần hiển thị</param>
        public void InBangDienThoai(DienThoai dt)
        {
            Console.WriteLine(new string('-', 110));
            Console.WriteLine(
                "Mã".PadRight(10) +
                "Tên".PadRight(25) +
                "Hãng".PadRight(15) +
                "Giá".PadRight(15) +
                "Số lượng".PadRight(12) +
                "RAM".PadRight(8) +
                "Lưu trữ".PadRight(10)
            );
            Console.WriteLine(new string('-', 110));

            Console.WriteLine(
                dt.Ma.PadRight(10) +
                dt.Ten.PadRight(25) +
                dt.Hang.PadRight(15) +
                $"{dt.Gia:N0}".PadRight(15) +
                dt.SoLuongTon.ToString().PadRight(12) +
                (dt.RAM + " GB").PadRight(8) +
                (dt.DungLuongLuuTru + " GB").PadRight(10)
            );

            Console.WriteLine(new string('-', 110));
        }

        /// <summary>
        /// Xóa điện thoại theo mã
        /// </summary>
        public void XoaDienThoaiTheoMa()
        {
            Console.Write("Nhập mã điện thoại cần xoá: ");
            string ma = Console.ReadLine();
            var dataDienThoai = _scenarioService.DeleteByAttributes(_dienThoaiList, "Ma", ma);
            _fileService.Delete(dataDienThoai, _filePath, "Ma", ma);

        }

        public void EditDienThoai()
        {
            Console.Write("Nhập mã điện thoại bạn muốn chỉnh sửa: ");
            string ma = Console.ReadLine();
            var updatedPhone = EditDienThoaiByMa(_dienThoaiList, ma);

            if (updatedPhone != null)
            {
                Console.WriteLine($" Điện thoại đã được chỉnh sửa:");
                InBangDienThoai(updatedPhone);
                _fileService.Update(updatedPhone, "Ma", ma, _filePath);
            }
        }

        #endregion

        #region Tìm kiếm 
        // Tìm kiếm theo mã
        public void TimKiemTheoMa()
        {
            Console.Write("Nhập mã điện thoại: ");
            string ma = Console.ReadLine();
            // Tìm kiếm đối tượng theo mã
            var foundDienThoai = _scenarioService.SearchObjectByAttribute(_dienThoaiList, "Ma", ma);
            if (foundDienThoai != null)
            {
                Console.WriteLine($"Tìm thấy điện thoại với Mã : {ma} ");
                InBangDienThoai(foundDienThoai);
            }
            else
            {
                Console.WriteLine($"X Không tìm thấy điện thoại với mã {ma} này.");
            }
        }

        // Tìm kiếm theo tên
        public void TimKiemTheoTen()
        {
            Console.Write("Nhập tên điện thoại: ");
            string ten = Console.ReadLine();
            var foundDienThoai = _scenarioService.SearchObjectListByAttributes(_dienThoaiList, "Ten", ten);
            if (foundDienThoai != null)
            {
                Console.WriteLine($"Tìm thấy điện thoại với Tên : {ten} ");
                InBangDienThoaiList(foundDienThoai);
            }
            else
            {
                Console.WriteLine($"X Không tìm thấy điện thoại với tên {ten} này.");
            }
        }

        // Tìm kiếm theo hãng
        public void TimKiemTheoHang()
        {
            Console.Write("Nhập hãng điện thoại: ");
            string hang = Console.ReadLine();
            var foundDienThoai = _scenarioService.SearchObjectListByAttributes(_dienThoaiList, "Hang", hang);
            if (foundDienThoai != null)
            {
                Console.WriteLine($"Tìm thấy điện thoại với tên Hãng : {hang} ");
                InBangDienThoaiList(foundDienThoai);
            }
            else
            {
                Console.WriteLine($"X Không tìm thấy điện thoại với tên Hãng {hang} này.");
            }
        }

        #endregion

        #region Sắp Xếp



        // 4.1 Sắp xếp theo mã điện thoại
        public void SapXepTheoMa()
        {
            var ascending = ValidateSortOrder();
            var danhSachDienThoai = _scenarioService.SortByAttributes(_dienThoaiList, "Ma", ascending);
            Console.WriteLine("Danh sách đã được sắp xếp theo mã điện thoại.");
            InBangDienThoaiList(danhSachDienThoai);
        }

        // 4.2 Sắp xếp theo tên điện thoại
        public void SapXepTheoTen()
        {
            var ascending = ValidateSortOrder();
            var danhSachDienThoai = _scenarioService.SortByAttributes(_dienThoaiList, "Ten", ascending);
            Console.WriteLine("Danh sách đã được sắp xếp theo tên điện thoại.");
            InBangDienThoaiList(danhSachDienThoai);
        }

        // 4.3 Sắp xếp theo hãng điện thoại
        public void SapXepTheoHang()
        {
            var ascending = ValidateSortOrder();
            var danhSachDienThoai = _scenarioService.SortByAttributes(_dienThoaiList, "Ten", ascending);
            Console.WriteLine("Danh sách đã được sắp xếp theo hãng điện thoại.");
            InBangDienThoaiList(danhSachDienThoai);
        }

        // 4.4 Sắp xếp theo RAM điện thoại
        public void SapXepTheoRAM()
        {
            var ascending = ValidateSortOrder();
            var danhSachDienThoai = _scenarioService.SortByAttributes(_dienThoaiList, "RAM", ascending);
            Console.WriteLine("Danh sách đã được sắp xếp theo RAM điện thoại.");
            InBangDienThoaiList(danhSachDienThoai);
        }

        #endregion

        #region Min/Max 

        // Tìm phần tử điện thoại có giá trị lớn nhất theo Giá
        public void TimMaxGia()
        {
            var maxDienThoai = _scenarioService.FindMaxByAttributes(_dienThoaiList, "Gia");
            Console.WriteLine($"Điện thoại có giá trị lớn nhất theo Giá:");
            InBangDienThoai(maxDienThoai);

        }

        // Tìm phần tử điện thoại có giá trị nhỏ nhất theo Giá
        public void TimMinGia()
        {
            var minDienThoai = _scenarioService.FindMinByAttributes(_dienThoaiList, "Gia");
            Console.WriteLine($"Điện thoại có giá trị nhỏ nhất theo Giá:");
            InBangDienThoai(minDienThoai);
        }

        // Tìm phần tử điện thoại có giá trị lớn nhất theo Số lượng tồn
        public void TimMaxSoLuongTon()
        {
            var maxDienThoai = _scenarioService.FindMaxByAttributes(_dienThoaiList, "SoLuongTon");
            Console.WriteLine($"Điện thoại có số lượng tồn lớn nhất: {maxDienThoai}");
            InBangDienThoai(maxDienThoai);
        }

        // Tìm phần tử điện thoại có giá trị nhỏ nhất theo Số lượng tồn
        public void TimMinSoLuongTon()
        {
            var minDienThoai = _scenarioService.FindMinByAttributes(_dienThoaiList, "SoLuongTon");
            Console.WriteLine($"Điện thoại có số lượng tồn nhỏ nhất: {minDienThoai}");
            InBangDienThoai(minDienThoai);
        }

        // Tìm phần tử điện thoại có giá trị lớn nhất theo RAM
        public void TimMaxRAM()
        {
            var maxDienThoai = _scenarioService.FindMaxByAttributes(_dienThoaiList, "RAM");
            Console.WriteLine($"Điện thoại có RAM lớn nhất: {maxDienThoai}");
            InBangDienThoai(maxDienThoai);
        }

        // Tìm phần tử điện thoại có giá trị nhỏ nhất theo RAM
        public void TimMinRAM()
        {
            var minDienThoai = _scenarioService.FindMinByAttributes(_dienThoaiList, "RAM");
            Console.WriteLine($"Điện thoại có RAM nhỏ nhất: {minDienThoai}");
            InBangDienThoai(minDienThoai);
        }

        // Tìm phần tử điện thoại có giá trị lớn nhất theo Dung lượng lưu trữ
        public void TimMaxDungLuongLuuTru()
        {
            var maxDienThoai = _scenarioService.FindMaxByAttributes(_dienThoaiList, "DungLuongLuuTru");
            Console.WriteLine($"Điện thoại có dung lượng lưu trữ lớn nhất: {maxDienThoai}");
            InBangDienThoai(maxDienThoai);
        }

        // Tìm phần tử điện thoại có giá trị nhỏ nhất theo Dung lượng lưu trữ
        public void TimMinDungLuongLuuTru()
        {
            var minDienThoai = _scenarioService.FindMinByAttributes(_dienThoaiList, "DungLuongLuuTru");
            Console.WriteLine($"Điện thoại có dung lượng lưu trữ nhỏ nhất: {minDienThoai}");
            InBangDienThoai(minDienThoai);
        }


        #endregion

        #region Tính tổng, trung bình, điếm

        // Tính tổng số lượng tồn kho theo hãng
        public void DemDienThoaiTheoHang()
        {
            Console.Write("Nhập hãng điện thoại cần điếm: ");
            string hang = Console.ReadLine();
            var count = _scenarioService.CountByAttributes(_dienThoaiList, "Hang", hang);
            Console.WriteLine($"\n Có {count} điện thoại của hãng diên thoại {hang}");
        }
        // Tính tổng số lượng tồn kho theo hãng
        public void TongSoLuongTonKhoTheoHang()
        {
            Console.Write("Nhập hãng điện thoại tính tổng số lượng tồn: ");
            string hang = Console.ReadLine();
            var sum = _scenarioService.SumByAttributes(_dienThoaiList, "Hang", hang, "SoLuongTon");
            Console.WriteLine($"\n Có {sum} điện thoại tồn kho của hãng diên thoại {hang}");
        }
        // Tính trung bình giá theo hãng
        public void TinhTrungBinhGiaTheoHang()
        {
            Console.Write("Nhập tên hãng cần tính trung bình giá: ");
            string hang = Console.ReadLine();
            var average = _scenarioService.AverageByAttributes(_dienThoaiList, "Hang", hang, "Gia");
            Console.WriteLine($"\n Giá trung bình của điện thoại hãng \"{hang}\" là: {average:N0} VNĐ");
        }
        // Điếm số lượng điện thoại theo khoảng giá
        public void DemDienThoaiTheoKhoangGia()
        {
            double giaMinTrieu;
            while (true)
            {
                Console.Write("Nhập giá tối thiểu (triệu VND): ");
                if (double.TryParse(Console.ReadLine(), out giaMinTrieu))
                    break;
                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
            }

            double giaMaxTrieu;
            while (true)
            {
                Console.Write("Nhập giá tối đa (triệu VND): ");
                if (double.TryParse(Console.ReadLine(), out giaMaxTrieu))
                    break;
                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
            }

            var count = _scenarioService.CountByRange(_dienThoaiList, "Gia", giaMinTrieu, giaMaxTrieu);
            Console.WriteLine($"\n Có {count} điện thoại trong khoảng giá {giaMinTrieu} – {giaMaxTrieu} triệu.");
        }
        // Điếm số lượng điện thoại theo khoảng RAM
        public void DemDienThoaiTheoKhoangRAM()
        {
            int ramMin;
            while (true)
            {
                Console.Write("Nhập RAM tối thiểu(GB): ");
                if (int.TryParse(Console.ReadLine(), out ramMin))
                    break;
                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
            }
            int ramMax;
            while (true)
            {
                Console.Write("Nhập RAM tối đa (GB): ");
                if (int.TryParse(Console.ReadLine(), out ramMax))
                    break;
                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
            }

            var count = _scenarioService.CountByRange(_dienThoaiList, "RAM", ramMin, ramMax);
            Console.WriteLine($"\n Có {count} điện thoại trong khoảng RAM {ramMin} GB – {ramMax} GB.");
        }

        #endregion

        #region Thống kê 

        /// <summary>
        /// Thống kê số lượng model theo từng hãng
        /// </summary>
        public void ThongkeModelTheoHang()
        {
            var thongKe = _scenarioService.CountByGroup(_dienThoaiList, "Hang");
            if (thongKe == null || thongKe.Count == 0)
            {
                Console.WriteLine(" Không có dữ liệu để thống kê.");
                return;
            }

            Console.WriteLine("=== Số lượng model theo từng hãng:");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("{0,-15} | {1,5}", "Hãng", "Số model");
            Console.WriteLine("-------------------------------");

            foreach (var kv in thongKe)
            {
                Console.WriteLine("{0,-15} | {1,5}", kv.Key, kv.Value);
            }
        }

        /// <summary>
        /// Thống kê tổng giá trị tồn kho theo từng hãng
        /// </summary>
        public void ThongKeGiaTriTonTheoHang()
        {
            var thongKe = _scenarioService.SumByGroup(_dienThoaiList, "Hang", "Gia");
            if (thongKe == null || thongKe.Count == 0)
            {
                Console.WriteLine(" Không có dữ liệu để thống kê.");
                return;
            }
            Console.WriteLine("=== Tổng giá trị tồn kho theo từng hãng:");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("{0,-15} | {1,10}", "Hãng", "Tổng giá trị");
            Console.WriteLine("-------------------------------");
            foreach (var kv in thongKe)
            {
                Console.WriteLine("{0,-15} | {1,10:N0}", kv.Key, kv.Value);
            }
        }

        /// <summary>
        /// Thống kê điện thoại sắp hết hàng theo từng hãng
        /// </summary>
        /// <param name="nguongCanhBao"></param>
        public void ThongKeDienThoaiSapHetHang(int nguongCanhBao = 3)
        {
            var thongKe = _scenarioService.CountByGroup(_dienThoaiList, "Hang");
            if (thongKe == null || thongKe.Count == 0)
            {
                Console.WriteLine(" Không có dữ liệu để thống kê.");
                return;
            }
            Console.WriteLine("=== Số lượng điện thoại sắp hết hàng theo từng hãng:");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("{0,-15} | {1,5}", "Hãng", "Số lượng");
            Console.WriteLine("-------------------------------");
            foreach (var kv in thongKe)
            {
                if (kv.Value < nguongCanhBao)
                {
                    Console.WriteLine("{0,-15} | {1,5}", kv.Key, kv.Value);
                }
            }
        }

        /// Thống kê điện thoại sắp hết hàng theo từng hãng
        //% tồn kho của một hãng = (Tổng số lượng tồn của hãng / Tổng số lượng tồn của tất cả hãng) * 100

        /// <summary>
        /// Tính phần trăm tồn kho theo từng hãng
        /// </summary>
        public void ThongkePhanTramTonKhoTheoHang()
        {
            var tonKhoTheoHang = TinhPhanTramTonKhoTheoHang(_dienThoaiList, "Hang", "SoLuongTon");

            Console.WriteLine("📊 Tỷ lệ phần trăm tồn kho theo hãng:");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("{0,-15} | {1,8}%", "Hãng", "Tỷ lệ");
            Console.WriteLine("-------------------------------------------");

            foreach (var kv in tonKhoTheoHang)
            {
                Console.WriteLine("{0,-15} | {1,8:N2}%", kv.Key, kv.Value);
            }
        }

        public void ThongkeDienThoaiTheoKhoangGia()
        {
            double giaMinTrieu;
            while (true)
            {
                Console.Write("Nhập giá tối thiểu (triệu VND): ");
                if (double.TryParse(Console.ReadLine(), out giaMinTrieu))
                    break;
                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
            }
            double giaMaxTrieu;
            while (true)
            {
                Console.Write("Nhập giá tối đa (triệu VND): ");
                if (double.TryParse(Console.ReadLine(), out giaMaxTrieu))
                    break;
                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập lại.");
            }
            var danhSachDienThoai = _scenarioService.FilterByRange(_dienThoaiList, "Gia", giaMinTrieu, giaMaxTrieu);
            InBangDienThoaiList(danhSachDienThoai);
        }

        #endregion

        #endregion

        #region Private Method

        private Dictionary<string, double> TinhPhanTramTonKhoTheoHang<T>(SinglyLinkedList<T> list, string hangProp, string soLuongTonProp)
        {
            var tongTheoHang = _scenarioService.SumByGroup(list, hangProp, soLuongTonProp);
            double tongTatCa = tongTheoHang.Values.Sum();

            var phanTram = new Dictionary<string, double>();
            foreach (var kvp in tongTheoHang)
            {
                phanTram[kvp.Key] = tongTatCa > 0 ? (kvp.Value / tongTatCa) * 100 : 0;
            }

            return phanTram;
        }

        private DienThoai EditDienThoaiByMa(SinglyLinkedList<DienThoai> list, string ma)
        {
            if (list == null || list.Head == null) return null;

            // Tìm kiếm điện thoại theo mã
            var dienThoaiToEdit = _scenarioService.SearchObjectByAttribute(_dienThoaiList, "Ma", ma);

            if (dienThoaiToEdit == null)
            {
                Console.WriteLine("❌ Không tìm thấy điện thoại với mã: " + ma);
                return null;
            }

            Console.WriteLine($"📱 Đang chỉnh sửa điện thoại: {dienThoaiToEdit.Ten}");

            // Yêu cầu người dùng chọn thuộc tính muốn chỉnh sửa
            Console.WriteLine("\nChọn thuộc tính bạn muốn chỉnh sửa:");
            Console.WriteLine("1. Tên");
            Console.WriteLine("2. Hãng");
            Console.WriteLine("3. Giá");
            Console.WriteLine("4. Số lượng tồn");
            Console.WriteLine("5. RAM");
            Console.WriteLine("6. Dung lượng lưu trữ");

            string choice = Console.ReadLine();

            // Nhập giá trị mới tùy theo thuộc tính
            switch (choice)
            {
                case "1":
                    Console.Write("Nhập tên mới: ");
                    dienThoaiToEdit.Ten = Console.ReadLine();
                    break;

                case "2":
                    Console.Write("Nhập hãng mới: ");
                    dienThoaiToEdit.Hang = Console.ReadLine();
                    break;

                case "3":
                    Console.Write("Nhập giá mới: ");
                    if (double.TryParse(Console.ReadLine(), out double newPrice))
                        dienThoaiToEdit.Gia = newPrice;
                    else
                        Console.WriteLine("❌ Giá không hợp lệ.");
                    break;

                case "4":
                    Console.Write("Nhập số lượng tồn mới: ");
                    if (int.TryParse(Console.ReadLine(), out int newQuantity))
                        dienThoaiToEdit.SoLuongTon = newQuantity;
                    else
                        Console.WriteLine("❌ Số lượng tồn không hợp lệ.");
                    break;

                case "5":
                    Console.Write("Nhập RAM mới: ");
                    if (int.TryParse(Console.ReadLine(), out int newRam))
                        dienThoaiToEdit.RAM = newRam;
                    else
                        Console.WriteLine("❌ RAM không hợp lệ.");
                    break;

                case "6":
                    Console.Write("Nhập dung lượng lưu trữ mới: ");
                    if (int.TryParse(Console.ReadLine(), out int newStorage))
                        dienThoaiToEdit.DungLuongLuuTru = newStorage;
                    else
                        Console.WriteLine("❌ Dung lượng lưu trữ không hợp lệ.");
                    break;

                default:
                    Console.WriteLine("❌ Lựa chọn không hợp lệ.");
                    return null;
            }

            Console.WriteLine("✅ Đã cập nhật thông tin điện thoại.");
            return dienThoaiToEdit;
        }
        // Lựa chọn sắp xếp tăng hoặc giảm 0 (Giảm) / 1 (Tăng)
        private bool ValidateSortOrder()
        {
            string input;
            bool ascending;
            while (true)
            {
                Console.Write("Lựa chọn sắp xếp 0 (Giảm) / 1 (Tăng) : ");
                input = Console.ReadLine();

                if (input == "1")
                {
                    ascending = true;
                    break;
                }
                else if (input == "0")
                {
                    ascending = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng nhập 0 (Giảm) hoặc 1 (Tăng).");
                }
            }
            return ascending;
        }
        #endregion
    }
}
