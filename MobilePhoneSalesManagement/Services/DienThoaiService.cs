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

        // 1. Thêm điện thoại vào danh sách
        public void ThemDienThoai()
        {
            Console.WriteLine("Nhập thông tin điện thoại:");
            Console.Write("Mã: ");
            string ma = Console.ReadLine();
            Console.Write("Tên: ");
            string ten = Console.ReadLine();
            Console.Write("Hãng: ");
            string hang = Console.ReadLine();
            Console.Write("Giá: ");
            double gia = double.Parse(Console.ReadLine());
            Console.Write("Số lượng tồn: ");
            int soLuongTon = int.Parse(Console.ReadLine());

            DienThoai dt = new DienThoai(ma, ten, hang, gia, soLuongTon);
            _dienThoaiList.Add(dt);
            Console.WriteLine("Điện thoại đã được thêm.");
        }

        // 2. In danh sách điện thoại
        public void InDanhSachDienThoai()
        {
            if (_dienThoaiList.Head == null)
            {
                Console.WriteLine("Danh sách điện thoại rỗng.");
                return;
            }

            Console.WriteLine("\nDanh sách điện thoại:");
            var node = _dienThoaiList.Head;
            while (node != null)
            {
                Console.WriteLine(node.Data); // In thông tin điện thoại
                node = node.Next;
            }
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
                    isStop= true;
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
                if (node.Data.Ma == ma)
                {
                    Console.WriteLine($"Tìm thấy: {node.Data}");
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
                    Console.WriteLine($"Tìm thấy: {node.Data}");
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
                    Console.WriteLine($"Tìm thấy: {node.Data}");
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
                        Console.Clear();
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

        // 7 Tính tổng, trung bình, điếm - 5yc 

        // 8 Thống kê theo điều kiện - 5yc

    }
}
