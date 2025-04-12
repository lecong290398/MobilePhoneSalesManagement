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
        void ReadPhoneFromFile();
        void PrintPhoneList(SinglyLinkedList<Phone>? dienThoaiList);
        void PrintPhone(Phone dt);
        void DeletePhoneByModel();
        void EditPhone();
        void SearchByCode();
        void SearchByName();
        void SearchByBrand();
        void SortByCode();
        void SortByName();
        void SortByBrand();
        void SortByRAM();
        void FindMaxPrice();
        void FindMinPrice();
        void FindMaxStockQuantity();
        void FindMinStockQuantity();
        void FindMaxRAM();
        void FindMinRAM();
        void FindMaxStorageCapacity();
        void FindMinStorageCapacity();
        void CountPhonesByBrand();
        void TotalStockQuantityByBrand();
        void CalculateAveragePriceByBrand();
        void CountPhonesByPriceRange();
        void CountPhonesByRAMRange();
        void GroupStatisticsByBrand();
        void StockValueStatisticsByBrand();
        void WarnLowStockPhones(int nguongCanhBao = 3);
        void StockPercentageStatisticsByBrand();
        void GroupStatisticsByPriceRange();
    }
}
