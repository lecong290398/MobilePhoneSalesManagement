using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Model
{
    public class Phone
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public int RAM { get; set; } // Dung lượng RAM
        public int StorageCapacity { get; set; } // Dung lượng lưu trữ

        // Constructor
        public Phone(string code, string name, string brand, double price, int stockQuantity, int ram, int storageCapacity)
        {
            Code = code;
            Name = name;
            Brand = brand;
            Price = price;
            StockQuantity = stockQuantity;
            RAM = ram;
            StorageCapacity = storageCapacity;
        }

        public override string ToString()
        {
            return $"{Code} - {Name} - {Brand} - {Price} - {StockQuantity} - RAM: {RAM} GB - Dung Lượng Lưu Trữ: {StorageCapacity} GB";
        }
    }
}
