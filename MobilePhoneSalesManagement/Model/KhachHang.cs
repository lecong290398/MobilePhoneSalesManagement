using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Model
{
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        // Constructor
        public KhachHang(string maKH, string tenKH, string diaChi, string soDienThoai)
        {
            MaKH = maKH;
            TenKH = tenKH;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
        }

        public override string ToString()
        {
            return $"{MaKH} - {TenKH} - {DiaChi} - {SoDienThoai}";
        }
    }
}
