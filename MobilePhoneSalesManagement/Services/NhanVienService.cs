using MobilePhoneSalesManagement.DataStructures;
using MobilePhoneSalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Services
{
    public class NhanVienService
    {
        private DoublyLinkedList<NhanVien> _nhanVienList;

        public NhanVienService()
        {
            _nhanVienList = new DoublyLinkedList<NhanVien>();
        }

        // Nhập danh sách nhân viên
        public void NhapDanhSachNhanVien()
        {
            Console.Write("Nhập số lượng nhân viên: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhập thông tin nhân viên thứ {i + 1}:");
                Console.Write("Mã nhân viên: ");
                string maNV = Console.ReadLine();
                Console.Write("Tên nhân viên: ");
                string tenNV = Console.ReadLine();
                Console.Write("Phòng ban: ");
                string phongBan = Console.ReadLine();

                NhanVien nv = new NhanVien(maNV, tenNV, phongBan);
                _nhanVienList.Add(nv);
            }
        }

        // In danh sách nhân viên
        public void InDanhSachNhanVien()
        {
            Console.WriteLine("\nDanh sách nhân viên:");
            _nhanVienList.PrintAll();
        }
    }
}
