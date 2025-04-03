using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Model
{
    public class HoaDon
    {
        public string MaHD { get; set; }
        public string MaDienThoai { get; set; }
        public string TenKhach { get; set; }
        public int SoLuongMua { get; set; }
        public double TongTien { get; set; }

        // Constructor
        public HoaDon(string maHD, string maDienThoai, string tenKhach, int soLuongMua, double tongTien)
        {
            MaHD = maHD;
            MaDienThoai = maDienThoai;
            TenKhach = tenKhach;
            SoLuongMua = soLuongMua;
            TongTien = tongTien;
        }

        public override string ToString()
        {
            return $"{MaHD} - {TenKhach} - {MaDienThoai} - {SoLuongMua} - {TongTien}";
        }
    }
}
