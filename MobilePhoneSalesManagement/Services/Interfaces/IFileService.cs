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
        /// <summary>
        /// Thêm một đối tượng vào file JSON
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của đối tượng</typeparam>
        /// <param name="item">Đối tượng cần thêm</param>
        /// <param name="filePath">Đường dẫn đến file JSON</param>
        void Add<T>(T item, string filePath);
        /// <summary>
        /// Lấy tất cả các đối tượng từ file JSON
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của đối tượng</typeparam>
        /// <param name="filePath">Đường dẫn đến file JSON</param>
        /// <returns>Danh sách các đối tượng</returns>
        SinglyLinkedList<T> GetAll<T>(string filePath);
        /// <summary>
        /// Cập nhật một đối tượng trong file JSON
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của đối tượng</typeparam>
        /// <param name="newItem">Đối tượng mới</param>
        /// <param name="keyValue">Giá trị khóa để tìm kiếm</param>
        /// <param name="filePath">Đường dẫn đến file JSON</param>
        void Update<T>(T newItem, string keyValue, string filePath);
        /// <summary>
        /// Xóa một đối tượng trong file JSON
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của đối tượng</typeparam>
        /// <param name="keyValue">Giá trị khóa để tìm kiếm</param>
        /// <param name="filePath">Đường dẫn đến file JSON</param>
        void Delete<T>(T data, string filePath);
    }
}
