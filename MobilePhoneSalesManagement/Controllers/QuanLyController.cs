using MobilePhoneSalesManagement.Services.Implements;
using MobilePhoneSalesManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Controllers
{
    public class QuanLyController
    {
        private DienThoaiService _dienThoaiService;
        private HoaDonService _hoaDonService;

        public QuanLyController() // Add IFileService as a parameter
        {
            // Initialize the file service
            IFileService fileService = new FileService();
            IScenarioService scenarioService = new ScenarioService();

            _dienThoaiService = new DienThoaiService(fileService, scenarioService); // Pass fileService to the constructor
            _hoaDonService = new HoaDonService();
        }

        public void HienThiMenu()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("===== MENU =====");
                Console.WriteLine("1. Quản lý điện thoại");
                Console.WriteLine("2. Quản lý hóa đơn");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                        _dienThoaiService.ProcessMenuDienThoai();
                        break;
                    case "2":
                        _hoaDonService.NhapDanhSachHoaDon();
                        _hoaDonService.InDanhSachHoaDon();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Chọn không hợp lệ.");
                        break;
                }
            }
        }
    }
}
