using MobilePhoneSalesManagement.DataStructures;
using MobilePhoneSalesManagement.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace MobilePhoneSalesManagement.Services.Implements
{
    public class FileService : IFileService
    {
        public FileService()
        {
        }
     
        public void Add<T>(T item, string filePath)
        {
            try
            {
                //  1. Tạo thư mục nếu chưa tồn tại
                string folder = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                //  2. Tải danh sách hiện có từ file
                var list = LoadFromJsonFile<T>(filePath);

                //  3. Thêm item mới vào danh sách
                list.Add(item);

                //  4. Lưu danh sách trở lại file
                SaveToJsonFile(list, filePath);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public SinglyLinkedList<T> GetAll<T>(string filePath)
        {
            return LoadFromJsonFile<T>(filePath);
        }

        /// <summary>
        /// Cập nhật đối tượng trong danh sách theo giá trị thuộc tính khóa.
        /// </summary>
        /// <typeparam name="T">Kiểu đối tượng trong danh sách (SinglyLinkedList).</typeparam>
        /// <param name="newItem">Đối tượng mới cần thay thế cho đối tượng cũ.</param>
        /// <param name="keyProperty">Tên thuộc tính khóa (ví dụ: "Ma").</param>
        /// <param name="keyValue">Giá trị thuộc tính khóa cần tìm.</param>
        /// <param name="filePath">Đường dẫn tới tệp JSON chứa danh sách.</param>
        public void Update<T>(T newItem, string keyProperty, string keyValue, string filePath)
        {
            // Load danh sách từ file JSON
            var list = LoadFromJsonFile<T>(filePath);
            var current = list.Head;

            // Duyệt qua danh sách để tìm đối tượng cần chỉnh sửa
            while (current != null)
            {
                // Lấy thông tin thuộc tính khóa
                var prop = typeof(T).GetProperty(keyProperty, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                // Kiểm tra nếu thuộc tính khóa và giá trị khóa khớp
                if (prop != null && keyValue != null && prop.GetValue(current.Data)?.ToString() == keyValue.ToString())
                {
                    // Cập nhật đối tượng mới
                    current.Data = newItem;
                    break;  // Đã tìm thấy đối tượng và chỉnh sửa xong
                }

                current = current.Next;
            }

            // Lưu danh sách đã chỉnh sửa vào file JSON
            SaveToJsonFile(list, filePath);
        }

        public void Delete<T>(T data, string filePath)
        {
            var list = LoadFromJsonFile<T>(filePath);
            var newList = new SinglyLinkedList<T>();
            var current = list.Head;

            bool found = false;

            while (current != null)
            {
                // So sánh toàn bộ đối tượng bằng Equals
                if (!current.Data.Equals(data))
                {
                    newList.Add(current.Data);
                }
                else
                {
                    found = true;
                }

                current = current.Next;
            }

            SaveToJsonFile(newList, filePath);

            if (found)
            {
                Console.WriteLine(" Đã xóa đối tượng ra khỏi file.");
            }
            else
            {
                Console.WriteLine("X Không tìm thấy đối tượng để xóa.");
            }
        }

        private void SaveToJsonFile<T>(SinglyLinkedList<T> list, string filePath)
        {
            var dataList = new List<T>();
            var node = list.Head;
            while (node != null)
            {
                dataList.Add(node.Data);
                node = node.Next;
            }

            string json = JsonConvert.SerializeObject(dataList, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private SinglyLinkedList<T> LoadFromJsonFile<T>(string filePath)
        {
            var list = new SinglyLinkedList<T>();

            if (!File.Exists(filePath))
                return list;

            string json = File.ReadAllText(filePath);
            var dataList = JsonConvert.DeserializeObject<List<T>>(json);

            foreach (var item in dataList)
                list.Add(item);

            return list;
        }

    }
}
