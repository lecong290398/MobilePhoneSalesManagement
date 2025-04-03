using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Model
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string PhongBan { get; set; }

        // Constructor
        public NhanVien(string maNV, string tenNV, string phongBan)
        {
            MaNV = maNV;
            TenNV = tenNV;
            PhongBan = phongBan;
        }

        public override string ToString()
        {
            return $"{MaNV} - {TenNV} - {PhongBan}";
        }
    }
}
