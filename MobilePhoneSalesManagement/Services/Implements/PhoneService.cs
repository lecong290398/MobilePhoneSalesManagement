using MobilePhoneSalesManagement.DataStructures;
using MobilePhoneSalesManagement.Model;
using MobilePhoneSalesManagement.Services.Interfaces;
using MobilePhoneSalesManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;

namespace MobilePhoneSalesManagement.Services.Implements
{
    public class PhoneService : IPhoneService
    {
        /// <summary>
        /// Danh sách liên kết chứa các đối tượng điện thoại.
        /// </summary>
        public SinglyLinkedList<Phone> _dienThoaiList;

        /// <summary>
        /// Dịch vụ xử lý file, cung cấp các phương thức để đọc và ghi dữ liệu từ/đến tệp.
        /// </summary>
        public IFileService _fileService;

        /// <summary>
        /// Dịch vụ xử lý các tình huống hoặc kịch bản liên quan đến điện thoại.
        /// </summary>
        public IScenarioService _scenarioService;

        /// <summary>
        /// Đường dẫn đến tệp JSON chứa dữ liệu danh sách điện thoại.
        /// </summary>
        public string _filePath;

        /// <summary>
        /// Constructor của lớp PhoneService. Phương thức này khởi tạo các thành phần cần thiết cho dịch vụ quản lý danh sách điện thoại.
        /// </summary>
        /// <param name="fileService">Dịch vụ xử lý file, cung cấp các phương thức để đọc và ghi dữ liệu từ/đến tệp.</param>
        /// <param name="scenarioService">Dịch vụ xử lý các tình huống hoặc kịch bản liên quan đến danh sách liên kết đơn</param>
        public PhoneService(IFileService fileService, IScenarioService scenarioService)
        {
            // Khởi tạo danh sách điện thoại rỗng
            _dienThoaiList = new SinglyLinkedList<Phone>();

            // Gán giá trị cho dịch vụ xử lý file
            _fileService = fileService;

            // Lấy đường dẫn đến thư mục dự án (ba thư mục cấp trên từ thư mục hiện tại)
            string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

            // Kết hợp đường dẫn dự án với đường dẫn đến tệp JSON chứa dữ liệu danh sách điện thoại
            _filePath = Path.Combine(projectDir, "Data\\phone.json");

            // Gán giá trị cho dịch vụ kịch bản
            _scenarioService = scenarioService;

            // Khởi tạo danh sách điện thoại với dữ liệu từ file
            _dienThoaiList = _fileService.GetAll<Phone>(_filePath);
        }

        #region Function

        //tạo các điện thoại mẫu
        public void AddSampleData()
        {
            var dienThoaiMoi = new Phone[]
            {
                new Phone("DT01", "iPhone 14", "Apple", 25000000, 15, 6, 128),
                new Phone("DT02", "Galaxy S23", "Samsung", 22000000, 10, 8, 256),
                new Phone("DT03", "Xperia 1 V", "Sony", 21000000, 8, 12, 256),
                new Phone("DT04", "Mi 13 Pro", "Xiaomi", 18000000, 12, 8, 128),
                new Phone("DT05", "OnePlus 11", "OnePlus", 19000000, 7, 16, 512),
                new Phone("DT06", "Pixel 8", "Google", 20000000, 5, 8, 256),
                new Phone("DT07", "Nokia X30", "Nokia", 9000000, 20, 6, 128),
                new Phone("DT08", "Oppo Find X5", "Oppo", 17000000, 9, 12, 256),
                new Phone("DT09", "Vivo X90", "Vivo", 16500000, 11, 8, 128),
                new Phone("DT10", "Realme GT Neo", "Realme", 13000000, 14, 12, 256),
                new Phone("DT11", "Huawei P50", "Huawei", 23000000, 6, 8, 128),
                new Phone("DT12", "LG Velvet", "LG", 15000000, 10, 8, 256),
                new Phone("DT13", "Asus Zenfone 8", "Asus", 21000000, 9, 16, 512),
                new Phone("DT14", "Motorola Edge 30", "Motorola", 17000000, 7, 8, 128),
                new Phone("DT15", "Xiaomi Mi 11", "Xiaomi", 20000000, 13, 12, 256),
                new Phone("DT16", "iPhone 13", "Apple", 23000000, 18, 6, 128),
                new Phone("DT17", "Galaxy Z Flip 3", "Samsung", 30000000, 6, 8, 256),
                new Phone("DT18", "Realme GT", "Realme", 16000000, 8, 12, 256),
                new Phone("DT19", "Oppo Reno6", "Oppo", 18000000, 9, 8, 128),
                new Phone("DT20", "Vivo V21", "Vivo", 17000000, 7, 8, 128),
                new Phone("DT21", "Nokia 8.3", "Nokia", 19000000, 12, 8, 128),
                new Phone("DT22", "Sony Xperia 10 III", "Sony", 21000000, 8, 8, 128),
                new Phone("DT23", "Infinix Zero X", "Infinix", 16000000, 10, 8, 128),
                new Phone("DT24", "Tecno Camon 17", "Tecno", 14000000, 15, 6, 64),
                new Phone("DT25", "Sharp Aquos R6", "Sharp", 25000000, 6, 12, 128),
                new Phone("DT26", "Google Pixel 6 Pro", "Google", 28000000, 9, 12, 256),
                new Phone("DT27", "Xiaomi Redmi Note 10", "Xiaomi", 13000000, 20, 6, 64),
                new Phone("DT28", "Honor Magic 4", "Honor", 27000000, 5, 8, 128),
                new Phone("DT29", "Samsung Galaxy A52", "Samsung", 18000000, 13, 8, 128),
                new Phone("DT30", "LG G8 ThinQ", "LG", 16000000, 11, 6, 64),
                new Phone("DT31", "Apple iPhone 12", "Apple", 20000000, 14, 6, 128),
                new Phone("DT32", "Huawei Mate 40", "Huawei", 27000000, 8, 12, 512),
                new Phone("DT33", "Asus ROG Phone 5", "Asus", 27000000, 7, 16, 512),
                new Phone("DT34", "Realme 8 Pro", "Realme", 17000000, 10, 8, 128),
                new Phone("DT35", "Xiaomi Poco X3 Pro", "Xiaomi", 15000000, 14, 8, 256),
                new Phone("DT36", "Vivo V23", "Vivo", 19000000, 9, 8, 128),
                new Phone("DT37", "Oppo F19 Pro", "Oppo", 16000000, 8, 8, 128),
                new Phone("DT38", "Nokia 7.2", "Nokia", 15000000, 10, 6, 128),
                new Phone("DT39", "Motorola Moto G100", "Motorola", 20000000, 6, 12, 256),
                new Phone("DT40", "Samsung Galaxy Note 20", "Samsung", 30000000, 5, 8, 512)
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
        public void AddPhone()
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
                    var foundDienThoai = _scenarioService.SearchObjectByAttribute(_dienThoaiList, "Code", ma);
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

                Phone dt = new Phone(ma, ten, hang, gia, soLuongTon, ram, dungLuongLuuTru);
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
        public SinglyLinkedList<Phone> ReadPhoneFromFile()
        {
            _dienThoaiList = _fileService.GetAll<Phone>(_filePath);
            if (_dienThoaiList.Head == null)
            {
                Console.WriteLine("X Danh sách điện thoại rỗng.");
            }
            else
            {
                Console.WriteLine("Danh sách điện thoại đã được đọc từ file.");
                PrintPhoneList(_dienThoaiList);
            }
            return _dienThoaiList;
        }

        /// <summary>
        /// In danh sách điện thoại 
        /// </summary>
        /// <param name="dienThoaiList">Danh sách điện thoại cần hiển thị</param>
        public void PrintPhoneList(SinglyLinkedList<Phone>? dienThoaiList)
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
                    dt.Code.PadRight(10) +
                    dt.Name.PadRight(25) +
                    dt.Brand.PadRight(15) +
                    $"{dt.Price:N0}".PadRight(15) +
                    dt.StockQuantity.ToString().PadRight(12) +
                    (dt.RAM + " GB").PadRight(8) +
                    (dt.StorageCapacity + " GB").PadRight(10)
                );
                node = node.Next;
            }
            Console.WriteLine(new string('-', 110));
        }

        /// <summary>
        /// In thông tin điện thoại 
        /// </summary>
        /// <param name="dt">Điện thoại cần hiển thị</param>
        public void PrintPhone(Phone dt)
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
                dt.Code.PadRight(10) +
                dt.Name.PadRight(25) +
                dt.Brand.PadRight(15) +
                $"{dt.Price:N0}".PadRight(15) +
                dt.StockQuantity.ToString().PadRight(12) +
                (dt.RAM + " GB").PadRight(8) +
                (dt.StorageCapacity + " GB").PadRight(10)
            );

            Console.WriteLine(new string('-', 110));
        }

        /// <summary>
        /// Xóa điện thoại theo mã
        /// </summary>
        public Phone DeletePhoneByModel()
        {
            Console.Write("Nhập mã điện thoại cần xoá: ");
            string ma = Console.ReadLine();
            var dataDienThoai = _scenarioService.DeleteByAttributes(_dienThoaiList, "Code", ma);
            _fileService.Delete(dataDienThoai, _filePath, "Code", ma);
            return dataDienThoai;
        }

        public Phone? EditPhone()
        {
            Console.Write("Nhập mã điện thoại bạn muốn chỉnh sửa: ");
            string ma = Console.ReadLine();
            var updatedPhone = EditDienThoaiByMa(_dienThoaiList, ma);

            if (updatedPhone != null)
            {
                Console.WriteLine($" Điện thoại đã được chỉnh sửa:");
                PrintPhone(updatedPhone);
                _fileService.Update(updatedPhone, "Code", ma, _filePath);
            }
            return updatedPhone;
        }

        #endregion

        #region Tìm kiếm 
        // Tìm kiếm theo mã
        public Phone? SearchByCode()
        {
            Console.Write("Nhập mã điện thoại: ");
            string ma = Console.ReadLine();
            // Tìm kiếm đối tượng theo mã
            var foundDienThoai = _scenarioService.SearchObjectByAttribute(_dienThoaiList, "Code", ma);
            if (foundDienThoai != null)
            {
                Console.WriteLine($"Tìm thấy điện thoại với Mã : {ma} ");
                PrintPhone(foundDienThoai);
            }
            else
            {
                Console.WriteLine($"X Không tìm thấy điện thoại với mã {ma} này.");
            }
            return foundDienThoai;
        }

        // Tìm kiếm theo tên
        public SinglyLinkedList<Phone> SearchByName()
        {
            Console.Write("Nhập tên điện thoại: ");
            string ten = Console.ReadLine();
            var foundDienThoai = _scenarioService.SearchObjectListByAttributes(_dienThoaiList, "Name", ten);
            if (foundDienThoai != null)
            {
                Console.WriteLine($"Tìm thấy điện thoại với Tên : {ten} ");
                PrintPhoneList(foundDienThoai);
                return foundDienThoai;

            }
            else
            {
                Console.WriteLine($"X Không tìm thấy điện thoại với tên {ten} này.");
                return new SinglyLinkedList<Phone>();
            }
        }

        // Tìm kiếm theo hãng
        public SinglyLinkedList<Phone> SearchByBrand()
        {
            Console.Write("Nhập hãng điện thoại: ");
            string hang = Console.ReadLine();
            var foundDienThoai = _scenarioService.SearchObjectListByAttributes(_dienThoaiList, "Brand", hang);
            if (foundDienThoai != null)
            {
                Console.WriteLine($"Tìm thấy điện thoại với tên Hãng : {hang} ");
                PrintPhoneList(foundDienThoai);
                return foundDienThoai;
            }
            else
            {
                Console.WriteLine($"X Không tìm thấy điện thoại với tên Hãng {hang} này.");
                return new SinglyLinkedList<Phone>();
            }
        }

        #endregion

        #region Sắp Xếp

        // 4.1 Sắp xếp theo mã điện thoại
        public SinglyLinkedList<Phone> SortByCode()
        {
            var ascending = ValidateSortOrder();
            var listPhone = _scenarioService.SortByAttributes(_dienThoaiList, "Code", ascending);
            if (listPhone != null)
            {
                Console.WriteLine("Danh sách đã được sắp xếp theo mã điện thoại.");
                PrintPhoneList(listPhone);
                return listPhone;
            }
            return new SinglyLinkedList<Phone>();

        }

        // 4.2 Sắp xếp theo tên điện thoại
        public SinglyLinkedList<Phone> SortByName()
        {
            var ascending = ValidateSortOrder();
            var listPhone = _scenarioService.SortByAttributes(_dienThoaiList, "Name", ascending);
            if (listPhone != null)
            {
                Console.WriteLine("Danh sách đã được sắp xếp theo tên điện thoại.");
                PrintPhoneList(listPhone);

            }
            return new SinglyLinkedList<Phone>();
        }

        // 4.3 Sắp xếp theo hãng điện thoại
        public SinglyLinkedList<Phone> SortByBrand()
        {
            var ascending = ValidateSortOrder();
            var listPhone = _scenarioService.SortByAttributes(_dienThoaiList, "Name", ascending);
            if (listPhone != null)
            {
                Console.WriteLine("Danh sách đã được sắp xếp theo hãng điện thoại.");
                PrintPhoneList(listPhone);
            }
            return new SinglyLinkedList<Phone>();
        }

        // 4.4 Sắp xếp theo RAM điện thoại
        public SinglyLinkedList<Phone> SortByRAM()
        {
            var ascending = ValidateSortOrder();
            var listPhone = _scenarioService.SortByAttributes(_dienThoaiList, "RAM", ascending);
            if (listPhone != null)
            {
                Console.WriteLine("Danh sách đã được sắp xếp theo RAM điện thoại.");
                PrintPhoneList(listPhone);
            }
            return new SinglyLinkedList<Phone>();

        }

        #endregion

        #region Min/Max 

        // Tìm phần tử điện thoại có giá trị lớn nhất theo Giá
        public Phone? FindMaxPrice()
        {
            var maxDienThoai = _scenarioService.FindMaxByAttributes(_dienThoaiList, "Price");
            Console.WriteLine($"Điện thoại có giá trị lớn nhất theo Giá:");
            PrintPhone(maxDienThoai);
            return maxDienThoai;
        }

        // Tìm phần tử điện thoại có giá trị nhỏ nhất theo Giá
        public Phone? FindMinPrice()
        {
            var minDienThoai = _scenarioService.FindMinByAttributes(_dienThoaiList, "Price");
            Console.WriteLine($"Điện thoại có giá trị nhỏ nhất theo Giá:");
            PrintPhone(minDienThoai);
            return minDienThoai;
        }

        // Tìm phần tử điện thoại có giá trị lớn nhất theo Số lượng tồn
        public Phone? FindMaxStockQuantity()
        {
            var maxDienThoai = _scenarioService.FindMaxByAttributes(_dienThoaiList, "StockQuantity");
            Console.WriteLine($"Điện thoại có số lượng tồn lớn nhất: {maxDienThoai}");
            PrintPhone(maxDienThoai);
            return maxDienThoai;
        }

        // Tìm phần tử điện thoại có giá trị nhỏ nhất theo Số lượng tồn
        public Phone? FindMinStockQuantity()
        {
            var minDienThoai = _scenarioService.FindMinByAttributes(_dienThoaiList, "StockQuantity");
            Console.WriteLine($"Điện thoại có số lượng tồn nhỏ nhất: {minDienThoai}");
            PrintPhone(minDienThoai);
            return minDienThoai;
        }

        // Tìm phần tử điện thoại có giá trị lớn nhất theo RAM
        public Phone? FindMaxRAM()
        {
            var maxDienThoai = _scenarioService.FindMaxByAttributes(_dienThoaiList, "RAM");
            Console.WriteLine($"Điện thoại có RAM lớn nhất: {maxDienThoai}");
            PrintPhone(maxDienThoai);
            return maxDienThoai;
        }

        // Tìm phần tử điện thoại có giá trị nhỏ nhất theo RAM
        public Phone? FindMinRAM()
        {
            var minDienThoai = _scenarioService.FindMinByAttributes(_dienThoaiList, "RAM");
            Console.WriteLine($"Điện thoại có RAM nhỏ nhất: {minDienThoai}");
            PrintPhone(minDienThoai);
            return minDienThoai;
        }

        // Tìm phần tử điện thoại có giá trị lớn nhất theo Dung lượng lưu trữ
        public Phone? FindMaxStorageCapacity()
        {
            var maxDienThoai = _scenarioService.FindMaxByAttributes(_dienThoaiList, "StorageCapacity");
            Console.WriteLine($"Điện thoại có dung lượng lưu trữ lớn nhất: {maxDienThoai}");
            PrintPhone(maxDienThoai);
            return maxDienThoai;
        }

        // Tìm phần tử điện thoại có giá trị nhỏ nhất theo Dung lượng lưu trữ
        public Phone? FindMinStorageCapacity()
        {
            var minDienThoai = _scenarioService.FindMinByAttributes(_dienThoaiList, "StorageCapacity");
            Console.WriteLine($"Điện thoại có dung lượng lưu trữ nhỏ nhất: {minDienThoai}");
            PrintPhone(minDienThoai);
            return minDienThoai;
        }


        #endregion

        #region Tính tổng, trung bình, điếm

        // Tính tổng số lượng tồn kho theo hãng
        public int CountPhonesByBrand()
        {
            Console.Write("Nhập hãng điện thoại cần điếm: ");
            string hang = Console.ReadLine();
            var count = _scenarioService.CountByAttributes(_dienThoaiList, "Brand", hang);
            Console.WriteLine($"\n Có {count} điện thoại của hãng diên thoại {hang}");
            return count;
        }
        // Tính tổng số lượng tồn kho theo hãng
        public int TotalStockQuantityByBrand()
        {
            Console.Write("Nhập hãng điện thoại tính tổng số lượng tồn: ");
            string hang = Console.ReadLine();
            var sum = _scenarioService.SumByAttributes(_dienThoaiList, "Brand", hang, "StockQuantity");
            Console.WriteLine($"\n Có {sum} điện thoại tồn kho của hãng diên thoại {hang}");
            return sum;
        }
        // Tính trung bình giá theo hãng
        public double CalculateAveragePriceByBrand()
        {
            Console.Write("Nhập tên hãng cần tính trung bình giá: ");
            string hang = Console.ReadLine();
            var average = _scenarioService.AverageByAttributes(_dienThoaiList, "Brand", hang, "Price");
            Console.WriteLine($"\n Giá trung bình của điện thoại hãng \"{hang}\" là: {average:N0} VNĐ");
            return average;
        }
        // Điếm số lượng điện thoại theo khoảng giá
        public int CountPhonesByPriceRange()
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

            var count = _scenarioService.CountByRange(_dienThoaiList, "Price", giaMinTrieu, giaMaxTrieu);
            Console.WriteLine($"\n Có {count} điện thoại trong khoảng giá {giaMinTrieu} – {giaMaxTrieu} triệu.");
            return count;
        }
        // Điếm số lượng điện thoại theo khoảng RAM
        public int CountPhonesByRAMRange()
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
            return count;
        }

        #endregion

        #region Thống kê 

        /// <summary>
        /// Thống kê số lượng model theo từng hãng
        /// </summary>
        public Dictionary<string, int> GroupStatisticsByBrand()
        {
            var thongKe = _scenarioService.CountByGroup(_dienThoaiList, "Brand");
            if (thongKe == null || thongKe.Count == 0)
            {
                Console.WriteLine(" Không có dữ liệu để thống kê.");
                return new Dictionary<string, int>();
            }

            Console.WriteLine("=== Số lượng model theo từng hãng:");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("{0,-15} | {1,5}", "Hãng", "Số model");
            Console.WriteLine("-------------------------------");

            foreach (var kv in thongKe)
            {
                Console.WriteLine("{0,-15} | {1,5}", kv.Key, kv.Value);
            }
            return thongKe;
        }

        /// <summary>
        /// Thống kê tổng giá trị tồn kho theo từng hãng
        /// </summary>
        public Dictionary<string, double> StockValueStatisticsByBrand()
        {
            var thongKe = _scenarioService.SumByGroup(_dienThoaiList, "Brand", "Price");
            if (thongKe == null || thongKe.Count == 0)
            {
                Console.WriteLine(" Không có dữ liệu để thống kê.");
                return new Dictionary<string, double>();
            }
            Console.WriteLine("=== Tổng giá trị tồn kho theo từng hãng:");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("{0,-15} | {1,10}", "Hãng", "Tổng giá trị");
            Console.WriteLine("-------------------------------");
            foreach (var kv in thongKe)
            {
                Console.WriteLine("{0,-15} | {1,10:N0}", kv.Key, kv.Value);
            }
            return thongKe;

        }

        /// <summary>
        /// Thống kê điện thoại sắp hết hàng theo từng hãng
        /// </summary>
        /// <param name="nguongCanhBao"></param>
        public Dictionary<string, int> WarnLowStockPhones(int nguongCanhBao = 3)
        {
            var thongKe = _scenarioService.CountByGroup(_dienThoaiList, "Brand");
            if (thongKe == null || thongKe.Count == 0)
            {
                Console.WriteLine(" Không có dữ liệu để thống kê.");
                return new Dictionary<string, int>();
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
            return thongKe;

        }

        /// Thống kê điện thoại sắp hết hàng theo từng hãng
        //% tồn kho của một hãng = (Tổng số lượng tồn của hãng / Tổng số lượng tồn của tất cả hãng) * 100
        /// <summary>
        /// Tính phần trăm tồn kho theo từng hãng
        /// </summary>
        public Dictionary<string, double> StockPercentageStatisticsByBrand()
        {
            var thongKe = TinhPhanTramTonKhoTheoHang(_dienThoaiList, "Brand", "StockQuantity");
            if (thongKe == null || thongKe.Count == 0)
            {
                Console.WriteLine(" Không có dữ liệu để thống kê.");
                return new Dictionary<string, double>();
            }
            Console.WriteLine(" Tỷ lệ phần trăm tồn kho theo hãng:");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("{0,-15} | {1,8}%", "Hãng", "Tỷ lệ");
            Console.WriteLine("-------------------------------------------");

            foreach (var kv in thongKe)
            {
                Console.WriteLine("{0,-15} | {1,8:N2}%", kv.Key, kv.Value);
            }
            return thongKe;
        }

        /// <summary>
        /// Phương thức này yêu cầu người dùng nhập giá tối thiểu và tối đa (triệu VND) để lọc các điện thoại theo giá.
        /// Sau khi nhập các giá trị hợp lệ, phương thức sẽ sử dụng `FilterByRange` để lọc danh sách điện thoại theo phạm vi giá và in ra danh sách điện thoại thỏa mãn điều kiện.
        /// </summary>
        public SinglyLinkedList<Phone> GroupStatisticsByPriceRange()
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
            var listPhone = _scenarioService.FilterByRange(_dienThoaiList, "Price", giaMinTrieu, giaMaxTrieu);
            if (listPhone != null)
            {
                PrintPhoneList(listPhone);
                return listPhone;
            }
            return new SinglyLinkedList<Phone>();
        }

        #endregion

        #endregion

        #region Private Method

        /// <summary>
        /// Tính toán tỷ lệ phần trăm tồn kho theo từng nhóm (theo hãng) trong danh sách.
        /// Phương thức này tính tổng tồn kho theo từng hãng, sau đó tính tỷ lệ phần trăm tồn kho của mỗi hãng so với tổng tồn kho của tất cả các hãng.
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách liên kết.</typeparam>
        /// <param name="list">Danh sách liên kết (SinglyLinkedList<T>) chứa các đối tượng cần tính toán tồn kho.</param>
        /// <param name="hangProp">Tên thuộc tính dùng để nhóm các đối tượng (ví dụ: hãng).</param>
        /// <param name="soLuongTonProp">Tên thuộc tính chứa số lượng tồn kho của mỗi đối tượng.</param>
        /// <returns>Dictionary với key là giá trị của thuộc tính nhóm (hãng), và value là tỷ lệ phần trăm tồn kho của hãng đó so với tổng tồn kho.</returns>
        private Dictionary<string, double> TinhPhanTramTonKhoTheoHang<T>(SinglyLinkedList<T> list, string hangProp, string soLuongTonProp)
        {
            // Tính tổng tồn kho theo từng hãng bằng phương thức SumByGroup
            var tongTheoHang = _scenarioService.SumByGroup(list, hangProp, soLuongTonProp);

            // Tính tổng tồn kho của tất cả các hãng
            double tongTatCa = tongTheoHang.Values.Sum();

            // Tạo dictionary để lưu trữ tỷ lệ phần trăm tồn kho của từng hãng
            var phanTram = new Dictionary<string, double>();

            // Duyệt qua từng hãng và tính tỷ lệ phần trăm tồn kho
            foreach (var kvp in tongTheoHang)
            {
                // Tính tỷ lệ phần trăm tồn kho của từng hãng (nếu tổng tồn kho > 0)
                phanTram[kvp.Key] = tongTatCa > 0 ? (kvp.Value / tongTatCa) * 100 : 0;
            }

            // Trả về dictionary chứa tỷ lệ phần trăm tồn kho theo từng hãng
            return phanTram;
        }

        /// <summary>
        /// Chỉnh sửa thông tin của một điện thoại trong danh sách theo mã sản phẩm.
        /// Phương thức này tìm kiếm một điện thoại trong danh sách theo mã sản phẩm, 
        /// cho phép người dùng chọn và chỉnh sửa thuộc tính của điện thoại đó (tên, hãng, giá, số lượng tồn, RAM, dung lượng lưu trữ).
        /// </summary>
        /// <param name="list">Danh sách liên kết chứa các đối tượng điện thoại.</param>
        /// <param name="ma">Mã của điện thoại cần chỉnh sửa.</param>
        /// <returns>Đối tượng điện thoại đã được chỉnh sửa nếu thành công, hoặc null nếu không tìm thấy điện thoại hoặc nhập sai thông tin.</returns>
        private Phone EditDienThoaiByMa(SinglyLinkedList<Phone> list, string ma)
        {
            if (list == null || list.Head == null) return null;

            // Tìm kiếm điện thoại theo mã
            var dienThoaiToEdit = _scenarioService.SearchObjectByAttribute(_dienThoaiList, "Code", ma);

            if (dienThoaiToEdit == null)
            {
                Console.WriteLine("X Không tìm thấy điện thoại với mã: " + ma);
                return null;
            }

            Console.WriteLine($" Đang chỉnh sửa điện thoại: {dienThoaiToEdit.Name}");

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
                    dienThoaiToEdit.Name = Console.ReadLine();
                    break;

                case "2":
                    Console.Write("Nhập hãng mới: ");
                    dienThoaiToEdit.Brand = Console.ReadLine();
                    break;

                case "3":
                    Console.Write("Nhập giá mới: ");
                    if (double.TryParse(Console.ReadLine(), out double newPrice))
                        dienThoaiToEdit.Price = newPrice;
                    else
                        Console.WriteLine(" Giá không hợp lệ.");
                    break;

                case "4":
                    Console.Write("Nhập số lượng tồn mới: ");
                    if (int.TryParse(Console.ReadLine(), out int newQuantity))
                        dienThoaiToEdit.StockQuantity = newQuantity;
                    else
                        Console.WriteLine("X Số lượng tồn không hợp lệ.");
                    break;

                case "5":
                    Console.Write("Nhập RAM mới: ");
                    if (int.TryParse(Console.ReadLine(), out int newRam))
                        dienThoaiToEdit.RAM = newRam;
                    else
                        Console.WriteLine("X RAM không hợp lệ.");
                    break;

                case "6":
                    Console.Write("Nhập dung lượng lưu trữ mới: ");
                    if (int.TryParse(Console.ReadLine(), out int newStorage))
                        dienThoaiToEdit.StorageCapacity = newStorage;
                    else
                        Console.WriteLine("X Dung lượng lưu trữ không hợp lệ.");
                    break;

                default:
                    Console.WriteLine("X Lựa chọn không hợp lệ.");
                    return null;
            }

            Console.WriteLine("✅ Đã cập nhật thông tin điện thoại.");
            return dienThoaiToEdit;
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
