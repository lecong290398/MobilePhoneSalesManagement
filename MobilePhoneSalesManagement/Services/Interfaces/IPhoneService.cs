using MobilePhoneSalesManagement.DataStructures;
using MobilePhoneSalesManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Services.Interfaces
{
    public interface IPhoneService
    {
        void AddSampleData();
        void AddPhone();
        SinglyLinkedList<Phone> ReadPhoneFromFile();
        void PrintPhoneList(SinglyLinkedList<Phone>? dienThoaiList);
        void PrintPhone(Phone dt);
        Phone DeletePhoneByModel();
        Phone? EditPhone();
        Phone? SearchByCode();
        SinglyLinkedList<Phone> SearchByName();
        SinglyLinkedList<Phone> SearchByBrand();
        SinglyLinkedList<Phone> SortByCode();
        SinglyLinkedList<Phone> SortByName();
        SinglyLinkedList<Phone> SortByBrand();
        SinglyLinkedList<Phone> SortByRAM();
        Phone? FindMaxPrice();
        Phone? FindMinPrice();
        Phone? FindMaxStockQuantity();
        Phone? FindMinStockQuantity();
        Phone? FindMaxRAM();
        Phone? FindMinRAM();
        Phone? FindMaxStorageCapacity();
        Phone? FindMinStorageCapacity();
        int CountPhonesByBrand();
        int TotalStockQuantityByBrand();
        double CalculateAveragePriceByBrand();
        int CountPhonesByPriceRange();
        int CountPhonesByRAMRange();
        Dictionary<string, int> GroupStatisticsByBrand();
        Dictionary<string, double> StockValueStatisticsByBrand();
        Dictionary<string, int> WarnLowStockPhones(int nguongCanhBao = 3);
        Dictionary<string, double> StockPercentageStatisticsByBrand();
        SinglyLinkedList<Phone> GroupStatisticsByPriceRange();
    }
}
