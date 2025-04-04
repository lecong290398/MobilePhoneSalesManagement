using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Model
{
    public class DienThoai
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string Hang { get; set; }
        public double Gia { get; set; }
        public int SoLuongTon { get; set; }
        public int RAM { get; set; } // Dung lượng RAM
        public int DungLuongLuuTru { get; set; } // Dung lượng lưu trữ

        // Constructor
        public DienThoai(string ma, string ten, string hang, double gia, int soLuongTon, int ram, int dungLuongLuuTru)
        {
            Ma = ma;
            Ten = ten;
            Hang = hang;
            Gia = gia;
            SoLuongTon = soLuongTon;
            RAM = ram;
            DungLuongLuuTru = dungLuongLuuTru;
        }

        public override string ToString()
        {
            return $"{Ma} - {Ten} - {Hang} - {Gia} - {SoLuongTon} - RAM: {RAM} GB - Dung Lượng Lưu Trữ: {DungLuongLuuTru} GB";
        }
    }
}
