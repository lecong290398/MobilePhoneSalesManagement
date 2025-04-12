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

        /// <summary>
        /// Thêm một đối tượng vào danh sách liên kết (SinglyLinkedList<T>) và lưu danh sách vào tệp JSON.
        /// Phương thức này sẽ thực hiện các bước sau:
        /// 1. Tạo thư mục nếu chưa tồn tại.
        /// 2. Tải danh sách hiện có từ tệp.
        /// 3. Thêm đối tượng mới vào danh sách.
        /// 4. Lưu danh sách trở lại tệp JSON.
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của đối tượng cần thêm vào danh sách.</typeparam>
        /// <param name="item">Đối tượng cần thêm vào danh sách.</param>
        /// <param name="filePath">Đường dẫn tệp nơi danh sách được lưu trữ.</param>
        public void Add<T>(T item, string filePath)
        {
            try
            {
                // 1. Tạo thư mục nếu chưa tồn tại
                string folder = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);  // Tạo thư mục chứa tệp nếu không có
                }

                // 2. Tải danh sách hiện có từ tệp
                var list = LoadFromJsonFile<T>(filePath);

                // 3. Thêm item mới vào danh sách
                list.Add(item);

                // 4. Lưu danh sách trở lại tệp
                SaveToJsonFile(list, filePath);
            }
            catch (Exception ex)
            {
                // Nếu có lỗi xảy ra trong quá trình thực hiện, ném lỗi đi
                throw;
            }
        }


        /// <summary>
        /// Tải và trả về toàn bộ danh sách liên kết (SinglyLinkedList<T>) từ tệp JSON.
        /// Phương thức này sẽ chỉ gọi phương thức `LoadFromJsonFile<T>` để tải danh sách từ tệp JSON.
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của đối tượng trong danh sách.</typeparam>
        /// <param name="filePath">Đường dẫn tệp chứa dữ liệu danh sách.</param>
        /// <returns>Danh sách liên kết (SinglyLinkedList<T>) chứa tất cả các đối tượng từ tệp JSON.</returns>
        public SinglyLinkedList<T> GetAll<T>(string filePath)
        {
            return LoadFromJsonFile<T>(filePath);
        }

        /// <summary>
        /// Cập nhật đối tượng trong danh sách theo giá trị thuộc tính khóa.
        /// </summary>
        /// <typeparam name="T">Kiểu đối tượng trong danh sách (SinglyLinkedList).</typeparam>
        /// <param name="newItem">Đối tượng mới cần thay thế cho đối tượng cũ.</param>
        /// <param name="keyProperty">Tên thuộc tính khóa (ví dụ: "Code").</param>
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

        /// <summary>
        /// Xóa đối tượng khỏi danh sách dựa trên thuộc tính khóa và giá trị khóa, và lưu lại vào tệp JSON.
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách (SinglyLinkedList).</typeparam>
        /// <param name="data">Đối tượng cần xóa (có thể bỏ qua, sẽ được tìm theo keyProperty và keyValue).</param>
        /// <param name="filePath">Đường dẫn đến tệp JSON.</param>
        /// <param name="keyProperty">Tên thuộc tính khóa để tìm đối tượng cần xóa.</param>
        /// <param name="keyValue">Giá trị của thuộc tính khóa cần xóa.</param>
        /// <returns>Trả về true nếu xóa thành công, false nếu không tìm thấy đối tượng.</returns>
        public bool Delete<T>(T data, string filePath, string keyProperty, string keyValue)
        {
            // Tải danh sách từ file JSON
            var list = LoadFromJsonFile<T>(filePath);
            if (list == null || list.Head == null)
            {
                Console.WriteLine("Danh sách rỗng hoặc không hợp lệ.");
                return false;
            }

            var current = list.Head;
            bool found = false;
            var prop = typeof(T).GetProperty(keyProperty, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            // Duyệt qua danh sách để tìm đối tượng cần xóa theo keyProperty và keyValue
            while (current != null)
            {
                // Lấy thông tin thuộc tính khóa

                if (prop != null && prop.GetValue(current.Data)?.ToString() == keyValue)
                {
                    found = true;
                    break; // Đã tìm thấy và thoát khỏi vòng lặp
                }

                current = current.Next;
            }

            if (found)
            {
                // Tạo danh sách mới bỏ qua phần tử bị xóa
                var newList = new SinglyLinkedList<T>();
                current = list.Head;

                while (current != null)
                {
                    // Nếu không phải phần tử cần xóa, thêm vào danh sách mới
                    if (prop != null && prop.GetValue(current.Data)?.ToString() != keyValue)
                    {
                        newList.Add(current.Data);
                    }
                    current = current.Next;
                }

                // Lưu danh sách mới vào tệp JSON
                SaveToJsonFile(newList, filePath);
                Console.WriteLine("Đã xóa đối tượng ra khỏi file.");
                return true;
            }
            else
            {
                Console.WriteLine("X Không tìm thấy đối tượng để xóa.");
                return false;
            }
        }

        /// <summary>
        /// Lưu dữ liệu từ danh sách liên kết SinglyLinkedList<T> vào tệp JSON.
        /// Phương thức này sẽ duyệt qua từng nút trong danh sách liên kết, lấy dữ liệu từ mỗi nút, 
        /// sau đó chuyển đổi danh sách dữ liệu thành định dạng JSON và lưu vào tệp theo đường dẫn chỉ định.
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu được lưu trữ trong danh sách liên kết.</typeparam>
        /// <param name="list">Danh sách liên kết (SinglyLinkedList<T>) chứa các đối tượng cần lưu vào tệp JSON.</param>
        /// <param name="filePath">Đường dẫn đầy đủ của tệp nơi dữ liệu sẽ được lưu.</param>
        private void SaveToJsonFile<T>(SinglyLinkedList<T> list, string filePath)
        {
            // Khởi tạo một danh sách tạm để chứa dữ liệu từ danh sách liên kết
            var dataList = new List<T>();

            // Khởi tạo biến node với phần tử đầu tiên của danh sách liên kết
            var node = list.Head;

            // Duyệt qua từng nút trong danh sách liên kết
            while (node != null)
            {
                // Thêm dữ liệu của nút vào danh sách tạm
                dataList.Add(node.Data);

                // Chuyển đến nút tiếp theo trong danh sách
                node = node.Next;
            }

            // Chuyển đổi danh sách dữ liệu sang định dạng JSON với định dạng dễ đọc (indented)
            string json = JsonConvert.SerializeObject(dataList, Newtonsoft.Json.Formatting.Indented);

            // Lưu dữ liệu JSON vào tệp theo đường dẫn chỉ định
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Tải dữ liệu từ tệp JSON và chuyển đổi chúng thành một danh sách liên kết (SinglyLinkedList<T>).
        /// Phương thức này sẽ đọc tệp JSON từ đường dẫn chỉ định, giải mã dữ liệu JSON thành danh sách các đối tượng,
        /// sau đó thêm các đối tượng vào danh sách liên kết.
        ///
        /// Nếu tệp không tồn tại, phương thức sẽ trả về một danh sách liên kết trống.
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của các đối tượng trong danh sách liên kết.</typeparam>
        /// <param name="filePath">Đường dẫn đến tệp JSON chứa dữ liệu cần tải.</param>
        /// <returns>Danh sách liên kết (SinglyLinkedList<T>) chứa các đối tượng được tải từ tệp JSON.</returns>
        private SinglyLinkedList<T> LoadFromJsonFile<T>(string filePath)
        {
            // Khởi tạo một danh sách liên kết trống để chứa các đối tượng từ tệp JSON
            var list = new SinglyLinkedList<T>();

            // Kiểm tra xem tệp có tồn tại không, nếu không thì trả về danh sách trống
            if (!File.Exists(filePath))
                return list;

            // Đọc nội dung tệp JSON thành chuỗi
            string json = File.ReadAllText(filePath);

            // Giải mã chuỗi JSON thành danh sách các đối tượng
            var dataList = JsonConvert.DeserializeObject<List<T>>(json);

            // Thêm từng đối tượng từ danh sách đã giải mã vào danh sách liên kết
            foreach (var item in dataList)
                list.Add(item);

            // Trả về danh sách liên kết chứa dữ liệu đã được tải
            return list;
        }


    }
}
