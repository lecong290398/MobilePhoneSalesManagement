using MobilePhoneSalesManagement.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Services.Interfaces
{
    public interface IFileService
    {
        void Add<T>(T item, string filePath);
        SinglyLinkedList<T> GetAll<T>(string filePath);
        void Update<T>(T data, string filePath, string keyProperty, string keyValue);
        bool Delete<T>(T data, string filePath, string keyProperty, string keyValue);
    }
}
