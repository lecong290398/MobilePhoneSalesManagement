using MobilePhoneSalesManagement.Controllers;
using MobilePhoneSalesManagement.Services.Implements;
using MobilePhoneSalesManagement.Services.Interfaces;

// Tạo đối tượng DienThoaiService để truyền vào QuanLyController
IFileService fileService = new FileService();
IScenarioService scenarioService = new ScenarioService();
IDienThoaiService dienThoaiService = new DienThoaiService(fileService, scenarioService);

// Tạo đối tượng QuanLyController và truyền DienThoaiService vào
QuanLyController controller = new QuanLyController(dienThoaiService);
// Gọi phương thức HienThiMenu
controller.HienThiMenu();