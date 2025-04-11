using MobilePhoneSalesManagement.DataStructures;
using MobilePhoneSalesManagement.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        // -------------------------
        // CREATE or ADD
        // -------------------------
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

        // -------------------------
        // READ ALL
        // -------------------------
        public SinglyLinkedList<T> GetAll<T>(string filePath)
        {
            return LoadFromJsonFile<T>(filePath);
        }

        // -------------------------
        // UPDATE (by key "Ma")
        // -------------------------
        public void Update<T>(T newItem, string keyValue, string filePath)
        {
            var list = LoadFromJsonFile<T>(filePath);
            var current = list.Head;

            while (current != null)
            {
                var prop = typeof(T).GetProperty("Ma");
                if (prop != null && prop.GetValue(current.Data)?.ToString() == keyValue)
                {
                    current.Data = newItem;
                    break;
                }
                current = current.Next;
            }

            SaveToJsonFile(list, filePath);
        }

        // -------------------------
        // DELETE (by key "Ma")
        // -------------------------
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

        // -------------------------
        // PRIVATE: Save to file
        // -------------------------
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

        // -------------------------
        // PRIVATE: Load from file
        // -------------------------
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

        private void editFile(string filePath, string content)
        {
            try
            {
                // 1. Tạo thư mục nếu chưa tồn tại
                string folder = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                // 2. Ghi nội dung vào file
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
