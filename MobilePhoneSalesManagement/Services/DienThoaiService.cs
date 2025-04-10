using MobilePhoneSalesManagement.DataStructures;
using MobilePhoneSalesManagement.Model;

namespace MobilePhoneSalesManagement.Services
{
    public class DienThoaiService
    {
        private SinglyLinkedList<DienThoai> _dienThoaiList;

        public DienThoaiService()
        {
            _dienThoaiList = new SinglyLinkedList<DienThoai>();
        }

        public void ProcessMenuDienThoai()
        {
            var isStop = false;
            while (!isStop)
            {
                Console.Clear(); // Xóa màn hình
                Console.WriteLine("===== MENU QUẢN LÝ ĐIỆN THOẠI =====");
                Console.WriteLine("1. Thêm điện thoại");
                Console.WriteLine("2. In danh sách điện thoại");
                Console.WriteLine("3. Tìm kiếm điện thoại");
                Console.WriteLine("4. Sắp xếp điện thoại");
                Console.WriteLine("5. Tìm MIN/MAX điện thoại");
                Console.WriteLine("6. Tính tổng, trung bình, điếm điện thoại");
                Console.WriteLine("7. Thống kê điện thoại");
                Console.WriteLine("0. Quay lại menu chính");
                Console.Write("Chọn chức năng: ");
                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        this.ThemDienThoai();
                        break;
                    case "2":
                        this.InDanhSachDienThoai();
                        break;
                    case "3":
                        this.TimKiemDienThoai();
                        break;
                    case "4":
                        this.SapXepDienThoai();
                        break;
                    case "5":
                        TimMinMax();
                        break;
                    case "6":
                        TinhTongTrungBinhDiemDienThoai();
                        break;
                    case "7":
                        ThongKeDienThoai();
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


        public void ThemDuLieuMau()
        {
            _dienThoaiList.Add(new DienThoai("DT01", "iPhone 14", "Apple", 25000000, 15));
            _dienThoaiList.Add(new DienThoai("DT02", "Galaxy S23", "Samsung", 22000000, 10));
            _dienThoaiList.Add(new DienThoai("DT03", "Xperia 1 V", "Sony", 21000000, 8));
            _dienThoaiList.Add(new DienThoai("DT04", "Mi 13 Pro", "Xiaomi", 18000000, 12));
            _dienThoaiList.Add(new DienThoai("DT05", "OnePlus 11", "OnePlus", 19000000, 7));
            _dienThoaiList.Add(new DienThoai("DT06", "Pixel 8", "Google", 20000000, 5));
            _dienThoaiList.Add(new DienThoai("DT07", "Nokia X30", "Nokia", 9000000, 20));
            _dienThoaiList.Add(new DienThoai("DT08", "Oppo Find X5", "Oppo", 17000000, 9));
            _dienThoaiList.Add(new DienThoai("DT09", "Vivo X90", "Vivo", 16500000, 11));
            _dienThoaiList.Add(new DienThoai("DT10", "Realme GT Neo", "Realme", 13000000, 14));
            Console.WriteLine("Đã thêm 10 điện thoại mẫu vào danh sách.");
        }


        // 1. Thêm điện thoại vào danh sách
        public void ThemDienThoai()
        {
            bool isAdding = true;
            while (isAdding)
            {
                Console.WriteLine("Nhập thông tin điện thoại:");
                Console.Write("Mã: ");
                string ma = Console.ReadLine();
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
                Console.WriteLine("Điện thoại đã được thêm.");
                Console.WriteLine(dt.ToString());
                Console.WriteLine("\nBạn có muốn thêm điện thoại khác không? (y/n): ");
                string response = Console.ReadLine();
                if (response.ToLower() != "y")
                {
                    isAdding = false;
                    Console.Clear();
                    ProcessMenuDienThoai();
                }
            }
        }

        // 2. In danh sách điện thoại
        public void InDanhSachDienThoai()
        {
            if (_dienThoaiList.Head == null)
            {
                Console.WriteLine("X Danh sách điện thoại rỗng.");
                return;
            }

            Console.WriteLine("\n ==== DANH SÁCH ĐIỆN THOẠI ====");
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

            var node = _dienThoaiList.Head;
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


        // 3. Tìm kiếm điện thoại
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
                        TimKiemTheoMa();
                        break;
                    case "2":
                        TimKiemTheoTen();
                        break;
                    case "3":
                        TimKiemTheoHang();
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

        // 3.1 Tìm kiếm theo mã
        private void TimKiemTheoMa()
        {
            Console.Write("Nhập mã điện thoại: ");
            string ma = Console.ReadLine();
            var node = _dienThoaiList.Head;
            bool found = false;
            while (node != null)
            {
                if (node.Data.Ma.ToLower() == ma.ToLower()) // so sánh chuỗi mà không phân biệt hoa thường
                {
                    Console.WriteLine($"Tìm thấy điện thoại theo mã {ma}:");
                    InBangDienThoai(node.Data);
                    found = true;
                    break;
                }
                node = node.Next;
            }

            if (!found)
            {
                Console.WriteLine("Không tìm thấy điện thoại với mã này.");
            }
        }

        // 3.2 Tìm kiếm theo tên
        private void TimKiemTheoTen()
        {
            Console.Write("Nhập tên điện thoại: ");
            string ten = Console.ReadLine();
            var node = _dienThoaiList.Head;
            bool found = false;
            while (node != null)
            {
                if (node.Data.Ten.Contains(ten, StringComparison.OrdinalIgnoreCase)) // Kiểm tra tên
                {
                    Console.WriteLine($"Tìm thấy điện thoại theo tên: {ten}");
                    InBangDienThoai(node.Data);
                    found = true;
                }
                node = node.Next;
            }

            if (!found)
            {
                Console.WriteLine("Không tìm thấy điện thoại với tên này.");
            }
        }

        // 3.3 Tìm kiếm theo hãng
        private void TimKiemTheoHang()
        {
            Console.Write("Nhập hãng điện thoại: ");
            string hang = Console.ReadLine();
            var node = _dienThoaiList.Head;
            bool found = false;
            while (node != null)
            {
                if (node.Data.Hang.Contains(hang, StringComparison.OrdinalIgnoreCase)) // Kiểm tra hãng
                {
                    Console.WriteLine($"Tìm thấy điện thoại theo hãng: {hang}");
                    InBangDienThoai(node.Data);
                    found = true;
                }
                node = node.Next;
            }

            if (!found)
            {
                Console.WriteLine("Không tìm thấy điện thoại với hãng này.");
            }
        }

        // 4. Sắp xếp điện thoại
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
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn tiêu chí sắp xếp: ");
                string chon = Console.ReadLine();
                switch (chon)
                {
                    case "1":
                        SapXepTheoMa();
                        break;
                    case "2":
                        SapXepTheoTen();
                        break;
                    case "3":
                        SapXepTheoHang();
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

        // 4.1 Sắp xếp theo mã điện thoại
        public void SapXepTheoMa()
        {
            // Sắp xếp bằng Bubble Sort
            bool swapped;
            do
            {
                swapped = false;
                var current = _dienThoaiList.Head;
                while (current != null && current.Next != null)
                {
                    if (string.Compare(current.Data.Ma, current.Next.Data.Ma) > 0)
                    {
                        // Swap dữ liệu giữa current và current.Next
                        var temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);

            Console.WriteLine("Danh sách đã được sắp xếp theo mã điện thoại.");
            InDanhSachDienThoai();
        }

        // 4.2 Sắp xếp theo tên điện thoại
        public void SapXepTheoTen()
        {
            // Sắp xếp bằng Bubble Sort
            bool swapped;
            do
            {
                swapped = false;
                var current = _dienThoaiList.Head;
                while (current != null && current.Next != null)
                {
                    if (string.Compare(current.Data.Ten, current.Next.Data.Ten) > 0)
                    {
                        // Swap dữ liệu giữa current và current.Next
                        var temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);

            Console.WriteLine("Danh sách đã được sắp xếp theo tên điện thoại.");
            InDanhSachDienThoai();
        }

        // 4.3 Sắp xếp theo hãng điện thoại
        public void SapXepTheoHang()
        {
            // Sắp xếp bằng Bubble Sort
            bool swapped;
            do
            {
                swapped = false;
                var current = _dienThoaiList.Head;
                while (current != null && current.Next != null)
                {
                    if (string.Compare(current.Data.Hang, current.Next.Data.Hang) > 0)
                    {
                        // Swap dữ liệu giữa current và current.Next
                        var temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);

            Console.WriteLine("Danh sách đã được sắp xếp theo hãng điện thoại.");
            InDanhSachDienThoai();
        }

        // 5. Xóa điện thoại
        public void XoaDienThoai()
        {
            var isStop = false;
            while (!isStop)
            {
                Console.Clear(); // Xóa màn hình
                Console.WriteLine("===== MENU XÓA ĐIỆN THOẠI =====");
                Console.WriteLine("Xóa điện thoại theo:");
                Console.WriteLine("1. Mã");
                Console.WriteLine("2. Tên");
                Console.WriteLine("3. Hãng");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn tiêu chí xóa: ");
                string chon = Console.ReadLine();
                switch (chon)
                {
                    case "1":
                        XoaDienThoaiTheoMa();
                        break;
                    case "2":
                        XoaDienThoaiTheoTen();
                        break;
                    case "3":
                        XoaDienThoaiTheoHang();
                        break;
                    case "0":
                        ProcessMenuDienThoai();
                        return;
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
        // 5.1 Xoá điện thoại theo mã
        public void XoaDienThoaiTheoMa()
        {
            Console.Write("Nhập mã điện thoại cần xoá: ");
            string ma = Console.ReadLine();

            var node = _dienThoaiList.Head;
            SinglyLinkedList<DienThoai>.Node previousNode = null;

            // Tìm kiếm điện thoại theo mã
            while (node != null)
            {
                if (node.Data.Ma == ma)
                {
                    if (previousNode == null)
                    {
                        // Nếu là phần tử đầu tiên, thay đổi head
                        _dienThoaiList.Head = node.Next;
                    }
                    else
                    {
                        previousNode.Next = node.Next; // Liên kết lại phần tử trước đó
                    }
                    Console.WriteLine($"Điện thoại đã được xoá.\n{node.Data}");
                    return;
                }
                previousNode = node;
                node = node.Next;
            }

            Console.WriteLine("Không tìm thấy điện thoại với mã này.");
        }

        // 5.2 Xoá điện thoại theo tên
        public void XoaDienThoaiTheoTen()
        {
            Console.Write("Nhập tên điện thoại cần xoá: ");
            string ten = Console.ReadLine();

            var node = _dienThoaiList.Head;
            SinglyLinkedList<DienThoai>.Node previousNode = null;

            // Tìm kiếm điện thoại theo tên
            while (node != null)
            {
                if (node.Data.Ten.Contains(ten, StringComparison.OrdinalIgnoreCase))
                {
                    if (previousNode == null)
                    {
                        // Nếu là phần tử đầu tiên, thay đổi head
                        _dienThoaiList.Head = node.Next;
                    }
                    else
                    {
                        previousNode.Next = node.Next; // Liên kết lại phần tử trước đó
                    }
                    Console.WriteLine($"Điện thoại đã được xoá.\n{node.Data}");
                    return;
                }
                previousNode = node;
                node = node.Next;
            }

            Console.WriteLine("Không tìm thấy điện thoại với tên này.");
        }

        // 5.3 Xoá điện thoại theo hãng
        public void XoaDienThoaiTheoHang()
        {
            Console.Write("Nhập hãng điện thoại cần xoá: ");
            string hang = Console.ReadLine();

            var node = _dienThoaiList.Head;
            SinglyLinkedList<DienThoai>.Node previousNode = null;

            // Tìm kiếm điện thoại theo hãng
            while (node != null)
            {
                if (node.Data.Hang.Contains(hang, StringComparison.OrdinalIgnoreCase))
                {
                    if (previousNode == null)
                    {
                        // Nếu là phần tử đầu tiên, thay đổi head
                        _dienThoaiList.Head = node.Next;
                    }
                    else
                    {
                        previousNode.Next = node.Next; // Liên kết lại phần tử trước đó
                    }
                    Console.WriteLine($"Điện thoại đã được xoá.\n{node.Data}");
                    return;
                }
                previousNode = node;
                node = node.Next;
            }

            Console.WriteLine("Không tìm thấy điện thoại với hãng này.");
        }

        // 6 Tìm phần từ lớn nhất , nhỏ nhất  - 4yc
        public void TimMinMax()
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
                        TimMinGia();
                        break;
                    case "2":
                        TimMaxGia();
                        break;
                    case "3":
                        TimMinSoLuongTon();
                        break;
                    case "4":
                        TimMaxSoLuongTon();
                        break;
                    case "5":
                        TimMinRAM();
                        break;
                    case "6":
                        TimMaxRAM();
                        break;
                    case "7":
                        TimMinDungLuongLuuTru();
                        break;
                    case "8":
                        TimMaxDungLuongLuuTru();
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

        // 6.1 Tìm phần tử điện thoại có giá trị lớn nhất theo Giá
        public void TimMaxGia()
        {
            if (_dienThoaiList.Head == null)
            {
                Console.WriteLine("Danh sách điện thoại rỗng.");
                return;
            }

            var node = _dienThoaiList.Head;
            DienThoai maxDienThoai = node.Data;

            while (node != null)
            {
                if (node.Data.Gia > maxDienThoai.Gia)
                {
                    maxDienThoai = node.Data;
                }
                node = node.Next;
            }

            Console.WriteLine($"Điện thoại có giá trị lớn nhất theo Giá: {maxDienThoai}");
        }

        // 6.1 Tìm phần tử điện thoại có giá trị nhỏ nhất theo Giá
        public void TimMinGia()
        {
            if (_dienThoaiList.Head == null)
            {
                Console.WriteLine("Danh sách điện thoại rỗng.");
                return;
            }

            var node = _dienThoaiList.Head;
            DienThoai minDienThoai = node.Data;

            while (node != null)
            {
                if (node.Data.Gia < minDienThoai.Gia)
                {
                    minDienThoai = node.Data;
                }
                node = node.Next;
            }

            Console.WriteLine($"Điện thoại có giá trị nhỏ nhất theo Giá: {minDienThoai}");
        }

        // 6.2 Tìm phần tử điện thoại có giá trị lớn nhất theo Số lượng tồn
        public void TimMaxSoLuongTon()
        {
            if (_dienThoaiList.Head == null)
            {
                Console.WriteLine("Danh sách điện thoại rỗng.");
                return;
            }

            var node = _dienThoaiList.Head;
            DienThoai maxDienThoai = node.Data;

            while (node != null)
            {
                if (node.Data.SoLuongTon > maxDienThoai.SoLuongTon)
                {
                    maxDienThoai = node.Data;
                }
                node = node.Next;
            }

            Console.WriteLine($"Điện thoại có số lượng tồn lớn nhất: {maxDienThoai}");
        }

        // 6.2 Tìm phần tử điện thoại có giá trị nhỏ nhất theo Số lượng tồn
        public void TimMinSoLuongTon()
        {
            if (_dienThoaiList.Head == null)
            {
                Console.WriteLine("Danh sách điện thoại rỗng.");
                return;
            }

            var node = _dienThoaiList.Head;
            DienThoai minDienThoai = node.Data;

            while (node != null)
            {
                if (node.Data.SoLuongTon < minDienThoai.SoLuongTon)
                {
                    minDienThoai = node.Data;
                }
                node = node.Next;
            }

            Console.WriteLine($"Điện thoại có số lượng tồn nhỏ nhất: {minDienThoai}");
        }

        // 6.3 Tìm phần tử điện thoại có giá trị lớn nhất theo RAM
        public void TimMaxRAM()
        {
            if (_dienThoaiList.Head == null)
            {
                Console.WriteLine("Danh sách điện thoại rỗng.");
                return;
            }

            var node = _dienThoaiList.Head;
            DienThoai maxDienThoai = node.Data;

            while (node != null)
            {
                if (node.Data.RAM > maxDienThoai.RAM)
                {
                    maxDienThoai = node.Data;
                }
                node = node.Next;
            }

            Console.WriteLine($"Điện thoại có RAM lớn nhất: {maxDienThoai}");
        }

        // 6.3 Tìm phần tử điện thoại có giá trị nhỏ nhất theo RAM
        public void TimMinRAM()
        {
            if (_dienThoaiList.Head == null)
            {
                Console.WriteLine("Danh sách điện thoại rỗng.");
                return;
            }

            var node = _dienThoaiList.Head;
            DienThoai minDienThoai = node.Data;

            while (node != null)
            {
                if (node.Data.RAM < minDienThoai.RAM)
                {
                    minDienThoai = node.Data;
                }
                node = node.Next;
            }

            Console.WriteLine($"Điện thoại có RAM nhỏ nhất: {minDienThoai}");
        }

        // 6.4 Tìm phần tử điện thoại có giá trị lớn nhất theo Dung lượng lưu trữ
        public void TimMaxDungLuongLuuTru()
        {
            if (_dienThoaiList.Head == null)
            {
                Console.WriteLine("Danh sách điện thoại rỗng.");
                return;
            }

            var node = _dienThoaiList.Head;
            DienThoai maxDienThoai = node.Data;

            while (node != null)
            {
                if (node.Data.DungLuongLuuTru > maxDienThoai.DungLuongLuuTru)
                {
                    maxDienThoai = node.Data;
                }
                node = node.Next;
            }

            Console.WriteLine($"Điện thoại có dung lượng lưu trữ lớn nhất: {maxDienThoai}");
        }

        // 6.4 Tìm phần tử điện thoại có giá trị nhỏ nhất theo Dung lượng lưu trữ
        public void TimMinDungLuongLuuTru()
        {
            if (_dienThoaiList.Head == null)
            {
                Console.WriteLine("Danh sách điện thoại rỗng.");
                return;
            }

            var node = _dienThoaiList.Head;
            DienThoai minDienThoai = node.Data;

            while (node != null)
            {
                if (node.Data.DungLuongLuuTru < minDienThoai.DungLuongLuuTru)
                {
                    minDienThoai = node.Data;
                }
                node = node.Next;
            }

            Console.WriteLine($"Điện thoại có dung lượng lưu trữ nhỏ nhất: {minDienThoai}");
        }

        // 7 Tính tổng, trung bình, điếm - 5yc 
        public void TinhTongTrungBinhDiemDienThoai()
        {
            var isStop = false;
            while (!isStop)
            {
                Console.Clear(); // Xóa màn hình
                Console.WriteLine("===== MENU TÍNH TỔNG, TRUNG BÌNH, ĐẾM ĐIỆN THOẠI =====");
                Console.WriteLine("Sắp xếp điện thoại theo:");
                Console.WriteLine("1. Tính tổng số lượng tồn theo hãng");
                Console.WriteLine("2. Trung bình giá theo hãng");
                Console.WriteLine("3. Điếm số lượng điện thoại theo số lượng tồn");
                Console.WriteLine("4. Điếm điện thoại theo khoảng giá");
                Console.WriteLine("5. Điếm số lượng điện thoại theo RAM");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn tiêu chí sắp xếp: ");
                string chon = Console.ReadLine();
                switch (chon)
                {
                    case "1":
                        TinhTongSoLuongTonTheoHang();
                        break;
                    case "2":
                        TinhTrungBinhGiaTheoHang();
                        break;
                    case "3":
                        DemDienThoaiTheoSoLuongTon_LinhHoat();
                        break;
                    case "4":
                        DemDienThoaiTheoKhoangGia();
                        break;
                    case "5":
                        DemDienThoaiTheoRAMMin();
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

        public void TinhTongSoLuongTonTheoHang()
        {
            Console.Write("Nhập tên hãng cần tính tổng số lượng tồn: ");
            string hangX = Console.ReadLine();

            var node = _dienThoaiList.Head;
            int tongSoLuong = 0;
            bool found = false;

            while (node != null)
            {
                if (node.Data.Hang.Equals(hangX, StringComparison.OrdinalIgnoreCase))
                {
                    tongSoLuong += node.Data.SoLuongTon;
                    found = true;
                }
                node = node.Next;
            }

            if (found)
            {
                Console.WriteLine($"\n✅ Tổng số lượng tồn của hãng \"{hangX}\" là: {tongSoLuong} sản phẩm.");
            }
            else
            {
                Console.WriteLine($" Không tìm thấy điện thoại nào thuộc hãng \"{hangX}\".");
            }
        }

        public void TinhTrungBinhGiaTheoHang()
        {
            Console.Write("Nhập tên hãng cần tính trung bình giá: ");
            string hangX = Console.ReadLine();

            var node = _dienThoaiList.Head;
            int count = 0;
            double tongGia = 0;

            while (node != null)
            {
                if (node.Data.Hang.Equals(hangX, StringComparison.OrdinalIgnoreCase))
                {
                    tongGia += node.Data.Gia;
                    count++;
                }
                node = node.Next;
            }

            if (count == 0)
            {
                Console.WriteLine($" Không có điện thoại nào thuộc hãng \"{hangX}\".");
            }
            else
            {
                double trungBinh = tongGia / count;
                Console.WriteLine($"\n📈 Giá trung bình của điện thoại hãng \"{hangX}\" là: {trungBinh:N0} VNĐ");
            }
        }
        
        public void DemDienThoaiTheoSoLuongTon_LinhHoat()
        {
            Console.Write("Nhập số lượng tồn tối thiểu (để trống nếu không dùng): ");
            string minInput = Console.ReadLine();
            Console.Write("Nhập số lượng tồn tối đa (để trống nếu không dùng): ");
            string maxInput = Console.ReadLine();

            int? tonMin = string.IsNullOrWhiteSpace(minInput) ? null : int.Parse(minInput);
            int? tonMax = string.IsNullOrWhiteSpace(maxInput) ? null : int.Parse(maxInput);

            int count = 0;
            var node = _dienThoaiList.Head;

            while (node != null)
            {
                int ton = node.Data.SoLuongTon;
                bool thoaDieuKien =
                    (!tonMin.HasValue || ton >= tonMin.Value) &&
                    (!tonMax.HasValue || ton <= tonMax.Value);

                if (thoaDieuKien)
                {
                    count++;
                }

                node = node.Next;
            }

            Console.WriteLine($"\n🔢 Số điện thoại thỏa điều kiện tồn:");
            Console.WriteLine($"→ Tổng: {count} điện thoại.");
        }
       
        public void DemDienThoaiTheoKhoangGia()
        {
            Console.Write("Nhập giá tối thiểu (triệu VND): ");
            double giaMinTrieu = double.Parse(Console.ReadLine());

            Console.Write("Nhập giá tối đa (triệu VND): ");
            double giaMaxTrieu = double.Parse(Console.ReadLine());

            double giaMin = giaMinTrieu * 1_000_000;
            double giaMax = giaMaxTrieu * 1_000_000;

            int count = 0;
            var node = _dienThoaiList.Head;

            while (node != null)
            {
                if (node.Data.Gia >= giaMin && node.Data.Gia <= giaMax)
                {
                    count++;
                }
                node = node.Next;
            }

            Console.WriteLine($"\n🔢 Có {count} điện thoại trong khoảng giá {giaMinTrieu} – {giaMaxTrieu} triệu.");
        }

        public void DemDienThoaiTheoRAMMin()
        {
            Console.Write("Nhập dung lượng RAM tối thiểu (GB): ");
            int ramMin = int.Parse(Console.ReadLine());

            int count = 0;
            var node = _dienThoaiList.Head;

            while (node != null)
            {
                if (node.Data.RAM >= ramMin)
                {
                    count++;
                }
                node = node.Next;
            }

            Console.WriteLine($"\n🔢 Có {count} điện thoại có RAM ≥ {ramMin} GB.");
        }


        // 8 Thống kê theo điều kiện 
        public void ThongKeDienThoai()
        {
            var isStop = false;
            while (!isStop)
            {
                Console.Clear(); // Xóa màn hình
                Console.WriteLine("===== MENU THỐNG KÊ ĐIỆN THOẠI =====");
                Console.WriteLine("Sắp xếp điện thoại theo:");
                Console.WriteLine("1. Hãng");
                Console.WriteLine("2. RAM");
                Console.WriteLine("3. Giá");
                Console.WriteLine("4. Dung lượng lưu trữ");
                Console.WriteLine("5. Số lượng tồn");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn tiêu chí sắp xếp: ");
                string chon = Console.ReadLine();
                switch (chon)
                {
                    case "1":
                        ThongKeDanhSachTheoHang();
                        break;
                    case "2":
                        ThongKeDanhSachTheoRAMMinMax_LinhHoat();
                        break;
                    case "3":
                        ThongKeDanhSachTheoGiaMinMax_LinhHoat();
                        break;
                    case "4":
                        ThongKeDanhSachTheoDungLuongLuuTruMinMax_LinhHoat();
                        break;
                    case "5":
                        ThongKeDanhSachTheoSoLuongTonMinMax_LinhHoat();
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

        // 8.1 Thống kê danh sách điện thoại theo hãng x (x người dùng nhập vào)
        public void ThongKeDanhSachTheoHang()
        {
            Console.Write("Nhập tên hãng cần thống kê: ");
            string hangX = Console.ReadLine();

            var node = _dienThoaiList.Head;
            bool found = false;

            // In header bảng
            Console.WriteLine("\n Danh sách điện thoại theo hãng: " + hangX);
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

            while (node != null)
            {
                var dt = node.Data;
                if (dt.Hang.Equals(hangX, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(
                        dt.Ma.PadRight(10) +
                        dt.Ten.PadRight(25) +
                        dt.Hang.PadRight(15) +
                        $"{dt.Gia:N0}".PadRight(15) +
                        dt.SoLuongTon.ToString().PadRight(12) +
                        (dt.RAM + " GB").PadRight(8) +
                        (dt.DungLuongLuuTru + " GB").PadRight(10)
                    );
                    found = true;
                }
                node = node.Next;
            }

            Console.WriteLine(new string('-', 110));

            if (!found)
            {
                Console.WriteLine(" Không có điện thoại nào thuộc hãng này.");
            }
        }

        // 8.2 Thống kê danh sách điện thoại theo RAM Min, Max (Min,Max người dùng nhập vào) - Linh hoạt có thể chỉ nhập Min hoặc Max
        public void ThongKeDanhSachTheoRAMMinMax_LinhHoat()
        {
            Console.Write("Nhập RAM tối thiểu (GB, để trống nếu không dùng): ");
            string minInput = Console.ReadLine();
            Console.Write("Nhập RAM tối đa (GB, để trống nếu không dùng): ");
            string maxInput = Console.ReadLine();

            int? ramMin = string.IsNullOrWhiteSpace(minInput) ? null : int.Parse(minInput);
            int? ramMax = string.IsNullOrWhiteSpace(maxInput) ? null : int.Parse(maxInput);

            var node = _dienThoaiList.Head;
            bool found = false;

            Console.WriteLine("\n Danh sách điện thoại thỏa điều kiện RAM:");
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

            while (node != null)
            {
                var dt = node.Data;
                bool thoaDieuKien =
                    (!ramMin.HasValue || dt.RAM >= ramMin.Value) &&
                    (!ramMax.HasValue || dt.RAM <= ramMax.Value);

                if (thoaDieuKien)
                {
                    Console.WriteLine(
                        dt.Ma.PadRight(10) +
                        dt.Ten.PadRight(25) +
                        dt.Hang.PadRight(15) +
                        $"{dt.Gia:N0}".PadRight(15) +
                        dt.SoLuongTon.ToString().PadRight(12) +
                        (dt.RAM + " GB").PadRight(8) +
                        (dt.DungLuongLuuTru + " GB").PadRight(10)
                    );
                    found = true;
                }

                node = node.Next;
            }

            Console.WriteLine(new string('-', 110));

            if (!found)
            {
                Console.WriteLine(" Không có điện thoại nào thỏa điều kiện RAM.");
            }
        }

        // 8.3 Thống kê danh sách điện thoại theo Giá Min, Max (Min,Max người dùng nhập vào) - Linh hoạt có thể chỉ nhập Min hoặc Max
        public void ThongKeDanhSachTheoGiaMinMax_LinhHoat()
        {
            Console.Write("Nhập giá tối thiểu (triệu VND, để trống nếu không dùng): ");
            string minInput = Console.ReadLine();
            Console.Write("Nhập giá tối đa (triệu VND, để trống nếu không dùng): ");
            string maxInput = Console.ReadLine();

            double? giaMin = string.IsNullOrWhiteSpace(minInput) ? null : double.Parse(minInput) * 1_000_000;
            double? giaMax = string.IsNullOrWhiteSpace(maxInput) ? null : double.Parse(maxInput) * 1_000_000;

            var node = _dienThoaiList.Head;
            bool found = false;

            Console.WriteLine("\n Danh sách điện thoại thỏa điều kiện giá:");
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

            while (node != null)
            {
                var dt = node.Data;
                bool thoaDieuKien =
                    (!giaMin.HasValue || dt.Gia >= giaMin.Value) &&
                    (!giaMax.HasValue || dt.Gia <= giaMax.Value);

                if (thoaDieuKien)
                {
                    Console.WriteLine(
                        dt.Ma.PadRight(10) +
                        dt.Ten.PadRight(25) +
                        dt.Hang.PadRight(15) +
                        $"{dt.Gia:N0}".PadRight(15) +
                        dt.SoLuongTon.ToString().PadRight(12) +
                        (dt.RAM + " GB").PadRight(8) +
                        (dt.DungLuongLuuTru + " GB").PadRight(10)
                    );
                    found = true;
                }

                node = node.Next;
            }

            Console.WriteLine(new string('-', 110));

            if (!found)
            {
                Console.WriteLine(" Không có điện thoại nào thỏa điều kiện giá.");
            }
        }

        // 8.4 Thống kê danh sách điện thoại theo Dung lượng lưu trữ Min, Max (Min,Max người dùng nhập vào) - Linh hoạt có thể chỉ nhập Min hoặc Max
        public void ThongKeDanhSachTheoDungLuongLuuTruMinMax_LinhHoat()
        {
            Console.Write("Nhập dung lượng lưu trữ tối thiểu (GB, để trống nếu không dùng): ");
            string minInput = Console.ReadLine();
            Console.Write("Nhập dung lượng lưu trữ tối đa (GB, để trống nếu không dùng): ");
            string maxInput = Console.ReadLine();

            int? dungLuongMin = string.IsNullOrWhiteSpace(minInput) ? null : int.Parse(minInput);
            int? dungLuongMax = string.IsNullOrWhiteSpace(maxInput) ? null : int.Parse(maxInput);

            var node = _dienThoaiList.Head;
            bool found = false;

            Console.WriteLine("\n Danh sách điện thoại theo dung lượng lưu trữ:");
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

            while (node != null)
            {
                var dt = node.Data;
                bool thoaDieuKien =
                    (!dungLuongMin.HasValue || dt.DungLuongLuuTru >= dungLuongMin.Value) &&
                    (!dungLuongMax.HasValue || dt.DungLuongLuuTru <= dungLuongMax.Value);

                if (thoaDieuKien)
                {
                    Console.WriteLine(
                        dt.Ma.PadRight(10) +
                        dt.Ten.PadRight(25) +
                        dt.Hang.PadRight(15) +
                        $"{dt.Gia:N0}".PadRight(15) +
                        dt.SoLuongTon.ToString().PadRight(12) +
                        (dt.RAM + " GB").PadRight(8) +
                        (dt.DungLuongLuuTru + " GB").PadRight(10)
                    );
                    found = true;
                }

                node = node.Next;
            }

            Console.WriteLine(new string('-', 110));

            if (!found)
            {
                Console.WriteLine(" Không có điện thoại nào thỏa điều kiện dung lượng.");
            }
        }

        // 8.5 Thống kê danh sách điện thoại theo số lượng tồn  Min (min được người dùng nhập vào) - Linh hoạt có thể chỉ nhập Min hoặc Max
        public void ThongKeDanhSachTheoSoLuongTonMinMax_LinhHoat()
        {
            Console.Write("Nhập số lượng tồn tối thiểu (để trống nếu không dùng): ");
            string minInput = Console.ReadLine();
            Console.Write("Nhập số lượng tồn tối đa (để trống nếu không dùng): ");
            string maxInput = Console.ReadLine();

            int? tonMin = string.IsNullOrWhiteSpace(minInput) ? null : int.Parse(minInput);
            int? tonMax = string.IsNullOrWhiteSpace(maxInput) ? null : int.Parse(maxInput);

            var node = _dienThoaiList.Head;
            bool found = false;

            Console.WriteLine("\n Danh sách điện thoại theo số lượng tồn:");
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

            while (node != null)
            {
                var dt = node.Data;
                bool thoaDieuKien =
                    (!tonMin.HasValue || dt.SoLuongTon >= tonMin.Value) &&
                    (!tonMax.HasValue || dt.SoLuongTon <= tonMax.Value);

                if (thoaDieuKien)
                {
                    Console.WriteLine(
                        dt.Ma.PadRight(10) +
                        dt.Ten.PadRight(25) +
                        dt.Hang.PadRight(15) +
                        $"{dt.Gia:N0}".PadRight(15) +
                        dt.SoLuongTon.ToString().PadRight(12) +
                        (dt.RAM + " GB").PadRight(8) +
                        (dt.DungLuongLuuTru + " GB").PadRight(10)
                    );
                    found = true;
                }

                node = node.Next;
            }

            Console.WriteLine(new string('-', 110));

            if (!found)
            {
                Console.WriteLine("X Không có điện thoại nào thỏa điều kiện số lượng tồn.");
            }
        }

    }
}
