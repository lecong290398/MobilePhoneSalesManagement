using MobilePhoneSalesManagement.DataStructures;
using MobilePhoneSalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Services.Interfaces
{
    public interface IDienThoaiService
    {
        void ThemDuLieuMau();
        void ThemDienThoai();
        void DocDienThoaiTuFile();
        void InBangDienThoaiList(SinglyLinkedList<DienThoai>? dienThoaiList);
        void InBangDienThoai(DienThoai dt);
        void XoaDienThoaiTheoMa();
        void EditDienThoai();
        void TimKiemTheoMa();
        void TimKiemTheoTen();
        void TimKiemTheoHang();
        void SapXepTheoMa();
        void SapXepTheoTen();
        void SapXepTheoHang();
        void SapXepTheoRAM();
        void TimMaxGia();
        void TimMinGia();
        void TimMaxSoLuongTon();
        void TimMinSoLuongTon();
        void TimMaxRAM();
        void TimMinRAM();
        void TimMaxDungLuongLuuTru();
        void TimMinDungLuongLuuTru();
        void DemDienThoaiTheoHang();
        void TongSoLuongTonKhoTheoHang();
        void TinhTrungBinhGiaTheoHang();
        void DemDienThoaiTheoKhoangGia();
        void DemDienThoaiTheoKhoangRAM();
        void ThongkeModelTheoHang();
        void ThongKeGiaTriTonTheoHang();
        void ThongKeDienThoaiSapHetHang(int nguongCanhBao = 3);
        void ThongkePhanTramTonKhoTheoHang();
        void ThongkeDienThoaiTheoKhoangGia();
    }
}
