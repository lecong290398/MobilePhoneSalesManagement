using MobilePhoneSalesManagement.DataStructures;
using MobilePhoneSalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Services
{
    public class KhachHangService
    {
        private DoublyLinkedList<KhachHang> _khachHangList;

        public KhachHangService()
        {
            _khachHangList = new DoublyLinkedList<KhachHang>();
        }

        // Nhập danh sách khách hàng
        public void NhapDanhSachKhachHang()
        {
            Console.Write("Nhập số lượng khách hàng: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhập thông tin khách hàng thứ {i + 1}:");
                Console.Write("Mã khách hàng: ");
                string maKH = Console.ReadLine();
                Console.Write("Tên khách hàng: ");
                string tenKH = Console.ReadLine();
                Console.Write("Địa chỉ: ");
                string diaChi = Console.ReadLine();
                Console.Write("Số điện thoại: ");
                string soDienThoai = Console.ReadLine();

                KhachHang kh = new KhachHang(maKH, tenKH, diaChi, soDienThoai);
                _khachHangList.Add(kh);
            }
        }

        // In danh sách khách hàng
        public void InDanhSachKhachHang()
        {
            Console.WriteLine("\nDanh sách khách hàng:");
            _khachHangList.PrintAll();
        }
    }
}
