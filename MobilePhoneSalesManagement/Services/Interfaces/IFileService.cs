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
        /// Cập nhật đối tượng trong danh sách theo giá trị thuộc tính khóa.
        /// </summary>
        /// <typeparam name="T">Kiểu đối tượng trong danh sách (SinglyLinkedList).</typeparam>
        /// <param name="newItem">Đối tượng mới cần thay thế cho đối tượng cũ.</param>
        /// <param name="keyProperty">Tên thuộc tính khóa (ví dụ: "Ma").</param>
        /// <param name="keyValue">Giá trị thuộc tính khóa cần tìm.</param>
        /// <param name="filePath">Đường dẫn tới tệp JSON chứa danh sách.</param>
        void Update<T>(T data, string filePath, string keyProperty, string keyValue);
        bool Delete<T>(T data, string filePath, string keyProperty, string keyValue);
    }
}
