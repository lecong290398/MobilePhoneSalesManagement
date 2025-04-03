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

        // Constructor
        public DienThoai(string ma, string ten, string hang, double gia, int soLuongTon)
        {
            Ma = ma;
            Ten = ten;
            Hang = hang;
            Gia = gia;
            SoLuongTon = soLuongTon;
        }

        public override string ToString()
        {
            return $"{Ma} - {Ten} - {Hang} - {Gia} - {SoLuongTon}";
        }
    }
}
