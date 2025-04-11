using MobilePhoneSalesManagement.DataStructures;
using MobilePhoneSalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Services.Implements
{
    public class HoaDonService
    {
        private SinglyLinkedList<HoaDon> _hoaDonList;

        public HoaDonService()
        {
            _hoaDonList = new SinglyLinkedList<HoaDon>();
        }

        // Nhập danh sách hóa đơn
        public void NhapDanhSachHoaDon()
        {
            Console.Write("Nhập số lượng hóa đơn: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhập thông tin hóa đơn thứ {i + 1}:");
                Console.Write("Mã hóa đơn: ");
                string maHD = Console.ReadLine();
                Console.Write("Mã điện thoại: ");
                string maDienThoai = Console.ReadLine();
                Console.Write("Tên khách hàng: ");
                string tenKhach = Console.ReadLine();
                Console.Write("Số lượng mua: ");
                int soLuongMua = int.Parse(Console.ReadLine());
                Console.Write("Tổng tiền: ");
                double tongTien = double.Parse(Console.ReadLine());

                HoaDon hd = new HoaDon(maHD, maDienThoai, tenKhach, soLuongMua, tongTien);
                _hoaDonList.Add(hd);
            }
        }

        // In danh sách hóa đơn
        public void InDanhSachHoaDon()
        {
            Console.WriteLine("\nDanh sách hóa đơn:");
            _hoaDonList.PrintAll();
        }


    }
}
