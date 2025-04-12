using MobileEmployeeSalesManagement.Services.Implements;
using MobilePhoneSalesManagement.Controllers;
using MobilePhoneSalesManagement.Services.Implements;
using MobilePhoneSalesManagement.Services.Interfaces;

// Tạo đối tượng PhoneService để truyền vào QuanLyController
IFileService fileService = new FileService();
IScenarioService scenarioService = new ScenarioService();
IPhoneService dienThoaiService = new PhoneService(fileService, scenarioService);
IEmployeeService employeeService = new EmployeeService(fileService, scenarioService);

// Tạo đối tượng QuanLyController và truyền PhoneService vào
QuanLyController controller = new QuanLyController(dienThoaiService, employeeService);
// Gọi phương thức HienThiMenu
controller.HienThiMenu();